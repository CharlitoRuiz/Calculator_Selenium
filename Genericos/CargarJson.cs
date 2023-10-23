using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Calculator.Genericos
{
    public class CargarJson
    {
        public POJO.CalculatorData calculator_data()
        {
            var Json = JsonConvert.DeserializeObject<POJO.CalculatorData>(File.ReadAllText(@"..\..\..\Data\calculator.json"));
            return Json;
        }

        public POJO.ConfigData config_data()
        {
            var Json = JsonConvert.DeserializeObject<POJO.ConfigData>(File.ReadAllText(@"..\..\..\Data\config.json"));
            return Json;
        }
    }
}
