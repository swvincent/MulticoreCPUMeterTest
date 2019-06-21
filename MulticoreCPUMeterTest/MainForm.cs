using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;           // Performance counters
//using System.Management;

namespace MulticoreCPUMeterTest
{
    public partial class MainForm : Form
    {
        private PerformanceCounter cpuPerfCounter;                      // Overall CPU stat
        private PerformanceCounter[] corePerfCounter;                   // Individual logical core stats
        private FifoStats[] fifoStats;
        private int coreCount;                                          // Number of cores

        private const int SAMPLE_SIZE = 10;                             // Number of samples to use in calculating averages

        public MainForm()
        {
            InitializeComponent();

            if (InitCounters())
            {
                meterTimer.Start();
            }
            else
            {
                // TODO: Exit application?
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
                // Overall CPU usage, just for reference
                cpuPerfCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                
                // Logical core perf counters and arrays for various values
                //https://stackoverflow.com/a/2670568
                coreCount = Environment.ProcessorCount;
                corePerfCounter = new PerformanceCounter[coreCount];
                fifoStats = new FifoStats[coreCount];

                procCountTextBox.Text = coreCount.ToString();

                // Create counter, average and gridview row for each core
                for (int i = 0; i < coreCount; i++)
                {
                    corePerfCounter[i] = new PerformanceCounter("Processor", "% Processor Time", i.ToString());
                    fifoStats[i] = new FifoStats(SAMPLE_SIZE);
                    coresGridView.Rows.Add("Core " + (i+1).ToString());
                }

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
                // Dispose CPU counter
                if (cpuPerfCounter != null)
                    cpuPerfCounter.Dispose();

                // Dispose of the core counters
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


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
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
            float[] coreSpreads = new float[coreCount];

            // Get new stats and update averages
            for (int i = 0; i < coreCount; i++)
            {
                lastCorePercs[i] = corePerfCounter[i].NextValue();
                fifoStats[i].Enqueue(lastCorePercs[i]);
                coreAvgs[i] = fifoStats[i].Average();
                coreSpreads[i] = fifoStats[i].Spread();

                // Update form
                coresGridView.Rows[i].Cells["lastReadingColumn"].Value =
                    Math.Round(lastCorePercs[i], MidpointRounding.AwayFromZero).ToString();
                coresGridView.Rows[i].Cells["avgReadingColumn"].Value =
                    Math.Round(coreAvgs[i], 2, MidpointRounding.AwayFromZero).ToString();
                coresGridView.Rows[i].Cells["spreadColumn"].Value =
                    Math.Round(coreSpreads[i], 2, MidpointRounding.AwayFromZero).ToString();
            }

            // Helpful: https://stackoverflow.com/a/13755053
            int mostActiveCore = coreAvgs.ToList().IndexOf(coreAvgs.Max());
            int largestSpreadCore = coreSpreads.ToList().IndexOf(coreSpreads.Max());

            // Update overall CPU and most active
            cpuTextBox.Text = Math.Round(cpuPerfCounter.NextValue(), MidpointRounding.AwayFromZero).ToString();
            mostActiveCoreTextBox.Text = (mostActiveCore + 1).ToString();

            // Reset row colors
            foreach (DataGridViewRow r in coresGridView.Rows)
            {
                //r.DefaultCellStyle.BackColor = Color.White;
                r.Cells["avgReadingColumn"].Style.BackColor = Color.White;
                r.Cells["spreadColumn"].Style.BackColor = Color.White;
            }

            // Highlight most active row
            //coresGridView.Rows[mostActiveCore].DefaultCellStyle.BackColor = Color.Yellow;
            coresGridView.Rows[mostActiveCore].Cells["avgReadingColumn"].Style.BackColor = Color.Yellow;
            coresGridView.Rows[largestSpreadCore].Cells["spreadColumn"].Style.BackColor = Color.Yellow;
        }
    }
}