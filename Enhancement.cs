using System;
using System.Collections.Generic;

namespace Ticketing_System
{
    public class Enhancement
    {
        public UInt64 ticketId {get; set;}
        public string summary {get; set;}
        public string status {get; set;}
        public string priority {get; set;}
        public string submitter {get; set;}
        public string assigned {get; set;}
        public string watching {get; set;}

        public string software {get; set;}
        public double cost {get; set;}
        public string reason {get; set;}
        public string estimate {get; set;}

        public string Display(){
            return $"\nTicketID: {ticketId}, \nSummary: {summary}, \nStatus: {status}, \nPriority: {priority}, \nSubmitter: {submitter}, \nAssigned: {assigned}, \nWatching: {watching}, \nSoftware: {software}, \nCost: {cost}, \nReason: {reason}, \nEstimate: {estimate}";
        }
    }
}