using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WebConfig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();;/
        }
        //foreach (XDocument doc = XDocument.Load("D:\\product.xml"))
        private void button1_Click(object sender, EventArgs e)
        {

			//asoa;hakljdha;sdhas			
			// Checking my Commit 
		
            string[] files = Directory.GetFiles("D:\\configs\\","*.*",SearchOption.AllDirectories);
            ArrayList list = new ArrayList();
            int Count1 = 0;
            int testCount = 0;
            int stopcount = 0;
            int oldcount = 0;
            int newcount = 0;
            int newkeycount = 0;
            string key_input; 
            string value_input;
            // Display all the files.
            string file1 = null;
            foreach (string file in files)
            {
                file1 = file;
                XDocument doc = XDocument.Load(file);
                //MessageBox.Show("problem");
                // MessageBox.Show(file);
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(@"D:\config_input.txt");
                    string[] split = null;

                    foreach (string line in lines)
                    {

                        ///Splitted String
                        split = line.Split(new char[0]);






                        foreach (XElement cell in doc.Element("configuration").Elements("location").Elements("appSettings").Elements("add"))
                        {
                            //     MessageBox.Show("Flow");
                            string str = cell.ToString();
                            var assemblyIdentity = XElement.Parse(str);
                            var name = (string)assemblyIdentity.Attribute("key");
                            var token = (string)assemblyIdentity.Attribute("value");

                           



                             key_input = split[0];
                             value_input = split[1];


                            //string key_input = key.Text;
                            //string value_input = value.Text;


                            if (name == key_input)
                            {
                                Count1++;

                                if (stopcount == 0) {
                                    oldcount++;

                                }
                                
                                testCount++;
                                cell.SetAttributeValue("value", value_input);
                                doc.Save(file);
                               // break;
                                //    MessageBox.Show("Test");
                                // MessageBox.Show(cell.ToString());

                            }//end of if

                           
                        }
                        
                        if (Count1 == 0) {

                            key_input = split[0];
                            value_input = split[1];

                            if (newcount == 0)
                            {
                                list.Add(key_input);
                                list.Add(value_input);
                            }

                //////////////  imp commented code

                            //string newKey = "<add key=" + '"' + key_input + '"' + " value=" + '"' + value_input + '"' + " />";
                            //string append = newKey + '\n' + "</appSettings>";
                            //string text = File.ReadAllText(file1);
                            //text = text.Replace("</appSettings>", append);
                            //File.WriteAllText(file1, text);
                                      
                          //  doc.Save(file1);

                            //    break;

                        }


                        Count1 = 0;

                    }



                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // MessageBox.Show(file);

                stopcount++;
                newcount++;
            }

            
            // MessageBox.Show(oldcount +"  Old Keys Updated" + "\n \n" + newcount +"  New Keys Added" ); 



            string[] files1 = Directory.GetFiles("D:\\configs\\", "*.*", SearchOption.AllDirectories);
            foreach (string file2 in files1) {  


            for (int i = 0; i < list.Count; i+=2)
            {

                string newKey = "<add key=" + '"' + list[i]+ '"' + " value=" + '"' + list[i+1] + '"' + " />";

                string append = newKey + '\n' + "</appSettings>";
                string text = File.ReadAllText(file2);
                text = text.Replace("</appSettings>", append);
                File.WriteAllText(file2, text);






            }

            }








            MyMessagebox.ShowBox("");
           
            //  MessageBox.Show("No of Old Key(s) Updated : " + oldcount  + "\n \n"  + "No of New Key(s) Added: " + list.Count/2 );

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

}

