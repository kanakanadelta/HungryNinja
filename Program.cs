using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy; 
        public bool IsSweet; 

        public Food(string name, int calories, bool isSpicy, bool isSweet)
        {
            Name = name;
            Calories = calories;
            IsSpicy = isSpicy;
            IsSweet = isSweet;
        }
        // END Food class
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
    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;
         
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }
         
        public int CalorieIntake {get;set;}
        // check if the ninja is full
        public bool IsFull
        {
            get
            {
                if(CalorieIntake > 1200)
                    return true;
                else
                    return false;
            }
        }
        // eat method
        public void Eat(Food item)
        {
            if(IsFull)
            {
                System.Console.WriteLine("Ninja is full!");
            }
            else
            {
                CalorieIntake+=item.Calories;
                FoodHistory.Add(item);
                System.Console.WriteLine($"Ninja ate {item.Name}. Spicy: {item.IsSpicy}, Sweet: {item.IsSweet}.");
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

            Ninja ninja = new Ninja();

            ninja.Eat(kingBuffet.Serve());
            ninja.Eat(kingBuffet.Serve());
            ninja.Eat(kingBuffet.Serve());
            ninja.Eat(kingBuffet.Serve());
            ninja.Eat(kingBuffet.Serve());
            ninja.Eat(kingBuffet.Serve());
            ninja.Eat(kingBuffet.Serve());
        }
    }
}
