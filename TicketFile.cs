using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace Ticketing_System
{
    public class TicketFile
    {
        public string filePath { get; set; }
        public List<Ticket> Tickets { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public TicketFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            Tickets = new List<Ticket>();

            try
            {
                StreamReader sr = new StreamReader(filePath);
                while(!sr.EndOfStream){
                    Ticket ticket = new Ticket();
                    string line = sr.ReadLine();
                    // convert string to array
                    string[] ticketDetails = line.Split(',');
                    
                    ticket.ticketId = UInt64.Parse(ticketDetails[0]);
                    ticket.summary = ticketDetails[1];
                    ticket.status = ticketDetails[2];
                    ticket.priority = ticketDetails[3];
                    ticket.submitter = ticketDetails[4];
                    ticket.assigned = ticketDetails[5];
                    ticket.watching = ticketDetails[6];
                    ticket.severity = ticketDetails[7];
                    Tickets.Add(ticket);
                }
                sr.Close();
                logger.Info("Tickets in file {Count}", Tickets.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        public void AddTicket(Ticket ticket)
        {
            try
            {
                ticket.ticketId = Tickets.Max(t => t.ticketId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{ticket.ticketId},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{ticket.watching},{ticket.severity}");
                sw.Close();
                Tickets.Add(ticket);
                logger.Info("Ticket id {Id} added", ticket.ticketId);
            }
            catch(Exception ex){
                logger.Error(ex.Message);
            }
        }
    }
}