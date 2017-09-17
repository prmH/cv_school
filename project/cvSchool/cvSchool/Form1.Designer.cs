namespace cvSchool
{
    partial class cv_school
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btFragment = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.bOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.fdbMain = new System.Windows.Forms.FolderBrowserDialog();
            this.btnGrey = new System.Windows.Forms.Button();
            this.btnFlip = new System.Windows.Forms.Button();
            this.btnNormalize = new System.Windows.Forms.Button();
            this.btnNoise = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNoise);
            this.panel1.Controls.Add(this.btnNormalize);
            this.panel1.Controls.Add(this.btnFlip);
            this.panel1.Controls.Add(this.btnGrey);
            this.panel1.Controls.Add(this.btFragment);
            this.panel1.Controls.Add(this.tbLog);
            this.panel1.Controls.Add(this.bOpen);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 261);
            this.panel1.TabIndex = 0;
            // 
            // btFragment
            // 
            this.btFragment.Location = new System.Drawing.Point(12, 54);
            this.btFragment.Name = "btFragment";
            this.btFragment.Size = new System.Drawing.Size(82, 23);
            this.btFragment.TabIndex = 4;
            this.btFragment.Text = "1. Fragments";
            this.btFragment.UseVisualStyleBackColor = true;
            this.btFragment.Click += new System.EventHandler(this.btFragment_Click);
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Location = new System.Drawing.Point(12, 83);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(532, 166);
            this.tbLog.TabIndex = 3;
            // 
            // bOpen
            // 
            this.bOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpen.Location = new System.Drawing.Point(519, 28);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(25, 21);
            this.bOpen.TabIndex = 2;
            this.bOpen.Text = "...";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Укажите каталог размещения файлов:";
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Enabled = false;
            this.tbPath.Location = new System.Drawing.Point(12, 28);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(501, 20);
            this.tbPath.TabIndex = 0;
            this.tbPath.Text = "~\\cv_school_test";
            // 
            // btnGrey
            // 
            this.btnGrey.Location = new System.Drawing.Point(100, 54);
            this.btnGrey.Name = "btnGrey";
            this.btnGrey.Size = new System.Drawing.Size(82, 23);
            this.btnGrey.TabIndex = 5;
            this.btnGrey.Text = "2. GreyScale";
            this.btnGrey.UseVisualStyleBackColor = true;
            this.btnGrey.Click += new System.EventHandler(this.btnGrey_Click);
            // 
            // btnFlip
            // 
            this.btnFlip.Location = new System.Drawing.Point(188, 54);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(82, 23);
            this.btnFlip.TabIndex = 6;
            this.btnFlip.Text = "3. Flip";
            this.btnFlip.UseVisualStyleBackColor = true;
            this.btnFlip.Click += new System.EventHandler(this.btnFlip_Click);
            // 
            // btnNormalize
            // 
            this.btnNormalize.Location = new System.Drawing.Point(276, 54);
            this.btnNormalize.Name = "btnNormalize";
            this.btnNormalize.Size = new System.Drawing.Size(82, 23);
            this.btnNormalize.TabIndex = 7;
            this.btnNormalize.Text = "4. Normalize";
            this.btnNormalize.UseVisualStyleBackColor = true;
            this.btnNormalize.Click += new System.EventHandler(this.btnNormalize_Click);
            // 
            // btnNoise
            // 
            this.btnNoise.Location = new System.Drawing.Point(364, 54);
            this.btnNoise.Name = "btnNoise";
            this.btnNoise.Size = new System.Drawing.Size(82, 23);
            this.btnNoise.TabIndex = 8;
            this.btnNoise.Text = "5. Noise";
            this.btnNoise.UseVisualStyleBackColor = true;
            this.btnNoise.Click += new System.EventHandler(this.btnNoise_Click);
            // 
            // cv_school
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 261);
            this.Controls.Add(this.panel1);
            this.Name = "cv_school";
            this.Text = "cv_school";
            this.Load += new System.EventHandler(this.cv_school_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.FolderBrowserDialog fdbMain;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btFragment;
        private System.Windows.Forms.Button btnGrey;
        private System.Windows.Forms.Button btnFlip;
        private System.Windows.Forms.Button btnNormalize;
        private System.Windows.Forms.Button btnNoise;
    }
}

