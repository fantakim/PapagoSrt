﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Keys = OpenQA.Selenium.Keys;

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

        public static string Translate(ChromeDriver driver)
        {
            driver.Navigate().GoToUrl("https://main--venerable-zabaione-67b63d.netlify.app");

            driver.WaitForFindElement(By.LinkText("파파고 번역 사이트")).Click();

            var frame = driver.WaitForFindElement(By.Id("translatedFrame"));
            driver.SwitchTo().Frame(frame);

            var textarea = driver.WaitForFindElement(By.Id("mat-input-0"));
            textarea.Clear();
            textarea.SendKeys(Keys.Control + "v");

            var saveButton = driver.WaitForFindElement(By.XPath("/html/body/app-root/div/section[1]/button"));
            saveButton.Click();

            var elements = driver.FindElements(By.XPath("//*[@papago-id]"));
            var lastElement = elements.LastOrDefault();
            if (lastElement == null)
                return string.Empty;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(d => lastElement.GetAttribute("papago-translate") == "translated");

            var result = driver.WaitForFindElement(By.ClassName("result"));
            return result.Text;
        }
    }

    public static class WebDriverExtensions
    {
        public static IWebElement WaitForFindElement(this IWebDriver driver, By by, int timeoutInSeconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            if (wait.Until(x => x.FindElement(by).Displayed))
            {
                return driver.FindElement(by);
            }

            return null;
        }
    }
}
