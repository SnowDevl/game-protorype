namespace prototype
{
    public class Enemy : Character
    {

        public Enemy()
        {
            health = 100;
            damage = 10;
            xpDrop = 20;
        }

        public void Attack(Character target)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"the enemy hited you and dealth {damage} damage!");
            Console.ResetColor();
            target.TakeDamage(damage);
            Thread.Sleep(100);
        }

    }

    public class Orc : Enemy
    {
        public Orc()
        {
            health = 60;
            damage = 7;
            xpDrop = 40;
        }
    }

    public class Goblin : Enemy
    {
        public Goblin()
        {
            health = 40;
            damage = 3;
            xpDrop = 30;
        }
    }

    public class Troll : Enemy
    {
        public Troll()
        {
            health = 80;
            damage = 10;
            xpDrop = 60;
        }
    }

    public class Dragon : Enemy
    {
        public Dragon()
        {
            health = 150;
            damage = 20;
            xpDrop = 80;
        }
    }

    public class Griph : Enemy
    {
        public Griph()
        {
            health = 120;
            damage = 15;
            xpDrop = 100;
        }
    }

    public class AncientOne : Enemy
    {
        public AncientOne()
        {
            health = 200;
            damage = 25;
            xpDrop = 140;
        }
    }

    public class Demon : Enemy
    {
        public Demon()
        {
            health = 180;
            damage = 30;
            xpDrop = 170;
        }
    }

    public class LordOfTheChains : Enemy
    {
        public LordOfTheChains()
        {
            health = 250;
            damage = 35;
            xpDrop = 180;
        }
    }

    public class TheKingInYellow : Enemy
    {
        public TheKingInYellow()
        {
            health = 400;
            damage = 50;
            xpDrop = 200;
        }
    }
}