using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ProcessManager processManager;

        public Form1()
        {
            InitializeComponent();
            processManager = new ProcessManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPrograms.Items.AddRange(new string[]
            {
                "Калькулятор",
                "Блокнот",
                "Paint",
                "Браузер",
                "Microsoft Word"
            });
            cmbPrograms.SelectedIndex = 0; 
            RefreshProcessList();
        }

        private void btnStartProgram_Click(object sender, EventArgs e)
        {
            try
            {
                string program = cmbPrograms.SelectedItem.ToString();
                switch (program)
                {
                    case "Калькулятор":
                        processManager.StartProgram("calc.exe");
                        break;
                    case "Блокнот":
                        processManager.StartProgram("notepad.exe");
                        break;
                    case "Paint":
                        processManager.StartProgram("mspaint.exe");
                        break;
                    case "Браузер":
                        processManager.StartProgram("msedge.exe"); 
                        break;
                    case "Microsoft Word":
                        processManager.StartProgram("winword.exe");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка запуску програми: {ex.Message}");
            }
        }

        private void btnStopProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProcesses.SelectedRows.Count > 0)
                {
                    int processId = int.Parse(dgvProcesses.SelectedRows[0].Cells["ProcessId"].Value.ToString());
                    processManager.StopProcess(processId);
                    RefreshProcessList();
                }
                else
                {
                    MessageBox.Show("Виберіть процес для зупинки.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка зупинки процесу: {ex.Message}");
            }
        }

        private void btnChangePriority_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProcesses.SelectedRows.Count > 0)
                {
                    int processId = int.Parse(dgvProcesses.SelectedRows[0].Cells["ProcessId"].Value.ToString());
                    processManager.ChangeProcessPriority(processId, ProcessPriorityClass.High);
                    RefreshProcessList();
                }
                else
                {
                    MessageBox.Show("Виберіть процес для зміни пріоритету.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка зміни пріоритету: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshProcessList();
        }

        private void RefreshProcessList()
        {
            try
            {
                dgvProcesses.AutoGenerateColumns = true;
                dgvProcesses.DataSource = null;
                dgvProcesses.DataSource = processManager.GetProcesses();
                dgvProcesses.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення списку: {ex.Message}");
            }
        }
    }
}