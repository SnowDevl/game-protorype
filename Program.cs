using System;
using System.Collections.Generic;

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
                
                throw new Exception("invalid Level");
                
            }
            else if (level <= 6)
            {
                return (Enemy)Activator.CreateInstance(enemies[rand.Next(0, 6)])!;

                throw new Exception("invalid Level");
            }
            else if (level <= 9)
            {
                return (Enemy)Activator.CreateInstance(enemies[rand.Next(0, 9)])!;

                throw new Exception("invalid Level");
            }
            else
            {
                return (Enemy)Activator.CreateInstance(enemies[rand.Next(0, enemies.Count)])!;

                throw new Exception("invalid Level");
            }
        }

        static void StartBattle()
        {
            Console.Clear();
            Console.WriteLine("you enter the dungeon and start exploring...");
            Console.WriteLine("on your way, you find a health potion that restores 20 health points. that potion will be useful in your battles againist the enemies!");

            while (player.health > 0){
            Enemy enemy = SpawnEnemy(player.lv);
            Console.WriteLine($"\nan {enemy.GetType().Name} appears!");
            Console.WriteLine(" ");

            Console.WriteLine($"Player health: {player.health}");
            Console.WriteLine($"Enemy health: {enemy.health}");
            Console.WriteLine(" ");

            Console.WriteLine("choose your action");
            Console.WriteLine("1 - battle againist the enemy");
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
                                Console.WriteLine($"\nthe enemy health is now {enemy.health}");
                                Console.WriteLine("--------------------------------");
                                Console.WriteLine(" ");
                                break;
                            case "2":
                                Console.WriteLine($"\nyou used a health potion, your health is now {player.health +20} ");
                                player.health += 20;
                                Console.WriteLine(" ");
                                break;
                            default:
                                Console.WriteLine("\ninvalid choice, you blewup and died :)");
                                player.health = 0;
                                break;
                        }
                        if (enemy.health <= 0)
                        {
                            Console.WriteLine("you defeated the enemy!");
                            player.GainXP(enemy.xpDrop);
                            Console.WriteLine(" ");
                            break;
                        }

                        Thread.Sleep(50);

                        enemy.Attack(player);
                        Console.WriteLine($"the enemy dealt {enemy.damage} damage to you!");
                        Console.WriteLine($"\nyour health is now {player.health}");
                        Console.WriteLine("================================");
                        Console.WriteLine(" ");
                        if (player.health <= 0)
                        {
                            Console.WriteLine("you were defeated by the enemy!");
                            Console.WriteLine("game over!");
                            Console.WriteLine("Thanks for playing! :)");
                            break;
                        }  

                        Thread.Sleep(50);

                    }
                    break;
                    case "2":
                        Console.WriteLine("you choose to run away, you are a coward!");
                        break;
                    case "3":
                        Console.WriteLine("you chose to use the health potion, you healed some health points!");
                        player.health += 20;
                        Console.WriteLine($"your health is now {player.health}");
                        break;
                    default:
                        Console.WriteLine("invalid choice, you blewup and died :)");
                        break;

            }
            }
        }
        }

    public class Character
    {
        public int health;
        public int damage;
        public int xp;
        public int lv;
        public int critDamage;
        public int heal;
        public int xpDrop;
        static Random rand = new Random();

        public void TakeDamage(int damage){

            if (rand.Next(0, 101) <= 20)
            {
                critDamage = damage * 2;
                Console.WriteLine($"you hited a critical strite and dealth {critDamage} damage!");
                health = Math.Max(0, health -= critDamage);
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine("you missed the critical strike! you dealth your normal damage!");
                critDamage = damage;
                health = Math.Max(0, health -= damage);
                Console.WriteLine(" ");
            }

        Console.WriteLine($"dealed {critDamage} damage!");
        }

    

    public void LevelUp()
        {
            while (xp >= 100)
            {
                lv++;
                xp -= 100;
                damage += 5;
                health += 20;
                Console.WriteLine($"you leveled up! you are now level {lv}" );
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

    public void criticalStrike()
        {
        }

    }   
}