using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using NLog.Web;

namespace Ticketing_System
{
    public class Search
    {
        public TicketFile ticketFile;
        public EnhancementFile enhancementFile;
        public TaskFile taskFile;
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        public Search(){
            string ticketFilePath = Directory.GetCurrentDirectory() + "\\tickets.csv";
            ticketFile = new TicketFile(ticketFilePath);

            string enhancementFilePath = Directory.GetCurrentDirectory() + "\\enhancements.csv";
            enhancementFile = new EnhancementFile(enhancementFilePath);

            string taskFilePath = Directory.GetCurrentDirectory() + "\\task.csv";
            taskFile = new TaskFile(taskFilePath);
            logger.Info("Created search.");
        }

        public String StatusSearch(string input){
            var ticketsOutput = new List<String>();
            String output = "";

            var tickets = ticketFile.Tickets.Where(Ticket => Ticket.status.Contains(input, StringComparison.OrdinalIgnoreCase));
            foreach(Ticket ticket in tickets){
                ticketsOutput.Add(ticket.Display());
            }
            var enhancements = enhancementFile.Enhancements.Where(Enhancement => Enhancement.status.Contains(input, StringComparison.OrdinalIgnoreCase));
            foreach(Enhancement enhancement in enhancements){
                ticketsOutput.Add(enhancement.Display());
            }
            var tasks = taskFile.Tasks.Where(Task => Task.status.Contains(input, StringComparison.OrdinalIgnoreCase));
            foreach(Task task in tasks){
                ticketsOutput.Add(task.Display());
            }
            
            foreach(var item in ticketsOutput){
                output += item  + "\n";
            }
            output += ($"There is {ticketsOutput.Count} result(s) from your search of \"{input}\".\n");

            logger.Info("{Count} status found", ticketsOutput.Count());
            return output;
        }
        
        public String PrioritySearch(string input){
            var ticketsOutput = new List<String>();
            String output = "";

            var tickets = ticketFile.Tickets.Where(Ticket => Ticket.priority.Contains(input, StringComparison.OrdinalIgnoreCase));
            foreach(Ticket ticket in tickets){
                ticketsOutput.Add(ticket.Display());
            }
            var enhancements = enhancementFile.Enhancements.Where(Enhancement => Enhancement.priority.Contains(input, StringComparison.OrdinalIgnoreCase));
            foreach(Enhancement enhancement in enhancements){
                ticketsOutput.Add(enhancement.Display());
            }
            var tasks = taskFile.Tasks.Where(Task => Task.priority.Contains(input, StringComparison.OrdinalIgnoreCase));
            foreach(Task task in tasks){
                ticketsOutput.Add(task.Display());
            }
            
            foreach(var item in ticketsOutput){
                output += item  + "\n";
            }
            output += ($"There is {ticketsOutput.Count} result(s) from your search of \"{input}\".\n");

            logger.Info("{Count} status found", ticketsOutput.Count());
            return output;
        }

        public String SubmitterSearch(string input){
            var ticketsOutput = new List<String>();
            String output = "";

            var tickets = ticketFile.Tickets.Where(Ticket => Ticket.submitter.Contains(input, StringComparison.OrdinalIgnoreCase));
            foreach(Ticket ticket in tickets){
                ticketsOutput.Add(ticket.Display());
            }
            var enhancements = enhancementFile.Enhancements.Where(Enhancement => Enhancement.submitter.Contains(input, StringComparison.OrdinalIgnoreCase));
            foreach(Enhancement enhancement in enhancements){
                ticketsOutput.Add(enhancement.Display());
            }
            var tasks = taskFile.Tasks.Where(Task => Task.submitter.Contains(input, StringComparison.OrdinalIgnoreCase));
            foreach(Task task in tasks){
                ticketsOutput.Add(task.Display());
            }
            
            foreach(var item in ticketsOutput){
                output += item  + "\n";
            }
            output += ($"There is {ticketsOutput.Count} result(s) from your search of \"{input}\".\n");

            logger.Info("{Count} status found", ticketsOutput.Count());
            return output;
        }
    }
}