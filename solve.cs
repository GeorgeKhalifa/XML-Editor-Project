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
        public static string solve(string xml_str)
        {
            /////////////////////////////////////////////////////////////////
            bool strange_tag = false;
            string final_result = "";
            // stack to check consistency..
            Stack<item> checker = new Stack<item>();
            // counter to loop through whole file (file as a string)..
            int i = 0;
            // variable to specify the id for each new inserted tag..
            int level_counter = 0;
            // to hold the open tag name..
            string tag_name = "";
            // to hold the closed tag name..
            string closed_tag_name = "";
            string tag_attributes = "";//*******Modified
            string tag_body = "";//*******Modified

            int removed_tabs = 0;
            bool without_attributes = false;
            //string xml_str;
            //xml_str = File.ReadAllText(@"F:\Downloads\data_sample.xml");


            while (i < xml_str.Length)
            {
                tag_name = "";
                closed_tag_name = "";
                tag_attributes = "";

                var Newitem = new item();
                strange_tag = false;
                #region when we hit an open tag
                // if its an open bracket for open tag..
                if (xml_str[i] == '<' && xml_str[i + 1] != '/')
                {
                    // now xml_str[i] = first char of this open tag name..
                    i++;
                    // while we don't hit the closed bracket of this open tag.. keep building the tag name..
                    while (xml_str[i] != ' ' && xml_str[i] != '>')//*******Modified
                    {
                        tag_name += xml_str[i];
                        i++;
                    }

                    if (xml_str[i] == '>') { without_attributes = true; i++; }
                    else { without_attributes = false; }
                    // if we reached here, so the xml_str[i] is equale '>'
                    ///////i++; 
                    while (xml_str[i] != '>' && without_attributes == false)//*******Modified
                    {//*******Modified
                        tag_attributes += xml_str[i];//*******Modified
                        i++;//*******Modified
                    }//*******Modified
                    if (xml_str[i] == '>')
                    {
                        if (xml_str[i - 1] == '/')
                        {
                            //Console.WriteLine($"<{tag_name}{tag_attributes}>");
                            final_result += $"<{tag_name}{tag_attributes}>";
                            strange_tag = true;
                        }
                        i++;
                    }
                    Newitem.name = tag_name;
                    Newitem.open = true;
                    Newitem.id = level_counter;
                    Newitem.closed = false;
                    Newitem.attributes = tag_attributes;//*******Modified
                    // if stack is empty, so this is the first item, so its parent = its id..
                    if (checker.Count == 0)
                    {
                        Newitem.parent_id = -1;
                    }
                    else
                    {
                        Newitem.parent_id = checker.Peek().id;
                    }
                    // push it into stack
                    if (strange_tag == false)
                    {
                        checker.Push(Newitem);
                    }
                    // add it into the list
                    items.Add(Newitem);
                    // print it
                    if (level_counter > 0 && items[level_counter - 1].parent_id == checker.Peek().parent_id)
                    {
                        //Console.WriteLine($"{String.Concat(Enumerable.Repeat(" ", items[level_counter - 1].closed_space))}<{checker.Peek().name}{checker.Peek().attributes}>");//*** modified at 5:52PM leve_counter-1 instead of closed space of items[level_counter-1
                        final_result += ($"<{checker.Peek().name}{checker.Peek().attributes}>");
                        items[level_counter].closed_space = level_counter - 1;
                    }
                    else
                    {
                        //Console.WriteLine($"{String.Concat(Enumerable.Repeat(" ", level_counter))}<{checker.Peek().name}{checker.Peek().attributes}>");
                        final_result += ($"<{checker.Peek().name}{checker.Peek().attributes}>");
                        items[level_counter].closed_space = level_counter;
                    }
                    //XML TO JSON
                    if (Newitem.parent_id > -1)
                    {
                        items[Newitem.parent_id].childrenList.Add(Newitem);
                    }

                    level_counter++;
                }
                #endregion