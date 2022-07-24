using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var userName = "your_gmail_Id"; //from E- mail ID
                var password="your_gmail_App_password"; //Gmail App password 
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(userName);
                    mail.To.Add(userName);
                    mail.Subject = "Hello World";
                    mail.Body = GetHTMLBody();
                    mail.IsBodyHtml = true;
                   
                 
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                         
                        smtp.Credentials = new NetworkCredential(userName, password);
                        //smtp.UseDefaultCredentials = true;
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex) {
            
            }
        }


        private string GetHTMLBody()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            string sb = "<ul>";
            foreach (var ip in host.AddressList)
            {
                sb += string.Format("<li>your {0} is : {1}</li>", ip.AddressFamily.ToString(), ip.ToString());
            }
            sb += "</ul>";
            return sb;
        }
    }
}
