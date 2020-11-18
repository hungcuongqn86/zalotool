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
using System.Text.RegularExpressions;
using System.Data;

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
                openfile1.Filter = "Excel Files (*.xlsx) |*.xlsx";
                openfile1.FilterIndex = 3;
                openfile1.Multiselect = false;
                openfile1.InitialDirectory = @"Desktop";

                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string pathName = openfile1.FileName;
                    this.textBox1.Text = pathName;

                    string fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    DataTable tbContainer = new DataTable();
                    string strConn = string.Empty;
                    string sheetName = fileName;

                    FileInfo file = new FileInfo(pathName);
                    if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
                    string extension = file.Extension;
                    switch (extension)
                    {
                        case ".xls":
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                            break;
                        case ".xlsx":
                            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                            break;
                        default:
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                            break;
                    }
                    OleDbConnection cnnxls = new OleDbConnection(strConn);
                    OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), cnnxls);
                    oda.Fill(tbContainer);

                    // dtGrid.DataSource = tbContainer;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString());
            }
        }
    }
}
