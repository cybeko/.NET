using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15
{
    internal class Book : ICloneable, IComparable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public int YearPublished { get; set; }
        public Book()
        {
            Title = string.Empty;
            Author = string.Empty;
            Description = string.Empty;
            PageCount = 0;
            YearPublished = 0;
        }

        public Book(string title, string author, string description, int pageCount, int yearPublished)
        {
            Title = title;
            Author = author;
            Description = description;
            PageCount = pageCount;
            YearPublished = yearPublished;
        }

        public object Clone()
        {
            return new Book(Title, Author, Description, PageCount, YearPublished);
        }

        public int CompareTo(object? obj)
        {
            if (obj is Book otherBook)
                return Title.CompareTo(otherBook.Title);
            throw new NotImplementedException();
        }

        public class SortByTitle : IComparer
        {
            int IComparer.Compare(object? obj1, object? obj2)
            {
                if (obj1 is Book book1 && obj2 is Book book2)
                    return book1.Title.CompareTo(book2.Title);
                throw new NotImplementedException();
            }
        }
        public class SortByAuthor : IComparer
        {
            int IComparer.Compare(object? obj1, object? obj2)
            {
                if (obj1 is Book book1 && obj2 is Book book2)
                    return book1.Author.CompareTo(book2.Author);
                throw new NotImplementedException();
            }
        }
        public class SortByYearPublished : IComparer
        {
            int IComparer.Compare(object? obj1, object? obj2)
            {
                if (obj1 is Book book1 && obj2 is Book book2)
                    return book1.YearPublished.CompareTo(book2.YearPublished);
                throw new NotImplementedException();
            }
        }

        public void Output()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Page Count: {PageCount}");
            Console.WriteLine($"Year Published: {YearPublished}");
        }
    }

}
