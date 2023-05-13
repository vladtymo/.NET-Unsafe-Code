using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_string_unsafe
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "It's a imutable string";
            string copy = str;

            Console.WriteLine("It's a imutable string");
            ReverseString(str);
            Console.WriteLine("Reversed!");
            Console.WriteLine("It's a imutable string");

            Console.WriteLine("str: " + str);
            Console.WriteLine("copy: " + copy);

            if (str == copy)
                Console.WriteLine("str == copy");
            if (str == "It's a imutable string")
                Console.WriteLine("str == It's a imutable string");
            if (str == "gnirts elbatumi a s'tI")
                Console.WriteLine("str == gnirts elbatumi a s'tI");
            if (string.ReferenceEquals("It's a imutable string", "gnirts elbatumi a s'tI"))
                Console.WriteLine("const Reference is Equals reversed const!");
            if (string.ReferenceEquals("It's a imutable string", str))
                Console.WriteLine("const Reference is Equals str!");
            if (string.Equals("It's a imutable string", "gnirts elbatumi a s'tI"))
                Console.WriteLine("const Is Equals const!");
            if (string.Equals("It's a imutable string", str))
                Console.WriteLine("const Is Equals str!");
            if ("It's a imutable string" == str)
                Console.WriteLine("const == str");
            if ("gnirts elbatumi a s'tI" == str)
                Console.WriteLine("reversed const == str");
            if (string.Equals("It's a imutable string", "gnirts elbatumi a s'tI"))
                Console.WriteLine("reversed const Is Equals const");
            if ("It's a imutable string" == "gnirts elbatumi a s'tI")
                Console.WriteLine("reversed const == const");

        }
        static unsafe void ReverseString(string str)
        {
            int i = 0;
            int j = str.Length - 1;

            fixed (char* fstr = str)
            {
                while (i < j)
                {
                    char temp = fstr[j];

                    fstr[j--] = fstr[i];
                    fstr[i++] = temp;
                }
            }
        }
    }
}
