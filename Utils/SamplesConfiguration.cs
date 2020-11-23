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

        private int _delay2Mess1Acc, _delay2Mess2Acc, _pauseAt, _pauseTime;
        private bool _makeFriendWithStrangers, _logWhenSuccessful;

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

        [System.Xml.Serialization.XmlElementAttribute("delay2Mess1Acc", DataType = "int")]
        public int Delay2Mess1Acc
        {
            get
            {
                return _delay2Mess1Acc;
            }

            set
            {
                _delay2Mess1Acc = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("delay2Mess2Acc", DataType = "int")]
        public int Delay2Mess2Acc
        {
            get
            {
                return _delay2Mess2Acc;
            }

            set
            {
                _delay2Mess2Acc = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("pauseAt", DataType = "int")]
        public int PauseAt
        {
            get
            {
                return _pauseAt;
            }

            set
            {
                _pauseAt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("pauseTime", DataType = "int")]
        public int PauseTime
        {
            get
            {
                return _pauseTime;
            }

            set
            {
                _pauseTime = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("makeFriendWithStrangers", DataType = "boolean")]
        public bool MakeFriendWithStrangers
        {
            get
            {
                return _makeFriendWithStrangers;
            }

            set
            {
                _makeFriendWithStrangers = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("logWhenSuccessful", DataType = "boolean")]
        public bool LogWhenSuccessful
        {
            get
            {
                return _logWhenSuccessful;
            }

            set
            {
                _logWhenSuccessful = value;
            }
        }
        #endregion

        #region Methods

        public void SetDefaultValue()
        {
            _delay2Mess1Acc = 3;
            _delay2Mess2Acc = 8;
            _pauseAt = 20;
            _pauseTime = 180;
            _makeFriendWithStrangers = false;
            _logWhenSuccessful = false;
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
