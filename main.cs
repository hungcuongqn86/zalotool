using MailKit.Security;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using transtrusttool.Utils;

namespace transtrusttool
{
    public partial class main : Form
    {
        public LogWriter logWriter;
        public static main thisForm;
        const SecureSocketOptions SslOptions = SecureSocketOptions.Auto;
        public IdleClient idleClient;
        public Task idleTask;

        private SamplesConfiguration _configuration;
        public main()
        {
            logWriter = new LogWriter("Open app...");
            InitializeComponent();
            thisForm = this;
        }

        public SamplesConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new SamplesConfiguration();

                    string configFullPath = Utils.Common.GetImagePath(Assembly.GetExecutingAssembly().Location) + @"\" + _configuration.FileName;

                    if (File.Exists(configFullPath))
                    {
                        TextReader reader = new StreamReader(configFullPath);
                        XmlSerializer serialize = new XmlSerializer(typeof(SamplesConfiguration));
                        _configuration = (SamplesConfiguration)serialize.Deserialize(reader);
                        reader.Close();
                    }
                    else
                    {
                        _configuration.SetDefaultValue();

                        ConfigurationForm configForm = new ConfigurationForm(this.Configuration);
                        configForm.ShowDialog();
                    }
                }
                return _configuration;
            }
            set
            {
                _configuration = value;
            }
        }

        private void Config_btn_Click(object sender, EventArgs e)
        {
            ConfigurationForm configForm = new ConfigurationForm(this.Configuration);
            configForm.ShowDialog();
        }

        private void Loading(bool status)
        {
            btnAuto1.Enabled = status;
        }

        private void BtnAuto1_Click(object sender, EventArgs e)
        {
            logWriter.LogWrite("btnAuto1_Click...");
            Loading(false);
            this.idleClient = new IdleClient(
                this.Configuration.Imap4Server, 993, SslOptions, 
                this.Configuration.Imap4UserName, 
                this.Configuration.Imap4Password,
                this.Configuration.TransperfectEmail,
                this.Configuration.TransperfectPass
                );
            this.idleTask = this.idleClient.RunAsync();
        }

        private void Btn_stop1_Click(object sender, EventArgs e)
        {
            logWriter.LogWrite("btn_stop1_Click...");
            Loading(true);
            this.idleClient.Exit();
            this.idleTask.GetAwaiter().GetResult();
        }

        private void BtnAuto2_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void Account1_start_btn_Click(object sender, EventArgs e)
        {
            Loading(false);
            logWriter.LogWrite("------------------------------------------------");
            logWriter.LogWrite("account1_start_btn_Click");
            /*using (var autoDriver = new AutoRun())
            {
                autoDriver.submissionId = "0623307";
                autoDriver.avaliableUrl = autoDriver.tdcAvaliableUrl;
                autoDriver.Autoget(this.Configuration.Imap4UserName, this.Configuration.TransperfectEmail, this.Configuration.TransperfectPass);
            }*/
            Loading(true);
        }

        private void Account2_start_btn_Click(object sender, EventArgs e)
        {
            Loading(false);
            logWriter.LogWrite("------------------------------------------------");
            logWriter.LogWrite("account1_start_btn_Click");
            /*using (var autoDriver = new AutoRun())
            {
                // autoDriver.submissionId = "0614938";
                autoDriver.avaliableUrl = autoDriver.tdcAvaliableUrl;
                autoDriver.Autoget(this.Configuration.Imap4UserName2, this.Configuration.TransperfectEmail2, this.Configuration.TransperfectPass2);
            }*/
            Loading(true);
        }

        private void Account1TptRun_Click(object sender, EventArgs e)
        {
            Loading(false);
            logWriter.LogWrite("------------------------------------------------");
            logWriter.LogWrite("account1TptRun_Click");
            /*using (var autoDriver = new AutoRun())
            {
                // autoDriver.submissionId = "0614938";
                autoDriver.avaliableUrl = autoDriver.tptAvaliableUrl;
                autoDriver.Autoget(this.Configuration.Imap4UserName, this.Configuration.TransperfectEmail, this.Configuration.TransperfectPass);
            }*/
            Loading(true);
        }

        private void Account2TptRun_Click(object sender, EventArgs e)
        {
            Loading(false);
            logWriter.LogWrite("------------------------------------------------");
            logWriter.LogWrite("account2TptRun_Click");
            /*using (var autoDriver = new AutoRun())
            {
                // autoDriver.submissionId = "0614938";
                autoDriver.avaliableUrl = autoDriver.tptAvaliableUrl;
                autoDriver.Autoget(this.Configuration.Imap4UserName2, this.Configuration.TransperfectEmail2, this.Configuration.TransperfectPass2);
            }*/
            Loading(true);
        }

        private void Btn_stop2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
