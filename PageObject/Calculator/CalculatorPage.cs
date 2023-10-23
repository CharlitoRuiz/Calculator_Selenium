using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.PageObject.Calculator
{
    public class CalculatorPage : BasePage
    {
        public CalculatorPage(string url, IWebDriver driver) : base(url, driver){}

        private By txtFirstNumber = By.Id("number1Field");
        private By txtSecondNumber = By.Id("number2Field");
        private By cmbOperation = By.Id("selectOperationDropdown");
        private By btnCalculate = By.Id("calculateButton");
        private By txtAnswer = By.Id("numberAnswerField");

        // set
        public IWebElement set_txtFirstNumber() { return _webDriver.FindElement(this.txtFirstNumber); }
        public IWebElement set_txtSecondNumber() { return _webDriver.FindElement(this.txtSecondNumber); }
        public IWebElement set_cmbOperation() { return _webDriver.FindElement(this.cmbOperation); }
        public IWebElement set_btnCalculate() { return _webDriver.FindElement(this.btnCalculate); }
        public IWebElement set_txtAnswer() { return _webDriver.FindElement(this.txtAnswer); }

        // metodos
        public void enterNumbers(string number1, string number2)
        {
            set_txtFirstNumber().SendKeys(number1);
            set_txtSecondNumber().SendKeys(number2);
        }

        public void chooseOperation(string operation)
        {
            SelectElement cmbOperation = new SelectElement(set_cmbOperation());
            cmbOperation.SelectByText(operation);
        }
        public void clickButtomCalculate()
        {
            set_btnCalculate().Click();
        }
        public String evaluateAnswer()
        {
            String result = set_txtAnswer().GetAttribute("value");
            return result;
        }
    }
}
