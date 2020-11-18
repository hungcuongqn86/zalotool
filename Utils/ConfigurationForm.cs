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
                _tbImap4Username.Text = _config.Imap4UserName;
                _tbImap4Password.Text = _config.Imap4Password;
                _tbImap4Server.Text = _config.Imap4Server;
                _tbTransperfectEmail.Text = _config.TransperfectEmail;
                _tbTransperfectPass.Text = _config.TransperfectPass;
            }
        }

        private void _bSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Imap4
                _config.Imap4UserName = _tbImap4Username.Text;
                _config.Imap4Password = _tbImap4Password.Text;
                _config.Imap4Server = _tbImap4Server.Text;
                _config.TransperfectEmail = _tbTransperfectEmail.Text;
                _config.TransperfectPass = _tbTransperfectPass.Text;

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