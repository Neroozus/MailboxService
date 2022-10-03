using KursovikMVSA.Services;
using MailKit;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KursovikMVSA.Forms
{
    public partial class InboxForm : Form
    {
        MyMailService myMailService;
        DataTable dt = new DataTable();
        IList<IMessageSummary> messageMails;
        MimeMessage message;
        IList<IMailFolder> folders;
        CheckBox headerCheckBox;
        ContextMenuStrip contextMenu;
        public InboxForm(AuthorizationService authorizationService)
        {
            myMailService = new MyMailService(authorizationService);
            InitializeComponent();

        }

        private void InboxForm_Load(object sender, EventArgs e)
        {
            downloadMenuItem.Enabled = false;
            deleteMailMenuItem.Enabled = false;
            updateMailBoxToolStripMenuItem.Enabled = false;
            replyMailToolStripMenuItem.Enabled = false;
            UserEmailLabel.Text = $"Здравствуйте, {myMailService.authorizationService.myClient.Email}";
            optionsFilterComboBox.Items.AddRange(new string[] { "№", "Дата", "Отправитель", "Тема", "Вложения" });
            optionsFilterComboBox.SelectedIndex = 0;
            inboxMenuStrip.Items.Insert(1, new ToolStripSeparator());
            typeof(DataGridView).InvokeMember(
   "DoubleBuffered",
   BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
   null,
   inboxDataGridView,
   new object[] { true });
            //Генерирование столбцов
            dt.Columns.Add("", typeof(bool));
            dt.Columns.Add("№");
            dt.Columns.Add("Дата");
            dt.Columns.Add("Отправитель");
            dt.Columns.Add("Тема");
            dt.Columns.Add("Вложения");
            dt.Columns.Add("UID");
            dt.Columns[0].ReadOnly = false;
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ReadOnly = true;
            }

            FillFoldersInbox();
            countFoldersToolStripStatusLabel.Text = $"Количество папок: {foldersInboxListBox.Items.Count}";
            contextMenu = new ContextMenuStrip();
            ToolStripMenuItem contextMenuUpdate = new ToolStripMenuItem("Обновить почтовой ящик");
            ToolStripMenuItem contextMenuSendMail = new ToolStripMenuItem("Отправить письмо");
            ToolStripMenuItem contextMenuDownloadAttachment = new ToolStripMenuItem("Скачать вложение");
            ToolStripMenuItem contextMenuDeleteMessage = new ToolStripMenuItem("Удалить отмеченные письма");
            ToolStripMenuItem contextMenuReplyMessage = new ToolStripMenuItem("Ответить");
            contextMenuUpdate.Click += new EventHandler(UpdateInbox_Click);
            contextMenuSendMail.Click += new EventHandler(SendMail_Click);
            contextMenuDownloadAttachment.Click += new EventHandler(DownloadAttachment_Click);
            contextMenuDeleteMessage.Click += new EventHandler(DeleteMessage_Click);
            contextMenuReplyMessage.Click += new EventHandler(ReplyMessage_Click);
            contextMenu.Items.AddRange(new ToolStripItem[] { contextMenuReplyMessage, contextMenuSendMail, contextMenuDownloadAttachment, contextMenuDeleteMessage, contextMenuUpdate });
            searchGroupBox.Enabled = false;
        }




        private void inboxDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                bodyRichTextBox.Text = "";
                CheckCheckBox(e.RowIndex);

            }

            else if (e.RowIndex >= 0)
            {
                string textMessageFromBody = "";
                textMessageFromBody = GetTextBodyFromMessageMail(e.RowIndex, e.ColumnIndex);
                bodyRichTextBox.Text = textMessageFromBody;
            }
        }

        public string GetTextBodyFromMessageMail(int rowIndex, int columnIndex, int defaultColumnIndex = 6)
        {
            string textBodyFromMessage = "";
            replyMailToolStripMenuItem.Enabled = true;

            if (columnIndex > 0)
            {
                foreach (var messageMail in messageMails)
                {
                    if (messageMail.UniqueId.Id == Convert.ToInt32(inboxDataGridView[defaultColumnIndex, rowIndex].Value))
                    {
                        message = myMailService.inbox.GetMessage(messageMail.UniqueId);
                        textBodyFromMessage = message.TextBody;
                        if (textBodyFromMessage == null)
                        {
                            textBodyFromMessage = message.HtmlBody;
                            textBodyFromMessage = myMailService.HtmlToPlainText(textBodyFromMessage);
                        }
                        int countAttachments = message.Attachments.Count();
                        if (countAttachments > 0)
                        {
                            downloadMenuItem.Enabled = true;

                            if (textBodyFromMessage.EndsWith("\n"))
                            {
                                textBodyFromMessage += "Вложения:\n";

                            }
                            else
                            {
                                textBodyFromMessage += "\nВложения:\n";

                            }

                            int i = 1;
                            foreach (var attachments in message.Attachments)
                            {
                                textBodyFromMessage += $"{i}." + attachments.ContentType.Name + "\n";
                                i++;
                            }
                        }
                        else
                        {
                            downloadMenuItem.Enabled = false;

                        }
                        break;
                    }
                }
            }

            return textBodyFromMessage;
        }
        private void inboxMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string itemText = e.ClickedItem.Text;
            switch (itemText)
            {
                case "Скачать вложение":
                    DownloadAttachment();
                    break;
                case "Отправить письмо":
                    SendMail();
                    break;
                case "Удалить письмо":
                    DeleteMessageMenu();
                    break;
                case "Обновить почтовой ящик":
                    UpdateInbox();
                    break;
                case "Ответить":
                    ReplyMessage();
                    break;
                case "Выйти из аккаунта":
                    Logout();
                    break;
            }
        }
        private void DeleteMessage()
        {
            int size = 0;
            for (int i = 0; i < inboxDataGridView.Rows.Count; i++)
            {
                if ((bool)inboxDataGridView.Rows[i].Cells[0].Value == true)
                {
                    size++;
                }
            }
            UniqueId[] uniqueIds = new UniqueId[size];
            int j = 0;
            for (int i = 0; i < inboxDataGridView.Rows.Count; i++)
            {
                if ((bool)inboxDataGridView.Rows[i].Cells[0].Value == true)
                {
                    if (messageMails[i].UniqueId.ToString() == inboxDataGridView.Rows[i].Cells[6].Value.ToString())
                    {
                        uniqueIds[j] = messageMails[i].UniqueId;
                        j++;
                    }


                }
            }
            myMailService.DeleteMessage(uniqueIds);
        }
        private void UpdateInboxDataGridView(IMailFolder folder)
        {
            messageMails = myMailService.GetMails(folder);
            int countMails = 0;
            foreach (var messageMail in messageMails)
            {
                countMails++;
                string attachment = "";
                var message = myMailService.inbox.GetMessage(messageMail.UniqueId);
                foreach (var attachments in message.Attachments)
                {
                    if (attachment == "")
                    {
                        attachment += attachments.ContentType.Name;

                    }
                    else
                    {
                        attachment += ", " + attachments.ContentType.Name;

                    }
                }
                dt.Rows.Add(new object[] { false, countMails, message.Date, message.From, message.Subject, attachment, messageMail.UniqueId });
            }
            inboxDataGridView.DataSource = null;
            inboxDataGridView.DataSource = dt;
            int sizeCellDataGridView = this.Width / 6;
            for (int i = 0; i < inboxDataGridView.ColumnCount; i++)
            {
                if (i == 0)
                {
                    inboxDataGridView.Columns[i].Width = sizeCellDataGridView - 92;

                }
                else if (i == 1)
                {
                    inboxDataGridView.Columns[i].Width = sizeCellDataGridView - 80;

                }
                else
                {
                    inboxDataGridView.Columns[i].Width = sizeCellDataGridView;

                }
            }
            inboxDataGridView.Columns[6].Visible = false;
            for (int i = 0; i < inboxDataGridView.RowCount; i++)
            {
                inboxDataGridView.Rows[i].Cells[0].ToolTipText = "Не отмечено";
            }
            headerCheckBox = new CheckBox();
            Point headerCellLocation = this.inboxDataGridView.GetCellDisplayRectangle(0, -1, true).Location;
            headerCheckBox.Location = new Point(headerCellLocation.X + 18, headerCellLocation.Y + 6);
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            inboxDataGridView.Controls.Add(headerCheckBox);
            inboxDataGridView.ClearSelection();
            inboxDataGridView.Columns[0].HeaderText = "";
            inboxDataGridView.Columns[0].ToolTipText = "Отметить все";
            inboxDataGridView.Columns[0].Frozen = true;
            countMailMessageToolStripStatusLabel.Text = $"Количество писем в этой папке: {inboxDataGridView.RowCount}";

        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            if (inboxDataGridView.Rows[0].Selected == false)
            {
                inboxDataGridView.Rows[0].Cells[1].Selected = true;
            }
            for (int i = 0; i < inboxDataGridView.RowCount; i++)
            {
                if (headerCheckBox.Checked == true)
                {
                    inboxDataGridView.Rows[i].Cells[0].Value = true;
                    inboxDataGridView.Rows[i].Cells[0].ToolTipText = "Отмечено";

                }
                else
                {
                    inboxDataGridView.Rows[i].Cells[0].Value = false;
                    inboxDataGridView.Rows[i].Cells[0].ToolTipText = "Не отмечено";


                }
            }
            inboxDataGridView.ClearSelection();
        }

        public void ClearRowsInboxDataGridView(DataGridView dataGridView)
        {
            while (dataGridView.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows.Remove(dataGridView.Rows[i]);
                }

            }
        }

        private void foldersInboxListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (foldersInboxListBox.SelectedItem != null)
            {
                countMailMessageToolStripStatusLabel.Text = "";
                workToolStripStatusLabel.Text = "Подождите, идет загрузка...";
                workStatusStrip.Refresh();
                Cursor.Current = Cursors.WaitCursor;
                bodyRichTextBox.Clear();
                ClearRowsInboxDataGridView(inboxDataGridView);
                UpdateInboxDataGridView(folders[foldersInboxListBox.SelectedIndex]);
                updateMailBoxToolStripMenuItem.Enabled = true;
                Cursor.Current = Cursors.Default;
                workToolStripStatusLabel.Text = "";
                searchGroupBox.Enabled = true;

            }


        }

        private void TranlateYandexFolders(List<string> names)
        {
            string[] translateFolders = new string[] { "Черновики", "Входящие", "Отправленные", "Спам", "Корзина" };
            for (int i = 0; i < names.Count; i++)
            {
                foldersInboxListBox.Items.Add(translateFolders[i]);
            }
        }
        private void TranslateGmailAndMailFolders(string name)
        {
            if (name == "INBOX")
            {
                foldersInboxListBox.Items.Add("Входящие");
            }
            else
            {
                foldersInboxListBox.Items.Add(name);

            }
        }

        private void CheckCheckBox(int rowIndex)
        {
            replyMailToolStripMenuItem.Enabled = false;
            if ((bool)inboxDataGridView.Rows[rowIndex].Cells[0].Value == false)
            {
                inboxDataGridView.Rows[rowIndex].Cells[0].Value = true;
                inboxDataGridView.Rows[rowIndex].Cells[0].ToolTipText = "Отмечено";
            }

            else
            {
                inboxDataGridView.Rows[rowIndex].Cells[0].Value = false;
                inboxDataGridView.Rows[rowIndex].Cells[0].ToolTipText = "Не отмечено";


            }
            for (int i = 0; i < inboxDataGridView.Rows.Count; i++)
            {
                if ((bool)inboxDataGridView.Rows[i].Cells[0].Value == true)
                {
                    deleteMailMenuItem.Enabled = true;
                    break;
                }
                else
                {
                    deleteMailMenuItem.Enabled = false;
                }
            }
        }
        private void FillFoldersInbox()
        {
            IMailFolder folder = myMailService.authorizationService.imapClient.GetFolder(myMailService.authorizationService.imapClient.PersonalNamespaces[0]);
            IMailFolder subFolder;
            List<string> names = new List<string>();
            if (myMailService.authorizationService.myClient.MailBox == 0)
            {
                folders = folder.GetSubfolders();
                folders.RemoveAt(1);
                subFolder = folder.GetSubfolder("[Gmail]");
                foreach (var item in subFolder.GetSubfolders())
                {
                    folders.Add(item);
                }
                foreach (var temp in folders)
                {
                    names.Add(temp.Name);
                }
                foreach (var name in names)
                {
                    TranslateGmailAndMailFolders(name);
                }

            }
            if (myMailService.authorizationService.myClient.MailBox == 1)
            {
                folders = folder.GetSubfolders();
                folders.RemoveAt(2);
                foreach (var temp in folders)
                {
                    names.Add(temp.Name);
                }
                TranlateYandexFolders(names);
            }
            if (myMailService.authorizationService.myClient.MailBox == 2)
            {
                folders = folder.GetSubfolders();
                foreach (var temp in folders)
                {
                    names.Add(temp.Name);
                }
                foreach (var name in names)
                {
                    TranslateGmailAndMailFolders(name);
                }
            }
        }

        private void UpdateInbox()
        {
            countMailMessageToolStripStatusLabel.Text = "";
            workToolStripStatusLabel.Text = "Подождите, идет загрузка...";
            workStatusStrip.Refresh();
            Cursor.Current = Cursors.WaitCursor;
            bodyRichTextBox.Clear();
            ClearRowsInboxDataGridView(inboxDataGridView);
            UpdateInboxDataGridView(folders[foldersInboxListBox.SelectedIndex]);
            Cursor.Current = Cursors.Default;
            workToolStripStatusLabel.Text = "";
            downloadMenuItem.Enabled = false;
            replyMailToolStripMenuItem.Enabled = false;
            deleteMailMenuItem.Enabled = false;
        }
        private void UpdateInbox_Click(object sender, EventArgs e)
        {
            UpdateInbox();
        }
        private void SendMail()
        {
            SendMailForm sendMailForm = new SendMailForm(myMailService);
            sendMailForm.Show();
        }
        private void SendMail_Click(object sender, EventArgs e)
        {
            SendMail();
        }
        private void DownloadAttachment()
        {
            DownloadAttachmentForm downloadAttachmentForm = new DownloadAttachmentForm(message);
            downloadAttachmentForm.Show();
        }
        private void DownloadAttachment_Click(object sender, EventArgs e)
        {
            DownloadAttachment();
        }
        private void DeleteMessageMenu()
        {
            DialogResult dialogDelete= MessageBox.Show(
          $"Вы действительно хотите удалить выбранные письма?",
           "Предупреждение",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning,
          MessageBoxDefaultButton.Button1,
          MessageBoxOptions.DefaultDesktopOnly);
           if(dialogDelete == DialogResult.Yes)
            {
                DeleteMessage();
                UpdateInbox();
                DialogResult dialogResult = MessageBox.Show(
              $"Сообщения были успешно удалены!",
               "Информация о проделанном действии",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
            }
           
        }
        private void DeleteMessage_Click(object sender, EventArgs e)
        {
            DeleteMessageMenu();
        }

        private void inboxDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                if (inboxDataGridView.RowCount != 0)
                {
                    var relativeMousePosition = inboxDataGridView.PointToClient(Cursor.Position);
                    inboxDataGridView.ContextMenuStrip = contextMenu;
                    if (downloadMenuItem.Enabled == false)
                    {
                        contextMenu.Items[2].Enabled = false;

                    }
                    else
                    {
                        contextMenu.Items[2].Enabled = true;

                    }
                    if (deleteMailMenuItem.Enabled == false)
                    {
                        contextMenu.Items[3].Enabled = false;
                    }
                    else
                    {
                        contextMenu.Items[3].Enabled = true;

                    }
                    if (replyMailToolStripMenuItem.Enabled == false)
                    {
                        contextMenu.Items[0].Enabled = false;
                    }
                    else
                    {
                        contextMenu.Items[0].Enabled = true;
                    }
                    inboxDataGridView.ContextMenuStrip.Show(inboxDataGridView, relativeMousePosition);
                    inboxDataGridView.ContextMenuStrip = null;

                }
            }

        }
        private void ReplyMessage()
        {
            Regex regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            string email = inboxDataGridView.CurrentRow.Cells[3].Value.ToString();
            email = regex.Match(email).ToString();
            SendMailForm sendMailForm = new SendMailForm(myMailService, email, inboxDataGridView.CurrentRow.Cells[4].Value.ToString());
            sendMailForm.Show();
        }

        private void ReplyMessage_Click(object sender, EventArgs e)
        {
            ReplyMessage();
        }

        private void searchKeyString_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchKeyStringComboBox.Text))
            {
                (inboxDataGridView.DataSource as DataTable).DefaultView.RowFilter = String.Empty;
            }
            else
            {
                (inboxDataGridView.DataSource as DataTable).DefaultView.RowFilter =
        String.Format("{0} like '%{1}%'", optionsFilterComboBox.Text.Trim().Replace("'", "''"), searchKeyStringComboBox.Text.Trim().Replace("'", "''")); ;
            }
        }
        private void Logout()
        {
            AuthorizationForm authorizationForm = new AuthorizationForm();
            myMailService.authorizationService.DisconnectImap();
            foreach (Form f in Application.OpenForms)
            {
                f.Hide();

            }
            authorizationForm.Show();
        }
    }
}

