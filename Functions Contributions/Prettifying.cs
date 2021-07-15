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

        public static string xml_prettifying(item ite, string tab)
        {
            if (ite.name == "")
                return "";
            string str = "";
            if (ite.attributes == "")
            {
                str += tab + "<" + ite.name + ">";
            }
            if (ite.attributes != "")
            {
                str += tab + "<" + ite.name + ite.attributes + ">";
            }
            if (ite.body == "")
            {
                str += '\n';
            }
            if (ite.body != "")
            {
                str += ite.body;
            }
            if (ite.childrenList.Count != 0)
            {
                tab += '\t';
                for (int i = 0; i < ite.childrenList.Count; i++)
                {
                    str += xml_prettifying(ite.childrenList[i], tab);
                }
                tab = tab.Remove(tab.Length - 1, 1);
            }
            if (ite.body == "")
            {
                str += tab + "</" + ite.name + ">";
            }
            if (ite.body != "")
            {
                str += "</" + ite.name + ">";
            }
            str += '\n';

            return str;
        }

    }

}