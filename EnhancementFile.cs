using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace Ticketing_System
{
    public class EnhancementFile
    {
        public string filePath { get; set; }
        public List<Enhancement> Enhancements { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public EnhancementFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            Enhancements = new List<Enhancement>();

            try
            {
                StreamReader sr = new StreamReader(filePath);
                while(!sr.EndOfStream){
                    Enhancement enhancement = new Enhancement();
                    string line = sr.ReadLine();
                    // convert string to array
                    string[] enhancementDetails = line.Split(',');
                    
                    enhancement.ticketId = UInt64.Parse(enhancementDetails[0]);
                    enhancement.summary = enhancementDetails[1];
                    enhancement.status = enhancementDetails[2];
                    enhancement.priority = enhancementDetails[3];
                    enhancement.submitter = enhancementDetails[4];
                    enhancement.assigned = enhancementDetails[5];
                    enhancement.watching = enhancementDetails[6];
                    enhancement.software = enhancementDetails[7];
                    enhancement.cost = Double.Parse(enhancementDetails[8]);
                    enhancement.reason = enhancementDetails[9];
                    enhancement.estimate = enhancementDetails[10];
                    Enhancements.Add(enhancement);
                }
                sr.Close();
                logger.Info("Enhancements in file {Count}", Enhancements.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        public void AddEnhancement(Enhancement enhancement)
        {
            try
            {
                enhancement.ticketId = Enhancements.Max(t => t.ticketId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{enhancement.ticketId},{enhancement.summary},{enhancement.status},{enhancement.priority},{enhancement.submitter},{enhancement.assigned},{enhancement.watching},{enhancement.software},{enhancement.cost},{enhancement.reason},{enhancement.estimate}");
                sw.Close();
                Enhancements.Add(enhancement);
                logger.Info("Enhancement id {Id} added", enhancement.ticketId);
            }
            catch(Exception ex){
                logger.Error(ex.Message);
            }
        }
    }
}