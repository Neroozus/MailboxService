
namespace KursovikMVSA
{
    public class MyClient
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int MailBox { get; set; }

        public MyClient(string email, string password, int mailBox)
        {
            Email = email;
            Password = password;
            MailBox = mailBox;
        }
    }
     
}
