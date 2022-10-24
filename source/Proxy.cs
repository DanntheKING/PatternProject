//Amiyah Frierson
//CSC 403-002
//24 October 2022

using System;
namespace Proxy.cs
{
    public class Boarding
    {
        public static void Main(string[] args)
        {
            // Create math proxy
            BagCheckArea securityProxy = new BagCheckArea();

            // Let the Passengers board
            securityProxy.CheckBags("contraband!", "nike shoes");
            securityProxy.CheckBags("gel pillow", "lipstick");
            securityProxy.CheckBags("lucky keychain", "contraband!");
            securityProxy.CheckBags("hair brush", "ceramic mug");
        }
    }

    /// The Subject Class
    public interface IDetector
    {
        void CheckBags(string x, string y);
    }

    /// The Real_Subject Class
    public class Security : IDetector
    {
        public void CheckBags(string item1, string item2) 
        {
             Console.WriteLine("The passenger boarded the plane without issue.");
        }
    }

    /// The Protection Proxy Class 
    public class BagCheckArea : IDetector
    {
        private Security guard = new Security();
        public void CheckBags(string item1, string item2)
        {
            if ((String.Equals(item1, "contraband!")) || (String.Equals(item2, "contraband!")))
            {
                Console.WriteLine("The alarm went off; the passenger with contraband was detained!");
            }
            else
            {
                guard.CheckBags(item1, item2);
            }
        }
    }
}
