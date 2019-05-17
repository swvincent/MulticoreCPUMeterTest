namespace MulticoreCPUMeterTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.meterTimer = new System.Windows.Forms.Timer(this.components);
            this.cpuTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.procCountTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mostActiveCoreTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.coresGridView = new System.Windows.Forms.DataGridView();
            this.coreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastReadingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgReadingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.coresGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // meterTimer
            // 
            this.meterTimer.Interval = 500;
            this.meterTimer.Tick += new System.EventHandler(this.meterTimer_Tick);
            // 
            // cpuTextBox
            // 
            this.cpuTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpuTextBox.Location = new System.Drawing.Point(262, 56);
            this.cpuTextBox.Name = "cpuTextBox";
            this.cpuTextBox.ReadOnly = true;
            this.cpuTextBox.Size = new System.Drawing.Size(84, 29);
            this.cpuTextBox.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(105, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "Overall CPU %:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // procCountTextBox
            // 
            this.procCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.procCountTextBox.Location = new System.Drawing.Point(262, 17);
            this.procCountTextBox.Name = "procCountTextBox";
            this.procCountTextBox.ReadOnly = true;
            this.procCountTextBox.Size = new System.Drawing.Size(43, 29);
            this.procCountTextBox.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(61, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(195, 24);
            this.label10.TabIndex = 18;
            this.label10.Text = "Logical Core Count:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mostActiveCoreTextBox
            // 
            this.mostActiveCoreTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostActiveCoreTextBox.Location = new System.Drawing.Point(262, 96);
            this.mostActiveCoreTextBox.Name = "mostActiveCoreTextBox";
            this.mostActiveCoreTextBox.ReadOnly = true;
            this.mostActiveCoreTextBox.Size = new System.Drawing.Size(84, 29);
            this.mostActiveCoreTextBox.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(82, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(174, 24);
            this.label13.TabIndex = 31;
            this.label13.Text = "Most Active Core:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // coresGridView
            // 
            this.coresGridView.AllowUserToAddRows = false;
            this.coresGridView.AllowUserToDeleteRows = false;
            this.coresGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.coresGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.coresGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.coresGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coreColumn,
            this.lastReadingColumn,
            this.avgReadingColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.coresGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.coresGridView.Location = new System.Drawing.Point(12, 140);
            this.coresGridView.Name = "coresGridView";
            this.coresGridView.ReadOnly = true;
            this.coresGridView.Size = new System.Drawing.Size(372, 268);
            this.coresGridView.TabIndex = 32;
            // 
            // coreColumn
            // 
            this.coreColumn.HeaderText = "Core";
            this.coreColumn.MinimumWidth = 100;
            this.coreColumn.Name = "coreColumn";
            this.coreColumn.ReadOnly = true;
            // 
            // lastReadingColumn
            // 
            this.lastReadingColumn.HeaderText = "Last";
            this.lastReadingColumn.MinimumWidth = 100;
            this.lastReadingColumn.Name = "lastReadingColumn";
            this.lastReadingColumn.ReadOnly = true;
            // 
            // avgReadingColumn
            // 
            this.avgReadingColumn.HeaderText = "Avg";
            this.avgReadingColumn.MinimumWidth = 100;
            this.avgReadingColumn.Name = "avgReadingColumn";
            this.avgReadingColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 423);
            this.Controls.Add(this.coresGridView);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.mostActiveCoreTextBox);
            this.Controls.Add(this.procCountTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cpuTextBox);
            this.Controls.Add(this.label9);
            this.MinimumSize = new System.Drawing.Size(416, 461);
            this.Name = "Form1";
            this.Text = "Multicore CPU Meter Test app";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.coresGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer meterTimer;
        private System.Windows.Forms.TextBox cpuTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox procCountTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox mostActiveCoreTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView coresGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn coreColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastReadingColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgReadingColumn;
    }
}

