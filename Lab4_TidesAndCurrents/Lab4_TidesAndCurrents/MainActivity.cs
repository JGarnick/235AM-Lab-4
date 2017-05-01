using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Lab4_TidesAndCurrents
{
    [Activity(Label = "Lab4_TidesAndCurrents", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        List<TideDataObject> tdObjects;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            tdObjects = new List<TideDataObject>();     // Instantiate the List object, note that there are no TideDataObjects yet

            // parse the spanish-english vocabulary file
            const int NUMBER_OF_FIELDS = 5;   
            TextParser parser = new TextParser("    ", NUMBER_OF_FIELDS);     // instantiate our general purpose text file parser object.
            List<string[]> stringArrays;    // The parser generates a List of string arrays. Each array represents one line of the text file.
            stringArrays = parser.ParseText(Assets.Open(@"9435385_annual.txt"));     // Open the file as a stream and parse all the text

            // Sort the List of string arrays
            stringArrays.Sort((x, y) => String.Compare(x[0], y[0],    // provide a comparator method for the array element containing pos		
                StringComparison.Ordinal));      // Sorts on part of speech using the comparator above. The rows need to be in order for the indexer to work.

            // Copy the List of strings into our List of VocabItem objects
            foreach (string[] tdo in stringArrays)
                tdObjects.Add(new TideDataObject(tdo[0], tdo[1], tdo[4], tdo[2], tdo[3]));

            // Instantiate our custom listView adapter
            ListAdapter = new TideDataAdapter(this, tdObjects);

            // This is all you need to do to enable fast scrolling
            ListView.FastScrollEnabled = true;
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            string word = tdObjects[position].Pred;
            Android.Widget.Toast.MakeText(this,
            word, Android.Widget.ToastLength.Short).Show();
                                          
        }
    }
}

