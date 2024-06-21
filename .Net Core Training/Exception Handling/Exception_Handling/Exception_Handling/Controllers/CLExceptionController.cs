using Microsoft.AspNetCore.Mvc;

namespace Exception_Handling.Controllers
{
    /// <summary>
    /// Controller manages different types of exception.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLExceptionController : ControllerBase
    {
        /// <summary>
        /// Generates a NullReferenceException by accessing a property of a null object.
        /// </summary>
        [HttpGet("nullreference" , Order = 5)]
        public IActionResult GenerateNullReferenceException()
        {
            string nullString = null;

            // This line will throw a NullReferenceException
            return Ok(nullString.Length);
        }

        [HttpGet("nullreference", Order = 6)]
        public IActionResult GenerateNullReferenceExceptio()
        {
            string nullString = null;

            // This line will throw a NullReferenceException
            return Ok(nullString.Length);
        }

        /// <summary>
        /// Generates an ArgumentNullException by calling a method on a null object.
        /// </summary>
        [HttpGet("argumentnull")]
        public IActionResult GenerateArgumentNullException()
        {
            string argNullString = null;

            //throw null objectException.
            return Ok(argNullString.ToUpper());
            
        }

        /// <summary>
        /// Generates a DivideByZeroException by dividing a number by zero.
        /// </summary>
        [HttpGet("dividebyzero")]
        public IActionResult GenerateDivideByZeroException()
        {
            int zero = 0;

            //throw divideByZeroException
            return Ok(10 / zero);
            
        }

        /// <summary>
        /// Generates an IndexOutOfRangeException by accessing an index that is out of range in an array.
        /// </summary>
        [HttpGet("indexoutofrange")]
        public IActionResult GenerateIndexOutOfRangeException()
        {
            int[] numbers = { 1, 2, 3 };

            //IndexOutOfBound Exception
            return Ok(numbers[5]);
          
        }

        /// <summary>
        /// Generates a FormatException by attempting to convert a non-numeric string to double.
        /// </summary>
        [HttpGet]
        [Route("FormatException")]
        public IActionResult FormatException()
        {
            var result = "String";
            return Ok(Convert.ToDouble(result));
        }

        /// <summary>
        /// Throws a NotImplementedException.
        /// </summary>
        [HttpGet]
        [Route("NotImplemented")]
        public IActionResult NotImplemented()
        {
            throw new NotImplementedException();
        }
    }
}
