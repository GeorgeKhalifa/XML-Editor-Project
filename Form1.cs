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
    
         //#region check consistency function that returns true of false
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



		        public Form1()
        {
            InitializeComponent();
        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            jsoncheckbox.Hide();
            lblerror.Hide();
            errorlist.Hide();
            lblconsistency.Hide();
        }

        private void button_WOC6_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            //file.Filter = "xml files (*.xml)*.xml|All Files (*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                lblpath.Text = file.FileName;
                xmlfile = File.ReadAllText(file.FileName);
            }
            lblconsistency.Hide();
            beging_tags = "";
            lblerror.Hide();
            errorlist.Hide();
        }

        //button4 for compress
        private void button4_Click(object sender, EventArgs e)
        {
            if (xmlfile == null)
            {
                MessageBox.Show("You must select a file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (xmlcheckbox.Checked == true)
            {
                
                compressed = Compress(xmlfile);
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                //saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        TextWriter txt = new StreamWriter(myStream);
                        txt.Write(string.Join(" ", compressed));
                        txt.Close();
                        myStream.Close();
                        var comp = string.Join(" ", compressed);
                        errorlist.Text = comp;
                    }
                }
                MessageBox.Show("Compression is done Successfully for XML file", "Compression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblerror.Text = ("Compression");
                lblerror.Show();
                errorlist.Show();
            }
            else if (jsoncheckbox.Checked == true)
            {
                compressed = Compress(JSON_output);
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                //saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        TextWriter txt = new StreamWriter(myStream);
                        txt.Write(string.Join(" ", compressed));
                        txt.Close();
                        myStream.Close();
                        var comp = string.Join(" ", compressed);
                        errorlist.Text = comp;
                    }
                }
                MessageBox.Show("Compression is done Successfully for JSON file", "Compression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblerror.Text = ("Compression");
                lblerror.Show();
                errorlist.Show();
            }
            else
            {
                MessageBox.Show("You must Select one of the files to Compress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDecompress_Click(object sender, EventArgs e)
        {
            if (xmlfile == null || compressed.Count == 0)
            {
                MessageBox.Show("You must Compress the file first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(xmlcheckbox.Checked==true)
            {
                string decompressed;
                decompressed = Decompress(compressed);
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

               // saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        TextWriter txt2 = new StreamWriter(myStream);
                        txt2.Write(decompressed);
                        txt2.Close();
                        myStream.Close();
                        errorlist.Text = decompressed;
                    }
                }
                MessageBox.Show("Decompression is done Successfully for XML file", "Decompression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblerror.Text = ("Decompression");
                lblerror.Show();
                errorlist.Show();

            }
            else if (jsoncheckbox.Checked == true)
            {
                string decompressed;
                decompressed = Decompress(compressed);
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                // saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        TextWriter txt2 = new StreamWriter(myStream);
                        txt2.Write(decompressed);
                        txt2.Close();
                        myStream.Close();
                        errorlist.Text = decompressed;
                    }
                }
                MessageBox.Show("Decompression is done Successfully for JSON file", "Decompression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblerror.Text = ("Decompression");
                lblerror.Show();
                errorlist.Show();
            }
            else
            {
                MessageBox.Show("You must Select one of the files to Decompress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            if (xmlfile == null )
            {
                MessageBox.Show("You must select a file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(minifyflag==false)
            {
                MessageBox.Show("You must Minifying first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                check = Check_Consistency(minified);
                if (check == true)
                {
                    //MessageBox.Show("Consistency is true", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblconsistency.Text = (" The file is consistened (True)");
                    lblconsistency.ForeColor = Color.Green;
                    lblconsistency.Show();

                }
                else if (check == false)
                {
                    //MessageBox.Show("Consistency is false", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblconsistency.Text = (" The file is not consistened (False)");
                    lblconsistency.ForeColor = Color.Red;
                    lblconsistency.Show();
                }
                consistancy = true;
            }
        }

        private void btnminify_Click(object sender, EventArgs e)
        {
           
            string total = "";
            if (xmlfile == null)
            {
                MessageBox.Show("You must select a file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                minified = minify(xmlfile);
                //string minified2 = "";
                //string temp = "";

                //minified2= begingtags(minified,ref begingtag);

                int i = 0;
                int start = 0;
                int count = 0;
                while (i < minified.Length)
                {
                    if (minified[i] == '<' && minified[i + 1] == '?')
                    {
                        start = i;
                        beging_tags += minified[i];
                        i++;
                        beging_tags += minified[i];
                        count = 1;
                        while (true)
                        {
                            if (minified[i] == '<' && minified[i + 1] != '?')
                            {
                                break;
                            }
                            i++;
                            count++;
                            beging_tags += minified[i];
                        }
                        minified = minified.Remove(start, count);
                        count = 0;
                        i = start - 1;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                if (beging_tags != "")
                {
                    begintag = true;
                    beging_tags = beging_tags.Substring(0, (beging_tags.Length) - 1);
                    total = beging_tags + minified;
                }
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                // saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        if (begintag == true)
                        {
                            TextWriter txt2 = new StreamWriter(myStream);
                            txt2.Write(total);
                            txt2.Close();
                            myStream.Close();
                            errorlist.Text= total;
                        }
                        else
                        {
                            TextWriter txt2 = new StreamWriter(myStream);
                            txt2.Write(minified);
                            txt2.Close();
                            myStream.Close();
                            errorlist.Text= minified;
                        }
                    }
                }
                MessageBox.Show("Minifying is done Successfully", "Minifying", MessageBoxButtons.OK, MessageBoxIcon.Information);
                minifyflag = true;
                lblerror.Text= ("Minifying");
                lblerror.Show();
                errorlist.Show();

            }
        }

        private void errorlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            if (minifyflag == false)
            {
                MessageBox.Show("You must Minifying first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (consistancy == false)
            {
                MessageBox.Show("You must check Consistency first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                solved = true;
                if (check == false)
                {
                    string solved_file = solve(minified);

                    string total;
                    Stream myStream;
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    // saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    //saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        if ((myStream = saveFileDialog1.OpenFile()) != null)
                        {
                            if (begintag == true)
                            {
                                total = beging_tags + solved_file;
                                TextWriter txt2 = new StreamWriter(myStream);
                                txt2.Write(total);
                                txt2.Close();
                                myStream.Close();

                            }
                            else
                            {
                                TextWriter txt2 = new StreamWriter(myStream);
                                txt2.Write(solved_file);
                                txt2.Close();
                                myStream.Close();
                            }
                            MessageBox.Show("The Solved file saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    errorlist.Text = "";
                    foreach (var k in Error_List)
                    {
                        errorlist.AppendText(k + "\r\n");
                        // errorlist.Text += "\n";
                    }

                    lblerror.Text = "Error List";
                    lblerror.Show();
                    errorlist.Show();
                }
                if (check == true)
                {
                    string solved_file = solve(minified);
                    string mess = "There are no Errors";
                    errorlist.Text = mess;
                    lblerror.Text = "Error List";
                    lblerror.Show();
                    errorlist.Show();
                    //errorlist.DataSource()
                }
            }
        }

        private void btnpretty_Click(object sender, EventArgs e)
        {
            if (solved == false)
            {
                MessageBox.Show("You must press on the solve button first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string pretty_file = "";
                pretty_file = xml_prettifying(items[0], "");
                pretty_file = pretty_file.Remove(pretty_file.Length - 1, 1);
                pretty_file = beging_tags + "\n" + pretty_file;
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                // saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        TextWriter txt2 = new StreamWriter(myStream);
                        txt2.Write(pretty_file);
                        txt2.Close();
                        myStream.Close();
                        errorlist.Text = pretty_file;
                    }
                }
                MessageBox.Show("Prettifying is done Successfully", "Prettifying", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblerror.Text = ("Prettifying");
                lblerror.Show();
                errorlist.Show();
            }
        }

        private void btnconvert_Click(object sender, EventArgs e)
        {
            if (solved == false)
            {
                MessageBox.Show("You must press on the solve button first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                split();
                printJSON();
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                // saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        TextWriter txt2 = new StreamWriter(myStream);
                        txt2.Write(JSON_output);
                        txt2.Close();
                        myStream.Close();
                        errorlist.Text = JSON_output;
                    }
                }
                MessageBox.Show("Conversion to JSON is done Successfully", "JSON", MessageBoxButtons.OK, MessageBoxIcon.Information);
                jsoncheckbox.Show();
                lblerror.Text = ("Conversion to JSON");
                lblerror.Show();
                errorlist.Show();
            }
        }
    }
}
