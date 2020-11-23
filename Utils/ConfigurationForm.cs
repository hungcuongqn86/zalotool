using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace transtrusttool.Utils
{
    public partial class ConfigurationForm : Form
    {
        private SamplesConfiguration _config = null;

        public ConfigurationForm(SamplesConfiguration config)
        {
            _config = config;
            InitializeComponent();
            InitConfiguration();
        }

        public void InitConfiguration()
        {
            if (_config != null)
            {
                // Imap4
                _tbDelay2Mess1Acc.Value = _config.Delay2Mess1Acc;
                _tbDelay2Mess2Acc.Value = _config.Delay2Mess2Acc;
            }
        }

        private void _bSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Imap4
                _config.Delay2Mess1Acc = Convert.ToInt32(_tbDelay2Mess1Acc.Value);
                _config.Delay2Mess2Acc = Convert.ToInt32(_tbDelay2Mess2Acc.Value);
                _config.Save();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                this.Close();
            }
        }

        private void _bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}