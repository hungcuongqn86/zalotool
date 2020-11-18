using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace transtrusttool.Utils
{
    [System.Xml.Serialization.XmlRootAttribute("config", IsNullable = false)]
    public class SamplesConfiguration
    {
        #region Fields

        private string _imap4Server, _imap4UserName, _imap4Password, _transperfectEmail, _transperfectPass, _imap4Server2, _imap4UserName2, _imap4Password2, _transperfectEmail2, _transperfectPass2;

        private const string _FILE_NAME_ = "Config.xml";

        #endregion

        #region Constructors

        public SamplesConfiguration()
        {
        }

        #endregion

        #region Properties

        public string FileName
        {
            get
            {
                return _FILE_NAME_;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("imap4server", DataType = "string")]
        public string Imap4Server
        {
            get
            {
                return _imap4Server;
            }

            set
            {
                _imap4Server = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("imap4username", DataType = "string")]
        public string Imap4UserName
        {
            get
            {
                return _imap4UserName;
            }

            set
            {
                _imap4UserName = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("imap4password", DataType = "string")]
        public string Imap4Password
        {
            get
            {
                return _imap4Password;
            }

            set
            {
                _imap4Password = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("transperfectemail", DataType = "string")]
        public string TransperfectEmail
        {
            get
            {
                return _transperfectEmail;
            }

            set
            {
                _transperfectEmail = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("transperfectpass", DataType = "string")]
        public string TransperfectPass
        {
            get
            {
                return _transperfectPass;
            }

            set
            {
                _transperfectPass = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("imap4server2", DataType = "string")]
        public string Imap4Server2
        {
            get
            {
                return _imap4Server2;
            }

            set
            {
                _imap4Server2 = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("imap4username2", DataType = "string")]
        public string Imap4UserName2
        {
            get
            {
                return _imap4UserName2;
            }

            set
            {
                _imap4UserName2 = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("imap4password2", DataType = "string")]
        public string Imap4Password2
        {
            get
            {
                return _imap4Password2;
            }

            set
            {
                _imap4Password2 = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("transperfectemail2", DataType = "string")]
        public string TransperfectEmail2
        {
            get
            {
                return _transperfectEmail2;
            }

            set
            {
                _transperfectEmail2 = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("transperfectpass2", DataType = "string")]
        public string TransperfectPass2
        {
            get
            {
                return _transperfectPass2;
            }

            set
            {
                _transperfectPass2 = value;
            }
        }
        #endregion

        #region Methods

        public void SetDefaultValue()
        {
            _imap4Server = "mail.example.com";
            _imap4UserName = "user1@example.com";
            _imap4Password = "yourpassword";
            _transperfectEmail = "user1@example.com";
            _transperfectPass = "yourpassword";

            _imap4Server2 = "mail.example.com";
            _imap4UserName2 = "user1@example.com";
            _imap4Password2 = "yourpassword";
            _transperfectEmail2 = "user1@example.com";
            _transperfectPass2 = "yourpassword";
        }

        public void Save()
        {
            Save(false);
        }

        public void Save(bool initValue)
        {
            if (initValue)
            {
                SetDefaultValue();
            }

            string configFullPath = Common.GetImagePath(Assembly.GetExecutingAssembly().Location) + @"\" + _FILE_NAME_;
            XmlSerializer serialize = new XmlSerializer(typeof(SamplesConfiguration));
            TextWriter writer = new StreamWriter(_FILE_NAME_);
            serialize.Serialize(writer, (SamplesConfiguration)this);
            writer.Close();
        }

        public bool CheckExistingConfig()
        {
            string configFullPath = Common.GetImagePath(Assembly.GetExecutingAssembly().Location) + @"\" + _FILE_NAME_;
            return File.Exists(configFullPath);
        }

        #endregion
    }
}
