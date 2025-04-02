using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber) {
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
				var sum = ConvetToDecimal(firstNumber) + ConvetToDecimal(secondNumber);
				return Ok(sum.ToString());
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("sub/{firstNumber}/{secondNumber}")]
		public IActionResult Sub(string firstNumber, string secondNumber) {
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
				var minus = ConvetToDecimal(firstNumber) - ConvetToDecimal(secondNumber);
				return Ok(minus.ToString());
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("mult/{firstNumber}/{secondNumber}")]
		public IActionResult Mult(string firstNumber, string secondNumber) {
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
				var mult = ConvetToDecimal(firstNumber) * ConvetToDecimal(secondNumber);
				return Ok(mult.ToString());
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("div/{firstNumber}/{secondNumber}")]
		public IActionResult Div(string firstNumber, string secondNumber) {
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
				var div = ConvetToDecimal(firstNumber) / ConvetToDecimal(secondNumber);
				return Ok(div.ToString());
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("mean/{firstNumber}/{secondNumber}")]
		public IActionResult Mean(string firstNumber, string secondNumber) {
			if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
				var mean = (ConvetToDecimal(firstNumber) + ConvetToDecimal(secondNumber))/2;
				return Ok(mean.ToString());
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("squa/{firstNumber}")]
		public IActionResult Squa(string firstNumber, string secondNumber) {
			if (IsNumeric(firstNumber)) {
				var squa = Math.Sqrt((double)ConvetToDecimal(firstNumber));
				return Ok(squa.ToString());
			}
			return BadRequest("Invalid Input");
		}

		private bool IsNumeric(string strNumber) {
			double number;
			bool isNumber =  double.TryParse(
				strNumber,
				System.Globalization.NumberStyles.Any,
				System.Globalization.NumberFormatInfo.InvariantInfo,
				out number
			);
			return isNumber;
		}

		private decimal ConvetToDecimal(string strNumber)
		{
			decimal decimalValue;
			if (decimal.TryParse(strNumber, out decimalValue))
			{
				return decimalValue;
			}
			return 0;
		}
	}
}
