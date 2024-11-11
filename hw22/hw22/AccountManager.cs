using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    public class AccountManager
    {
        public Dictionary<string, string> EmployeeAccounts { get; private set; } = new Dictionary<string, string>();
        public void AddEmployee(string login, string password)
        {
            if (!EmployeeAccounts.ContainsKey(login))
            {
                EmployeeAccounts[login] = password;
                Console.WriteLine($"Employee '{login}' added");
            }
            else
            {
                Console.WriteLine($"Login '{login}' already exists");
            }
        }
        public void DeleteEmployee(string login)
        {
            if (EmployeeAccounts.Remove(login))
            {
                Console.WriteLine($"Employee '{login}' removed");
            }
            else
            {
                Console.WriteLine($"Login '{login}' not found");
            }
        }

        public void EditEmployee(string login, string newPassword)
        {
            if (EmployeeAccounts.ContainsKey(login))
            {
                EmployeeAccounts[login] = newPassword;
                Console.WriteLine($"Employee '{login}''s information updated");
            }
            else
            {
                Console.WriteLine($"Login '{login}' not found");
            }
        }
        public string GetPassword(string login)
        {
            if (EmployeeAccounts.TryGetValue(login, out string? password))
            {
                return password;
            }
            else
            {
                throw new Exception($"Login '{login}' not found");
            }
        }
    }
}
