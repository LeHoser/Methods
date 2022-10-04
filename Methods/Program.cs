using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class Program
    {
        static int playerHp;
        static int enemyHp;
        static Random rdn = new Random();
        static float criticalHit;
        static int bigHeal;

        static void Main(string[] args)
        {
            playerHp = 40;
            int playerAttack;
            playerAttack = 3;
            int extraDamage;
            extraDamage = 2;
            int playerCombinedDamage;
            playerCombinedDamage = playerAttack + extraDamage;

            enemyHp = 40;
            int enemyAttack;
            enemyAttack = 3;
            int enemyExtraDamage;
            enemyExtraDamage = 1;
            int enemyCombinedDamage;
            enemyCombinedDamage = enemyAttack + extraDamage;

           
            ShowHud();

            while(playerHp > 0 && enemyHp > 0)
            {
                Console.WriteLine("=== Enter 'a' to attack, 's' to take damage, or 'h' to heal ==");

                string choice = Console.ReadLine();
                criticalHit = rdn.Next(1, 10);

                if (choice == "a" && criticalHit >= 7)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Player landed a critical hit!");
                    enemyHp -= playerCombinedDamage;
                    Console.WriteLine("The player attacks the enemy and deals " + playerCombinedDamage + " damage!");
                    ShowHud();
                }

                else if(choice == "a" && criticalHit < 7)
                {
                    enemyHp -= playerAttack;
                    Console.WriteLine("--------------------");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("The player attacks the enemy and deals " + playerAttack + " damage!");
                    ShowHud();
                }
                


                if(choice == "s" && criticalHit == 4)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Enemy landed a critical hit!");
                    playerHp -= enemyCombinedDamage;
                    Console.WriteLine("The enemy attacks the player and deals " + enemyCombinedDamage + " damage!");
                    ShowHud();
                }

                if(choice == "s" && criticalHit > 7)
                {
                    //playerHp -= enemyAttack;
                    Console.WriteLine("--------------------");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("The enemy misses!");
                    ShowHud();
                }
                else if(choice == "s" && criticalHit < 4)
                {
                    playerHp -= enemyAttack;
                    Console.WriteLine("--------------------");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("The enemy attacks the player and deals " + enemyCombinedDamage + " damage!");
                    ShowHud();
                }

                if(choice == "h")
                {
                    Heal();
                    ShowHud();
                }
            }
        }

        static void ShowHud()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");
            Console.WriteLine("Player Health: " + playerHp);
            Console.WriteLine();
            Console.WriteLine("Enemy Health: " + enemyHp);
            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");
        }

        static void Heal()
        {
            bigHeal = rdn.Next(1, 10);

            if (bigHeal >= 5)
            {
                playerHp += 4;
                Console.WriteLine("Player restored " + 4 + " health");
            }
            else if(bigHeal < 5)
            {
                playerHp += 2;
                Console.WriteLine("Player restored " + 2 + " health");
            }
        }
    }    
}
