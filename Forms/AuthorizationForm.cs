using System;
using System.Windows.Forms;
using KursovikMVSA.Services;
using KursovikMVSA.Forms;

namespace KursovikMVSA
{
    public partial class AuthorizationForm : Form
    {

        AuthorizationService authorizationService;
        InboxForm inboxForm;
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void authorizationButton_Click(object sender, EventArgs e)
        {
             authorizationService = new AuthorizationService(emailTextbox.Text + mailBoxComboBox.SelectedItem, passwordTextBox.Text, mailBoxComboBox.SelectedIndex);
            try
            {
                
                authorizationService.EnterInboxImap(mailBoxComboBox.SelectedIndex);
                inboxForm = new InboxForm(authorizationService);
                DialogResult dialogResult = MessageBox.Show(
                    "Вход в почтовой ящик успешно выполнен!",
                     "Уведомление о входе",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                if(dialogResult == DialogResult.OK)
                {
                    inboxForm.Show();
                    this.Hide();
                }
                
            }
            catch (Exception)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Неверный Email или пароль. Пожалуйста, введите правильные данные и попробуйте снова.",
                     "Ошибка входа!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            authorizationButton.Enabled = false;
            mailBoxComboBox.Items.AddRange(new string[] { "@gmail.com", "@yandex.ru", "@mail.ru" });
            mailBoxComboBox.SelectedIndex = 0;

        }

        private void emailTextbox_TextChanged(object sender, EventArgs e)
        {
            if (emailTextbox.Text != "" && passwordTextBox.Text.Length>=4)
            {
                authorizationButton.Enabled = true;

            }
            else
            {
                authorizationButton.Enabled = false;

            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (emailTextbox.Text != "" && passwordTextBox.Text.Length >= 4)
            {
                authorizationButton.Enabled = true;

            }
            else
            {
                authorizationButton.Enabled = false;

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                    "Это программа является почтовым клиентом для сервисов: gmail, yandex и mail, чтобы войти введите Email и пароль.\n",
                     "О программе",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
