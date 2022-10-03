using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using System;

namespace KursovikMVSA.Services
{
    public class AuthorizationService
    {
        public ImapClient imapClient;
        public SmtpClient smtpClient;
        public MyClient myClient;
      

        public AuthorizationService(string email, string password, int mailBox)
        {
            myClient = new MyClient(email, password, mailBox);
            imapClient = new ImapClient();
            smtpClient = new SmtpClient();

        }

        public void EnterInboxImap(int mailBox)
        {
            try
            {
                if (mailBox == 0)
                {
                    ConnectImap("imap.gmail.com");
                    
                }
                else if(mailBox == 1)
                {
                    ConnectImap("imap.yandex.ru");

                }
                else if (mailBox == 2)
                {
                    ConnectImap("imap.mail.ru");

                }
            }

            catch (ServiceNotAuthenticatedException)
            {
                throw new Exception();
            }
        }

        public void EnterInboxSmtp()
        {
            try
            {
                if (myClient.MailBox == 0)
                {
                    ConnectSmtp("smtp.gmail.com");

                }
                else if (myClient.MailBox == 1)
                {
                    ConnectSmtp("smtp.yandex.ru");

                }
                else if (myClient.MailBox == 2)
                {
                    ConnectSmtp("smtp.mail.ru");

                }
            }

            catch (ServiceNotAuthenticatedException)
            {
                throw new Exception();
            }
        }

        private void ConnectImap(string domain)
        {
            imapClient.Connect(domain, 993, true);
            imapClient.Authenticate(myClient.Email, myClient.Password);
        }
        public void DisconnectImap()
        {
            imapClient.Disconnect(true);
        }

        private void ConnectSmtp(string domain)
        {
            smtpClient.Connect(domain, 465, true);
            smtpClient.Authenticate(myClient.Email, myClient.Password);
        }
    }
}

