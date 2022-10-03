
namespace KursovikMVSA.Forms
{
    partial class InboxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InboxForm));
            this.inboxDataGridView = new System.Windows.Forms.DataGridView();
            this.bodyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.inboxMenuStrip = new System.Windows.Forms.MenuStrip();
            this.updateMailBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replyMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.foldersInboxListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.workStatusStrip = new System.Windows.Forms.StatusStrip();
            this.workToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.countMailMessageToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.countFoldersToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.searchKeyStringComboBox = new System.Windows.Forms.TextBox();
            this.optionsFilterComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UserEmailLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inboxDataGridView)).BeginInit();
            this.inboxMenuStrip.SuspendLayout();
            this.workStatusStrip.SuspendLayout();
            this.searchGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inboxDataGridView
            // 
            this.inboxDataGridView.AllowUserToAddRows = false;
            this.inboxDataGridView.AllowUserToDeleteRows = false;
            this.inboxDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.inboxDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inboxDataGridView.Location = new System.Drawing.Point(210, 157);
            this.inboxDataGridView.MultiSelect = false;
            this.inboxDataGridView.Name = "inboxDataGridView";
            this.inboxDataGridView.RowHeadersVisible = false;
            this.inboxDataGridView.RowHeadersWidth = 51;
            this.inboxDataGridView.RowTemplate.Height = 29;
            this.inboxDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inboxDataGridView.Size = new System.Drawing.Size(549, 202);
            this.inboxDataGridView.TabIndex = 0;
            this.inboxDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inboxDataGridView_CellClick);
            this.inboxDataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.inboxDataGridView_CellMouseDown);
            // 
            // bodyRichTextBox
            // 
            this.bodyRichTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bodyRichTextBox.Location = new System.Drawing.Point(209, 394);
            this.bodyRichTextBox.Name = "bodyRichTextBox";
            this.bodyRichTextBox.ReadOnly = true;
            this.bodyRichTextBox.Size = new System.Drawing.Size(549, 196);
            this.bodyRichTextBox.TabIndex = 1;
            this.bodyRichTextBox.Text = "";
            // 
            // inboxMenuStrip
            // 
            this.inboxMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.inboxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateMailBoxToolStripMenuItem,
            this.sendMailMenuItem,
            this.downloadMenuItem,
            this.replyMailToolStripMenuItem,
            this.deleteMailMenuItem,
            this.logoutToolStripMenuItem1});
            this.inboxMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.inboxMenuStrip.Name = "inboxMenuStrip";
            this.inboxMenuStrip.ShowItemToolTips = true;
            this.inboxMenuStrip.Size = new System.Drawing.Size(858, 40);
            this.inboxMenuStrip.TabIndex = 2;
            this.inboxMenuStrip.Text = "menuStrip1";
            this.inboxMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.inboxMenuStrip_ItemClicked);
            // 
            // updateMailBoxToolStripMenuItem
            // 
            this.updateMailBoxToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.updateMailBoxToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateMailBoxToolStripMenuItem.Image")));
            this.updateMailBoxToolStripMenuItem.Name = "updateMailBoxToolStripMenuItem";
            this.updateMailBoxToolStripMenuItem.Size = new System.Drawing.Size(46, 36);
            this.updateMailBoxToolStripMenuItem.Text = "Обновить почтовой ящик";
            this.updateMailBoxToolStripMenuItem.ToolTipText = "Обновить почтовый ящик";
            // 
            // sendMailMenuItem
            // 
            this.sendMailMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sendMailMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendMailMenuItem.Image")));
            this.sendMailMenuItem.Name = "sendMailMenuItem";
            this.sendMailMenuItem.Size = new System.Drawing.Size(46, 36);
            this.sendMailMenuItem.Text = "Отправить письмо";
            this.sendMailMenuItem.ToolTipText = "Отправить письмо";
            // 
            // downloadMenuItem
            // 
            this.downloadMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.downloadMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("downloadMenuItem.Image")));
            this.downloadMenuItem.Name = "downloadMenuItem";
            this.downloadMenuItem.Size = new System.Drawing.Size(46, 36);
            this.downloadMenuItem.Text = "Скачать вложение";
            this.downloadMenuItem.ToolTipText = "Скачать вложение";
            // 
            // replyMailToolStripMenuItem
            // 
            this.replyMailToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.replyMailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("replyMailToolStripMenuItem.Image")));
            this.replyMailToolStripMenuItem.Name = "replyMailToolStripMenuItem";
            this.replyMailToolStripMenuItem.Size = new System.Drawing.Size(46, 36);
            this.replyMailToolStripMenuItem.Text = "Ответить";
            this.replyMailToolStripMenuItem.ToolTipText = "Ответить";
            // 
            // deleteMailMenuItem
            // 
            this.deleteMailMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteMailMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteMailMenuItem.Image")));
            this.deleteMailMenuItem.Name = "deleteMailMenuItem";
            this.deleteMailMenuItem.Size = new System.Drawing.Size(46, 36);
            this.deleteMailMenuItem.Text = "Удалить письмо";
            this.deleteMailMenuItem.ToolTipText = "Удалить отмеченные письма";
            // 
            // logoutToolStripMenuItem1
            // 
            this.logoutToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logoutToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.logoutToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("logoutToolStripMenuItem1.Image")));
            this.logoutToolStripMenuItem1.Name = "logoutToolStripMenuItem1";
            this.logoutToolStripMenuItem1.Size = new System.Drawing.Size(46, 36);
            this.logoutToolStripMenuItem1.Text = "Выйти из аккаунта";
            this.logoutToolStripMenuItem1.ToolTipText = "Выйти из аккаунта";
            // 
            // foldersInboxListBox
            // 
            this.foldersInboxListBox.FormattingEnabled = true;
            this.foldersInboxListBox.ItemHeight = 20;
            this.foldersInboxListBox.Location = new System.Drawing.Point(15, 49);
            this.foldersInboxListBox.Name = "foldersInboxListBox";
            this.foldersInboxListBox.Size = new System.Drawing.Size(150, 344);
            this.foldersInboxListBox.TabIndex = 3;
            this.foldersInboxListBox.SelectedIndexChanged += new System.EventHandler(this.foldersInboxListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Папки:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Письма:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Текст письма:";
            // 
            // workStatusStrip
            // 
            this.workStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.workStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workToolStripStatusLabel,
            this.countMailMessageToolStripStatusLabel,
            this.countFoldersToolStripStatusLabel});
            this.workStatusStrip.Location = new System.Drawing.Point(0, 689);
            this.workStatusStrip.Name = "workStatusStrip";
            this.workStatusStrip.Size = new System.Drawing.Size(858, 22);
            this.workStatusStrip.TabIndex = 7;
            // 
            // workToolStripStatusLabel
            // 
            this.workToolStripStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.workToolStripStatusLabel.Name = "workToolStripStatusLabel";
            this.workToolStripStatusLabel.Size = new System.Drawing.Size(0, 16);
            this.workToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // countMailMessageToolStripStatusLabel
            // 
            this.countMailMessageToolStripStatusLabel.Name = "countMailMessageToolStripStatusLabel";
            this.countMailMessageToolStripStatusLabel.Size = new System.Drawing.Size(0, 16);
            this.countMailMessageToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // countFoldersToolStripStatusLabel
            // 
            this.countFoldersToolStripStatusLabel.Name = "countFoldersToolStripStatusLabel";
            this.countFoldersToolStripStatusLabel.Size = new System.Drawing.Size(843, 16);
            this.countFoldersToolStripStatusLabel.Spring = true;
            this.countFoldersToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // searchKeyStringComboBox
            // 
            this.searchKeyStringComboBox.Location = new System.Drawing.Point(7, 54);
            this.searchKeyStringComboBox.Name = "searchKeyStringComboBox";
            this.searchKeyStringComboBox.Size = new System.Drawing.Size(151, 27);
            this.searchKeyStringComboBox.TabIndex = 9;
            this.searchKeyStringComboBox.TextChanged += new System.EventHandler(this.searchKeyString_TextChanged);
            // 
            // optionsFilterComboBox
            // 
            this.optionsFilterComboBox.FormattingEnabled = true;
            this.optionsFilterComboBox.Location = new System.Drawing.Point(224, 54);
            this.optionsFilterComboBox.Name = "optionsFilterComboBox";
            this.optionsFilterComboBox.Size = new System.Drawing.Size(151, 28);
            this.optionsFilterComboBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Введите ключевое слово:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Выберите фильтр:";
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Controls.Add(this.searchKeyStringComboBox);
            this.searchGroupBox.Controls.Add(this.label5);
            this.searchGroupBox.Controls.Add(this.label4);
            this.searchGroupBox.Controls.Add(this.optionsFilterComboBox);
            this.searchGroupBox.Location = new System.Drawing.Point(299, 26);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(381, 108);
            this.searchGroupBox.TabIndex = 13;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Поиск";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.foldersInboxListBox);
            this.groupBox1.Controls.Add(this.searchGroupBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bodyRichTextBox);
            this.groupBox1.Controls.Add(this.inboxDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(29, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 607);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Почтовый ящик";
            // 
            // UserEmailLabel
            // 
            this.UserEmailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserEmailLabel.AutoSize = true;
            this.UserEmailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.UserEmailLabel.Location = new System.Drawing.Point(514, 9);
            this.UserEmailLabel.MaximumSize = new System.Drawing.Size(350, 0);
            this.UserEmailLabel.Name = "UserEmailLabel";
            this.UserEmailLabel.Size = new System.Drawing.Size(50, 20);
            this.UserEmailLabel.TabIndex = 15;
            this.UserEmailLabel.Text = "label6";
            this.UserEmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 711);
            this.Controls.Add(this.UserEmailLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.workStatusStrip);
            this.Controls.Add(this.inboxMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InboxForm";
            this.Text = "Почтовый ящик";
            this.Load += new System.EventHandler(this.InboxForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inboxDataGridView)).EndInit();
            this.inboxMenuStrip.ResumeLayout(false);
            this.inboxMenuStrip.PerformLayout();
            this.workStatusStrip.ResumeLayout(false);
            this.workStatusStrip.PerformLayout();
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView inboxDataGridView;
        private System.Windows.Forms.RichTextBox bodyRichTextBox;
        private System.Windows.Forms.MenuStrip inboxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem downloadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendMailMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMailMenuItem;
        private System.Windows.Forms.ListBox foldersInboxListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem updateMailBoxToolStripMenuItem;
        private System.Windows.Forms.StatusStrip workStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel workToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel countMailMessageToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel countFoldersToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem replyMailToolStripMenuItem;
        private System.Windows.Forms.TextBox searchKeyStringComboBox;
        private System.Windows.Forms.ComboBox optionsFilterComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label UserEmailLabel;
    }
}