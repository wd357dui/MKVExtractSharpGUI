namespace MKVExtractSharpGUI
{
    partial class MkvExtractSharpGUI
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ExtractButton = new System.Windows.Forms.Button();
            this.FileAddressInput = new System.Windows.Forms.TextBox();
            this.InputFileLabel = new System.Windows.Forms.Label();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.ShowOutputsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ExtractButton
            // 
            this.ExtractButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExtractButton.Location = new System.Drawing.Point(12, 106);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(280, 23);
            this.ExtractButton.TabIndex = 5;
            this.ExtractButton.Text = "Extract";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // FileAddressInput
            // 
            this.FileAddressInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileAddressInput.Location = new System.Drawing.Point(12, 24);
            this.FileAddressInput.Name = "FileAddressInput";
            this.FileAddressInput.Size = new System.Drawing.Size(225, 21);
            this.FileAddressInput.TabIndex = 1;
            // 
            // InputFileLabel
            // 
            this.InputFileLabel.AutoSize = true;
            this.InputFileLabel.Location = new System.Drawing.Point(12, 9);
            this.InputFileLabel.Name = "InputFileLabel";
            this.InputFileLabel.Size = new System.Drawing.Size(71, 12);
            this.InputFileLabel.TabIndex = 0;
            this.InputFileLabel.Text = "Input File:";
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectFileButton.Location = new System.Drawing.Point(243, 24);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(49, 21);
            this.SelectFileButton.TabIndex = 2;
            this.SelectFileButton.Text = "Select";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // AboutLabel
            // 
            this.AboutLabel.AutoSize = true;
            this.AboutLabel.Location = new System.Drawing.Point(12, 52);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(251, 12);
            this.AboutLabel.TabIndex = 3;
            this.AboutLabel.Text = "MkvExtract GUI(written in C#) by wd357dui";
            // 
            // ShowOutputsCheckBox
            // 
            this.ShowOutputsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowOutputsCheckBox.AutoSize = true;
            this.ShowOutputsCheckBox.Location = new System.Drawing.Point(12, 84);
            this.ShowOutputsCheckBox.Name = "ShowOutputsCheckBox";
            this.ShowOutputsCheckBox.Size = new System.Drawing.Size(240, 16);
            this.ShowOutputsCheckBox.TabIndex = 4;
            this.ShowOutputsCheckBox.Text = "Show command line inputs and outputs";
            this.ShowOutputsCheckBox.UseVisualStyleBackColor = true;
            this.ShowOutputsCheckBox.CheckedChanged += new System.EventHandler(this.ShowOutputsCheckBox_CheckedChanged);
            // 
            // MkvExtractSharpGUI
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 141);
            this.Controls.Add(this.ShowOutputsCheckBox);
            this.Controls.Add(this.AboutLabel);
            this.Controls.Add(this.SelectFileButton);
            this.Controls.Add(this.InputFileLabel);
            this.Controls.Add(this.FileAddressInput);
            this.Controls.Add(this.ExtractButton);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(320, 180);
            this.Name = "MkvExtractSharpGUI";
            this.Text = "MkvExtract GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            this.DragEnter += MkvExtractSharpGUI_DragEnter;
            this.DragDrop += MkvExtractSharpGUI_DragDrop;
        }

        #endregion

        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.TextBox FileAddressInput;
        private System.Windows.Forms.Label InputFileLabel;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Label AboutLabel;
        private System.Windows.Forms.CheckBox ShowOutputsCheckBox;
    }
}

