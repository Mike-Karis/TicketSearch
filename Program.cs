using System;
using NLog.Web;
using System.IO;
using System.Linq;

namespace Ticketing_System
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Info("Program started");

            string ticketType = "";

            do{
                Console.WriteLine("1) Look at Bug/Defect");
                Console.WriteLine("2) Look at Enhancement");
                Console.WriteLine("3) Look at Task");
                Console.WriteLine("4) Perform Search");
                Console.WriteLine("Enter any other key to exit.");
                ticketType = Console.ReadLine();
                logger.Info("User ticketType: {TicketType}", ticketType);

                string choice = "";

                if (ticketType == "1")
                {
                    string ticketFilePath = Directory.GetCurrentDirectory() + "\\tickets.csv";
                    TicketFile ticketFile = new TicketFile(ticketFilePath);
                    do
                    {
                        // ask user a question
                        Console.WriteLine("1) Read tickets from file.");
                        Console.WriteLine("2) Add ticket to file.");
                        Console.WriteLine("Enter any other key to exit.");
                        // input response
                        choice = Console.ReadLine();
                        logger.Info("User choice: {Choice}", choice);

                        if (choice == "1")
                        {
                            foreach(Ticket ticket in ticketFile.Tickets){
                                Console.WriteLine(ticket.Display());
                            }
                        }
                        else if (choice == "2")
                        {
                            Ticket ticket = new Ticket();

                            int ticketId = ticketFile.Tickets.Count + 1;
                            Console.WriteLine("Ticket ID: " + ticketId);

                            Console.WriteLine("Enter a Summary.");
                            ticket.summary = Console.ReadLine();

                            Console.WriteLine("Enter the status.");
                            ticket.status = Console.ReadLine();

                            Console.WriteLine("Enter the priority.");
                            ticket.priority = Console.ReadLine();

                            Console.WriteLine("Enter the name of the submitter of the ticket.");
                            ticket.submitter = Console.ReadLine();

                            Console.WriteLine("Enter the name of the person assigned to the ticket.");
                            ticket.assigned = Console.ReadLine();

                            Console.WriteLine("Enter the person watching the ticket.");
                            ticket.watching = Console.ReadLine();

                            Console.WriteLine("Enter the severity.");
                            ticket.severity = Console.ReadLine();

                            ticketFile.AddTicket(ticket);
                        }
                    } while (choice == "1" || choice == "2");
                } else if (ticketType == "2"){
                    string ticketFilePath = Directory.GetCurrentDirectory() + "\\enhancements.csv";
                    EnhancementFile enhancementFile = new EnhancementFile(ticketFilePath);
                    do{
                        // ask user a question
                        Console.WriteLine("1) Read enhancement from file.");
                        Console.WriteLine("2) Add enhancement to file.");
                        Console.WriteLine("Enter any other key to exit.");
                        // input response
                        choice = Console.ReadLine();
                        logger.Info("User choice: {Choice}", choice);

                        if (choice == "1")
                        {
                            foreach(Enhancement enhancement in enhancementFile.Enhancements){
                                Console.WriteLine(enhancement.Display());
                            }
                        }
                        else if (choice == "2")
                        {
                            Enhancement enhancement = new Enhancement();

                            int ticketId = enhancementFile.Enhancements.Count + 1;
                            Console.WriteLine("Ticket ID: " + ticketId);

                            Console.WriteLine("Enter a Summary.");
                            enhancement.summary = Console.ReadLine();

                            Console.WriteLine("Enter the status.");
                            enhancement.status = Console.ReadLine();

                            Console.WriteLine("Enter the priority.");
                            enhancement.priority = Console.ReadLine();

                            Console.WriteLine("Enter the name of the submitter of the ticket.");
                            enhancement.submitter = Console.ReadLine();

                            Console.WriteLine("Enter the name of the person assigned to the ticket.");
                            enhancement.assigned = Console.ReadLine();

                            Console.WriteLine("Enter the person watching the ticket.");
                            enhancement.watching = Console.ReadLine();

                            Console.WriteLine("Enter the software.");
                            enhancement.software = Console.ReadLine();

                            Console.WriteLine("Enter the cost.");
                            enhancement.cost = double.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the reason.");
                            enhancement.reason = Console.ReadLine();

                            Console.WriteLine("Enter the estimate.");
                            enhancement.estimate = Console.ReadLine();

                            enhancementFile.AddEnhancement(enhancement);
                        }
                    } while (choice == "1" || choice == "2");
                } else if (ticketType == "3"){
                    string ticketFilePath = Directory.GetCurrentDirectory() + "\\task.csv";
                    TaskFile taskFile = new TaskFile(ticketFilePath);
                    do{
                        // ask user a question
                        Console.WriteLine("1) Read task from file.");
                        Console.WriteLine("2) Add task to file.");
                        Console.WriteLine("Enter any other key to exit.");
                        // input response
                        choice = Console.ReadLine();
                        logger.Info("User choice: {Choice}", choice);

                        if (choice == "1")
                        {
                            foreach(Task task in taskFile.Tasks){
                                Console.WriteLine(task.Display());
                            }
                        }
                        else if (choice == "2")
                        {
                            Task task = new Task();

                            int ticketId = taskFile.Tasks.Count + 1;
                            Console.WriteLine("Ticket ID: " + ticketId);

                            Console.WriteLine("Enter a Summary.");
                            task.summary = Console.ReadLine();

                            Console.WriteLine("Enter the status.");
                            task.status = Console.ReadLine();

                            Console.WriteLine("Enter the priority.");
                            task.priority = Console.ReadLine();

                            Console.WriteLine("Enter the name of the submitter of the ticket.");
                            task.submitter = Console.ReadLine();

                            Console.WriteLine("Enter the name of the person assigned to the ticket.");
                            task.assigned = Console.ReadLine();

                            Console.WriteLine("Enter the person watching the ticket.");
                            task.watching = Console.ReadLine();

                            Console.WriteLine("Enter the project name.");
                            task.projectName = Console.ReadLine();

                            Console.WriteLine("Enter the due date. (M/D/Y)");
                            task.dueDate = DateTime.Parse(Console.ReadLine());

                            taskFile.AddTask(task);
                        }
                    } while (choice == "1" || choice == "2");
                } else if (ticketType == "4"){
                    Search search = new Search();
                    do{
                        Console.WriteLine("1) Search based on status");
                        Console.WriteLine("2) Search based on priority");
                        Console.WriteLine("3) Search based on submitter");
                        Console.WriteLine("Enter any other key to exit.");
                        choice = Console.ReadLine();
                        logger.Info("User choice: {Choice}", choice);
                        if(choice == "1"){
                            Console.Write("Search status: ");
                            var input = Console.ReadLine();
                            Console.WriteLine(search.StatusSearch(input));
                        } else if (choice == "2"){
                            Console.Write("Search priority: ");
                            var input = Console.ReadLine();
                            Console.WriteLine(search.PrioritySearch(input));
                        }else if (choice == "3"){
                            Console.Write("Search submitter: ");
                            var input = Console.ReadLine();
                            Console.WriteLine(search.SubmitterSearch(input));
                        }
                    }while(choice == "1" || choice == "2" || choice == "3");
                }
            } while (ticketType == "1" || ticketType == "2" || ticketType == "3" || ticketType == "4");
            logger.Info("Program ended");
        }
    }
}
