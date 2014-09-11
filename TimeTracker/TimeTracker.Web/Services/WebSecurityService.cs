using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.Web.Services
{
    public class WebSecurityService
    {
        private static string sigma = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static Random random = new Random();
        public static string GetSalt()
        {
            return string.Concat(Enumerable.Range(0, 64).Select(num => sigma[random.Next(sigma.Length)]));
        }
    }
}