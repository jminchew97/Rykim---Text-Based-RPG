using System;


class MainClass {
  
  public static void Main (string[] args) 
  {
    // Create player object
    Player player = new Player();
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
      player.name = Console.ReadLine();
      print($"welcome to Ryskim {player.name}");
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
      printStats(player.name, player.money, player.xp, player.maxXp);

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
            int hp = random(player.maxHp, 5); // Generating enemy health
            int maxHP = hp;
            int attack = random(hp/2 + 1, 1);
            print("Enemy Name:" + enemyName + " | Enemy HP:" + hp.ToString() + " | Enemy Attack:" + attack);
            Console.ReadKey();
            while (hp > 0 & player.hp > 0)
            {
              clear();
  
              // Generate random hits based on both attack levels
              int playerHit = random(player.attack, 1 );
              int enemyHit = random(attack, 1);
              
              // Print battle stats 
              print($"{player.name} HP:{player.hp}|{player.maxHp}  /  {enemyName} HP:{hp}|{maxHP}");
              hp -= playerHit;
              print("You hit a " + playerHit + ".");
              // Check if enemy is dead
              if (hp <= 0)
              {
                break;
              }
              
              print(enemyName + " hit a " + enemyHit + ".");

              // Deal damage to both opponents
              
              player.hp -= enemyHit;

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
              player.xp += addXP;
              player.money += addCoins;

              // Player levels up
              if (player.xp >= player.maxXp)
              {
                // Level up attack & hp
                player.attack += 1;
                player.maxHp += 1;

                // Change maxXP and keep leftover xp
                int leftoverXP = 0;
                if (player.xp > player.maxXp)
                {
                  leftoverXP = player.xp - player.maxXp;
                }
                player.xp = leftoverXP;
                player.maxXp += 10;
                
                
                print($"Contratulations, you leveled up attack to {player.attack} and hp to {player.hp}.");
                print($"debug: attack:{player.attack}  HP:{player.maxHp}   maxXP:{player.maxXp}   xp:{player.xp}   ");
                Console.ReadKey();
              }

              // Adding coins to player
              player.money += addCoins;

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
  public static void printStats(string name, int money, int xp, int maxXp)
  {
    Console.WriteLine("- - - - - - - - - - - - - - - - - - - ");
    Console.WriteLine($"|{name} | ${money} | XP:{xp}/{maxXp}");
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

    public string name = "Player";
    public int money = 10;
    public int attack = 10;
    public int hp = 10;
    public int maxHp = 10;
    public int xp = 0;
    public int maxXp = 10;

    public Player()
    {
      // stuff
    }
    
}