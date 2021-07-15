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
		
		  public static List<int> Compress(string file)
        {
            List<int> compressed = new List<int>(); // for data copmressed
            Dictionary<string, int> compress_table = new Dictionary<string, int>();
            for (int i = 0; i < 256; i++)
            {
                compress_table.Add(((char)i).ToString(), i);
            }
            string pervious = ""; //p or w
            string next_char = ""; //c

            pervious += file[0];

            for (int i = 0; i < file.Length; i++)
            {
                if (i != (file.Length) - 1)
                {
                    next_char += file[i + 1];
                }
                if (compress_table.ContainsKey(pervious + next_char))
                {
                    pervious = pervious + next_char;
                }
                else
                {
                    compressed.Add(compress_table[pervious]);
                    compress_table.Add(pervious + next_char, compress_table.Count);
                    pervious = next_char;
                }
                next_char = "";
            }
            compressed.Add(compress_table[pervious]);
            return compressed;
        }
	}
}