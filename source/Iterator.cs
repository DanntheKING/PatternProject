/*Name: Frankie Lavall
 * Date: 10/24/2022
 * CSC 403-002
 */

using System;
using System.Collections.Generic;

namespace iteratorPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Making a collection to iterate
            ListOfShoes Shoes = new ListOfShoes();
            Shoes[0] = "Jordans";
            Shoes[1] = "Nikes";
            Shoes[2] = "Adidas";
            Shoes[3] = "New Balance";
            Shoes[4] = "Puma";

            // Creating Iterator
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
        
        //Helps get Count of items in collection
        public int Count
        {
            get {return items.Count;}
        }

        // Gets index
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

        //Finds first item in interation
        public override object First()
        {
            currentShoe = 0;
            return ShoeCollection[currentShoe] as object;
        }

        //Finds next item in interation
        public override object Next()
        {
            object i = null;
            if (currentShoe < ShoeCollection.Count - 1) 
            { 
                i = ShoeCollection[++currentShoe];
            }
            return i;
        }

        //Finds Last item in interation
        public override object Last()
        {
            return ShoeCollection[ShoeCollection.Count - 1];
        }

        //Finds current item in interation
        public override object Current()
        {
            return ShoeCollection[currentShoe];
        }

        //Tells if you have iterated to end of list
        public override bool IsDone()
        {
            return currentShoe >= ShoeCollection.Count; 
        }
    }
}
