using AventStack.ExtentReports;
using Calculator.Genericos;
using Calculator.PageObject.Calculator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Test.Calculator
{
    [TestFixture]
    public class CalculatorTest : BaseTest
    {
        CargarJson json = new CargarJson();

        [Test]
        public void CalculateTwoNumbers()
        {
            CalculatorPage calculator = new CalculatorPage(baseURL, driver );
            POJO.CalculatorData calculator_object = json.calculator_data();
            test = extent.CreateTest("Add two numbers");
            
            // variables
            String number1 = calculator_object.number1;
            String number2 = calculator_object.number2;
            String operation = calculator_object.operation;

            try
            {
                calculator.enterNumbers(number1, number2);
                test.Log(Status.Pass, "Enter number 1: " + number1);
                test.Log(Status.Pass, "Enter number 2: " + number2);
                calculator.chooseOperation(operation);
                test.Log(Status.Pass, "Choose operation: " + operation);
                calculator.clickButtomCalculate();
                String result = calculator.evaluateAnswer();
                String format_result = result.Replace(".", ",");

                // validate result
                switch (operation)
                {
                    case "Add": 
                        Assert.IsTrue((decimal.Parse(number1) + decimal.Parse(number2)) == (decimal.Parse(format_result)));
                        break;
                    case "Subtract":
                        Assert.IsTrue((decimal.Parse(number1) - decimal.Parse(number2)) == (decimal.Parse(format_result)));
                        break;
                    case "Multiply":
                        Assert.IsTrue((decimal.Parse(number1) * decimal.Parse(number2)) == (decimal.Parse(format_result)));
                        break;
                    case "Divide":
                        Assert.IsTrue((decimal.Parse(number1) / decimal.Parse(number2)) == (decimal.Parse(format_result)));
                        break;
                    default: Assert.IsTrue((number1 + number2).Equals(result));
                        break;
                }
                
                test.Log(Status.Pass, "Validation successfull: " + result);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
