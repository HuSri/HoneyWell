using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.SessionState;

namespace HoneyWell.COMM
{
    public class RandomKey
    {
        public static RandomKey Instance()
        {
            return new RandomKey();
        }
        private static char[] constant =   
        {   
        '0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','j','h','i','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
        };
        public string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(10);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(10)]);
            }
            return newRandom.ToString();
        }   

    }
}

