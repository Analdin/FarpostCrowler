using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarpostCrowler
{
    internal class Variables
    {
        public static string idAdv { get; set; }
        public static IWebElement nowPlace { get; set; }
        public static string idInBlack { get; set; }
        public static double OldBid { get; set; }
        public static double CurBid { get; set; }
        public static double limitStart { get; set; }
        public static double limitStop { get; set; }
        public static double fullLimit { get; set; }
        public static string TimeStart { get; set; }
        public static string TimeEnd { get; set; }
        public static string loginField { get; set; }
        public static string passField { get; set; }
        public static int TimeSetFrom { get; set; }
        public static int TimeSetTo { get; set; }
        public static string boxRubrika { get; set; }
    }
}
