using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace hacker
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            callwithoutGenerics();
            watch.Stop();
            Console.WriteLine("Call without generics elpsed time::" + watch.Elapsed);
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            callwithGenerics();
            watch1.Stop();
            Console.WriteLine("Call with generics elpsed time::" + watch1.Elapsed);
        }
        public static void callwithoutGenerics()
        {
            ArrayList obj = new ArrayList();
            int x = 20;
            obj.Add(x); //boxing
            int y = (int)obj[0];    //unboxing
           
        
        }
        public static void callwithGenerics()
        {
            TestClass<int> genobj = new TestClass<int>();
            int x = 20;
            genobj.Add(x); //No boxing
            int y = (int)genobj[0];    //No unboxing

        }
    }
    public class TestClass<T>
    {
        // define an Array of Generic type with length 5  
        T[] obj = new T[5];
        int count = 0;

        // adding items mechanism into generic type  
        public void Add(T item)
        {
            //checking length  
            if (count + 1 < 6)
            {
                obj[count] = item;

            }
            count++;
        }
        //indexer for foreach statement iteration  
        public T this[int index]
        {
            get { return obj[index]; }
            set { obj[index] = value; }
        }
       
    }  
}

   
