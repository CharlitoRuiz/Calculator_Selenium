using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.PageObject
{
    public class BasePage
    {
        public IWebDriver _webDriver;
        public string baseURL;

        public BasePage(string url, IWebDriver driver) {
            this._webDriver = driver;
            this.baseURL = url;
        }
    }
}
