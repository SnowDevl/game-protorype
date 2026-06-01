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
            xpDrop = 20;
        }
    }

    public class Goblin : Enemy
    {
        public Goblin()
        {
            health = 40;
            damage = 3;
            xpDrop = 10;
        }
    }

    public class Troll : Enemy
    {
        public Troll()
        {
            health = 80;
            damage = 10;
            xpDrop = 30;
        }
    }

    public class Dragon : Enemy
    {
        public Dragon()
        {
            health = 150;
            damage = 20;
            xpDrop = 50;
        }
    }

    public class Griph : Enemy
    {
        public Griph()
        {
            health = 120;
            damage = 15;
            xpDrop = 40;
        }
    }

    public class AncientOne : Enemy
    {
        public AncientOne()
        {
            health = 200;
            damage = 25;
            xpDrop = 60;
        }
    }

    public class Demon : Enemy
    {
        public Demon()
        {
            health = 180;
            damage = 30;
            xpDrop = 70;
        }
    }

    public class LordOfTheChains : Enemy
    {
        public LordOfTheChains()
        {
            health = 250;
            damage = 35;
            xpDrop = 80;
        }
    }

    public class TheKingInYellow : Enemy
    {
        public TheKingInYellow()
        {
            health = 400;
            damage = 50;
            xpDrop = 100;
        }
    }
}