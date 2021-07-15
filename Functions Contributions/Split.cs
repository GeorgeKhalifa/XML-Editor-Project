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


        public static void split()
        {
            //splitting attributes into attributes list to use it in converting to JSON file
            string temp = "";
            foreach (item it in items)
            {
                if (it.attributes.Length != 0)
                {
                    for (int str_index = 0; str_index < it.attributes.Length; str_index++)
                    {
                        if ((it.attributes[str_index] == ' ' && str_index == 0) || (it.attributes[str_index] == ' ' && it.attributes[str_index - 1] == '\"'))
                            continue;
                        else
                        {
                            if (it.attributes[str_index] != '=' && it.attributes[str_index] != '\"')
                            {
                                if ((it.attributes[str_index - 1] == ' ' && str_index == 1) || (it.attributes[str_index - 1] == ' ' && it.attributes[str_index - 2] == '\"'))
                                {
                                    temp += '-';
                                    temp += it.attributes[str_index];
                                    continue;
                                }
                                temp += it.attributes[str_index];
                            }
                            if (it.attributes[str_index] == '=')
                            {
                                it.attributesList.Add(temp);
                                temp = "";
                                continue;
                            }
                            if (it.attributes[str_index] == '\"' && it.attributes[str_index - 1] == '=')
                            {
                                continue;
                            }
                            if (it.attributes[str_index] == '\"' && it.attributes[str_index - 1] != '=')
                            {
                                it.attributesList.Add(temp);
                                temp = "";
                                continue;
                            }
                        }
                    }
                }
            }
        }

    }

}