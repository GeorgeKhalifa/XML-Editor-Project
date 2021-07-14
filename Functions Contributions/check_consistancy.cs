        //#region check consistency function that returns true of false
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor
{
        public static bool Check_Consistency(string tags)
        {
            /*         <B1>B</B1><frame f='2'/>       */
            string tag_name = "";
            string closed_tag_name = "";
            string tag_attributes = "";
            Stack<string> checker = new Stack<string>();
            int i = 0;
            //string xml_str = "";
            bool without_attributes = false;
            bool we_hit_frame = false;
            while (i < tags.Length)
            {
                tag_name = "";
                closed_tag_name = "";
                tag_attributes = "";
                // if its an open bracket for open tag..
                if (tags[i] == '<' && tags[i + 1] != '/')
                {
                    i++;
                    while (tags[i] != ' ' && tags[i] != '>' && tags[i] != '/')
                    {
                        tag_name += tags[i];
                        i++;
                    }
                    if (tags[i] == '/' && tags[i + 1] == '>')
                    {
                        // remember to print it..
                        i += 2;
                        we_hit_frame = true;
                    }
                    else
                    {
                        if (tags[i] == '>') { without_attributes = true; i++; we_hit_frame = false; }
                        else { without_attributes = false; we_hit_frame = false; }
                        while (tags[i] != '>' && without_attributes == false)//*******Modified
                        {//*******Modified
                            tag_attributes += tags[i];//*******Modified
                            i++;//*******Modified
                            if (tags[i] == '/' && tags[i + 1] == '>')
                            {
                                // remember to print it..
                                i++;
                                we_hit_frame = true;

                            }

                        }//*******Modified
                        if (tags[i] == '>') { i++; }
                        if (we_hit_frame == false)
                        {
                            checker.Push(tag_name);
                        }
                    }
                }
                // if its not an open tag
                else
                {
                    // if we hit the body, we keep increasing the counter i untill we reach the open bracket of the closed tag
                    while (tags[i] != '<')
                    {
                        i++;
                    }
                    // if we hit the open bracket of the closed tag..
                    closed_tag_name = "";
                    if (tags[i] == '<' && tags[i + 1] == '/')
                    {
                        i += 2; //--> now i points to first char of the closed tag name..
                        while (tags[i] != '>')
                        {
                            closed_tag_name += tags[i];
                            i++;
                        }
                        i++;
                    }
                    string top = checker.Pop();
                    // now check the top of the stack..
                    if (top != closed_tag_name)
                    {
                        return false;
                    }
                }
            }
            if (checker.Count == 0) { return true; }
            else { return false; }
        }
        // #endregion
}