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
