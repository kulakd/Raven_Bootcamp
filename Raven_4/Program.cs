using System;
using System.Linq;
using Raven.Client;
using Raven.Client.Documents;

namespace Raven_4
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            while (true)
            {
                Console.WriteLine("Please, press:");
                Console.WriteLine("C - Create");
                Console.WriteLine("R - Retrieve");
                Console.WriteLine("U - Update");
                Console.WriteLine("D - Delete");
                Console.WriteLine("Q - Query all contacts (limit to 128 items)");

                var input = Console.ReadKey();
                Console.WriteLine("\n------------");

                switch (input.Key)
                {
                    case ConsoleKey.C:
                        CreateContact();
                        break;
                    case ConsoleKey.R:
                        RetrieveContact();
                        break;
                    case ConsoleKey.U:
                        UpdateContact();
                        break;
                    case ConsoleKey.D:
                        DeleteContact();
                        break;
                    case ConsoleKey.Q:
                        QueryAllContacts();
                        break;
                    default:
                        return;
                }
                Console.WriteLine("------------");
            }
        }
        private void CreateContact()
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                Console.WriteLine("Name: ");
                var name = Console.ReadLine();

                Console.WriteLine("Email: ");
                var email = Console.ReadLine();

                var contact = new Model
                {
                    Name = name,
                    Email = email
                };

                session.Store(contact);

                Console.WriteLine($"New Contact ID {contact.Id}");

                session.SaveChanges();
            }
        }

        private void RetrieveContact()
        {
            Console.WriteLine("Enter the contact id: ");
            var id = Console.ReadLine();

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var contact = session.Load<Model>(id);

                if (contact == null)
                {
                    Console.WriteLine("Contact not found.");
                    return;
                }

                Console.WriteLine($"Name: {contact.Name}");
                Console.WriteLine($"Email: {contact.Email}");
            }
        }

        private void UpdateContact()
        {
            Console.WriteLine("Enter the contact id: ");
            var id = Console.ReadLine();

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var contact = session.Load<Model>(id);

                if (contact == null)
                {
                    Console.WriteLine("Contact not found.");
                    return;
                }

                Console.WriteLine($"Actual name: {contact.Name}");
                Console.WriteLine("New name: ");
                contact.Name = Console.ReadLine();

                Console.WriteLine($"Actual email: {contact.Email}");
                Console.WriteLine("New email address: ");
                contact.Email = Console.ReadLine();

                session.SaveChanges();
            }
        }
        private void DeleteContact()
        {
            Console.WriteLine("Enter the contact id: ");
            var id = Console.ReadLine();

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var contact = session.Load<Model>(id);

                if (contact == null)
                {
                    Console.WriteLine("Contact not found.");
                    return;
                }

                session.Delete(contact);
                session.SaveChanges();
            }
        }

        private void QueryAllContacts()
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var contacts = session.Query<Model>().ToList();

                foreach (var contact in contacts)
                {
                    Console.WriteLine($"{contact.Id} - {contact.Name} - {contact.Email}");
                }

                Console.WriteLine($"{contacts.Count} contacts found.");
            }
        }

    }
}