using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15
{
    class Library : IEnumerable, IEnumerator
    {
        Book[] arr;
        int curpos = -1;
        public Library(int len)
        {
            arr = new Book[len];
            for (int i = 0; i < len; i++)
            {
                arr[i] = new Book();
            }
        }

        public Library() : this(1) { }

        public Library(Book[] clubs)
        {
            arr = new Book[clubs.Length];
            for (int i = 0; i < clubs.Length; i++)
            {
                arr[i] = new Book(clubs[i].Title, clubs[i].Author, clubs[i].Description, clubs[i].PageCount, clubs[i].YearPublished);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public void Reset()
        {
            curpos = -1;
        }
        public object Current
        {
            get
            {
                return arr[curpos];
            }
        }

        public bool MoveNext()
        {
            if (curpos < arr.Length - 1)
            {
                curpos++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Output()
        {
            foreach (Book book in arr)
            {
                book.Output();
            }
        }
        public void LibSort()
        {
            Console.WriteLine("\nSorting by default");
            Array.Sort(arr);
        }

        public void LibSortByYear()
        {
            Console.WriteLine("\nSorting by year published");
            Array.Sort(arr, new Book.SortByYearPublished());
        }
        public void LibSortByAuthor()
        {
            Console.WriteLine("\nSorting by author");
            Array.Sort(arr, new Book.SortByAuthor());
        }
        public void LibSortByPublisher()
        {
            Console.WriteLine("\nSorting by title");
            Array.Sort(arr, new Book.SortByTitle());
        }
    }
}
