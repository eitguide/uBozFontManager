namespace FontManager.UI.Control
{
    partial class FontInfoUc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUcTitleName = new System.Windows.Forms.Label();
            this.txtUcContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUcTitleName
            // 
            this.txtUcTitleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUcTitleName.AutoSize = true;
            this.txtUcTitleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtUcTitleName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtUcTitleName.Location = new System.Drawing.Point(4, 7);
            this.txtUcTitleName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtUcTitleName.Name = "txtUcTitleName";
            this.txtUcTitleName.Size = new System.Drawing.Size(106, 20);
            this.txtUcTitleName.TabIndex = 0;
            this.txtUcTitleName.Text = "Ten thong tin";
            // 
            // txtUcContent
            // 
            this.txtUcContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUcContent.AutoSize = true;
            this.txtUcContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtUcContent.Location = new System.Drawing.Point(184, 7);
            this.txtUcContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtUcContent.MaximumSize = new System.Drawing.Size(533, 0);
            this.txtUcContent.Name = "txtUcContent";
            this.txtUcContent.Size = new System.Drawing.Size(53, 20);
            this.txtUcContent.TabIndex = 1;
            this.txtUcContent.Text = "Bước ";
            // 
            // FontInfoUc
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.txtUcContent);
            this.Controls.Add(this.txtUcTitleName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FontInfoUc";
            this.Size = new System.Drawing.Size(739, 39);
            this.Load += new System.EventHandler(this.FontInfoUc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtUcTitleName;
        private System.Windows.Forms.Label txtUcContent;
    }
}
