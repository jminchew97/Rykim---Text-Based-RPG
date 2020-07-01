using System;


class MainClass {
  
  public static void Main (string[] args) 
  {
    string playerName = "Player";
    int money = 10;
    int playerAttack = 10;
    int playerHP = 10;
    int playerMaxHP = 10;
    int xp = 0;
    int maxXP = 10;
    bool exitIntro = false;



    // Dungeon variables
    string[] monsterNames = {"Vortexstrike","Fogmask","Rustpod","Sorrowscreamer","Volatile Eyes","Bold Wailer","Mean Monster","Lone Phantom Hippo","Onyx Razor Lion","Arctic Doom Owl"};

    // Intro to Ryskim
    while (exitIntro == false)  
    {
      clear();
      Console.WriteLine("Welcome to the world of Ryskim!");
      Console.WriteLine("What is your name fellow traveler?");
      // Get name of player
      playerName = Console.ReadLine();
      print("welcome to Ryskim " + playerName + ".");
      Console.Clear();

      // Exiting intro
      exitIntro = true;

    }

    // Main game loop
    bool exitGame = false;
    while (exitGame == false)
    {
      clear();
      
      string menuChoice;
      // Dash board
      printStats(playerName, money, xp, maxXP);

      print("\nWhere would you like to go?");

      print("1.Dungeon\n2.Store\n3.Forest");
      
      // Take user input on where to travel to
      menuChoice = Console.ReadLine();
      print(menuChoice);

      
      if (menuChoice == "1")  // The Dungeon
      {
        bool exitDungeon = false;
        while (exitDungeon == false)
        {
          clear();
          print("*you enter a dark pit...");
          Console.ReadKey();
          print("*you come out the other side in a very dim lit dungeon*");
          Console.ReadKey();
          clear();

          print("Marcus: Welcome treveller...you lookin' to rough up some beasts?");
          print("1.Yes  /  2.No");
          string userChoice = Console.ReadLine();

          // The player enters a battle with a monster
          if (userChoice == "1") 
          {
            clear();
            // Create new random object
            
            // Creating all enemy variables
            int randomNumber = random(monsterNames.Length);
            string enemyName = monsterNames[randomNumber]; // Creating monster name
            int hp = random(playerMaxHP, 5); // Generating enemy health
            int maxHP = hp;
            int attack = random(hp/2 + 1, 1);
            print("Enemy Name:" + enemyName + " | Enemy HP:" + hp.ToString() + " | Enemy Attack:" + attack);
            Console.ReadKey();
            while (hp > 0 & playerHP > 0)
            {
              clear();
  
              // Generate random hits based on both attack levels
              int playerHit = random(playerAttack, 1 );
              int enemyHit = random(attack, 1);
              
              // Print battle stats 
              print($"{playerName} HP:{playerHP}|{playerMaxHP}  /  {enemyName} HP:{hp}|{maxHP}");
              hp -= playerHit;
              print("You hit a " + playerHit + ".");
              // Check if enemy is dead
              if (hp <= 0)
              {
                break;
              }
              
              print(enemyName + " hit a " + enemyHit + ".");

              // Deal damage to both opponents
              
              playerHP -= enemyHit;

              Console.ReadKey();
            }
            
            // One of the opponents died in battle
            if (hp <= 0) // Enemy died
            {
              clear();
              // Generating xp
              int addXP = random(maxHP);
              // Generating coins
              int addCoins = random(attack);

              print($"You killed a {enemyName}");
              print($"{enemyName} dropped {addCoins} coins.");
              print($"You gained {addXP} XP!");
              
              // Add xp and coins to player
              xp += addXP;
              money += addCoins;

              // Player levels up
              if (xp >= maxXP)
              {
                // Level up attack & hp
                playerAttack += 1;
                playerMaxHP += 1;

                // Change maxXP and keep leftover xp
                int leftoverXP = 0;
                if (xp > maxXP)
                {
                  leftoverXP = xp - maxXP;
                }
                xp = leftoverXP;
                maxXP += 10;
                
                
                print($"Contratulations, you leveled up attack to {playerAttack} and hp to {playerHP}.");
                print($"debug: attack:{playerAttack}  HP:{playerMaxHP}   maxXP:{maxXP}   xp:{xp}   ");
                Console.ReadKey();
              }

              // Adding coins to player
              money += addCoins;

            }
            else // You died
            {
              print($"You were slayed by a {enemyName}");
              
            }
            Console.ReadKey();
          }
          else if (userChoice == "2")
          {
            print("You exit the dungeon.");
            exitDungeon = true;
          }
            // battle sequence
            
        }
      }
      else if (menuChoice == "2") // The store
      {
        bool exitStore = false;
        while (!exitStore)
        {
          print("Welcome to the General Store, how may I help ya?");
          Console.ReadKey();
        }

      }
    }
      
  }
  // Functions
  public static void printStats(string name, int money, int xp, int maxXP)
  {
    Console.WriteLine("- - - - - - - - - - - - - - - - - - - ");
    Console.WriteLine($"|{name} | ${money} | XP:{xp}/{maxXP}");
    Console.WriteLine("- - - - - - - - - - - - - - - - - - - ");
  }

  public static void print(string text)
  {
    Console.WriteLine(text);
  }

  public static void clear()
  {
    Console.Clear();
  }
  public static int random(int max, int min=1)
  {
      // stuff
      var rand = new Random();

      int number = rand.Next(min, max);

      return number;
  }

}

class Player {

    string name = "Player";
    int money = 10;
    int attack = 10;
    int hp = 10;
    int maxHp = 10;
    int xp = 0;
    int maxXp = 10;

    Player(string playerName)
    {
      name = playerName;
    }
    
}