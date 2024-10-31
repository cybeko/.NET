using BuildingHouse;

House house = new House();
Worker[] workers = {
    new Worker("Jimmy", "Doe"),
    new Worker("Anya", "Doe"),
    new Worker("Swansea", "Doe"),
    new Worker("Daisuke", "Doe")
};
TeamLeader teamLeader = new TeamLeader("Curly", "Doe");
Team team = new Team(workers, teamLeader, house);

team.BeginConstruction();