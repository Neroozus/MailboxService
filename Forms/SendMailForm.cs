using KursovikMVSA.Services;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KursovikMVSA.Forms
{
    public partial class SendMailForm : Form
    {
        MyMailService myMailService;
        DataTable dt = new DataTable();
        string[] fileNames;
        public SendMailForm(MyMailService myMailService)
        {
            this.myMailService = myMailService;
            InitializeComponent();
            sendMailButton.Enabled = false;
        }
        public SendMailForm(MyMailService myMailService, string replyEmail, string replySubject)
        {
            this.myMailService = myMailService;
            InitializeComponent();
            recipientMailTextBox.Text = replyEmail;
            subjectMailTextBox.Text = "Re: " + replySubject;
            sendMailButton.Enabled = true;
        }
        private void SendMailForm_Load(object sender, EventArgs e)
        {
            
            dt.Columns.Add("№ файла");
            dt.Columns.Add("Имя файла");
            attachmentsDataGridView.Visible = false;
            label4.Visible = false;
        }

        private void sendMailButton_Click(object sender, EventArgs e)
        {
            string emailToSend = recipientMailTextBox.Text;
            string emailFromSend = myMailService.authorizationService.myClient.Email;
            string subject = subjectMailTextBox.Text;
            string sendTextBody = sendTextBodyRichTextBox.Text;
            if (fileNames != null)
            {
                try
                {
                    myMailService.SendEmailWithAttachment(emailToSend, emailFromSend, subject, sendTextBody, fileNames);
                    fileNames = null;
                    attachmentsDataGridView.Visible = false;
                    label4.Visible = false;
                    DialogResult dialogResult = MessageBox.Show(
                   $"Сообщение получателю {emailToSend} было успешно отправлено!",
                    "Информация о проделанном действии",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception)
                {
                    DialogResult dialogResult = MessageBox.Show(
                 $"Сообщение получателю {emailToSend} не было отправлено!",
                  "Ошибка",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                try
                {
                    myMailService.SendMail(emailToSend, emailFromSend, subject, sendTextBody);
                    DialogResult dialogResult = MessageBox.Show(
                       $"Сообщение получателю {emailToSend} было успешно отправлено!",
                        "Информация о проделанном действии",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1,
                       MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception)
                {
                    DialogResult dialogResult = MessageBox.Show(
                     $"Сообщение получателю {emailToSend} не было отправлено!",
                      "Ошибка",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.DefaultDesktopOnly);
                }
            }

        }

        private void attachFileButton_Click(object sender, EventArgs e)
        {
            
            if(attachmentsFileOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] safeFileNames = new string[0];
                dt.Rows.Clear();
                fileNames = attachmentsFileOpenFileDialog.FileNames;
                safeFileNames = attachmentsFileOpenFileDialog.SafeFileNames;
                for (int i = 0; i < fileNames.Length; i++)
                {
                    dt.Rows.Add(new object[] { (i + 1).ToString(), safeFileNames[i] });
                }
                attachmentsDataGridView.DataSource = null;
                attachmentsDataGridView.DataSource = dt;
                int sizeCellDataGridView = attachmentsDataGridView.Width/2;
                for(int i=0; i < attachmentsDataGridView.ColumnCount; i++)
                {
                    attachmentsDataGridView.Columns[i].Width = sizeCellDataGridView;
                }              
                attachmentsDataGridView.Visible = true;
                label4.Visible = true;
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void recipientMailTextBox_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            if(regex.IsMatch(recipientMailTextBox.Text) == true)
            {
                sendMailButton.Enabled = true;

            }
            else
            {
                sendMailButton.Enabled = false;

            }

        }
    }
}
