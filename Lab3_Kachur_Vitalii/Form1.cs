using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Lab3_Kachur_Vitalii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            lblProgress.Text = "0%";
        }

        private OpenFileDialog openFileDialog = new OpenFileDialog();

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblFilePath.Text = openFileDialog.FileName;
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblFilePath.Text) || string.IsNullOrEmpty(txtEncryptionKey.Text))
            {
                MessageBox.Show("Оберіть файл та введіть ключ.");
                return;
            }

            if (txtEncryptionKey.Text.Length < 16)
            {
                MessageBox.Show("Ключ має бути не менше 16 символів.");
                return;
            }

            string inputFile = lblFilePath.Text;
            string outputFile = Path.GetDirectoryName(inputFile) + "\\" + Path.GetFileNameWithoutExtension(inputFile) + "_encrypted" + Path.GetExtension(inputFile);

            progressBar.Value = 0;
            lblProgress.Text = "0%";

            backgroundWorker.RunWorkerAsync(new EncryptionArgs
            {
                Key = txtEncryptionKey.Text,
                InputFile = inputFile,
                OutputFile = outputFile,
                Mode = "Encrypt"
            });
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblFilePath.Text) || string.IsNullOrEmpty(txtEncryptionKey.Text))
            {
                MessageBox.Show("Оберіть файл та введіть ключ.");
                return;
            }

            if (txtEncryptionKey.Text.Length < 16)
            {
                MessageBox.Show("Ключ має бути не менше 16 символів.");
                return;
            }

            string inputFile = lblFilePath.Text;
            string outputFile = Path.GetDirectoryName(inputFile) + "\\" + Path.GetFileNameWithoutExtension(inputFile) + "_decrypted" + Path.GetExtension(inputFile);

            progressBar.Value = 0;
            lblProgress.Text = "0%";

            backgroundWorker.RunWorkerAsync(new EncryptionArgs
            {
                Key = txtEncryptionKey.Text,
                InputFile = inputFile,
                OutputFile = outputFile,
                Mode = "Decrypt"
            });
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (EncryptionArgs)e.Argument;
            var encryptor = new FileEncryptor(args.Key);
            var stopwatch = Stopwatch.StartNew();

            try
            {
                if (args.Mode == "Encrypt")
                {
                    encryptor.Encrypt(args.InputFile, args.OutputFile, progress =>
                        backgroundWorker.ReportProgress(progress));
                }
                else
                {
                    encryptor.Decrypt(args.InputFile, args.OutputFile, progress =>
                        backgroundWorker.ReportProgress(progress));
                }

                stopwatch.Stop();
                FileInfo fileInfo = new FileInfo(args.OutputFile);
                e.Result = new EncryptionResult
                {
                    ElapsedTime = stopwatch.Elapsed,
                    FileName = fileInfo.Name,
                    FileSize = fileInfo.Length
                };
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            lblProgress.Text = $"{e.ProgressPercentage}%"; 
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 100;
            lblProgress.Text = "100%";

            if (e.Result is EncryptionResult result)
            {
                MessageBox.Show($"Операція завершена!\n" +
                    $"Назва файла: {result.FileName}\n" +
                    $"Розмір файла: {result.FileSize / 1024.0:F2} KB\n" +
                    $"Час виконання: {result.ElapsedTime.TotalSeconds:F2} секунд.");
            }
            else
            {
                MessageBox.Show($"Помилка: {e.Result}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class EncryptionArgs
    {
        public string Key { get; set; }
        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public string Mode { get; set; }
    }

    public class EncryptionResult
    {
        public TimeSpan ElapsedTime { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
    }
}
