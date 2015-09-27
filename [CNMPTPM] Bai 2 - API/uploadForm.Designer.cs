namespace _CNMPTPM__Bai_2___API
{
    partial class uploadForm
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
            this.bChoose = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.bUpload = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDes = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // bChoose
            // 
            this.bChoose.Location = new System.Drawing.Point(84, 17);
            this.bChoose.Name = "bChoose";
            this.bChoose.Size = new System.Drawing.Size(88, 23);
            this.bChoose.TabIndex = 0;
            this.bChoose.Text = "Choose photo";
            this.bChoose.UseVisualStyleBackColor = true;
            this.bChoose.Click += new System.EventHandler(this.bChoose_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(84, 46);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(195, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // bUpload
            // 
            this.bUpload.Location = new System.Drawing.Point(125, 174);
            this.bUpload.Name = "bUpload";
            this.bUpload.Size = new System.Drawing.Size(75, 23);
            this.bUpload.TabIndex = 3;
            this.bUpload.Text = "Upload";
            this.bUpload.UseVisualStyleBackColor = true;
            this.bUpload.Click += new System.EventHandler(this.bUpload_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoEllipsis = true;
            this.labelTitle.Location = new System.Drawing.Point(178, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(101, 18);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "File name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description:";
            // 
            // txtDes
            // 
            this.txtDes.Location = new System.Drawing.Point(84, 72);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(195, 96);
            this.txtDes.TabIndex = 2;
            this.txtDes.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            this.openFileDialog1.Title = "Choose a photo";
            // 
            // uploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 224);
            this.Controls.Add(this.txtDes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.bUpload);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.bChoose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "uploadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upload a photo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bChoose;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button bUpload;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtDes;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}