using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Text;

namespace PapagoSrt
{
    public class Papago
    {
        public static ChromeDriver CreateChromeDriver()
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

        public static string Translate(ChromeDriver driver, IList<string> contents)
        {
            driver.Navigate().GoToUrl($"https://papago.naver.com/?sk=auto&tk=ko");

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnTranslate")));
            }
            catch
            {
                throw new Exception("Webpage Timed out!");
            }

            var sourceTextbox = driver.FindElement(By.Id("txtSource"));
            var targetTextbox = driver.FindElement(By.Id("txtTarget"));

            var translatedText = new StringBuilder();
            foreach (var content in contents)
            {
                var script = $"var ele = `{content.Replace("`", "\\`")}`;document.getElementById('txtSource').value=ele;";
                ((IJavaScriptExecutor)driver).ExecuteScript(script);
                sourceTextbox.SendKeys(" ");

                Thread.Sleep(2000);

                var translated = targetTextbox.Text;
                translatedText.Append(translated);
            }
            
            return translatedText.ToString();
        }
    }
}
