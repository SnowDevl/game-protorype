namespace prototype
{
    public class Player : Character
    {
        public Player()
        {
            health = 100;
            MaxHealth = 100;
            damage = 10;
            xp = 0;
            lv = 1;
            heal = 20;
            potions = 3;
        }

        public void Attack(Character target){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"you hited the enemy and dealth {damage} damage!");
                Console.ResetColor();
                target.TakeDamage(damage);
                Thread.Sleep(100);
            }


    }
}