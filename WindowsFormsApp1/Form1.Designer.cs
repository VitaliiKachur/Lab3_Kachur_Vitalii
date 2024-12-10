namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvProcesses = new System.Windows.Forms.DataGridView();
            this.btnStartProgram = new System.Windows.Forms.Button();
            this.btnStopProcess = new System.Windows.Forms.Button();
            this.btnChangePriority = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbPrograms = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProcesses
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProcesses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesses.Location = new System.Drawing.Point(12, 12);
            this.dgvProcesses.Name = "dgvProcesses";
            this.dgvProcesses.Size = new System.Drawing.Size(1016, 399);
            this.dgvProcesses.TabIndex = 0;
            // 
            // btnStartProgram
            // 
            this.btnStartProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnStartProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartProgram.ForeColor = System.Drawing.Color.Navy;
            this.btnStartProgram.Location = new System.Drawing.Point(735, 521);
            this.btnStartProgram.Name = "btnStartProgram";
            this.btnStartProgram.Size = new System.Drawing.Size(130, 61);
            this.btnStartProgram.TabIndex = 1;
            this.btnStartProgram.Text = "Запустити програму";
            this.btnStartProgram.UseVisualStyleBackColor = false;
            this.btnStartProgram.Click += new System.EventHandler(this.btnStartProgram_Click);
            // 
            // btnStopProcess
            // 
            this.btnStopProcess.BackColor = System.Drawing.Color.Red;
            this.btnStopProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStopProcess.Location = new System.Drawing.Point(192, 493);
            this.btnStopProcess.Name = "btnStopProcess";
            this.btnStopProcess.Size = new System.Drawing.Size(143, 61);
            this.btnStopProcess.TabIndex = 2;
            this.btnStopProcess.Text = "Зупинити процес";
            this.btnStopProcess.UseVisualStyleBackColor = false;
            this.btnStopProcess.Click += new System.EventHandler(this.btnStopProcess_Click);
            // 
            // btnChangePriority
            // 
            this.btnChangePriority.BackColor = System.Drawing.Color.Yellow;
            this.btnChangePriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangePriority.ForeColor = System.Drawing.Color.Navy;
            this.btnChangePriority.Location = new System.Drawing.Point(382, 493);
            this.btnChangePriority.Name = "btnChangePriority";
            this.btnChangePriority.Size = new System.Drawing.Size(130, 61);
            this.btnChangePriority.TabIndex = 3;
            this.btnChangePriority.Text = "Змінити пріоритет";
            this.btnChangePriority.UseVisualStyleBackColor = false;
            this.btnChangePriority.Click += new System.EventHandler(this.btnChangePriority_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRefresh.Location = new System.Drawing.Point(24, 493);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 61);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Оновити список";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbPrograms
            // 
            this.cmbPrograms.FormattingEnabled = true;
            this.cmbPrograms.Location = new System.Drawing.Point(687, 457);
            this.cmbPrograms.Name = "cmbPrograms";
            this.cmbPrograms.Size = new System.Drawing.Size(216, 21);
            this.cmbPrograms.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1040, 603);
            this.Controls.Add(this.cmbPrograms);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnChangePriority);
            this.Controls.Add(this.btnStopProcess);
            this.Controls.Add(this.btnStartProgram);
            this.Controls.Add(this.dgvProcesses);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер процесів";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProcesses;
        private System.Windows.Forms.Button btnStartProgram;
        private System.Windows.Forms.Button btnStopProcess;
        private System.Windows.Forms.Button btnChangePriority;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbPrograms;
    }
}

