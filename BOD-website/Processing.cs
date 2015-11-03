/*  2015(c) Socrates Wong
 *  Permissiable use granted under Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International, written permission required other usage.   
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BODwebsite
{
     static class Roll {
        public static List<Person> allmembers = new List<Person>();
        
        public static String[] Depart = { "COMM", "D&I", "GR", "PRO", "SPA", "ENG", "AD" };// names of BOD departments
        public static List<Person>[] Departmembers = new List<Person>[Depart.Length];
        public static void gensList() {
            for (int x = 0; x < Departmembers.Length;x++ )
            {
                Departmembers[x] = new List<Person>();
            }
            foreach (Person x in allmembers) {
                for(int y=0; y<Depart.Length;y++) { 
                    if (x.department.Equals(Depart[y]))
                    {
                        Departmembers[y].Add(x);
                    }
                }
            }
        }
        public static Department[] depart = new Department[Depart.Length];
        public static void start() {

            Console.Out.Write("start");
            depart = new Department[Depart.Length + 1];
            Console.Out.Write(0);
            depart[0] = new Department("Communications");
            Console.Out.Write(1);
            depart[1] = new Department("Diversity &amp; Inclusion");
            Console.Out.Write(2);
            depart[2] = new Department("Governmental Relations");
            Console.Out.Write(3);
            depart[3] = new Department("Programming");
            Console.Out.Write(4);
            depart[4] = new Department("Strategic Planning &amp; Assessment");
            Console.Out.Write(5);
            depart[5] = new Department("Student Organization Engagement");
            Console.Out.Write(6);
            depart[6] = new Department("Associate Directors");
        }
        public static String Output(int x) {
            String str= depart[x].sperater() + depart[x].header();
            foreach (Person g in Departmembers[x]) {
                str += g.ToString(ref depart[x].Frist);
            }
            str += depart[x].ending();
            return str;
       }
        public static String alloutput(){
            String x="";
            for (int y = 0; y < Departmembers.Length; y++)
                x += Output(y);
            return x;
        }
    }
    class Department // represent a BOD department
    {
        String name; 
        public Boolean Frist;
        public Department(String str) { name = str; }
        
        public String sperater() { return "[separator headline=\"h2\" title=\""+name+"\"]\n\n[custom_table style=\"3\"]\n";
        }
        public String header()
        {
            return "\n<table width=\"100%\">\n<thead>\n<tr>\n<th width=\"20%\">Name</th>\n<th width=\"60%\">Title</th>\n<th width=\"20%\">Email</th></tr></thead><tbody>\n";
        }
        public String ending()
        {
            return "\n</tbody>\n</table>\n[/custom_table]\n";
        }
    }
    class Person // repersent a person
    {   
       public String Fname,Lname,email,department, role;
       
        String name() {
            return Fname + " " + Lname;
        }
       public String ToString(ref bool Frist) {
           String str = "\n";
           if (!Frist) {
               str += "<tr>\n";
               str += "<td width=\"20%\">" + name() + "</td>\n";
               str += "<td width=\"60%\">" + role + "</td>\n";
               //str += "<td width=\"20%\"><a href=\"mailto:" + email + "\">zmehta@purdue.edu</a></td>\n";
                str+= "<td width=\"20%\"><span data-sheets-value=\"[null,2,&quot;"+email+"&quot;]\" data-sheets-userformat=\"[null,null,16899,[null,0],[null,2,65535],null,null,null,null,null,null,null,0,null,null,null,null,1]\"><a href=\""+email+"\">"+email+"</a></span></td>";
               str += "<tr>\n";
               Frist = true;
           }
           else
           {
               
               str += "<tr>\n";
               str += "<td width=\"20%\">" + name() + "</td>\n";
               str += "<td width=\"60%\">" + role + "</td>\n";
               str += "<td width=\"20%\"><a href=\"mailto:" + email + "\">"+email+"</a></td>\n";
               str += "<tr>\n";
           }
            return str;
        }
    }
    class IO {// handles the IO
        public static void load()
        {
            Roll.allmembers = new List<Person>();
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("BOD.csv");
            char[] separatingChars = { ',', '|' };
            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    List<string> x = new List<String>();
                    String[] stuff = line.Split(separatingChars, StringSplitOptions.RemoveEmptyEntries);
                    Person p = new Person();
                    p.Fname = stuff[0];
                    p.Lname = stuff[1];
                    p.email = stuff[2];
                    p.department = stuff[3];
                    p.role = stuff[4];
                    Roll.allmembers.Add(p);
                    counter++;
                }
                catch (Exception e) { Console.Out.Write(e); }
            }

            file.Close();



        }
        public static void write(String x){

            StreamWriter writetext = new StreamWriter("write.html");
            writetext.WriteLine(x);
            writetext.Close();
        }
    }
}
