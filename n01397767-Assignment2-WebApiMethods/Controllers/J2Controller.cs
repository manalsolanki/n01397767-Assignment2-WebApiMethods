using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01397767_Assignment2_WebApiMethods.Controllers
{
    //<objective>
    // You supervise a small parking lot which has N parking spaces.
    //Yesterday, you recorded which parking spaces were occupied by cars and which were empty.
    //Today, you recorded the same information.
    //How many of the parking spaces were occupied both yesterday and today?
    //</objective>
    public class J2Controller : ApiController
    {
        /// <summary>
        /// This method returns a string thats states how many parking spaces were occupied both the days
        /// when given number of parking places N ,(1<= N <=100)(int) and two strings with length N. 
        /// The first string is information about yesterday's parking
        /// and the second string is for todays parking places which are occupied or free.
        /// Each of the string should only have "E" or "C".
        /// Here "E" = Parking space are empty and "C" = Parking space are occupied,
        ///<example>
        ///GET api/J2/OccupyParking/4/CCEC/CECE ---> Number of occupied places today and tomorrow are 1.
        ///GET api/J2/OccupyParking/5/CCEEC/ECCEE ---> Number of occupied places today and tomorrow are 1.
        ///GET api/J2/OccupyParking/9/CCCEEECCC/CECECECEC ---> Number of occupied places today and tomorrow are 4.
        ///</example>
        /// </summary>
        /// <param name="numOfParking">Number of Parking Spaces.It should be range 1 to 100.</param>
        /// <param name="yestParking">Parking Information of Yesterday.Character should be C or E.</param>
        /// <param name="todayParking">Parking Information of Today.Character should be C or E.</param>
        /// <returns>Returns a string specifying how many parking spaces were occupied both today and yesterday.</returns>
        [HttpGet]
        [Route("api/J2/OccupyParking/{numOfParking}/{yestParking}/{todayParking}")]
        public string OccupyParking(int numOfParking, string yestParking, string todayParking)
        {
            string answer = " "; // Stores final return string.
            int occupied = 0; //stores how many parking spaces are occupied both the days.

            // Converting both the string in the uppercase
            string yestTemp = yestParking.ToUpper();
            string todayTemp = todayParking.ToUpper();

            // As we need to browser each character of srting converting them to character array.
            char[] yestchars = yestTemp.ToCharArray();
            char[] todaychars = todayTemp.ToCharArray();

            //Check whether the number of Parking space are in range 1-100.
            if (numOfParking < 1 || numOfParking > 100)
            {
                answer = "Please enter the number of parking spaces in the range that is 1-100.";
            }
            //The number is in the range.
            else
            {
                //Checks whether the length of string is same as the number of Parking spaces..
                if ((yestParking.Length == numOfParking) && (todayParking.Length == numOfParking))
                {
                    //They are same, So a loop for traversing each value in the arrays.
                    for (int i = 0; i < numOfParking; i++)
                    {
                        //Checks whether the characters are "C" or "E"
                        if ((yestchars[i] == 'C' || yestchars[i] == 'E') && (todaychars[i] == 'C' || todaychars[i] == 'E'))
                        {
                            //Checks that character at i position are same or not and if same then it is "C" or not.
                            if ((yestchars[i] == todaychars[i]) && (yestchars[i] == 'C'))
                            {
                                // Increments the occupied spaces. 
                                occupied = occupied + 1;
                            }
                        }
                        // Charaters in string are not "C" or "E"
                        else
                        {
                            // The loop will be terminated.
                            answer = "Please Enter 'C' or 'E' in the input string.";
                            break;
                        }
                    }
                }
                // If the length of string is not same.
                else
                {
                    answer = "One of the string doesnt have " + numOfParking + " characters.";
                }
            }
            // If there are any common parking spaces.
            if (occupied > 0)
            {
                answer = "Number of occupied places today and tomorrow are " + occupied;
            }
            return answer;
        }
    }
}
