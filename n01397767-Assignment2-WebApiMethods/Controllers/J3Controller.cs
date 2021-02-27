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
            int[] distance = new int[] { 0,city1, city2, city3, city4 };
            int[][] result = new int[5][];
            int totaldistance = 0;
            bool checkmark = true;
            for(int i = 0; i < 5; i++)
            {
                if(distance[i]<0 || distance[i] > 100)
                {
                    checkmark = false;
                    result = null;
                    break;
                }
            }
            if (checkmark)
            { 
                for(int i = 0; i < 5; i++)
                {
                    result[i] = new int[5];

                }
                for(int i = 0; i < 5; i++)
                {
                    for(int j =0;j< 5; j++)
                    {
                 
                        if (i == j)
                        {
                            result[i][j] = 0;
                        }
                        else if (i < j)
                        {
                            for(int k = i + 1; k <= j; k++)
                            {
                                totaldistance = totaldistance + distance[k];
                            }
                            result[i][j] = totaldistance;
                            totaldistance = 0;
                        }
                        else
                        {
                        
                            result[i][j] = result[j][i];
                            //i<j
                            //i=0,j=2, array = 0,3,10,12,5 -->13
                            //                 and  end till j
                            //i = 1,j=3 , array = 0,3,10,12,5 -->22
                            //start from i|+1 and end till j 
                            //i =3 ; j=4 , array = 0,3,10,12,5 --->5
                            //start from i+1  and end till j
                            //i>j
                            //i=3j=0 , array = 0,3,10,12,5 
                            //start from i j-1 --->i--
                            //totaldistance = totaldistance + distance[j];
                            //result[i][j] = totaldistance;
                        }
                    }
              
                }
            }
            return result;
        }
    }
}
