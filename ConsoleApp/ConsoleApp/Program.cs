using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // MyList<T>

            var list = new MyList<int>(8);

            list[0] = 12;
            list[1] = 25;

            list.Add(5);
            list.Add(12);
            list.Add(22);

            list[3] = 15;
            list[4] = 45;

            list.ListAll();
            
            Console.WriteLine($"Size of collection = {list.Capacity}\n\n");


            // MyDictionary <Tkey, TValue>

            var dictionary = new MyDictionary<int, string>();
            dictionary.Add(0, "Test1");
            dictionary.Add(1, "Test2");
            dictionary.Add(2, "Test3");
            dictionary[2] = "Test3Index";
            dictionary.ListAll();

            Console.WriteLine($"Number of elements in collection: {dictionary.Counter}");

        }
    }

    class MyList<T>
    {
        private T[] myList = null;
        private int newIndex = 0;
        private int CountItems = 0;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < myList.Length)
                    return myList[index];
                else
                {
                    Console.WriteLine(new ArgumentOutOfRangeException().Message);
                    return myList[0];
                }
            }
            set { myList[index] = value;
            }
        }

        public MyList()
        {
            this.myList = new T[1];
        }

        public MyList(int count)
        {
            this.myList = new T[count];
        }


        public void Add(T item)
        {
            myList[newIndex] = item;
            newIndex++;
            CountItems++;
        }

        public void ListAll ()
        {
            for (int i = 0; i < myList.Length; i++)
            {
                Console.WriteLine($"Index {i} = {myList[i]}");
            }
        }

        public int Capacity
        {
            get { return myList.Length; }

        }
        public int Count
        {
            get { return CountItems; }
        }

        
    }
    class MyDictionary<TKey, TValue>
    {
        private int counter = 0;
        private TKey[] Keylist = new TKey[0];
        private TValue[] Valuelist = new TValue[0];
        public int Counter
        {
            get { return this.counter; }
        }

        public MyDictionary()
        {
            TKey[] Keylist = new TKey[0];
            TValue[] Valuelist = new TValue[0];
            this.Keylist = Keylist;
            this.Valuelist = Valuelist;
        }
        public void Add(TKey Key, TValue Value)
        {
            this.counter++;
            Array.Resize(ref Keylist, counter);
            Keylist[counter - 1] = Key;

            Array.Resize(ref Valuelist, counter);
            Valuelist[counter - 1] = Value;
        }

      
        public TValue this[TKey Key]
        {
            get
            {
                int index = -1;
                for (int i = 0; i < counter; i++)
                {
                    if (Key.Equals(Keylist[i]))
                        index = i;
                }
                if (index == -1)
                {
                    Console.WriteLine(new NullReferenceException().Message);
                    index++;
                }
                return Valuelist[index];
            }
            set
            {
                for (int i = 0; i < counter; i++)
                    if (Key.Equals(Keylist[i]))
                    {
                        Valuelist[i] = value;
                    }
            }
        }

        public void ListAll()
        {
            for (int i = 0; i < Keylist.Length; i++)
            {
                Console.WriteLine($"Key = {Keylist[i]}, Value = {Valuelist[i]}");
            }
        }
    }
    public class Pair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public Pair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
    }



}
