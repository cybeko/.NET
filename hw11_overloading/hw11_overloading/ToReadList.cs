using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    internal class ToReadList
    {
        public string[] List { get; set; }
        public ToReadList()
        {
            List = new string[0];
        }
        public ToReadList(params string[] user_param)
        {
            List = new string[user_param.Length];
            for (int i = 0; i < user_param.Length; i++)
            {
                List[i] = user_param[i];
            }
        }
        public void DisplayList()
        {
            Console.WriteLine($"List of books: ");

            for (int i = 0; i < List.Length; i++)
            {
                if (List[i] != null)
                {
                    Console.WriteLine($"{i+1}. {List[i]}");
                }
            }
        }
        public string this[int id]
        {
            get
            {
                if (id >= 0 && id < List.Length)
                {
                    return List[id];
                }
                else
                {
                    throw new Exception($"\nInvalid index: {id}");
                }
            }
            set
            {
                if (id >= 0 && id < List.Length)
                {
                    List[id] = value;
                }
                else
                {
                    throw new Exception($"\nInvalid index: {id}");
                }
            }
        }
        public string this[string id]
        {
            get
            {
                if (!int.TryParse(id, out int i))
                    throw new Exception($"\nInvalid index: {id}");
                if (i >= 0 && i < List.Length)
                {
                    return List[i];
                }
                else
                {
                    throw new Exception($"\nInvalid index: {id}");
                }
            }
            set
            {
                if (!int.TryParse(id, out int i))
                    throw new Exception($"\nInvalid index: {id}");

                if (i >= 0 && i < List.Length)
                {
                    List[i] = value;
                }
                else
                {
                    throw new Exception($"\nInvalid index: {id}");
                }
            }
        }

        public static ToReadList operator +(ToReadList obj, string book_name)
        {
            int id = -1;
            for (int i = 0; i < obj.List.Length; i++)
            {
                if (obj.List[i] == null)
                {
                    id = i;
                    break;
                }
            }

            if (id != -1)
            {
                obj.List[id] = book_name;
            }
            else
            {
                string[] newList = new string[obj.List.Length + 1];
                for (int i = 0; i < obj.List.Length; i++)
                {
                    newList[i] = obj.List[i];
                }
                newList[newList.Length - 1] = book_name;
                obj.List = newList;
            }
            return obj;
        }

        public static ToReadList operator -(ToReadList obj, string book_name)
        {
            int book_id = Array.IndexOf(obj.List, book_name);

            if (book_id == -1)
            {
                Console.WriteLine($"Book \"{book_name}\" not found");
                return obj;
            }
            string[] newList = new string[obj.List.Length - 1];
            for (int i = 0, j = 0; i < obj.List.Length; i++)
            {
                if (i != book_id)
                {
                    newList[j++] = obj.List[i];
                }
            }
            obj.List = newList;
            return obj;
        }
        public static bool operator == (ToReadList obj1, ToReadList obj2)
        {
            if(obj1.List.Length == obj2.List.Length)
                return true;
            else return false;
        }

        public static bool operator !=(ToReadList obj1, ToReadList obj2)
        {
            return !(obj1 == obj2);
        }

        public static bool operator >(ToReadList obj1, ToReadList obj2)
        {
            if (obj1.List.Length > obj2.List.Length)
                return true;
            return false;
        }

        public static bool operator <(ToReadList obj1, ToReadList obj2)
        {
            if (obj1.List.Length < obj2.List.Length)
                return true;
            return false;
        }

    }

}
