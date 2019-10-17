using System;
using System.Collections.Generic;

namespace HungryNinja
{
    interface IConsumable
    {
        string Name {get;set;}
        int Calories {get;set;}
        bool IsSpicy {get;set;}
        bool IsSweet {get;set;}
        string GetInfo();
    }   

    class Food : IConsumable
    {
        public string Name{get;set;}
        public int Calories{get;set;}
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy{get;set;}
        public bool IsSweet{get;set;}

        public string GetInfo()
        {
            return $"{Name} (Food).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }
        public Food(string name, int calories, bool isSpicy, bool isSweet)
        {
            Name = name;
            Calories = calories;
            IsSpicy = isSpicy;
            IsSweet = isSweet;
        }
        // END Food class
    }

    class Drink : IConsumable
    {
        public string Name {get;set;}
        public int Calories {get;set;}
        public bool IsSpicy {get;set;}
        public bool IsSweet {get;set;}
        
        // Implement a GetInfo Method
        public string GetInfo()
        {
            return $"{Name} (Drink).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }
        // Add a constructor method
        public Drink(string name, int calories, bool isSpicy, bool isSweet)
        {
            Name = name;
            Calories = calories;
            IsSpicy = isSpicy;
            IsSweet = true;
        }
    }   


    class Buffet
    {
        public List<Food> Menu;

        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("10 Piece Sushi", 600, false, false)
            };
        }

        //methods:
        public Food Serve()
        {
            Random r = new Random();
            return Menu[r.Next(0,Menu.Count)];
        }
        // END Buffet class
    }
    abstract class Ninja
    {
        private int calorieIntake;
        public List<IConsumable> ConsumptionHistory;
         
        public Ninja()
        {
            calorieIntake = 0;
            ConsumptionHistory = new List<IConsumable>();
        }
         
        public int CalorieIntake {get;set;}
        // check if the ninja is full
        public abstract bool IsFull();
        // eat method
        public abstract void Consume(IConsumable item);

        // public void Eat(Food item)
        // {
        //     if(IsFull)
        //     {
        //         System.Console.WriteLine("Ninja is full!");
        //     }
        //     else
        //     {
        //         CalorieIntake+=item.Calories;
        //         ConsumptionHistory.Add(item);
        //         System.Console.WriteLine($"Ninja consumed {item.Name}. Spicy: {item.IsSpicy}, Sweet: {item.IsSweet}.");
        //     }
        // }
    }

    class SweetTooth : Ninja
    {
        // provide override for IsFull (Full at 1500 Calories)
        public override bool IsFull()
        {
            if(CalorieIntake > 1500)
                return true;
            else
                return false;
        }
        public override void Consume(IConsumable item)
        {
            if(IsFull())
            {
                System.Console.WriteLine("Ninja is full and cannot eat anymore!!");
            }
            else
            {
                CalorieIntake+=item.Calories;
                if(item.IsSweet)
                    CalorieIntake+=10;
                ConsumptionHistory.Add(item);
                System.Console.WriteLine($"Ninja consumed {item.Name}. Spicy: {item.IsSpicy}, Sweet: {item.IsSweet}.\n Number of items consumed: {ConsumptionHistory.Count}");
                item.GetInfo();
            }
        }
    }

    class SpiceHound : Ninja
    {
        // provide override for IsFull (Full at 1200 Calories)        // provide override for IsFull (Full at 1500 Calories)
        public override bool IsFull()
        {
            if(CalorieIntake > 1200)
                return true;
            else
                return false;
        }
        public override void Consume(IConsumable item)
        {
            if(IsFull())
            {
                System.Console.WriteLine("Ninja is full and cannot eat anymore!!");
            }
            else
            {
                CalorieIntake+=item.Calories;
                if(item.IsSpicy)
                    CalorieIntake+=10;
                ConsumptionHistory.Add(item);
                System.Console.WriteLine($"Ninja consumed {item.Name}. Spicy: {item.IsSpicy}, Sweet: {item.IsSweet}.\n Number of items consumed: {ConsumptionHistory.Count}");
                item.GetInfo();
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Buffet time!");
            Buffet kingBuffet = new Buffet();
            kingBuffet.Menu.Add(new Food("Mochi", 100, false, true));
            kingBuffet.Menu.Add(new Food("Tonkatsu", 350, false, false));
            kingBuffet.Menu.Add(new Food("Edamame", 200, false, false));
            kingBuffet.Menu.Add(new Food("Sweet and Spicy Pork", 350, true, true));

            SweetTooth n1 = new SweetTooth();
            SpiceHound n2 = new SpiceHound();

            
            while(!n1.IsFull())
            {
                n1.Consume(kingBuffet.Serve());
            }
            while(!n2.IsFull())
            {
                n2.Consume(kingBuffet.Serve());
            }
        }
    }
}
