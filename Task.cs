using System;
using System.Collections.Generic;

namespace Ticketing_System
{
    public class Task
    {
        public UInt64 ticketId {get; set;}
        public string summary {get; set;}
        public string status {get; set;}
        public string priority {get; set;}
        public string submitter {get; set;}
        public string assigned {get; set;}
        public string watching {get; set;}

        public string projectName {get; set;}
        public DateTime dueDate {get; set;}

        public string Display(){
            return $"\nTicketID: {ticketId}, \nSummary: {summary}, \nStatus: {status}, \nPriority: {priority}, \nSubmitter: {submitter}, \nAssigned: {assigned}, \nWatching: {watching}, \nProject Name: {projectName}, \nDue Date: {dueDate}";
        }
    }
}