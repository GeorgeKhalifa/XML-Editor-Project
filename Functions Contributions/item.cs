using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor
{
    public class item
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public string name { get; set; }
        public bool closed { get; set; }
        public bool open { get; set; }

        public string body { get; set; }
        public string attributes { get; set; }
        public int closed_space { get; set; }

        //XML TO JSON
        public List<string> bodyList { get; set; }
        public List<string> attributesList = new List<string>();
        public List<item> childrenList { get; set; }
        item(string name = "", int id = -1, bool closed = false, bool open = false, int parent_id = -1, string body = "", string attributes = "", int closed_space = 0)
        {
            this.id = id;
            this.name = name;
            this.open = open;
            this.closed = closed;
            this.parent_id = parent_id;
            this.body = body;
            this.attributes = attributes;
            this.closed_space = closed_space;
        }

        public item()
        {
            this.id = 0;
            this.name = "";
            this.open = false;
            this.closed = false;
            this.parent_id = 0;
            this.body = "";

            //XML TO JSON
            this.childrenList = new List<item>();
        }
    }
}
                #region when we hit a closed tag

                #endregion

                #region when we hit the body of the tag
                else
                {
                    tag_body = "";
                    while (xml_str[i] != '<')
                    {
                        tag_body += xml_str[i];
                        i++;
                    }
                    items[checker.Peek().id].body = tag_body;
                    if (items[checker.Peek().id].body != "")
                    {
                        final_result += ($"{checker.Peek().body}");
                       // Console.WriteLine($"{String.Concat(Enumerable.Repeat(" ", items[checker.Peek().id].closed_space + 1))}{checker.Peek().body}");// modified at 5:52 PM instead of items[checker.Peek().id].closed_Space+1 it was level_counter
                    }
                    if (xml_str[i] == '<' && xml_str[i + 1] == '/')
                    {
                        int j = i + 2;
                        string compared = "";
                        while (xml_str[j] != '>')
                        {
                            compared += xml_str[j];
                            j++;
                        }
                        var the_top = checker.Peek();
                        if (the_top.name == compared)
                        {
                            int taps_num = 0;
                            checker.Pop();
                            if (the_top.closed_space == items[the_top.id].id - 1) { taps_num = items[the_top.id - 1].closed_space; }
                            else if (the_top.closed_space == the_top.id) { taps_num = the_top.id; }
                            final_result += ($"</{the_top.name}>");
                            //Console.WriteLine($"{String.Concat(Enumerable.Repeat(" ", taps_num))}</{the_top.name}>");
                            //Console.WriteLine($"</{the_top.name}>\n");
                            while (xml_str[i] != '>')
                            {
                                i++;
                            }
                            i++;
                        }
                        else
                        {      // <b1><b2><b3></b2></b1>
                            bool its_for_one_of_parents = false;
                            //bool checking_for_parents_id_Done = false;
                            int parent_checker_counter = checker.Peek().parent_id;
                            while (parent_checker_counter > -1)
                            {
                                if (items[parent_checker_counter].name == compared)
                                {
                                    its_for_one_of_parents = true;
                                    int current_top_index = checker.Peek().id;
                                    while (current_top_index != parent_checker_counter)
                                    {
                                        int taps_num = 0;
                                        Error_List.Add($"Error >> The Closed Tag of {items[current_top_index].name} is missed and the closed tag of its parent is here!!");
                                        var removed = checker.Pop();
                                        if (removed.closed_space == removed.id - 1) { taps_num = items[removed.id - 1].closed_space; }
                                        else if (removed.closed_space == removed.id) { taps_num = removed.id; }
                                        final_result += ($"</{removed.name}>");
                                        //Console.WriteLine($"{String.Concat(Enumerable.Repeat(" ", taps_num))}</{removed.name}>");

                                        //Console.WriteLine($"</{removed.name}>");
                                        current_top_index = items[current_top_index].parent_id;
                                    }

                                    if (current_top_index == parent_checker_counter)
                                    {
                                        int taps_num = 0;
                                        var popped = checker.Pop();
                                        if (popped.closed_space == popped.id - 1) { taps_num = items[popped.id - 1].closed_space; }
                                        else if (popped.closed_space == popped.id) { taps_num = popped.id; }
                                        final_result += ($"</{popped.name}>");
                                        //Console.WriteLine($"{String.Concat(Enumerable.Repeat(" ", taps_num))}</{popped.name}>");
                                        //Console.WriteLine($"</{popped.name}>");
                                        while (xml_str[i] != '>')
                                        {
                                            i++;
                                        }
                                        i++;
                                        parent_checker_counter = -1;
                                    }
                                }
                                else
                                {
                                    parent_checker_counter = items[parent_checker_counter].parent_id;
                                }
                            }
                            if (its_for_one_of_parents == false)
                            {
                                int taps_num = 0;
                                // if all parents not equale this closed tag, so the closed tag isn't missed, its just a wrong tag name
                                Error_List.Add($"Error!, Wrong Tag Name for the closed tag of this tag : {the_top.name}");
                                checker.Pop();
                                if (the_top.closed_space == the_top.id - 1) { taps_num = items[the_top.id - 1].closed_space; }
                                else if (the_top.closed_space == the_top.id) { taps_num = the_top.id; }
                                final_result += ($"</{the_top.name}>");
                                //Console.WriteLine($"{String.Concat(Enumerable.Repeat(" ", taps_num))}</{the_top.name}>");
                                //Console.WriteLine($"</{the_top.name}>");
                                while (xml_str[i] != '>')
                                {
                                    i++;
                                }
                                i++;
                            }
                           
                           
                        }

                    }
                    else if (xml_str[i] == '<' && xml_str[i + 1] != '/')
                    {
                        int taps_num = 0;
                        Error_List.Add($"Error!, Closed Tag is Missed for this tag : {checker.Peek().name}");
                        var popped = checker.Pop();
                        if (popped.closed_space == items[popped.id].id - 1) { taps_num = items[popped.id - 1].closed_space; }
                        else if (popped.closed_space == popped.id) { taps_num = popped.id; }
                        final_result += ($"</{popped.name}>");
                        //Console.WriteLine($"{String.Concat(Enumerable.Repeat(" ", taps_num))}</{popped.name}>");
                        //Console.WriteLine($"{String.Concat(Enumerable.Repeat(" ", level_counter-removed_tabs))}</{popped.name}>>");
                        //Console.WriteLine($"</{popped.name}>\n");

                    }
                }
                #endregion

            }

            while (checker.Count > 0)
            {
                final_result += ($"</{checker.Peek().name}>");
                //Console.WriteLine($"</{checker.Peek().name}>");
                Error_List.Add($"Error >> Closed Tag of {checker.Peek().name} is missed!!");
                checker.Pop();
            }
            /*foreach (var error in Error_List)
            {
                Console.WriteLine(error);
            }*/
            return final_result;
        }