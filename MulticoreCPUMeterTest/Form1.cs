﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;           //Performance counters
//using System.Management;

namespace MulticoreCPUMeterTest
{
    public partial class Form1 : Form
    {
        private PerformanceCounter cpuPerfCounter;                      //Ovall CPU stat
        private PerformanceCounter[] corePerfCounter;                   //Individual logical core stats
        private MovingAverageCalculator[] coreAvgCalcs;                 //Used to calc moving averages
        private int coreCount;                                          //Number of cores
        private int sampleCounter;                                      //Count of sample since last determined most active core
        private int mostActiveCore;                                     //Index of most active core

        private const int SAMPLE_SIZE = 60;                             //Number of samples to use in calculating averages
        private const int RESET_SAMPLE_COUNT = 20;                      //Reset most active core after this many samples collected

        public Form1()
        {
            InitializeComponent();

            if (InitCounters())
            {
                meterTimer.Start();
            }
            else
            {
                //TODO: Exit application?
            }
        }


        #region Init/Dispose

        /// <summary>
        /// Initialize performance counters
        /// </summary>
        /// <returns></returns>
        private bool InitCounters()
        {
            try
            {
                //Overall CPU usage, just for reference
                cpuPerfCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                
                //Logical core perf counters and arrays for various values
                //https://stackoverflow.com/a/2670568
                coreCount = Environment.ProcessorCount;
                corePerfCounter = new PerformanceCounter[coreCount];
                coreAvgCalcs = new MovingAverageCalculator[coreCount];

                procCountTextBox.Text = coreCount.ToString();

                //Create counter, average and gridview row for each core
                for (int i = 0; i < coreCount; i++)
                {
                    corePerfCounter[i] = new PerformanceCounter("Processor", "% Processor Time", i.ToString());
                    coreAvgCalcs[i] = new MovingAverageCalculator(SAMPLE_SIZE);
                    coresGridView.Rows.Add("Core " + (i+1).ToString());
                }

                //Set sampleCounter same as sample size so it calcs on first run
                sampleCounter = RESET_SAMPLE_COUNT;

                return true;
            }
            catch (Exception caught)
            {
                MessageBox.Show(string.Format("Error occured during counter/array initialization. Details:\n\n{0}",caught.Message), "Initialization Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /// <summary>
        /// Dispose counter objects
        /// </summary>
        private void DisposeCounters()
        {
            try
            {
                //Dispose CPU counter
                if (cpuPerfCounter != null)
                    cpuPerfCounter.Dispose();

                //Dispose of the core counters
                if (corePerfCounter != null)
                {
                    foreach(PerformanceCounter p in corePerfCounter)
                    {
                        if (p != null)
                        p.Dispose();
                    }
                }
            }
            finally
            { PerformanceCounter.CloseSharedResources(); }
        }

        #endregion Init/Dispose


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisposeCounters();
        }


        private void meterTimer_Tick(object sender, EventArgs e)
        {
            UpdateStats();
        }


        /// <summary>
        /// Update stats, averages, etc.
        /// </summary>
        private void UpdateStats()
        {
            float[] lastCorePercs = new float[coreCount];
            float[] coreAvgs = new float[coreCount];

            //Get new stats and update averages
            for (int i = 0; i < coreCount; i++)
            {
                lastCorePercs[i] = corePerfCounter[i].NextValue();
                coreAvgs[i] = coreAvgCalcs[i].NextValue(lastCorePercs[i]);
                
                //Update form
                coresGridView.Rows[i].Cells["lastReadingColumn"].Value =
                    Math.Round(lastCorePercs[i], MidpointRounding.AwayFromZero).ToString();
                coresGridView.Rows[i].Cells["avgReadingColumn"].Value =
                    Math.Round(coreAvgs[i], 2, MidpointRounding.AwayFromZero).ToString();
            }

            sampleCounter++;

            //Every time we've collected a full round of stats,
            //redetermine which core is most active
            if (sampleCounter > RESET_SAMPLE_COUNT)
            {
                //Helpful: https://stackoverflow.com/a/13755053
                float maxValue = coreAvgs.Max();
                mostActiveCore = coreAvgs.ToList().IndexOf(maxValue);

                sampleCounter = 1;
            }

            //Update overall CPU and most active
            cpuTextBox.Text = Math.Round(cpuPerfCounter.NextValue(), MidpointRounding.AwayFromZero).ToString();
            mostActiveCoreTextBox.Text = (mostActiveCore + 1).ToString();
        }
    }
}