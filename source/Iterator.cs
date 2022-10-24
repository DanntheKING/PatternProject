using System;
using System.Collections.Generic;

namespace iteratorPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListOfShoes Shoes = new ListOfShoes();
            Shoes[0] = "Jordans";
            Shoes[1] = "Nikes";
            Shoes[2] = "Adidas";
            Shoes[3] = "New Balance";
            Shoes[4] = "Puma";

            Iterator Ishoe = Shoes.CreateIterator();
            Console.WriteLine("Iterating the List of Shoes");

            object item = Ishoe.First();

            while (item != null)
            {
                Console.WriteLine(item);
                item = Ishoe.Next();
            }

            Console.ReadKey();
        }
    }

    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    public class ListOfShoes : Aggregate
    {
        List<object> items = new List<object>();    

        public override Iterator CreateIterator()
        {
            return new CIterator(this);
        }
        public int Count
        {
            get {return items.Count;}
        }

        public object this[int index]
        {
            get { return items[index]; }
            set { items.Add(value); }
        }
    }

    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract object Last();
        public abstract bool IsDone();
        public abstract object Current();
    }

    public class CIterator : Iterator
    {
        ListOfShoes ShoeCollection;
        int currentShoe = 0;

        public CIterator(ListOfShoes ShoeCollection)
        {
            this.ShoeCollection = ShoeCollection;
        }

        public override object First()
        {
            currentShoe = 0;
            return ShoeCollection[currentShoe] as object;
        }

        public override object Next()
        {
            object i = null;
            if (currentShoe < ShoeCollection.Count - 1) 
            { 
                i = ShoeCollection[++currentShoe];
            }
            return i;
        }
        public override object Last()
        {
            return ShoeCollection[ShoeCollection.Count - 1];
        }

        public override object Current()
        {
            return ShoeCollection[currentShoe];
        }

        public override bool IsDone()
        {
            return currentShoe >= ShoeCollection.Count; 
        }
    }
}
