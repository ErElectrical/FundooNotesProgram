using System;
using System.Collections.Generic;
using System.Text;
using Experimental.System.Messaging;
using System.Net;
using System.Net.Mail;

namespace CommonLayer.Model
{
    /// <summary>
    /// Microsoft Messaging Queue (MSMQ) technology is used for asynchronous communication using messages.
    /// MSMQ also can be considered to be an Inter- process communication capability.
    /// asynchronus meaning not happen at same time 
    /// in MsMq we send the email id to queue than queue event handler will handle it and send response to the user

    /// </summary>
    public class MsMq
    {
        //declare the queue instance
        MessageQueue messagequeue = new MessageQueue();

        public void Sender(string Token)
        {
            //setting the queue path where we store the token
            this.messagequeue.Path = @".\pivate$\Tokens";
            try
            {
                //if path exists than we create the message queue there
                if(MessageQueue.Exists(this.messagequeue.Path))
                {
                    MessageQueue.Create(this.messagequeue.Path);
                
                }
                //decide the format of the message queue
                this.messagequeue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                //register the Method to the event 
                this.messagequeue.ReceiveCompleted += MessageQue_RecivedCompleted; 
                this.messagequeue.Send(Token);
                this.messagequeue.BeginReceive();
                this.messagequeue.Close();
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void MessageQue_RecivedCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var message = this.messagequeue.EndReceive(e.AsyncResult);
            string token = message.Body.ToString();
            try
            {
                MailMessage mailmessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("jonapifundooapp@gmail.com", "maa@355133"),
                    //SSL stands for Secure Sockets Layer
                    //it's the standard technology for keeping an internet connection secure and safeguarding
                    //any sensitive data that is being sent between two systems,
                    //preventing criminals from reading and modifying any information transferred,
                    //including potential personal details.

                    EnableSsl = true
                };
                mailmessage.From = new MailAddress("jonapifundooapp@gmail.com", "maa@355133");

                mailmessage.To.Add(new MailAddress("jonapifundooapp@gmail.com"));//provide the dummy gmail yo mailaddress constructor
                mailmessage.Body = token;
                mailmessage.Subject = "FundooNote App reset link";
                smtpClient.Send(mailmessage);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
