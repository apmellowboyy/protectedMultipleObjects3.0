using System;
using System.ComponentModel.Design;
namespace late
{
    class Skaters
    {
        protected string _Name;
        protected string _Sponser;
        protected int _Age;
        protected string _Gender;

        public Skaters()
        {
            _Name = string.Empty;
            _Sponser = string.Empty;
            _Age = 0;
            _Gender = string.Empty;
        }
        public Skaters(string name, string sponser, int age, string gender)
        {
            _Name=name;
            _Sponser=sponser;
            _Age=age;
            _Gender=gender;
        }

        public virtual void addChange()
        {
            Console.WriteLine($"Name -");
            _Name = Console.ReadLine();
            Console.WriteLine("Sponser -");
            _Sponser = Console.ReadLine();
            Console.WriteLine("Age -");
            _Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Gender -");
            _Gender = Console.ReadLine();
        }

        public virtual void print()
        {
            Console.WriteLine($" Name - {_Name}");
            Console.WriteLine($" Sponser - {_Sponser}");
            Console.WriteLine($" Age - {_Age}");
            Console.WriteLine($" Gender - {_Gender}");
        }
    }

    class Styles : Skaters
    {
        protected string _Vert;
        protected string _Street;
        protected string _Hybrid;

        public Styles()

        {
            _Vert = string.Empty;
            _Street = string.Empty;
            _Hybrid = string.Empty;
        }
        public Styles(string vert, string street, string hybrid)
            : base()
        {
            _Vert=vert;
            _Street=street;
            _Hybrid=hybrid;
        }

        public override void addChange()
        {
            Console.WriteLine("Styles info");
            Console.WriteLine("Vert -");
            _Vert = Console.ReadLine();
            Console.WriteLine("Street -");
            _Street = Console.ReadLine();
            Console.WriteLine("Hybrid -");
            _Hybrid = Console.ReadLine();
        }
        public override void print()
        {
            Console.WriteLine();
            Console.WriteLine($"Vert - {_Vert}");
            Console.WriteLine($"Street - {_Street}");
            Console.WriteLine($"Hybrid - {_Hybrid}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many skaters blud?");
            int maxSka;
            while (!int.TryParse(Console.ReadLine(), out maxSka))
                Console.WriteLine("Bruh enter a real number smhhh");
            Skaters[] ska = new Skaters[maxSka];
            Console.WriteLine("How many styles of skating?");
            int maxSty;
            while (!int.TryParse(Console.ReadLine(), out maxSty))
                Console.WriteLine("You're killing me smalls, enter something real!");
            Styles[] sty = new Styles[maxSty];
            int choice, rec, type;
            int skaCounter = 0, styCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("1 for Skaters, 2 for Styles");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("OMG bruh hit 1 or 2, skaters or styles..");
                try
                {
                    switch (choice)
                    {
                        case 1:
                            if (type == 1)
                            {
                                if (skaCounter <= maxSka)
                                {
                                    ska[skaCounter] = new Skaters();
                                    ska[skaCounter].addChange();
                                    skaCounter++;
                                }
                                else
                                    Console.WriteLine("Cannot add any more bruh!");

                            }
                            else
                            {
                                if (styCounter <= maxSty)
                                {
                                    sty[styCounter]= new Styles();
                                    sty[styCounter].addChange();
                                    styCounter++;
                                }
                                else
                                    Console.WriteLine("Cant put any more numbers blud");
                            }
                            break;
                        case 2:
                            Console.Write("1 to change skaters, 2 to change styles");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter data you want changed");
                            rec--;
                            if (type == 1)
                            {
                                while (rec > skaCounter - 1 || rec < 0)
                                {
                                    Console.Write("invalid number dawg go again!");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter data you want changed ");
                                    rec--;
                                }
                                ska[rec].addChange();
                            }
                            else
                            {
                                while (rec > styCounter - 1 || rec < 0)
                                {
                                    Console.Write("Horrible number choice what else you got?");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter data you want changed");
                                    rec--;
                                }
                                sty[rec].addChange();
                            }
                            break;
                        case 3:
                            if (type == 1)
                            {
                                for (int i = 0; i < skaCounter; i++)
                                    ska[i].print();
                            }
                            else
                            {
                                for (int i = 0; i < styCounter; i++)
                                    sty[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }

        private static int Menu()
        {
            Console.WriteLine("Select from the menu BLUD");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}
