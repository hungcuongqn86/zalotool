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
        public AutoRun(string profileName)
        {
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
            try
            {
                chromeDriver = new ChromeDriver(options)
                {
                    Url = webUrl
                };
                chromeDriver.Navigate();
                WaitLoading();
                login();
            }
            catch (Exception error)
            {
                // MessageBox.Show(error.Message.ToString());
            }
        }

        private void login()
        {
            System.Threading.Thread.Sleep(3000);
            /*
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
                }
            }
            */

            string url = chromeDriver.Url;
            if (url.Contains("id.zalo.me/account"))
            {
                logWriter.LogWrite("Login fall!");
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

        private void clearWebField(IWebElement element)
        {
            while (!element.GetAttribute("value").Equals(""))
            {
                element.SendKeys(Keys.Backspace);
            }
        }

        public bool RunAuto(string phone, string content, string photo, int delay2Mess1Acc)
        {
            bool res = false;
            // SendKeys phone
            ReadOnlyCollection<IWebElement> eSearchInput = chromeDriver.FindElements(By.Id("contact-search-input"));
            if (eSearchInput.Count > 0)
            {
                // fa-textbox-icon-clear
                ReadOnlyCollection<IWebElement> eClearBtn = chromeDriver.FindElements(By.XPath("//div[contains(@class, 'global-search-no-result')]"));
                if (eClearBtn.Count > 0)
                {
                    eClearBtn.First().Click();
                    System.Threading.Thread.Sleep(1000);
                }

                clearWebField(eSearchInput.First());
                eSearchInput.First().SendKeys(phone);
                System.Threading.Thread.Sleep(2000);
                try
                {
                    ReadOnlyCollection<IWebElement> searchResultList = chromeDriver.FindElements(By.Id("searchResultList"));
                    IWebElement firtItem = searchResultList.First().FindElement(By.XPath("//div[contains(@class, 'list-friend-conctact') and contains(@class, 'item')]"));
                    if (firtItem != null)
                    {
                        firtItem.Click();
                        System.Threading.Thread.Sleep(1000);
                        IWebElement chatbox = chromeDriver.FindElement(By.Id("input_line_0"));
                        if (chatbox != null)
                        {
                            chatbox.Click();
                            chatbox.SendKeys(content);
                            System.Threading.Thread.Sleep(1000);
                            IWebElement sendBtn = chromeDriver.FindElement(By.Id("sendBtn"));
                            if (sendBtn != null)
                            {
                                sendBtn.Click();
                            }

                            // photo
                            // send-photo-btn
                            if (photo.Trim().Length > 0)
                            {
                                // delay2Mess1Acc
                                if (delay2Mess1Acc > 0)
                                {
                                    System.Threading.Thread.Sleep(1000 * delay2Mess1Acc);
                                }

                                IWebElement sendPhotoInput = chromeDriver.FindElement(By.Id("file"));
                                if (sendPhotoInput != null)
                                {
                                    Unhide(chromeDriver, sendPhotoInput);
                                    // sendPhotoInput.Click();
                                    sendPhotoInput.SendKeys(photo);
                                    System.Threading.Thread.Sleep(5000);
                                }
                            }

                            // res
                            res = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    res = false;
                    // MessageBox.Show(error.Message.ToString());
                }
            }
            return res;
        }

        private void Unhide(IWebDriver driver, IWebElement element)
        {
            try
            {
                String script = "arguments[0].style.opacity=1;"
                  + "arguments[0].style['transform']='translate(0px, 0px) scale(1)';"
                  + "arguments[0].style['MozTransform']='translate(0px, 0px) scale(1)';"
                  + "arguments[0].style['WebkitTransform']='translate(0px, 0px) scale(1)';"
                  + "arguments[0].style['msTransform']='translate(0px, 0px) scale(1)';"
                  + "arguments[0].style['OTransform']='translate(0px, 0px) scale(1)';"
                  + "return true;";
                ((IJavaScriptExecutor)driver).ExecuteScript(script, element);
            }
            catch (Exception error)
            {
                // MessageBox.Show(error.Message.ToString());
            }
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
