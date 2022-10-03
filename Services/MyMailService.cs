using MailKit;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace KursovikMVSA.Services
{
    public class MyMailService
    {
        public AuthorizationService authorizationService;
        public IMailFolder inbox { get; set; }

        public MyMailService(AuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
            //Inbox = authorizationService.imapClient.Inbox;
        }
        public MyMailService()
        {

        }
        public IList<IMessageSummary> GetMails(IMailFolder folder)
        {
            inbox = folder;
            inbox.Open(FolderAccess.ReadWrite);
            var items = inbox.Fetch(0, -1, MessageSummaryItems.UniqueId);
            return items;
        }

        public bool DownloadAttachment(MimeMessage attachments, string fileName, string path)
        {
            string fullPath = path + "\\" + fileName;
            foreach (var attachment in attachments.Attachments)
            {
                if (fileName == attachment.ContentType.Name)
                {

                    using (var stream = File.Create(fullPath))
                    {
                        if (attachment is MessagePart)
                        {
                            var rfc822 = (MessagePart)attachment;

                            rfc822.Message.WriteTo(stream);
                        }
                        else
                        {
                            var part = (MimePart)attachment;

                            part.Content.DecodeTo(stream);

                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return true;
        }
        public void SendMail(string emailToSend, string emailFrom, string subject, string textBody)
        {
            MimeMessage message = new MimeMessage();
            FillMessage(message, emailToSend, emailFrom, subject);
            message.Body = new TextPart("plain")
            {
                Text = textBody
            };

            authorizationService.EnterInboxSmtp();
            authorizationService.smtpClient.Send(message);
            authorizationService.smtpClient.Disconnect(true);
        }
        public void SendEmailWithAttachment(string emailToSend, string emailFrom, string subject, string textBody, string[] fileNames)
        {
            MimeMessage message = new MimeMessage();
            FillMessage(message, emailToSend, emailFrom, subject);
            BodyBuilder builder = new BodyBuilder();
            builder.TextBody = @textBody;
            if (fileNames.Length == 1)
            {
                builder.Attachments.Add(fileNames[0]);
            }
            else
            {
                for (int i = 0; i < fileNames.Length; i++)
                {
                    builder.Attachments.Add(fileNames[i]);
                }
            }
            
            message.Body = builder.ToMessageBody();
            authorizationService.EnterInboxSmtp();
            authorizationService.smtpClient.Send(message);
            authorizationService.smtpClient.Disconnect(true);
        }

        public void DeleteMessage(UniqueId[] uniqueIds)
        {
            for(int i=0; i < uniqueIds.Length; i++)
            {
                inbox.AddFlags(uniqueIds[i], MessageFlags.Deleted, false);

            }
            inbox.Expunge();
        }

        private void FillMessage(MimeMessage message, string emailToSend, string emailFrom, string subject)
        {
            message.From.Add(new MailboxAddress(inbox.Name, emailFrom));
            message.To.Add(new MailboxAddress("", emailToSend));
            message.Subject = subject;
        }

        public string HtmlToPlainText(string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";
            const string stripFormatting = @"<[^>]*(>|$)";
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }
    }
}
