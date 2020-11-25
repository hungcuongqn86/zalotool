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
        public AutoRun autoRun;

        private SamplesConfiguration _configuration;
        public main()
        {
            logWriter = new LogWriter("=============================================================");
            logWriter.LogWrite("Open App...");
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
            button1.Enabled = status;
        }

        private void BtnAuto1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn file danh sách số điện thoại!", "Thông báo!", MessageBoxButtons.OK);
                return;
            }

            if (this.textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nội dung tin nhắn!", "Thông báo!", MessageBoxButtons.OK);
                return;
            }

            logWriter.LogWrite("START ...");
            Loading(false);
            if (autoRun != null)
            {
                autoRun.Dispose();
            }
            autoRun = new AutoRun("zalotool");
            if (autoRun.loginStatus)
            {
                using (StreamReader reader = File.OpenText(this.textBox1.Text))
                {
                    string line = "";
                    string content = this.textBox2.Text;
                    string photo = this.textBox3.Text;
                    int index = 0;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (index > 0)
                        {
                            if (this.Configuration.Delay2Mess2Acc > 0)
                            {
                                System.Threading.Thread.Sleep(1000 * this.Configuration.Delay2Mess2Acc);
                            }

                            if (this.Configuration.PauseAt > 0 && this.Configuration.PauseTime > 0)
                            {
                                if (index % this.Configuration.PauseAt == 0)
                                {
                                    if (this.Configuration.PauseTime > this.Configuration.Delay2Mess2Acc)
                                    {
                                        System.Threading.Thread.Sleep(1000 * (this.Configuration.PauseTime - this.Configuration.Delay2Mess2Acc));
                                    }
                                }
                            }
                        }

                        bool check = autoRun.RunAuto(line, content, photo, this.Configuration.Delay2Mess1Acc);
                        string[] arr = new string[4];
                        ListViewItem itm;
                        arr[0] = line;
                        if (check)
                        {
                            arr[1] = "Thành công";
                            if (this.Configuration.LogWhenSuccessful)
                            {
                                logWriter.LogWrite(arr[0] + " ---------------------- true");
                            }
                        }
                        else
                        {
                            arr[1] = "Thất bại";
                            logWriter.LogWrite(arr[0] + " ---------------------- false");
                        }

                        itm = new ListViewItem(arr);
                        this.listView1.Items.Add(itm);
                        index++;
                    }
                }

                autoRun.Dispose();
                Loading(true);
                logWriter.LogWrite("END");
                MessageBox.Show("Hoàn thành gửi tin!", "Thông báo!", MessageBoxButtons.OK);
                return;
            }
            else
            {
                // autoRun.Dispose();
                Loading(true);
                MessageBox.Show("Đăng nhập không thành công! hãy đăng nhập zalo trên trình duyệt chrome và thực hiện lại!", "Login...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            logWriter.LogWrite("End...");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi ứng dụng!?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                logWriter.LogWrite("Exit");
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Text File (*.txt) |*.txt";
                openfile1.FilterIndex = 3;
                openfile1.Multiselect = false;
                openfile1.InitialDirectory = @"Desktop";

                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string pathName = openfile1.FileName;
                    this.textBox1.Text = pathName;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog();
                // .png, .jpg, .jpeg, .gif
                openfile1.Filter = "Image files (*.jpg, *.jpeg, *.gif, *.png) | *.jpg; *.jpeg; *.gif; *.png";
                openfile1.FilterIndex = 3;
                openfile1.Multiselect = false;
                openfile1.InitialDirectory = @"Desktop";

                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string pathName = openfile1.FileName;
                    this.textBox3.Text = pathName;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString());
            }
        }
    }
}
