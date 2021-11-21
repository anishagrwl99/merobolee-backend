using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Settings
{

    /// <summary>
    /// SMTP Server information
    /// </summary>
    public class SMTPServerInfo
    {
        /// <summary>
        /// Email server login user
        /// </summary>
        public string FromEmail { get; set; }


        /// <summary>
        /// ogin username password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// SMTP Server HOST url (IP Address)
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// SMTP Server port number
        /// </summary>
        public int Port { get; set; }


        /// <summary>
        /// Enable ssl for sending email
        /// </summary>
        public bool EnableSSL { get; set; }
    }
}

