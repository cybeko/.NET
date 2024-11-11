using Generic;
using hw21_generic;

//1
Oceanarium<SeaCreature> oceanarium = new Oceanarium<SeaCreature>(5);
oceanarium.AddCreature(new Fish("Clown Fish"));
oceanarium.AddCreature(new Crustacean("Shrimp"));
oceanarium.AddCreature(new Mammal("Dolphin"));

oceanarium.PrintAllCreatures();

//2
FootballTeam<FootballPlayer> team = new FootballTeam<FootballPlayer>(3, "Team One");

FootballPlayer player1 = new FootballPlayer("John", "Doe", 30);
FootballPlayer player2 = new FootballPlayer("Jane", "Doe", 24);

team.AddPlayer(player1);
team.AddPlayer(player2);

team.PrintAllPlayers();

//3

Cafe<Worker> cafe = new Cafe<Worker>(5, "Iris");

Worker worker1 = new Worker("John", "Doe", 30);
Worker worker2 = new Worker("Jane", "Doe", 24);

cafe.AddWorker(worker1);
cafe.AddWorker(worker2);

cafe.PrintAllPlayers();