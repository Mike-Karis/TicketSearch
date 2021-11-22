using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace Ticketing_System
{
    public class TaskFile
    {
        public string filePath { get; set; }
        public List<Task> Tasks { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public TaskFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            Tasks = new List<Task>();

            try
            {
                StreamReader sr = new StreamReader(filePath);
                while(!sr.EndOfStream){
                    Task task = new Task();
                    string line = sr.ReadLine();
                    // convert string to array
                    string[] taskDetails = line.Split(',');
                    
                    task.ticketId = UInt64.Parse(taskDetails[0]);
                    task.summary = taskDetails[1];
                    task.status = taskDetails[2];
                    task.priority = taskDetails[3];
                    task.submitter = taskDetails[4];
                    task.assigned = taskDetails[5];
                    task.watching = taskDetails[6];
                    task.projectName = taskDetails[7];
                    task.dueDate = DateTime.Parse(taskDetails[8]);
                    Tasks.Add(task);
                }
                sr.Close();
                logger.Info("Tickets in file {Count}", Tasks.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        public void AddTask(Task task)
        {
            try
            {
                task.ticketId = Tasks.Max(t => t.ticketId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{task.ticketId},{task.summary},{task.status},{task.priority},{task.submitter},{task.assigned},{task.watching},{task.projectName},{task.dueDate}");
                sw.Close();
                Tasks.Add(task);
                logger.Info("Task id {Id} added", task.ticketId);
            }
            catch(Exception ex){
                logger.Error(ex.Message);
            }
        }
    }
}