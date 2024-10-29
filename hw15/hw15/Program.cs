using hw15;

Console.WriteLine("Hello, World!");
Book[] books = new Book[]
{
    new Book("A title", "A auth", "A desc", 180, 1925),
    new Book("B title", "C auth", "B desc", 220, 1930),
    new Book("C title", "D auth", "C desc", 300, 1945),
    new Book("D title", "E auth", "D desc", 150, 1980),
    new Book("E title", "F auth", "E desc", 250, 2000),
    new Book("F title", "G auth", "F desc", 350, 2010)
};

Library library = new Library(books);

Console.WriteLine("Books before sorting:");
library.Output();

library.LibSort();
library.Output();

library.LibSortByAuthor();
library.Output();

library.LibSortByYear();
library.Output();