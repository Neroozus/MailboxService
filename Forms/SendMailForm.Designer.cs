
namespace KursovikMVSA.Forms
{
    partial class SendMailForm
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
            this.recipientMailTextBox = new System.Windows.Forms.TextBox();
            this.sendTextBodyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sendMailButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.attachmentsDataGridView = new System.Windows.Forms.DataGridView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.attachFileButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.subjectMailTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.attachmentsFileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // recipientMailTextBox
            // 
            this.recipientMailTextBox.Location = new System.Drawing.Point(31, 59);
            this.recipientMailTextBox.Name = "recipientMailTextBox";
            this.recipientMailTextBox.Size = new System.Drawing.Size(297, 27);
            this.recipientMailTextBox.TabIndex = 0;
            this.recipientMailTextBox.TextChanged += new System.EventHandler(this.recipientMailTextBox_TextChanged);
            // 
            // sendTextBodyRichTextBox
            // 
            this.sendTextBodyRichTextBox.Location = new System.Drawing.Point(31, 188);
            this.sendTextBodyRichTextBox.Name = "sendTextBodyRichTextBox";
            this.sendTextBodyRichTextBox.Size = new System.Drawing.Size(297, 120);
            this.sendTextBodyRichTextBox.TabIndex = 1;
            this.sendTextBodyRichTextBox.Text = "";
            // 
            // sendMailButton
            // 
            this.sendMailButton.Location = new System.Drawing.Point(6, 519);
            this.sendMailButton.Name = "sendMailButton";
            this.sendMailButton.Size = new System.Drawing.Size(157, 29);
            this.sendMailButton.TabIndex = 2;
            this.sendMailButton.Text = "Отправить!";
            this.sendMailButton.UseVisualStyleBackColor = true;
            this.sendMailButton.Click += new System.EventHandler(this.sendMailButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.attachmentsDataGridView);
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.attachFileButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.subjectMailTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.recipientMailTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sendMailButton);
            this.groupBox1.Controls.Add(this.sendTextBodyRichTextBox);
            this.groupBox1.Location = new System.Drawing.Point(30, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 554);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Отправить письмо";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Вложения:";
            // 
            // attachmentsDataGridView
            // 
            this.attachmentsDataGridView.AllowUserToAddRows = false;
            this.attachmentsDataGridView.AllowUserToDeleteRows = false;
            this.attachmentsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.attachmentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attachmentsDataGridView.Location = new System.Drawing.Point(31, 380);
            this.attachmentsDataGridView.MultiSelect = false;
            this.attachmentsDataGridView.Name = "attachmentsDataGridView";
            this.attachmentsDataGridView.ReadOnly = true;
            this.attachmentsDataGridView.RowHeadersVisible = false;
            this.attachmentsDataGridView.RowHeadersWidth = 80;
            this.attachmentsDataGridView.RowTemplate.Height = 29;
            this.attachmentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.attachmentsDataGridView.Size = new System.Drawing.Size(297, 117);
            this.attachmentsDataGridView.TabIndex = 10;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(188, 519);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(164, 29);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Закрыть";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // attachFileButton
            // 
            this.attachFileButton.Location = new System.Drawing.Point(94, 320);
            this.attachFileButton.Name = "attachFileButton";
            this.attachFileButton.Size = new System.Drawing.Size(164, 31);
            this.attachFileButton.TabIndex = 7;
            this.attachFileButton.Text = "Прикрепить файл(ы)";
            this.attachFileButton.UseVisualStyleBackColor = true;
            this.attachFileButton.Click += new System.EventHandler(this.attachFileButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Текст сообщения:";
            // 
            // subjectMailTextBox
            // 
            this.subjectMailTextBox.Location = new System.Drawing.Point(31, 123);
            this.subjectMailTextBox.Name = "subjectMailTextBox";
            this.subjectMailTextBox.Size = new System.Drawing.Size(297, 27);
            this.subjectMailTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Тема:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Кому:";
            // 
            // attachmentsFileOpenFileDialog
            // 
            this.attachmentsFileOpenFileDialog.FileName = "openFileDialog1";
            this.attachmentsFileOpenFileDialog.Multiselect = true;
            // 
            // SendMailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 578);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendMailForm";
            this.Text = "Отправить письмо";
            this.Load += new System.EventHandler(this.SendMailForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox recipientMailTextBox;
        private System.Windows.Forms.RichTextBox sendTextBodyRichTextBox;
        private System.Windows.Forms.Button sendMailButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox subjectMailTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button attachFileButton;
        private System.Windows.Forms.OpenFileDialog attachmentsFileOpenFileDialog;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridView attachmentsDataGridView;
        private System.Windows.Forms.Label label4;
    }
}