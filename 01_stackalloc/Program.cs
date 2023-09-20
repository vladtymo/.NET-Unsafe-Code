using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_stackalloc
{
    class Program
    {
        // Project -> Properties -> Build -> Allow Unsafe Code
        unsafe struct Unsafe
        {
            public int* Pointer { get; set; }
            public float Name { get; set; }
        }
        unsafe static int* UnsafeMethod()
        {
            const int size = 10;
            int* arr = stackalloc int[size];
            int* p = arr;

            //*(++p) = 3;
            *(p++) = 1;

            for (int i = 2; i <= size; i++, p++)
            {
                *p = p[-1] * i;
            }
            for (int i = 0; i < size; ++i)
            {
                Console.WriteLine(arr[i]);
            }
            return arr;
        }
        unsafe static int* GenerateArr(out int size)
        {
            Random rnd = new Random();
            size = rnd.Next(10, 20);
            int[] arr = new int[size];
            //int* arr = stackalloc int[size];

            fixed (int* arrPtr = arr)
            {
                //int* arrPtr = arr;
                for (int* p = arrPtr; p < arrPtr + size; ++p)
                {
                    *p = rnd.Next(100);
                }

                //GC.Collect();

                for (int i = 0; i < size; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();

                return arrPtr;
            }
        }
        static void Main(string[] args)
        {
            // unsafe block allow use a pointers (* & ->)
            unsafe
            {
                ////// pointer to base type
                //int num = 10;
                //int* pointer = &num;
                //Console.WriteLine("Address: " + (int)pointer);
                //Console.WriteLine("Value: " + *pointer);

                //////////////// pointer to struct
                //Unsafe @unsafe = new Unsafe();
                //Unsafe* strPtr = &@unsafe;

                //(*strPtr).Pointer = &num;
                //strPtr->Pointer = &num;
                //Console.WriteLine(*@unsafe.Pointer);

                ///////// create an array
                //const int size = 10;
                //int* arr = stackalloc int[size];

                //Console.WriteLine("First: " + *arr); // 0x57658648

                //for (int i = 0; i < size; i++)
                //{
                //    arr[i] = i * i;
                //    //*(arr + i) = i * i;
                //}

                //*(arr + 100000) = 0; // error

                //for (int* ptr = arr; ptr < arr + size; ptr++)
                //{
                //    Console.Write(*ptr + " ");
                //}

                //////// invoke unsafe method
                //int* arr = UnsafeMethod();

                //// return pointer to an array
                int* arr = GenerateArr(out int size);

                // fixed block closed, array can be destroyed
                GC.Collect();

                for (int i = 0; i < size; i++)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}
