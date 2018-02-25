using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace subset
{
    class Program
    {
        static void Main(string[] args)
        {
            var pool = new List<string[]>();
            string[] source = { "1", "2", "3"};
            Imager(source);
            subset(source, pool);             
            dublicates(pool);
            pool.Sort((a, b) => b.Length.CompareTo(a.Length));
            ListImager(pool);
            Console.ReadLine();
        }
        //jopa
        static void dublicates(List<string[]> pool)
        {
            for (int i = 0; i < pool.Count - 1; i++)
            {
                for (int j = 0; j < pool.Count; j++)
                {
                    if (pool[i].Length == pool[j].Length)
                    {
                        if (j != i && pool[i].SequenceEqual(pool[j]))
                        {
                            pool.RemoveAt(j);
                        }
                    }
                }
            }
        }

        static void subset(string[] source, List<string[]> pool)
        {            
            if (source.Length > 1)            
            {               
                for (int i = 0; i < source.Length; i++)
                {
                    var innerset = new string[source.Length - 1];
                    var k = 0;
                    for (int j = 0; j < source.Length; j++)
                    {
                        if (j != i)
                        {
                            innerset[k] = source[j];                           
                            k++;
                        }                        
                    }  
                    pool.Add(innerset);
                    subset(innerset, pool);
                }       
            }
        }


        static void subset_net(string[] source)
        {
            for (int i = 0; i < Math.Pow(source.Length, 2); i++)
            {
                var temp = new string[source.Length];
                for (int j = 0; j < source.Length; j++)
                {
                    if ((i & (1 << (source.Length - 1 - j))) != 0)
                    {
                        temp[j] = source[j];
                    }
                }
                Imager(temp);
            }
        }

        static void ListImager(List<string[]> list)
        {
            foreach (var item in list)
            {
                Imager(item);
            }
        }

        static void Imager(string[] str)
        {
            foreach (var item in str)
            {
                if (item != null)
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
