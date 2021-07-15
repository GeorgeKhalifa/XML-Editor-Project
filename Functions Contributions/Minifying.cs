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


        //remove spaces, new lines and carriage return between differnet tags
        public static string minify(string filetext)
        {
            filetext = filetext.Replace("\n", String.Empty);
            filetext = filetext.Replace("\r", String.Empty);
            filetext = filetext.Replace("\t", String.Empty);

            int i = 0; 
            int count = 0;
            int start = 0;
            while (i < (filetext.Length) - 1)
            {
                if (filetext[i] == '<' && filetext[i + 1] == '!')
                {
                    start = i;
                    while (filetext[i] != '>') { count++; i++; }
                    //i++;
                    filetext = filetext.Remove(start, count + 1);
                    count = 0;
                    i = start - 1;
                }
                i++;
            }


            i = 0;
            int j = 0;
            count = 0;
            // bool flag = false;
            while (i < filetext.Length)
            {
                //rightfile += filetext[i];
                if (filetext[i] == '>')
                {
                    //i++;
                    if (i < (filetext.Length) - 1)
                    {
                        if (filetext[i + 1] == ' ')
                        {
                            j = i + 1;
                            i++;
                            while (filetext[i] == ' ')
                            {
                                count++;
                                i++;
                                //j = i; ------> Here
                                if (filetext[i] == '<')
                                {
                                    filetext = filetext.Remove(j, count);
                                    count = 0;
                                    //rightfile += filetext[i];
                                    //flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                i++;
            }
            return filetext;
        }

    }
}