using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01397767_Assignment2_WebApiMethods.Controllers
{
    // <objective>
        //You decide to go for a very long drive on a very straight road. Along this road are five cities. As
        //you travel, you record the distance between each pair of consecutive cities.
        //You would like to calculate a distance table that indicates the distance between any two of the cities
        //you have encountered.
    //</objective>
    public class J3Controller : ApiController
    {
        /// <summary>
        /// This methods returns a multidimension array when we input distance between each city.
        /// The input should be a postive integer and less than 1000, each representing the distances between
        ///consecutive pairs of consecutive cities: specifically, the ith integer represents the distance between
        ///city i and city i + 1
        ///<example>
        ///GET api/J3/ReachedDestination/3/10/15/5 --->
        ///     [[0,3,13,25,30],[3,0,10,22,27],[13,10,0,12,17],[25,22,12,0,5],[30,27,17,5,0]]
        /// GET api/J3/ReachedDestination/13/10/117/5 --->
        ///     [[0,13,23,140,145],[13,0,10,127,132],[23,10,0,117,122],[140,127,117,0,5],[145,132,122,5,0]]
        /// GET api/J3/ReachedDestination/1/-2/7/90 ---> Null(Blank)
        /// GET api/J3/ReachedDestination/1/2/7/1000 ---> Null(Blank)
        ///</example>
        /// </summary>
        /// <param name="city1">Distance of city1</param>
        /// <param name="city2">Distance of city2 from city1</param>
        /// <param name="city3">Distance of city3 from city2</param>
        /// <param name="city4">Distance of city4 from city3.</param>
        /// <returns>
        /// 1.It returns an int multidemension array size 5*5 where each block [] is 
        /// with the ith line (1 ≤ i ≤ 5) containing the distance from city i to
        /// cities 1, 2, ... 5 in order.
        /// 2.If one of the input value doesnot satisfies the input condition then it returns null.
        /// </returns>
        //GET api/J3/ReachedDestination/3/10/12/5 --> Ouput will be an array.
        [HttpGet]
        [Route("api/J3/ReachedDestination/{city1}/{city2}/{city3}/{city4}")]
        public int[,] ReachedDestination(int city1,int city2,int city3,int city4)
        {
            //A array which stores all the distance from the city.
            int[] distance = new int[] { 0,city1, city2, city3, city4 };
            //To store the final answer.
            int[,] result = new int[5,5];
            //Everytime calculates the total distance for that particular city.
            int totaldistance = 0;
            // To check whether the number is postive and less than 100.
            bool checkmark = true;

            //This loops checks whether all the city distance are positive and less than 1000.
            for (int i = 0; i < 5; i++)
            {
                if (distance[i] < 0 || distance[i] >= 1000)
                {
                    //If they are not correct then null will be returned as an output.
                    checkmark = false;
                    result = null;
                    break;
                }
            }

            //once the conditions are satisifed
            if (checkmark)
            { 
                //This loop keeps the count of the row in the 5*5 array.
                for(int i = 0; i < 5; i++)
                {
                    //This loop keeps the count of the column in the 5*5 array.
                    for(int j =0;j< 5; j++)
                    {
                        //This is the main logic for the whole code.
                        //Also we will get a symmetric Matrix as an output.
                      /*
                        i<j
                        i=0,j=2, array = 0,3,10,12,5 -->13
                        start from i+1 and  end till j --->increment
                        i =3 ; j=4 , array = 0,3,10,12,5 --->5
                        start from i+1  and end till j --->i++
                        i=j
                         then 0
                        i>j
                        i=3j=0 , array = 0,3,10,12,5 
                        start from i j-1 --->decrement 
                       */

                        //So if both the values are then value at that position will be zero.
                        if (i == j)
                        {
                            result[i,j] = 0;
                        }

                        //If the value of i less then j, then as mentioned above.
                        else if (i < j)
                        {
                            //We will use this loop to calcalute distance of city j from city i.
                            for(int k = i + 1; k <= j; k++)
                            {
                                totaldistance = totaldistance + distance[k];
                            }
                            result[i,j] = totaldistance;
                            totaldistance = 0;
                        }
                        else
                        {
                            //As this is symetric matrix we can use this assignment.
                            result[i,j] = result[j,i];
                        }
                    }
                }
            }
            //If null then the input is invalid.
            return result;
        }
    }
}
