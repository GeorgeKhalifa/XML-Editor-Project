
        //XML to JSON
        public static void printNode(item Node, int indent = 2, bool isArray = false)
        {
            //JSONNNNNNN
            //XML TO JSON
            //string JSON_output = "";

            //item Node= items[0]; 
            //int indent = 2;
            //bool isArray = false;
            string str = new string(' ', indent);

            //   Console.Write(Node.name);

            if (Node.childrenList.Count == 0)
            {
                if (isArray)
                {
                    //Console.Write(str);
                    //string
                  JSON_output += str;
                }

                //ATTRIBUTES //leaf Node:
                if (Node.attributesList.Count != 0)
                {
                    //Console.WriteLine("{");
                    //string
                    JSON_output += "{ \n";

                    int num = Node.attributesList.Count;
                    for (int i = 0; i < num; i += 2)
                    {
                       // Console.WriteLine(str + "\"" + Node.attributesList[i] + "\":" + "\"" + Node.attributesList[i + 1] + "\","); //
                                                                                                                                    //string
                        JSON_output += str + "\"" + Node.attributesList[i] + "\":" + "\"" + Node.attributesList[i + 1] + "\",\n";
                    }

                    //ATTRIBUTESS:
                    //Console.WriteLine(str + $" \"#Text\": \"{Node.body}\"");
                    //string
                    JSON_output += str +  $" \"#Text\": \"{Node.body}\" \n";

                    //Console.Write(str + "}");
                    JSON_output += str + "}";

                }
                //
                else
                {
                    //Console.Write($"\"{Node.body}\"");
                    //string
                    JSON_output += $"\"{Node.body}\"";
                }

                //Console.Write($" \"{Node.body}\""); WASNT COMMENTED , FOR ATTR. SAKE

                //Console.WriteLine(isLast ? "" : ","); //,

                return;
            }

            //Console.Write(str);
            // Console.WriteLine('{');
            JSON_output += "{\n";
            if (Node.attributesList.Count > 0)
            {
                int num = Node.attributesList.Count;
                for (int i = 0; i < num; i += 2)
                {
                   // Console.WriteLine(str + "\"" + Node.attributesList[i] + "\":" + "\"" + Node.attributesList[i + 1] + "\",");
                    //string
                    JSON_output += str + "\"" + Node.attributesList[i] + "\":" + "\"" + Node.attributesList[i + 1] + "\",\n";
                }
            }




            //DUPLICATE CASE
            Dictionary<string, List<item>> groups = new Dictionary<string, List<item>>();

            foreach (var child in Node.childrenList)
            {
                //if not present
                if (!groups.ContainsKey(child.name))
                {
                    groups.Add(child.name, new List<item> { child });
                }
                else
                {//if present
                    groups[child.name].Add(child);
                }
            }


            foreach (var group in groups.Select((Entry, Index) => new { Entry, Index }))
            {
                //Console.Write(str);
                //string
                JSON_output += str;
                //Console.Write($"\"{group.Entry.Key}\": ");
                //string
                JSON_output += $"\"{group.Entry.Key}\": ";
                //Console.Write(group.Entry.Value.Count > 1 ? "[ \n" : "");
                //string
                JSON_output += group.Entry.Value.Count > 1 ? "[ \n" : "";

                for (int i1 = 0; i1 < group.Entry.Value.Count; i1++)
                {
                    item node = group.Entry.Value[i1];
                    printNode(node, indent + 2, group.Entry.Value.Count > 1);
                    //Console.Write(i1 == group.Entry.Value.Count - 1 ? "" : ",\n");  //
                                                                                    //string
                    JSON_output += i1 == group.Entry.Value.Count - 1 ? "" : ",\n";
                }

                //Console.Write(str);
                //Console.Write(group.Entry.Value.Count > 1 ? " \n" + str + "]" : "");
                //string
                JSON_output += group.Entry.Value.Count > 1 ? " \n" + str + "]" : "";
                //Console.WriteLine(group.Index == groups.Count - 1 ? "" : ",");
                //string
                JSON_output += group.Index == groups.Count - 1 ? "" : ",\n";
            }

            //Console.Write(str);
            //string 
            JSON_output += str;
            //Console.Write("}");
            //strin
            JSON_output += "}";
        }

        //XML TO JSON CHILDREN ATTRIBUTES
        //array of strings
        //dict of strings

        public static void printJSON()
        {
            //Console.WriteLine('{');
            //string
            JSON_output += "{";
            //Console.Write($"\"{items[0].name}\": ");
            //string
            JSON_output += $"\"{items[0].name}\": ";
            printNode(items[0]);
            //Console.Write('}');
            //string
            JSON_output += "}";

        }   
