using System;
using Android.Widget;
using System.Collections.Generic;
using Android.App;
using Android.Views;

namespace Lab4_TidesAndCurrents
{

    // Cutom list adapter class
    public class TideDataAdapter : BaseAdapter<TideDataObject>, ISectionIndexer
    {
        List<TideDataObject> tdObjects;  
        Activity context;       // The activity we are running in

        public TideDataAdapter(Activity c, List<TideDataObject> tdo) : base()
        {
            tdObjects = tdo;
            context = c;
            BuildSectionIndex();
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override int Count
        {
            get { return tdObjects.Count; }
        }

        public override TideDataObject this[int position]
        {
            get { return tdObjects[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.TwoLineListItem, null);
            }
               
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = tdObjects[position].Date + " " + tdObjects[position].Day;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = tdObjects[position].Level + ": " + tdObjects[position].Time;
            
            return view;
        }

        // -- Code for the ISectionIndexer implementation follows --
        String[] sections;
        Java.Lang.Object[] sectionsObjects;
        Dictionary<string, int> alphaIndex;

        public int GetPositionForSection(int section)
        {
            return alphaIndex[sections[section]];
        }

        public int GetSectionForPosition(int position)
        {
            return 1;
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionsObjects;
        }

        private void BuildSectionIndex()
        {
            alphaIndex = new Dictionary<string, int>();     // Map sequential numbers
            for (var i = 0; i < tdObjects.Count; i++)
            {
                string key = "";
                // Use the month as a key
                var month = tdObjects[i].Date.Split('/')[1];
                if (month == "01")
                    key = "Jan";
                else if (month == "02")
                    key = "Feb";
                else if (month == "03")
                    key = "Mar";
                else if (month == "04")
                    key = "Apr";
                else if (month == "05")
                    key = "May";
                else if (month == "06")
                    key = "Jun";
                else if (month == "07")
                    key = "Jul";
                else if (month == "08")
                    key = "Aug";
                else if (month == "09")
                    key = "Sep";
                else if (month == "10")
                    key = "Oct";
                else if (month == "11")
                    key = "Nov";
                else if (month == "12")
                    key = "Dec";


                if (!alphaIndex.ContainsKey(key))
                {
                    alphaIndex.Add(key, i);
                }
            }

            // Get the count of sections
            sections = new string[alphaIndex.Keys.Count];
            // Copy section names into the sections array
            alphaIndex.Keys.CopyTo(sections, 0);

            // Copy section names into a Java object array
            sectionsObjects = new Java.Lang.Object[sections.Length];
            for (var i = 0; i < sections.Length; i++)
            {
                sectionsObjects[i] = new Java.Lang.String(sections[i]);
            }
        }

    }
}

