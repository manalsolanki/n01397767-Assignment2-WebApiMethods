using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01397767_Assignment2_WebApiMethods.Controllers
{
    public class J3Controller : ApiController
    {
        [HttpGet]
        [Route("api/J3/ReachedDestination/{city1}/{city2}/{city3}/{city4}")]
        public int[][] ReachedDestination(int city1,int city2,int city3,int city4)
        {
            int[] distance = new int[] { city1, city2, city3, city4 };
            int[][] result = new int[5][];
            int totaldistance = 0;
            
            for(int i = 0; i < 4; i++)
            {
                if(distance[i]<0 || distance[i] > 100)
                {
                    return null;
                }
            }
           
            for(int i = 0; i < 5; i++)
            {
                result[i] = new int[5];

            }
            for(int i = 0; i < 4; i++)
            {
                totaldistance = totaldistance + distance[i];
                result[0][i] = totaldistance;
            }
            return result;
        }
    }
}
