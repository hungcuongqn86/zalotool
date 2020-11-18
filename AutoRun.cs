using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

namespace transtrusttool
{
    public class AutoRun : IDisposable
    {
        public LogWriter logWriter;
        public ChromeDriver chromeDriver;
        public string submissionId;
        // string dashboardUrl = "https://dashboard.transperfect.com/";
        public string tdcAvaliableUrl = "https://gl-tdcprod1.translations.com/PD/#userMenuAVAILABLE_SUBMISSION";
        public string tptAvaliableUrl = "https://gl-tptprod1.transperfect.com/PD/#userMenuAVAILABLE_SUBMISSION";
        public string avaliableUrl = "https://gl-tdcprod1.translations.com/PD/#userMenuAVAILABLE_SUBMISSION";
        public bool working = false;
        public string email;
        public string pass;
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        public AutoRun(string imap4UserName, string email, string pass)
        {
            this.email = email;
            this.pass = pass;

            logWriter = new LogWriter("AutoRun ...");
            string profilePath = "C:/profile";
            try
            {
                bool exists = System.IO.Directory.Exists(profilePath);
                if (!exists)
                    System.IO.Directory.CreateDirectory(profilePath);
            }
            catch
            {
                logWriter.LogWrite("Error, Could not create directory for saving profiles!");
                logWriter.LogWrite("------------------------------------------------");
                return;
            }

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--user-data-dir=" + profilePath + "/" + imap4UserName);
            options.AddArgument("profile-directory=" + imap4UserName);
            options.AddArgument("disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--start-maximized");
            chromeDriver = new ChromeDriver(options)
            {
                Url = tdcAvaliableUrl
            };
            chromeDriver.Navigate();
            WaitLoading();

            login();

            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 300000;
            myTimer.Start();
        }

        private void TimerEventProcessor(Object myObject,
                                        EventArgs myEventArgs)
        {
            if (working == false)
            {
                chromeDriver.Navigate().Refresh();
                // if end session
                System.Threading.Thread.Sleep(5000);
                ReadOnlyCollection<IWebElement> msgErrorBox = chromeDriver.FindElements(By.Id("errorMessage-title"));
                if (msgErrorBox.Count > 0)
                {
                    ReadOnlyCollection<IWebElement> buttonClose = chromeDriver.FindElements(By.Id("errorMessage-closeButton"));
                    if (buttonClose.Count > 0)
                    {
                        string tbuttonClose = buttonClose.First().TagName;
                        if (tbuttonClose == "button")
                        {
                            buttonClose.First().Click();
                        }
                        WaitLoading();
                        login();
                    }
                }

                ReadOnlyCollection<IWebElement> sessionTerminatedErrorBox = chromeDriver.FindElements(By.XPath("//div[text()='Session terminated' and contains(@id, 'innerCt')]"));
                if (sessionTerminatedErrorBox.Count > 0)
                {
                    ReadOnlyCollection<IWebElement> buttonClose = chromeDriver.FindElements(By.XPath("//span[text()='Close' and contains(@id, 'btnInnerEl')]"));
                    if (buttonClose.Count > 0)
                    {
                        IWebElement abuttonClose = buttonClose.First().FindElement(By.XPath("..")).FindElement(By.XPath("..")).FindElement(By.XPath(".."));
                        string tbuttonClose = abuttonClose.TagName;
                        if (tbuttonClose == "a")
                        {
                            abuttonClose.Click();
                        }
                        WaitLoading();
                        login();
                    }
                }

                // If logout
                ReadOnlyCollection<IWebElement> loginForm = chromeDriver.FindElements(By.Id("loginForm"));
                if (loginForm.Count > 0)
                {
                    login();
                }
            }
        }

