using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Program
{
    List<Enemy> enemies = new List<Enemy>()
    {
         Orc(namespace = "Orc"),
        new Goblin(namespace = "Goblin"),
        new Throll(namespace = "Throll"),
        new Dragon(namespace = "Dragon"),
        new Griph(namespace = "Griph"),
        new AncientOne(namespace = "AncientOne"),
        new Demon(namespace = "Demon"),
        new LordOfTheChains(namespace = "LordOfTheChains"),
        new TheKingInYellow(namespace = "TheKingInYellow")
    };
    public static void Main()
    {
        Console.WriteLine("welcome to the game!");
        Console.WriteLine("you are a brave adventurer, exploring an ancient dungeon filled with dangerous enemies. your goal is to survive and defeat as many enemies as possible!");
        Console.WriteLine("press any key to start the game...");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("you enter the dungeon and start exploring...");
        Console.WriteLine("on your way, you find a health potion that restores 20 health points. that potion will be useful in your battles againist the enemies!");


        Player player = new Player();
        Enemy enemy = new Enemy();
        Console.WriteLine("\nan enemy appears!");

        Console.WriteLine($"Player health: {player.health}");
        Console.WriteLine($"Enemy health: {enemy.health}");

        Console.WriteLine("chose your action");
        Console.WriteLine("1 - battle againist the enemy");
        Console.WriteLine("2 - run away");
        Console.WriteLine("3 - use health potion");

        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine("you chose to battle the enemy!");
                while (player.health > 0 && enemy.health > 0)
                {
                    enemy.health -= player.damage;
                    Console.WriteLine($"you dealt {player.damage} damage to the enemy!");
                    if (enemy.health <= 0)
                    {
                        Console.WriteLine("you defeated the enemy!");
                        break;
                    }

                    player.health -= enemy.damage;
                    Console.WriteLine($"the enemy dealt {enemy.damage} damage to you!");
                    if (player.health <= 0)
                    {
                        Console.WriteLine("you were defeated by the enemy!");
                        break;
                    }  

                    }
                    break;
                case "2":
                    Console.WriteLine("you chose to run away, you are a coward!");
                    break;
                case "3":
                    Console.WriteLine("you chose to use the health potion, you healed some health points!");
                    player.health += 20;
                    Console.WriteLine($"your health is now {player.health}");
                    break;
                default:
                    Console.WriteLine("invalid choise, you lose!");
                    break;

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

    public void TakeDamage(int damage){
    Console.WriteLine($"you took {damage} damage!");
    health = Math.Max(0, health -= damage);
    }

public class Player : Character
{


    
    public Player()
    {
        health = 100;
        damage = 10;
        xp = 0;
        lv = 1;

    }

    public void Attack(Character target){
            Console.WriteLine($"you attacket the enemy and dealth {damage} damage!");
            target.TakeDamage(damage);
        }

}

public void LevelUp()
    {
        if (xp >= 100)
        {
            lv++;
            xp = 0;
            damage += 5;
            health += 20;
            Console.WriteLine($"you leveled up! you are now level {lv}" );
        }
    }

public void GainXP(int amount)
    {
        xp += amount;
        Console.WriteLine($"the eb=nemy was defeated and you gained {amount} xp!");
        LevelUp();
    }

public void criticalStrike()
    {
        Random rand = new Random();

        if (rand.Next(0, 100) <= 20)
        {
            critDamage = damage * 2;
            Console.WriteLine($"you hited a critical strite and dealth {critDamage} damage!");
        }
        else
        {
            Console.WriteLine("you missed the critical strike! you dealth your normal damage!");
        }
    }

public class Enemy : Character
{

    public Enemy()
    {
        health = 100;
        damage = 10;
    }

    public void Attack(Character target)
    {
        Console.WriteLine($"the enemy attacket you and dealth {damage} damage!");
        target.TakeDamage(damage);
    }

}

public class Orc : Enemy
{
    public Orc()
    {
        health = 60;
        damage = 7;
    }
}

public class Goblin : Enemy
{
    public Goblin()
    {
        health = 40;
        damage = 3;
    }
}

public class Throll : Enemy
{
    public Throll()
    {
        health = 80;
        damage = 10;
    }
}

public class Dragon : Enemy
{
    public Dragon()
    {
        health = 150;
        damage = 20;
    }
}

public class Griph : Enemy
{
    public Griph()
    {
        health = 120;
        damage = 15;
    }
}

public class AncientOne : Enemy
{
    public AncientOne()
    {
        health = 200;
        damage = 25;
    }
}

public class Demon : Enemy
{
    public Demon()
    {
        health = 180;
        damage = 30;
    }
}

public class LordOfTheChains : Enemy
{
    public LordOfTheChains()
    {
        health = 250;
        damage = 35;
    }
}

public class TheKingInYellow : Enemy
{
    public TheKingInYellow()
    {
        health = 400;
        damage = 50;
    }
}
}