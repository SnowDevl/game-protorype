namespace prototype
{
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