using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Text;

namespace PapagoSrt
{
    public class PapagoDriver : IDisposable
    {
        private readonly ChromeDriver _driver;

        public PapagoDriver()
        {
            _driver = CreateChromeDriver();
            NavigateToTranslationPage();
            WaitForPageLoad();
        }

        public string Translate(string content)
        {
            var sourceTextbox = _driver.FindElement(By.Id("txtSource"));
            var targetTextbox = _driver.FindElement(By.Id("txtTarget"));
            var translatedText = new StringBuilder();

            var script = $"var ele = `{content.Replace("`", "\\`")}`;document.getElementById('txtSource').value=ele;";
            ((IJavaScriptExecutor)_driver).ExecuteScript(script);
            sourceTextbox.SendKeys(" ");

            var translated = WaitForTranslationComplete(targetTextbox);
            translatedText.Append(translated);

            return translatedText.ToString();
        }

        private string WaitForTranslationComplete(IWebElement targetTextbox)
        {
            const int checkIntervalMs = 500;
            const int stableWaitMs = 1000;
            const int maxWaitMs = 15000;

            var startTime = DateTime.Now;
            var lastText = "";
            var lastChangeTime = DateTime.Now;

            while ((DateTime.Now - startTime).TotalMilliseconds < maxWaitMs)
            {
                var currentText = targetTextbox.Text;
                
                if (currentText != lastText)
                {
                    lastText = currentText;
                    lastChangeTime = DateTime.Now;
                }
                else if (!string.IsNullOrEmpty(currentText) && (DateTime.Now - lastChangeTime).TotalMilliseconds >= stableWaitMs)
                {
                    return currentText;
                }

                Thread.Sleep(checkIntervalMs);
            }

            return lastText;
        }

        private ChromeDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("incognito");
            options.AddArgument("window-size=1920x1080");
            options.AddArgument("disable-gpu");
            options.AddArgument("start-maximized");

            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            var driver = new ChromeDriver(service, options);
            driver.Manage().Window.Minimize();
            driver.Manage().Window.Position = new Point(-2000, 0);

            return driver;
        }

        private void NavigateToTranslationPage()
        {
            _driver.Navigate().GoToUrl("https://papago.naver.com/?sk=auto&tk=ko");
        }

        private void WaitForPageLoad()
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnTranslate")));
            }
            catch
            {
                throw new Exception("Webpage Timed out!");
            }
        }

        public void Dispose()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
