using hw13_AnimalWorld;


Continent africa = new Africa();
AnimalWorld africanWorld = new AnimalWorld(africa);

africanWorld.FeedAll();

Continent northAmerica = new NorthAmerica();
AnimalWorld americanWorld = new AnimalWorld(northAmerica);

americanWorld.FeedAll();