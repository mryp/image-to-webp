using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToWebp
{
    public partial class MainForm : Form
    {
        protected class WorkerParam
        {
            public string FilePath { get; set; } = "";
            public int Quality { get; set; } = 100;

            public override string ToString()
            {
                return $"{FilePath},{Quality}";
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Log.Info("アプリケーション起動");
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Info("アプリケーション終了");
        }

        private void filePathRefButton_Click(object sender, EventArgs e)
        {
            if (imageOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = imageOpenFileDialog.FileName;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (bgWorker.IsBusy)
            {
                return;
            }

            var filePath = filePathTextBox.Text;
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("画像ファイルパスが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(filePath))
            {
                MessageBox.Show("画像ファイルパスが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            startButton.Enabled = false;
            bgWorker.RunWorkerAsync(new WorkerParam()
            {
                FilePath = filePath,
                Quality = 90,
            });
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender is not BackgroundWorker worker)
            {
                Log.Error("sender is not BackgroundWorker");
                e.Result = "処理パラメーターエラー";
                return;
            }
            if (e.Argument is not WorkerParam param)
            {
                Log.Error("e.Argument is not WorkerParam");
                e.Result = "処理パラメーターエラー";
                return;
            }

            worker.ReportProgress(1);
            Log.Info($"処理開始 param={param}");

            var isSuccess = imageToWebp(param.FilePath, param.Quality);

            worker.ReportProgress(1, Path.GetFileName(param.FilePath));
            Log.Info("処理完了");

            var result = isSuccess ? "成功" : "失敗";
            e.Result = $"処理結果 {result}";
        }

        private static bool imageToWebp(string imagePath, int quality)
        {
            var dirPath = Path.GetDirectoryName(imagePath);
            if (dirPath == null)
            {
                Log.Warn($"ファイルパスはフルパスで指定してください file={imagePath}");
                return false;
            }
            var outputPath = Path.Combine(dirPath, Path.GetFileNameWithoutExtension(imagePath) + ".webp");
            if (File.Exists(outputPath))
            {
                Log.Warn($"ファイルが既に存在しています file={outputPath}");
                return false;
            }

            try
            {
                var image = Image.FromFile(imagePath);

            }
            catch (Exception e)
            {
                Log.Error(e, "変換処理例外");
                return false;
            }

            return true;
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            startButton.Enabled = true;
            if (e.Cancelled)
            {
                MessageBox.Show("キャンセルされました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.Result == null)
            {
                MessageBox.Show("想定外のエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(e.Result.ToString(), "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