        private void login()
        {
            System.Threading.Thread.Sleep(5000);
            // If nologin
            string url = chromeDriver.Url;
            if (url.Contains("gl-tdcprod1.translations.com/PD/login") || url.Contains("gl-tptprod1.transperfect.com/PD/login"))
            {
                // confirm login
                ReadOnlyCollection<IWebElement> eloginwithemailbutton = chromeDriver.FindElements(By.Id("loginwithemail-button"));
                if (eloginwithemailbutton.Count > 0)
                {
                    eloginwithemailbutton.First().Click();
                    WaitLoading();
                    System.Threading.Thread.Sleep(3000);
                    logWriter.LogWrite("login with email...");
                }
            }

            url = chromeDriver.Url;
            if (url.Contains("sso.transperfect.com/Account/Login"))
            {
                // SendKeys email
                ReadOnlyCollection<IWebElement> eEmails = chromeDriver.FindElements(By.Id("Email"));
                if (eEmails.Count > 0)
                {
                    eEmails.First().Clear(); ;
                    eEmails.First().SendKeys(email);
                    System.Threading.Thread.Sleep(2000);
                }

                // SendKeys password /Password
                ReadOnlyCollection<IWebElement> ePasswords = chromeDriver.FindElements(By.Id("Password"));
                if (ePasswords.Count == 0)
                {
                    // SubmitLogin
                    ReadOnlyCollection<IWebElement> SubmitLogin = chromeDriver.FindElements(By.Id("SubmitLogin"));
                    if (SubmitLogin.Count > 0)
                    {
                        SubmitLogin.First().Click();
                        WaitLoading();
                        System.Threading.Thread.Sleep(2000);
                        ePasswords = chromeDriver.FindElements(By.Id("Password"));
                    }
                }
                System.Threading.Thread.Sleep(2000);
                if (ePasswords.Count > 0)
                {
                    ePasswords.First().Clear(); ;
                    ePasswords.First().SendKeys(pass);
                    System.Threading.Thread.Sleep(2000);
                }

                // SubmitLogin2
                System.Threading.Thread.Sleep(2000);
                ReadOnlyCollection<IWebElement> SubmitLogin2 = chromeDriver.FindElements(By.Id("SubmitLogin"));
                if (SubmitLogin2.Count > 0)
                {
                    SubmitLogin2.First().Click();
                    WaitLoading();
                    System.Threading.Thread.Sleep(2000);
                }

                logWriter.LogWrite("login...");
            }

            url = chromeDriver.Url;
            if (url.Contains("sso.transperfect.com/Account/Login"))
            {
                logWriter.LogWrite("Login fall!");
                chromeDriver.Quit();
                MessageBox.Show("Login fall!", "Login...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // button-1217 -- Close
            System.Threading.Thread.Sleep(5000);
            ReadOnlyCollection<IWebElement> buttonClose = chromeDriver.FindElements(By.XPath("//span[text()='Close' and contains(@id, 'btnInnerEl')]"));
            if (buttonClose.Count > 0)
            {
                IWebElement abuttonClose = buttonClose.First().FindElement(By.XPath("..")).FindElement(By.XPath("..")).FindElement(By.XPath(".."));
                string tbuttonClose = abuttonClose.TagName;
                if (tbuttonClose == "a")
                {
                    abuttonClose.Click();
                }
                WaitLoading();
            }
        }

        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Quit();
            }
        }

