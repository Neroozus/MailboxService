using KursovikMVSA.Services;
using MimeKit;
using System;
using System.Windows.Forms;

namespace KursovikMVSA.Forms
{
    public partial class DownloadAttachmentForm : Form
    {
        MyMailService myMailService;
        MimeMessage attachments;
        public DownloadAttachmentForm(MimeMessage attachments)
        {
            this.attachments = attachments;
            myMailService = new MyMailService();
            InitializeComponent();
        }

        private void DownloadAttachmentForm_Load(object sender, EventArgs e)
        {
            foreach (var attachment in attachments.Attachments)
            {
                attachmentsNameComboBox.Items.Add(attachment.ContentType.Name);
            }
            attachmentsNameComboBox.SelectedIndex = 0;
        }

        private void downloadAttachmentButton_Click(object sender, EventArgs e)
        {
            string fileName = attachmentsNameComboBox.SelectedItem.ToString();
            string path = "";
            using (FolderBrowserDialog openFileDialog = new FolderBrowserDialog())
            {

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.SelectedPath;
                    if (myMailService.DownloadAttachment(attachments, fileName, path) == true)
                    {
                        DialogResult dialogResult = MessageBox.Show(
                  $"Файл {fileName} успешно скачан!",
                   "Информация о проделанном действии",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information,
                  MessageBoxDefaultButton.Button1,
                  MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show(                 
                  $"Произошла ошибка! Файл {fileName} не может быть скачан.",
                  "Ошибка!",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            }


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
