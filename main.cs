using System;


class MainClass {
  
  public static void Main (string[] args) {
    string name = "Player";
    int money = 10;
    int playerAttack = 10;
    int playerHP = 10;
    bool exitIntro = false;



    // Dungeon variables
    string[] monsterNames = {"Vortexstrike","Fogmask","Rustpod","Sorrowscreamer","Volatile Eyes","The Bold Wailer","The Mean Monster","The Lone Phantom Hippo","The Onyx Razor Lion","The Arctic Doom Owl"};

    // Intro to Ryskim
    while (exitIntro == false)  
    {
      clear();
      Console.WriteLine("Welcome to the world of Ryskim!");
      Console.WriteLine("What is your name fellow traveler?");
      // Get name of player
      name = Console.ReadLine();
      print("welcome to Ryskim " + name + ".");
      Console.Clear();

      // Exiting intro
      exitIntro = true;

    }

    // Main game loop
    bool exitGame = false;
    while (exitGame == false)
    {
      
      string menuChoice;
      // Dash board
      printStats(name, money);

      print("\nWhere would you like to go?");

      print("1. Dungeon");
      print("2. Forest");
      print("3. ??");
      print("4. ??");
      print("5. ??");
      // Take user input on where to travel to
      menuChoice = Console.ReadLine();
      print(menuChoice);

      
      if (menuChoice == "1")  // The Dungeon
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
        if (userChoice == "1") {
          clear();
          // Create new random object
          var rand = new Random();
          // Creating all enemy variables
          int randomNumber = rand.Next(monsterNames.Length);
          string enemyName = monsterNames[randomNumber]; // Creating monster name
          int hp = rand.Next(1, playerHP); // Generating enemy health
          int attack = rand.Next(1, hp/2);
          print("Enemy Name:" + enemyName + " | Enemy HP:" + hp.ToString() + " | Enemy Attack:" + attack);
          Console.ReadKey();
          //while ()
        }
        


      }
      
      Console.ReadKey();
    }
  }
  
  public static void printStats(string name, int money)
  {
    Console.WriteLine("- - - - - - - - - - - - - - - - - - - ");
    Console.WriteLine("| " + name + " | $" + money + " |");
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
}


  
