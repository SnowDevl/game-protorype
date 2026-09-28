using System;
using System.Collections.Generic;
using System.Drawing;

namespace prototype
{
    public class Program
    {
        static Player player = new Player();
        static Random rand = new Random();
        
        static List<Type> enemies = new List<Type>()
        {
            typeof(Orc),
            typeof(Goblin),
            typeof(Troll),
            typeof(Dragon),
            typeof(Griph),
            typeof(AncientOne),
            typeof(Demon),
            typeof(LordOfTheChains),
            typeof(TheKingInYellow)
        };
        public static void Main()
        {
            
            WelcomeGame();
            StartBattle();
        }

        static void WelcomeGame()
        {
            Console.Clear();

            Console.WriteLine("welcome to the game!");
            Console.WriteLine("you are a brave adventurer, exploring an ancient dungeon filled with dangerous enemies. your goal is to survive and defeat as many enemies as possible!");
            Console.WriteLine("press any key to start the game...");

            Console.ReadKey();
        }

        static public Enemy SpawnEnemy(int level)
        {
            if (level <= 3)
            {

                return (Enemy)Activator.CreateInstance(enemies[rand.Next(0, 3)])!;
                
            }
            else if (level <= 6)
            {
                return (Enemy)Activator.CreateInstance(enemies[rand.Next(0, 6)])!;

            }
            else if (level <= 9)
            {
                return (Enemy)Activator.CreateInstance(enemies[rand.Next(0, 9)])!;

            }
            else
            {
                return (Enemy)Activator.CreateInstance(enemies[rand.Next(0, enemies.Count)])!;

            }
        }

        static void StartBattle()
        {
            Console.Clear();
            Console.WriteLine("you enter the dungeon and start exploring...");
            Console.WriteLine("on your way, you find a health potion that restores 20 health points. that potion will be useful in your battles againist the enemies!");

            while (player.health > 0){
            Enemy enemy = SpawnEnemy(player.lv);
            Console.Write($"\nan ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{enemy.GetType().Name}");
            Console.ResetColor();
            Console.Write($" appears!");
            Console.WriteLine(" ");

            
            Console.Write($"Player health: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{player.health}");
            Console.ResetColor();


            Console.Write($"\nEnemy health: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{enemy.health}\n");
            Console.ResetColor();
            
            Console.WriteLine(" ");

            Console.WriteLine("choose your action");
            Console.WriteLine("1 - battle against the enemy");
            Console.WriteLine("2 - run away");
            Console.WriteLine("3 - use health potion");
            Console.WriteLine(" ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("you chose to battle the enemy!");
                    while (player.health > 0 && enemy.health > 0)
                    {
                        Console.WriteLine("choose your action");
                        Console.WriteLine("1 - attack");
                        Console.WriteLine("2 - use health potion");
                        Console.WriteLine(" ");
                        switch (Console.ReadLine())

                        {
                            case "1":
                                player.Attack(enemy);
                                Console.Write($"\nthe enemy health is now ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"{enemy.health}\n");
                                Console.ResetColor();
                                Console.WriteLine("--------------------------------");
                                Console.WriteLine(" ");

                                break;
                            case "2":
                                if (player.potions > 0){
                                    player.potions --;
                                    player.Heal(player.heal);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    
                                    Console.WriteLine($"\nyou used a health potion, your health is now {player.health} you have {player.potions} potions now ");
                                    Console.ResetColor();

                                    Console.WriteLine(" ");
                                    
                                    }
                                else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGray;

                                        Console.WriteLine("you don't have potions anymore");

                                        Console.ResetColor();
                                    }
                                break;
                                
                            default:
                                Console.WriteLine("\ninvalid choice, you blewup and died :)");
                                player.health = 0;
                                break;
                        }
                        Console.WriteLine("press any key to continue");
                        Console.ReadLine();
                        Console.Clear();
                        if (enemy.health <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("you defeated the enemy!");
                            player.GainXP(enemy.xpDrop);
                            Console.WriteLine(" ");
                            Console.ResetColor();
                            break;
                        }

                        Thread.Sleep(500);

                        enemy.Attack(player);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"the enemy dealt {enemy.damage} damage to you!");
                        Console.ResetColor();
                        Console.Write($"\nyour health is now ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{player.health}\n");
                        Console.ResetColor();
                        Console.WriteLine("================================");
                        Console.WriteLine(" ");
                        if (player.health <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;

                            Console.WriteLine("you were defeated by the enemy!");
                            Console.WriteLine("game over!");
                            Console.ResetColor();
                            
                            Console.WriteLine("Thanks for playing! :)");
                            break;
                        }  

                        Thread.Sleep(500);

                    }
                    break;
                    case "2":
                        Console.WriteLine("you choose to run away, you are a coward!");
                        break;
                    case "3":
                        player.Heal(player.heal);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("you chose to use the health potion, you healed some health points!");
                        Console.WriteLine($"your health is now {player.health}");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("invalid choice, you blewup and died :)");
                        player.health = 0;
                        Console.ResetColor();
                        break;

            }
            }
        }
        }

    public class Character
    {
        public int MaxHealth;
        public int health;
        public int damage;
        public int xp;
        public int lv;
        public int critDamage;
        public int heal;
        public int xpDrop;
        public int potions;
        static Random rand = new Random();

        public void TakeDamage(int damage){

            if (rand.Next(0, 101) <= 20)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                critDamage = damage * 2;
                Console.WriteLine($"hited a critical strite and dealt {critDamage} damage!");
                health = Math.Max(0, health -= critDamage);
                Console.WriteLine(" ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("you missed the critical strike! you dealth your normal damage!");
                critDamage = damage;
                health = Math.Max(0, health -= damage);
                Console.WriteLine(" ");
                Console.ResetColor();
            }

        Console.WriteLine($"dealed {critDamage} damage!");
        }

    


    public void Heal(int amount)
        {
            health = Math.Min(MaxHealth, health + amount);
        }

    public void LevelUp()
        {
            while (xp >= 100)
            {
                lv++;
                xp -= 100;
                damage += 5;
                MaxHealth += 20;
                health = Math.Min(MaxHealth, health + 20);
                heal += 5;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"you leveled up! you are now level {lv}" );
                Console.ResetColor();
            }
        }

    public void GainXP(int amount)
        {
            xp += amount;
            int xpNeeded = 100 - xp;
            Console.WriteLine($"the enemy was defeated and you gained {amount} xp!");
            Console.WriteLine($"you need {xpNeeded} xp to level up!");
            LevelUp();
        }

    }   
}