using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01397767_Assignment2_WebApiMethods.Controllers
{
    // <objective>
    //      To decide if the number is a telemarketer number or not.
    // </objective>
    public class J1Controller : ApiController
    {
        /// <summary>
        /// This method returns a string(ignore or answer) when recieves an input of 4 digits(int) ranging between 0 to 9.
        /// It will check whether the digits entered are telemarketer number or not.
        /// The digits enetered should be between 0 to 9.
        /// There are some conditions:
        ///     1.The first of these four digit is an 8 or 9.
        ///     2.The last digit is an 8 or 9.
        ///     3.The second and third digit are same.
        /// If all this condition satisfies then the number is a telemarketer number.
        /// So we need to ignore this number otherwise answer the number.
        /// </summary>
        /// <example>
        /// GET api/J1/TeleMarketer/1/4/5/9 --> Answer
        /// GET api/J1/TeleMarketer/9/6/6/8 --> Ignore
        /// GET api/J1/TeleMarketer/8/8/8/8 --> Ignore
        /// </example>
        /// <param name="digit1">The 1st digit out of the four </param>
        /// <param name="digit2">The 2nd digit out of the four</param>
        /// <param name="digit3">The 3rd digit out of the four</param>
        /// <param name="digit4">The 4th digit out of the four</param>
        /// <returns>A string that is "Answer"/"Ignore" based upon the conditions.</returns>

        [HttpGet]
        [Route("api/J1/TeleMarketer/{digit1}/{digit2}/{digit3}/{digit4}")]
        public string TeleMarketer(int digit1, int digit2, int digit3, int digit4)
        {
            //Stores the output string
            string telemarketernumber = "";

            //Stores whether pattern is matched or not.
            bool patternCheck = false;

            // Checks whether the input are in range or not.
            if ((digit1 < 0) || (digit2 < 0) || (digit3 < 0) || (digit4 < 0) || (digit1 > 9) || (digit2 > 9) || (digit3 > 9) || (digit4 > 9))
            {
                telemarketernumber = "Please Enter a valid Input.Range 0-9";
            }
            // The input digits are in range 0-9.
            else
            {

                // It will check whether the 1 and 4 digit are 8 or 9.
                if ((digit1 == 8 || digit1 == 9) && (digit4 == 8 || digit4 == 9))
                {
                    //If they are , then it will check 2 and 3 digit are same
                    if (digit2 == digit3)
                    {
                        //If the are same , then pattern is matched
                        patternCheck = true;
                    }
                    // Here the 2 and 3 digit are not same.
                    else
                    {
                        //So pattern doesnot match.
                        patternCheck = false;
                    }
                }
                // The either or one of the digit is not 8 or 9
                else
                {
                    //So pattern doesnot match.
                    patternCheck = false;
                }

                //If the pattern matches
                if (patternCheck)
                {
                    //Then the number should be ignored
                    telemarketernumber = "Ignore";
                }
                // Pattern doesnot match
                else
                {
                    // Number should be Answered.
                    telemarketernumber = "Answer";
                }
            }
            return telemarketernumber;
        }
    }
}
