
namespace KursovikMVSA.Forms
{
    partial class DownloadAttachmentForm
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
            this.attachmentsNameComboBox = new System.Windows.Forms.ComboBox();
            this.downloadAttachmentButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // attachmentsNameComboBox
            // 
            this.attachmentsNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.attachmentsNameComboBox.FormattingEnabled = true;
            this.attachmentsNameComboBox.Location = new System.Drawing.Point(33, 75);
            this.attachmentsNameComboBox.Name = "attachmentsNameComboBox";
            this.attachmentsNameComboBox.Size = new System.Drawing.Size(225, 28);
            this.attachmentsNameComboBox.TabIndex = 0;
            // 
            // downloadAttachmentButton
            // 
            this.downloadAttachmentButton.Location = new System.Drawing.Point(33, 121);
            this.downloadAttachmentButton.Name = "downloadAttachmentButton";
            this.downloadAttachmentButton.Size = new System.Drawing.Size(94, 29);
            this.downloadAttachmentButton.TabIndex = 1;
            this.downloadAttachmentButton.Text = "Скачать";
            this.downloadAttachmentButton.UseVisualStyleBackColor = true;
            this.downloadAttachmentButton.Click += new System.EventHandler(this.downloadAttachmentButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите файл для скачивания:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.attachmentsNameComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.downloadAttachmentButton);
            this.groupBox1.Location = new System.Drawing.Point(42, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 171);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Скачать вложения";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(164, 121);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Закрыть";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // DownloadAttachmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 219);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadAttachmentForm";
            this.Text = "Скачать вложения";
            this.Load += new System.EventHandler(this.DownloadAttachmentForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox attachmentsNameComboBox;
        private System.Windows.Forms.Button downloadAttachmentButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancelButton;
    }
}