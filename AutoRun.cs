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
        public string webUrl = "https://chat.zalo.me/";
        public bool working = false;
        public string email;
        public string pass;
        public AutoRun(string profileName, string email, string pass)
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
            options.AddArgument("--user-data-dir=" + profilePath + "/" + profileName);
            options.AddArgument("profile-directory=" + profileName);
            options.AddArgument("disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--start-maximized");
            chromeDriver = new ChromeDriver(options)
            {
                Url = webUrl
            };
            chromeDriver.Navigate();
            WaitLoading();

            login();
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

            /*url = chromeDriver.Url;
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
            }*/
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
            
            working = false;
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
