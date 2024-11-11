using GenericCollection;

//1
AccountManager accountManager = new AccountManager();

accountManager.AddEmployee("john231", "hello123");
accountManager.AddEmployee("alice1", "world097");

accountManager.EditEmployee("john231", "newpassword789");

string password = accountManager.GetPassword("john231");
Console.WriteLine(password);

accountManager.DeleteEmployee("alice1");
accountManager.DeleteEmployee("alice2");

//2

var dictionary = new EnglishFrenchDictionary();

dictionary.AddWord("hello", "bonjour");
dictionary.AddWord("hello", "salut", "amities", "he");
dictionary.SearchTranslation("hello");

dictionary.EditFrenchTranslation("hello", "hé", "hola");
dictionary.RemoveFrenchTranslation("hello", "hola");
dictionary.RemoveWord("world");
dictionary.SearchTranslation("hello");

//3
Cafe cafe = new Cafe();

cafe.Arrive(new Customer("John", false));
cafe.Arrive(new Customer("Alice", true));
cafe.Arrive(new Customer("Jane", false));
cafe.Arrive(new Customer("Jimbo", true));

cafe.ServeCustomer();
cafe.ServeCustomer();
cafe.ServeCustomer();
cafe.ServeCustomer();
cafe.ServeCustomer();