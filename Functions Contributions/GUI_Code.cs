////////////////////////////////////////// GUI/////////////////////////////////////////       
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
		public Form1()
        {
            InitializeComponent();
        }
	   private void Form1_Load(object sender, EventArgs e)
        {
            jsoncheckbox.Hide();
            lblerror.Hide();
            errorlist.Hide();
            lblconsistency.Hide();
        }
		////////////////////////////////////Open file button
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
		///////////////////////////////////////////button4 for compress
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