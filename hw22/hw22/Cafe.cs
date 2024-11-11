using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    public class Cafe
    {
        private Queue<Customer> Queue = new Queue<Customer>();
        private List<Customer> VIPCustomers = new List<Customer>();

        public void Arrive(Customer customer)
        {
            if (customer.IsVIP)
            {
                VIPCustomers.Add(customer);
                Console.WriteLine($"VIP customer {customer.Name} added to queue.");
            }
            else
            {
                Queue.Enqueue(customer);
                Console.WriteLine($"Customer {customer.Name} added to queue");
            }
        }

        public void ServeCustomer()
        {
            if (VIPCustomers.Count > 0)
            {
                Customer reservedCustomer = VIPCustomers[0];
                VIPCustomers.RemoveAt(0);
                Console.WriteLine($"VIP customer {reservedCustomer.Name} took their table.");
            }
            else if (Queue.Count > 0)
            {
                Customer customer = Queue.Dequeue();
                Console.WriteLine($"Customer {customer.Name} took their table.");
            }
            else
            {
                Console.WriteLine("Queue is empty");
            }
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public bool IsVIP { get; set; }

        public Customer(string name, bool isVIP)
        {
            Name = name;
            IsVIP = isVIP;
        }
    }
}
