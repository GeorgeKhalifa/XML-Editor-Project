using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XML_Editor
{
    public partial class Form1 : Form
    {
		public static string xmlfile;
        public static string jsonfile;
        public static string minified;
        public static bool check;
        public static string beging_tags = "";
        public static bool begintag = false;
        public static List<int> compressed = new List<int>(); // for data copmressed
        // list to add strings that represents all errors we have..
        public static List<string> Error_List = new List<string>();

        // list for adding tags once they arrived..
        public static List<item> items = new List<item>();

        public static string JSON_output = "";

        public static bool solved = false;

        public static bool minifyflag = false;

        public static bool consistancy = false;
		 public static string Decompress(List<int> compressed)
        {
            Dictionary<int, string> decompress_table = new Dictionary<int, string>();
            for (int i = 0; i < 256; i++)
            {
                decompress_table.Add(i, ((char)i).ToString());
            }
            string s = decompress_table[compressed[0]]; // s for translation for the first input code
            compressed.RemoveAt(0); // remove the transelated one 
            StringBuilder decompressed = new StringBuilder(s); // to modify or append in the same string to improve the performance 
            foreach (int i in compressed)
            {
                string entry = "";
                if (decompress_table.ContainsKey(i))
                {
                    entry = decompress_table[i];
                }
                else if (i == decompress_table.Count)
                {
                    entry = s + s[0];
                }
                decompressed.Append(entry);
                decompress_table.Add(decompress_table.Count, s + entry[0]);//new sequence added to the table (dictionary)
                s = entry;
            }
            return decompressed.ToString();
        }
	}
}