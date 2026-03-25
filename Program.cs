using System;

namespace TilburgDelivery
{
    public interface ISendable
    {
        void Send(string destination);
        void Send(string destination, bool isRegistered);
    }
    //-----------------------------------------------------//
    public abstract class Parcel:ISendable
    {
        public abstract void Send(string destination);

        public abstract void Send(string destination, bool isRegistered);

        public void CheckRegistration(string destination, bool isRegistered)
        {
            if (isRegistered) Console.WriteLine($"[TRACKING] Registered delivery to {destination}: Signature required!");
        }
    }
    //------------------------------------------------------//
    public class Letter : Parcel
    {
        public override void Send(string destination) => Console.WriteLine("Placing stamp on letter...");

        public override void Send(string destination, bool isRegistered)
        {
            CheckRegistration(destination, isRegistered);
            Send(destination);
        }
    }

    public class Box : Parcel
    {
        public override void Send(string destination) => Console.WriteLine("Loading box onto truck...");

        public override void Send(string destination, bool isRegistered)
        {
            CheckRegistration(destination, isRegistered);
            Send(destination);
        }
    }

    public class Furniture : Parcel
    {
        public override void Send(string destination) => Console.WriteLine("Moving furniture with a two-man team...");

        public override void Send(string destination, bool isRegistered)
        {
            if (isRegistered)
            
                Console.WriteLine($"WHITE-GLOVE: Special registered delivery for furniture to {destination}!");
            
            else
                Send(destination);
            
        }
    }
    //------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            ISendable[] deliveryBag = { new Letter(), new Box(), new Furniture() };

            Console.WriteLine("--- Tilburg Post Morning Run ---");
            foreach (ISendable item in deliveryBag)
            {
                item.Send("Stationsstraat 12, Tilburg", true);
            }
        }
    }
}
















