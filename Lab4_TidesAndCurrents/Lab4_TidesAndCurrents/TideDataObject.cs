using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Lab4_TidesAndCurrents
{
    public class TideDataObject
    {
        public string Date { get; set; }
        public string Day { get; set; }
        public string Level { get; set; }
        public string Time { get; set; }
        public string Pred { get; set; }


        public TideDataObject(string date, string day, string level, string time, string pred)
        {
            Date = date;
            Day = day;
            if (level == "L")
                Level = "Low";
            else
                Level = "High";
            Time = time;
            Pred = pred + " cm";
        }
    }
}