        public void RunAuto(string endpoint, string submission)
        {
            working = true;
            // string msg = "Email " + imap4UserName + ", Subject: " + subject;
            this.logWriter.LogWrite(String.Format("RunAuto: {0} - {1}", endpoint, submission));
            submissionId = submission;
            if (endpoint == "TDC-PD")
            {
                avaliableUrl = tdcAvaliableUrl;
            }
            if (endpoint == "TPT-PD")
            {
                avaliableUrl = tptAvaliableUrl;
            }

            // Open newtab
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles.First());
            System.Threading.Thread.Sleep(1000);
            ReadOnlyCollection<IWebElement> availableTab = chromeDriver.FindElements(By.XPath("//a[contains(@href, 'translations.com')]"));
            if (availableTab.Count > 0)
            {
                IWebElement availableLink = availableTab.First();
                String selectLinkOpeninNewTab = Keys.Control + Keys.Return;
                availableLink.SendKeys(selectLinkOpeninNewTab);
                WaitLoading();
                chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles.Last());
                chromeDriver.Navigate().GoToUrl(avaliableUrl);
                WaitLoading();
                Autoget();
                chromeDriver.Close();
            }
            chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles.First());
            working = false;
        }

        public void Autoget()
        {
            System.Threading.Thread.Sleep(5000);
            ReadOnlyCollection<IWebElement> buttonClose = chromeDriver.FindElements(By.XPath("//span[text()='Close' and contains(@id, 'btnInnerEl')]"));
            if (buttonClose.Count > 0)
            {
                IWebElement abuttonClose = buttonClose.First().FindElement(By.XPath("..")).FindElement(By.XPath("..")).FindElement(By.XPath(".."));
                string tbuttonClose = abuttonClose.TagName;
                if (tbuttonClose == "a")
                {
                    abuttonClose.Click();
                }
                WaitLoading();
                login();
            }

            //select submission
            string xpath;
            if (String.IsNullOrEmpty(this.submissionId))
            {
                xpath = "//div[contains(@class, 'x-grid-cell-inner')]";
            }
            else
            {
                xpath = "//div[contains(text(),'" + this.submissionId + "') and contains(@class, 'x-grid-cell-inner')]";
            }

            ReadOnlyCollection<IWebElement> submission = chromeDriver.FindElements(By.XPath(xpath));
            if (submission.Count == 0)
            {
                System.Threading.Thread.Sleep(5000);
                submission = chromeDriver.FindElements(By.XPath(xpath));
            }

            if (submission.Count > 0)
            {
                submission.First().FindElement(By.XPath("..")).Click();
                WaitLoading();
                System.Threading.Thread.Sleep(1000);

                ReadOnlyCollection<IWebElement> buttonpd_job_info_action = chromeDriver.FindElements(By.XPath("//span[text()='Job Info' and contains(@id, 'pd_job_info_action')]"));
                if (buttonpd_job_info_action.Count > 0)
                {
                    logWriter.LogWrite("SubmissionID = " + submission.First().Text);
                    IWebElement abuttonpd_job_info_action = buttonpd_job_info_action.First().FindElement(By.XPath("..")).FindElement(By.XPath("..")).FindElement(By.XPath(".."));
                    string tbuttonpd_job_info_action = abuttonpd_job_info_action.TagName;
                    if (tbuttonpd_job_info_action == "a")
                    {
                        abuttonpd_job_info_action.Click();
                    }
                    WaitLoading();
                    System.Threading.Thread.Sleep(5000);

                    // pdSubmissionBudgetJobInfoColumnRadioAccept
                    ReadOnlyCollection<IWebElement> pdSubmissionBudgetJobInfoColumnRadioAccept = chromeDriver.FindElements(By.XPath("//div[contains(@class, 'x-grid-radio-col')]"));
                    if (pdSubmissionBudgetJobInfoColumnRadioAccept.Count > 0)
                    {
                        pdSubmissionBudgetJobInfoColumnRadioAccept.First().FindElement(By.XPath("..")).FindElement(By.XPath("..")).Click();
                        WaitLoading();
                    }

                    //checkbox-inputEl
                    ReadOnlyCollection<IWebElement> checkboxinputEl = chromeDriver.FindElements(By.XPath("//label[contains(@id, 'checkbox-') and contains(@id, '-boxLabelEl')]"));
                    if (checkboxinputEl.Count > 0)
                    {
                        checkboxinputEl.First().Click();
                        WaitLoading();
                    }

                    //buttonSubmit
                    ReadOnlyCollection<IWebElement> buttonSubmit = chromeDriver.FindElements(By.XPath("//span[text()='Submit' and contains(@id, 'btnInnerEl')]"));
                    if (buttonSubmit.Count > 0)
                    {
                        IWebElement abuttonSubmit = buttonSubmit.First().FindElement(By.XPath("..")).FindElement(By.XPath("..")).FindElement(By.XPath(".."));
                        string tagname = abuttonSubmit.TagName;
                        if (tagname == "a")
                        {
                            abuttonSubmit.Click();
                            logWriter.LogWrite("Submit...");
                        }
                        WaitLoading();
                    }

                    try
                    {
                        // button -- Close
                        System.Threading.Thread.Sleep(5000);
                        ReadOnlyCollection<IWebElement> buttonClose1 = chromeDriver.FindElements(By.XPath("//span[text()='Close' and contains(@id, 'btnInnerEl')]"));
                        if (buttonClose1.Count > 0)
                        {
                            IWebElement abuttonClose1 = buttonClose1.Last().FindElement(By.XPath("..")).FindElement(By.XPath("..")).FindElement(By.XPath(".."));
                            string tbuttonClose1 = abuttonClose1.TagName;
                            if (tbuttonClose1 == "a")
                            {
                                abuttonClose1.Click();
                            }
                            WaitLoading();
                        }
                    }
                    catch {}

                    try
                    {
                        // button -- Close
                        System.Threading.Thread.Sleep(5000);
                        ReadOnlyCollection<IWebElement> buttonClose2 = chromeDriver.FindElements(By.XPath("//span[text()='Close' and contains(@id, 'btnInnerEl')]"));
                        if (buttonClose2.Count > 0)
                        {
                            IWebElement abuttonClose2 = buttonClose2.Last().FindElement(By.XPath("..")).FindElement(By.XPath("..")).FindElement(By.XPath(".."));
                            string tbuttonClose2 = abuttonClose2.TagName;
                            if (tbuttonClose2 == "a")
                            {
                                abuttonClose2.Click();
                            }
                            WaitLoading();
                        }
                    }
                    catch {}
                }
                else
                {
                    logWriter.LogWrite("Not show Job Info!");
                }
            }
            else
            {
                logWriter.LogWrite("Not submission!");
            }

            System.Threading.Thread.Sleep(5000);
            logWriter.LogWrite("Done!");
        }

        private void WaitLoading()
        {
            // wait loading
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(30));
            Func<IWebDriver, bool> waitLoading = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                try
                {
                    IWebElement alertE = Web.FindElement(By.Id("abccuongnh"));
                    return false;
                }
                catch
                {
                    return true;
                }
            });

            try
            {
                wait.Until(waitLoading);
            }
            catch { }
        }
    }
}
