namespace prototype
{
    public class Player : Character
    {
        public Player()
        {
            health = 100;
            damage = 10;
            xp = 0;
            lv = 1;
            heal = 20;
        }

        public void Attack(Character target){
                Console.WriteLine($"you attacket the enemy and dealth {damage} damage!");
                target.TakeDamage(damage);
            }


    }
}