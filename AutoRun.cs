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
        public bool loginStatus = false;
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
            System.Threading.Thread.Sleep(3000);
            string url = chromeDriver.Url;
            if (url.Contains("id.zalo.me/account"))
            {
                // SendKeys email
                ReadOnlyCollection<IWebElement> eEmails = chromeDriver.FindElements(By.Id("input-phone"));
                if (eEmails.Count > 0)
                {
                    eEmails.First().Clear(); ;
                    eEmails.First().SendKeys(email);
                    System.Threading.Thread.Sleep(1000);
                }

                // SendKeys password /Password
                ReadOnlyCollection<IWebElement> ePasswords = chromeDriver.FindElements(By.XPath("//input[@type='password']"));
                if (ePasswords.Count > 0)
                {
                    ePasswords.First().Clear(); ;
                    ePasswords.First().SendKeys(pass);
                    System.Threading.Thread.Sleep(1000);
                }

                // SubmitLogin
                ReadOnlyCollection<IWebElement> SubmitLogin = chromeDriver.FindElements(By.Id("SubmitLogin"));
                if (SubmitLogin.Count > 0)
                {
                    SubmitLogin.First().Click();
                    WaitLoading();
                    System.Threading.Thread.Sleep(2000);
                    ePasswords = chromeDriver.FindElements(By.Id("Password"));
                }


                // SubmitLogin2
                System.Threading.Thread.Sleep(2000);
                ReadOnlyCollection<IWebElement> SubmitLogin2 = chromeDriver.FindElements(By.XPath("//a[contains(@class, 'btn--m') and contains(@class, 'first')]"));
                if (SubmitLogin2.Count > 0)
                {
                    SubmitLogin2.First().Click();
                    WaitLoading();
                    System.Threading.Thread.Sleep(2000);
                }
            }

            url = chromeDriver.Url;
            if (url.Contains("id.zalo.me/account"))
            {
                logWriter.LogWrite("Login fall!");
                MessageBox.Show("Đăng nhập không thành công! hãy đăng nhập zalo trên trình duyệt chrome và thực hiện lại!", "Login...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            logWriter.LogWrite("login...");
            loginStatus = true;
        }

        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Quit();
            }
        }

        public bool RunAuto(string phone, string content)
        {
            bool res = false;
            // SendKeys phone
            ReadOnlyCollection<IWebElement> eSearchInput = chromeDriver.FindElements(By.Id("contact-search-input"));
            if (eSearchInput.Count > 0)
            {
                eSearchInput.First().Clear(); ;
                eSearchInput.First().SendKeys(phone);
                System.Threading.Thread.Sleep(2000);

                //searchResultList
                ReadOnlyCollection<IWebElement> searchResultList = chromeDriver.FindElements(By.Id("searchResultList"));
                IWebElement firtItem = searchResultList.First().FindElement(By.XPath("//div[contains(@class, 'list-friend-conctact') and contains(@class, 'item')]"));
                if (firtItem != null)
                {
                    firtItem.Click();
                    System.Threading.Thread.Sleep(1000);
                    IWebElement chatbox = chromeDriver.FindElement(By.Id("input_line_0"));
                    if (chatbox != null)
                    {
                        // chromeDriver.ExecuteScript("arguments[0].innerText = '" + content + "'", chatbox);
                        chatbox.SendKeys(content);
                        System.Threading.Thread.Sleep(1000);
                        IWebElement sendBtn = chromeDriver.FindElement(By.Id("sendBtn"));
                        if (sendBtn != null)
                        {
                            sendBtn.Click();
                            res = true;
                        }
                    }
                }
                
            }
            return res;
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
