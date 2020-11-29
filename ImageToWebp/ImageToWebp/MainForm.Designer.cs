
namespace ImageToWebp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.filePathRefButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.imageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.qualityNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.qualityNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(114, 12);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(592, 27);
            this.filePathTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "画像ファイル：";
            // 
            // filePathRefButton
            // 
            this.filePathRefButton.Location = new System.Drawing.Point(712, 11);
            this.filePathRefButton.Name = "filePathRefButton";
            this.filePathRefButton.Size = new System.Drawing.Size(88, 29);
            this.filePathRefButton.TabIndex = 2;
            this.filePathRefButton.Text = "参照";
            this.filePathRefButton.UseVisualStyleBackColor = true;
            this.filePathRefButton.Click += new System.EventHandler(this.filePathRefButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 87);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(788, 46);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "処理開始";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // imageOpenFileDialog
            // 
            this.imageOpenFileDialog.Filter = "画像ファイル|*.png;*.jpg;*.bmp|すべてのファイル|*.*";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // qualityNumeric
            // 
            this.qualityNumeric.Location = new System.Drawing.Point(114, 45);
            this.qualityNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qualityNumeric.Name = "qualityNumeric";
            this.qualityNumeric.Size = new System.Drawing.Size(110, 27);
            this.qualityNumeric.TabIndex = 4;
            this.qualityNumeric.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "品質：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 143);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.qualityNumeric);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.filePathRefButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filePathTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Image to Webp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qualityNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button filePathRefButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.OpenFileDialog imageOpenFileDialog;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.NumericUpDown qualityNumeric;
        private System.Windows.Forms.Label label2;
    }
}

