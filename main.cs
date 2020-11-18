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
using System.Data.OleDb;

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

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi ứng dụng!?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog();
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.textBox1.Text = openfile1.FileName;
                }
                {
                    string pathconn = "Provider = Microsoft.jet.OLEDB.4.0; Data source=" + textBox1.Text + ";Extended Properties=\"Excel 8.0;HDR= yes;\";";
                    OleDbConnection conn = new OleDbConnection(pathconn);
                    // OleDbDataAdapter MyDataAdapter = new OleDbDataAdapter("Select * from [" + textBox2.Text + "$]", conn);
                    // DataTable dt = new DataTable();
                    // MyDataAdapter.Fill(dt);
                    // dataGridView1.DataSource = dt;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString());
            }
        }
    }
}
