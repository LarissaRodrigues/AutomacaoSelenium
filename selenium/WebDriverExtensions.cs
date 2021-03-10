using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace selenium
{
    public static class WebDriverExtensions
    {
        public static void AbrirPaginaNavegador(this IWebDriver webDriver, TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(url);
        }

        public static string ObterValor(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            return webElement.Text;
        }

        public static void AtribuirValor(this IWebDriver webDriver, By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.Clear();
            webElement.SendKeys(text);
        }

        public static void Enviar(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.Submit();
        }

        public static void Esperar(this IWebDriver webDriver, By by, TimeSpan timeToWait = default(TimeSpan))
        {
            if (timeToWait == default(TimeSpan))
                timeToWait = TimeSpan.FromSeconds(50);

            SleepTest();
            WebDriverWait wait = new WebDriverWait(webDriver, timeToWait);
            wait.Until(d => d.FindElement(by));
        }

        public static void Clique(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.Click();
        }

        public static void SleepTest(int millisecondsTimeOut = 500)
        {
            Thread.Sleep(millisecondsTimeOut);
        }

        public static void AtribuirSelectByValue(this IWebDriver webDriver, By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            SelectElement select = new SelectElement(webElement);
            select.SelectByValue(text);
        }


        public static void AtribuirSelectByText(this IWebDriver webDriver, By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            SelectElement select = new SelectElement(webElement);
            select.SelectByText(text);
        }

        public static List<string> ObsterValorTabela(this IWebDriver webDriver, By by)
        {
            IWebElement webElementTable = webDriver.FindElement(by);
            List<IWebElement> linhas = webElementTable.FindElements(By.TagName("td")).ToList();

            List<string> tabela = new List<string>();
            foreach (var item in linhas)
            {
                tabela.Add(item.Text);

            }
            return tabela;
        }

    }
}
