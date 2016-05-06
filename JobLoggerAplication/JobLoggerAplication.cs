using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

///////////////////////////////////////////////////////////////////////////////////////////////
//File: JobLoggerConsoleAplication.cs
//Classes: JobLoggerConsoleAplication, JobLogger
//Author: Christian Alfredo Pujadas Mendoza
//Date: 05-05-2016
//Description: This application log different messages (message, warning or error) 
//             throughout an application
///////////////////////////////////////////////////////////////////////////////////////////////

namespace JobLoggerConsoleAplication
{
    class JobLoggerConsoleAplication
    {
        static void Main(string[] args)
        {
            JobLogger jobLogger = new JobLogger(true, true, true, 1);

            //[TestMethod] InsertIntoDatabase
            Console.WriteLine("Test method jobLogger.InsertIntoDatabase(\"messageTest\", \"1\")");
            bool insertIntoDatabaseReturn = jobLogger.InsertIntoDatabase("messageTest", "1");
            PrintResult(insertIntoDatabaseReturn);

            Console.WriteLine("Test method jobLogger.InsertIntoDatabase(\"\", \"-51\")");
            insertIntoDatabaseReturn = jobLogger.InsertIntoDatabase("", "-51");
            PrintResult(insertIntoDatabaseReturn);

            Console.WriteLine("Test method jobLogger.InsertIntoDatabase(null, null)");
            insertIntoDatabaseReturn = jobLogger.InsertIntoDatabase(null, null);
            PrintResult(insertIntoDatabaseReturn);

            //[TestMethod] SaveToFile
            Console.WriteLine("Test method jobLogger.SaveToFile(\"messageTest\")");
            bool saveToFileReturn = jobLogger.SaveToFile("messageTest");
            PrintResult(saveToFileReturn);

            Console.WriteLine("Test method jobLogger.SaveToFile(\"\")");
            saveToFileReturn = jobLogger.SaveToFile("");
            PrintResult(saveToFileReturn);

            Console.WriteLine("Test method jobLogger.SaveToFile(null)");
            saveToFileReturn = jobLogger.SaveToFile(null);
            PrintResult(saveToFileReturn);

            //[TestMethod] VerifyConfiguration
            Console.WriteLine("Test method jobLogger.VerifyConfiguration(false, false, false)");
            string verifyConfigurationReturn = jobLogger.VerifyConfiguration(false, false, false);
            PrintResult(verifyConfigurationReturn);

            Console.WriteLine("Test method jobLogger.VerifyConfiguration(false, false, true)");
            verifyConfigurationReturn = jobLogger.VerifyConfiguration(false, false, true);
            PrintResult(verifyConfigurationReturn);

            //[TestMethod] VerifyMessage
            Console.WriteLine("Test method jobLogger.VerifyMessage(\"messageTest\")");
            bool verifyMessageReturn = jobLogger.VerifyMessage("messageTest");
            PrintResult(verifyConfigurationReturn);

            Console.WriteLine("Test method jobLogger.VerifyMessage(\"\")");
            verifyMessageReturn = jobLogger.VerifyMessage("");
            PrintResult(verifyConfigurationReturn);

            Console.WriteLine("Test method jobLogger.VerifyMessage(null)");
            verifyMessageReturn = jobLogger.VerifyMessage(null);
            PrintResult(verifyConfigurationReturn);

            //[TestMethod] VerifySpecifiction
            Console.WriteLine("Test method jobLogger.VerifySpecification(true, true, true, 1)");
            string verifySpecifictionReturn = jobLogger.VerifySpecification(true, true, true, 1);
            PrintResult(verifySpecifictionReturn);

            Console.WriteLine("Test method jobLogger.VerifySpecification(false, false, true, 1)");
            verifySpecifictionReturn = jobLogger.VerifySpecification(false, false, true, 1);
            PrintResult(verifySpecifictionReturn);

            Console.WriteLine("Test method jobLogger.VerifySpecification(false, false, false, 1)");
            verifySpecifictionReturn = jobLogger.VerifySpecification(false, false, false, 1);
            PrintResult(verifySpecifictionReturn);

            Console.WriteLine("Test method jobLogger.VerifySpecification(false, true, false, -10)");
            verifySpecifictionReturn = jobLogger.VerifySpecification(false, true, false, -10);
            PrintResult(verifySpecifictionReturn);

            //[TestMethod] WriteToConsole
            Console.WriteLine("Test method jobLogger.WriteToConsole(\"messageTest\", true, true, true, 1)");
            bool writeToConsoleReturn = jobLogger.WriteToConsole("messageTest", true, true, true, 1);
            PrintResult(writeToConsoleReturn);

            Console.WriteLine("Test method jobLogger.WriteToConsole(\"\", true, true, true, 1)");
            writeToConsoleReturn = jobLogger.WriteToConsole("", true, true, true, 1);
            PrintResult(writeToConsoleReturn);

            Console.WriteLine("Test method jobLogger.WriteToConsole(null, true, true, true, 1)");
            writeToConsoleReturn = jobLogger.WriteToConsole(null, true, true, true, 1);
            PrintResult(writeToConsoleReturn);

            Console.WriteLine("Test method jobLogger.WriteToConsole(\"messageTest\", false, false, false, 1)");
            writeToConsoleReturn = jobLogger.WriteToConsole("messageTest", false, false, false, 1);
            PrintResult(writeToConsoleReturn);

            Console.WriteLine("Test method jobLogger.WriteToConsole(\"messageTest\", false, true, false, 5)");
            writeToConsoleReturn = jobLogger.WriteToConsole("messageTest", false, true, false, 5);
            PrintResult(writeToConsoleReturn);

            //[TestMethod] LoggerMessage
            Console.WriteLine("Test method jobLogger.LoggerMessage(\"messageTest\", true, true, true)");
            string loggerMessageReturn = jobLogger.LoggerMessage("messageTest", true, true, true);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(\"messageTest\", false, false, false)");
            loggerMessageReturn = jobLogger.LoggerMessage("messageTest", false, false, false);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(\"messageTest\", true, false, true)");
            loggerMessageReturn = jobLogger.LoggerMessage("messageTest", true, false, true);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(\"\", true, false, true)");
            loggerMessageReturn = jobLogger.LoggerMessage("", true, false, true);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(null, true, false, true)");
            loggerMessageReturn = jobLogger.LoggerMessage(null, true, false, true);
            PrintResult(loggerMessageReturn);

            jobLogger = new JobLogger(false, false, false, 2);
            Console.WriteLine("Test method jobLogger.LoggerMessage(\"messageTest\", true, true, true)");
            loggerMessageReturn = jobLogger.LoggerMessage("messageTest", true, true, true);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(\"messageTest\", false, false, false)");
            loggerMessageReturn = jobLogger.LoggerMessage("messageTest", false, false, false);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(\"messageTest\", true, false, true)");
            loggerMessageReturn = jobLogger.LoggerMessage("messageTest", true, false, true);
            PrintResult(insertIntoDatabaseReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(\"\", true, false, true)");
            loggerMessageReturn = jobLogger.LoggerMessage("", true, false, true);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(null, true, false, true)");
            loggerMessageReturn = jobLogger.LoggerMessage(null, true, false, true);
            PrintResult(loggerMessageReturn);

            jobLogger = new JobLogger(false, true, false, 3);
            Console.WriteLine("Test method jobLogger.LoggerMessage(\"messageTest\", true, true, true)");
            loggerMessageReturn = jobLogger.LoggerMessage("messageTest", true, true, true);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(\"messageTest\", false, false, false)");
            loggerMessageReturn = jobLogger.LoggerMessage("messageTest", false, false, false);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(\"messageTest\", true, false, true)");
            loggerMessageReturn = jobLogger.LoggerMessage("messageTest", true, false, true);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(\"\", true, false, true)");
            loggerMessageReturn = jobLogger.LoggerMessage("", true, false, true);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(null, true, false, true)");
            loggerMessageReturn = jobLogger.LoggerMessage(null, true, false, true);
            PrintResult(loggerMessageReturn);

            jobLogger = new JobLogger(false, true, false, 8);
            Console.WriteLine("Test method jobLogger.LoggerMessage(\"messageTest\", true, true, true)");
            loggerMessageReturn = jobLogger.LoggerMessage("messageTest", true, true, true);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(\"messageTest\", false, false, false)");
            loggerMessageReturn = jobLogger.LoggerMessage("messageTest", false, false, false);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(\"messageTest\", true, false, true)");
            loggerMessageReturn = jobLogger.LoggerMessage("messageTest", true, false, true);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(\"\", true, false, true)");
            loggerMessageReturn = jobLogger.LoggerMessage("", true, false, true);
            PrintResult(loggerMessageReturn);

            Console.WriteLine("Test method jobLogger.LoggerMessage(null, true, false, true)");
            loggerMessageReturn = jobLogger.LoggerMessage(null, true, false, true);
            PrintResult(loggerMessageReturn);
            Thread.Sleep(1500);
        }

        public static void PrintResult(string result)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(150);
            Console.WriteLine("Result: " + result);
            Console.WriteLine("-------------");
            Thread.Sleep(300);
        }

        public static void PrintResult(bool result)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(150);
            Console.WriteLine("Result: " + result);
            Console.WriteLine("-------------");
            Thread.Sleep(300);
        }
    }

    public class JobLogger
    {
        private static bool _logToFile;
        private static bool _logToConsole;
        private static bool _logToDatabase;
        private static int _messageType;
        private bool _initialized;

        public bool LogToFile
        {
            get
            {
                return _logToFile;
            }
            set
            {
                _logToFile = value;
            }
        }

        public bool LogToConsole
        {
            get
            {
                return _logToConsole;
            }
            set
            {
                _logToConsole = value;
            }
        }

        public bool LogToDatabase
        {
            get
            {
                return _logToDatabase;
            }
            set
            {
                _logToDatabase = value;
            }
        }

        public static int MessageType
        {
            get
            {
                return _messageType;
            }
            set
            {
                if ((value > 0) && (value < 4))
                {
                    _messageType = value;
                }
                else
                {
                    _messageType = -1;
                }
            }
        }

        public bool Initialized
        {
            get
            {
                return _initialized;
            }
            set
            {
                _initialized = value;
            }
        }

        public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, int messageType)
        {
            LogToFile = logToFile;
            LogToConsole = logToConsole;
            LogToDatabase = logToDatabase;
            MessageType = messageType;
            Initialized = true;
        }

        //private static bool InsertIntoDatabase(string messageString, string messageType)
        public bool InsertIntoDatabase(string messageString, string messageType)
        {
            bool insertIntoDatabaseReturn = false;

            try
            {
                int numberFromMessageType;
                bool isNumeric = int.TryParse(messageType, out numberFromMessageType);

                //if (isNumeric && (Convert.ToInt16(messageType) > 0) && (Convert.ToInt16(messageType) < 4) && messageString != string.Empty)
                if (isNumeric && (Convert.ToInt16(messageType) > 0) && messageString != string.Empty)
                {
                    //SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                    SqlConnection connection = new SqlConnection("ConnectionString");
                    connection.Open();

                    string sqlQueryInsertInto = "Insert into Log Values('" + messageString + "'," + messageType + ")";

                    SqlCommand command = new SqlCommand(sqlQueryInsertInto);
                    command.ExecuteNonQuery();

                    connection.Close();

                    insertIntoDatabaseReturn = true;
                }
            }
            catch
            {
                insertIntoDatabaseReturn = false;
            }

            return insertIntoDatabaseReturn;
        }

        //public static string LoggerMessage(string messageString, bool message, bool warning, bool error)
        public string LoggerMessage(string messageString, bool message, bool warning, bool error)
        {
            string LogMessageReturn = string.Empty;

            if (messageString != string.Empty)
            {
                if (VerifyMessage(messageString))
                {
                    string verifyConfigurationReturn = VerifyConfiguration(LogToConsole, LogToFile, LogToDatabase);
                    LogMessageReturn = verifyConfigurationReturn;

                    if (verifyConfigurationReturn == string.Empty)
                    {
                        string verifySpecificationReturn = VerifySpecification(message, warning, error, MessageType);
                        LogMessageReturn = verifySpecificationReturn;

                        if (verifySpecificationReturn == string.Empty)
                        {
                            bool mesageTypePermitedToLog = false;
                            mesageTypePermitedToLog = (message && MessageType == 1) || (warning && MessageType == 2) || (error && MessageType == 3);

                            bool writeToFileReturn = false;

                            if (LogToFile && mesageTypePermitedToLog)
                            {
                                writeToFileReturn = SaveToFile(messageString);
                            }

                            bool writeToConsole = false;

                            if (LogToConsole && mesageTypePermitedToLog)
                            {
                                writeToConsole = WriteToConsole(messageString, message, warning, error, MessageType);
                            }

                            bool insertIntoDatabaseReturn = false;

                            if (LogToDatabase && mesageTypePermitedToLog)
                            {
                                insertIntoDatabaseReturn = InsertIntoDatabase(messageString, MessageType.ToString());
                            }
                        }
                    }
                }
            }
            return LogMessageReturn;
        }

        //private static bool SaveToFile(string messageString)
        public bool SaveToFile(string messageString)
        {
            bool writeToFileReturn = false;

            try
            {
                if (messageString != string.Empty)
                {
                    if (messageString != null)
                    {
                        string stringMessageToTxtFile = string.Empty;
                        //string pathAndFileString = ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt";
                        string pathAndFileString = Environment.CurrentDirectory + "\\LogFile" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".txt";

                        using (StreamWriter sw = File.AppendText(pathAndFileString))
                        {
                            sw.WriteLine(DateTime.Now.ToShortDateString() + " " + messageString);
                        }

                        writeToFileReturn = true;
                    }
                }
            }
            catch
            {
                writeToFileReturn = false;
            }

            return writeToFileReturn;
        }

        //private static string VerifyConfiguration(bool logToConsole, bool logToFile, bool logToDatabase)
        public string VerifyConfiguration(bool logToConsole, bool logToFile, bool logToDatabase)
        {
            string verifyConfigurationReturn = string.Empty;

            if (!logToConsole && !logToFile && !logToDatabase)
            {
                verifyConfigurationReturn = "Invalid_configuration";
            }

            return verifyConfigurationReturn;
        }

        //private static bool VerifyMessage(string messageString)
        public bool VerifyMessage(string messageString)
        {
            bool verifyMessageReturn = true;

            if (messageString == null)
            {
                verifyMessageReturn = false;
            }
            else if (messageString.Length == 0)
            {
                messageString.Trim();
                verifyMessageReturn = false;
            }

            return verifyMessageReturn;
        }

        //private static string VerifySpecification(bool logError, bool logMessage, bool logWarning, int messageType)
        public string VerifySpecification(bool logError, bool logMessage, bool logWarning, int messageType)
        {
            string verifySpecificationReturn = string.Empty;

            //if ((!logError && !logMessage && !logWarning) || messageType == -1)
            if ((!logError && !logMessage && !logWarning) || !((messageType > 0) && (messageType < 4)))
            {
                verifySpecificationReturn = "Error_or_Warning_or_Message_must_be_specified";
            }

            return verifySpecificationReturn;
        }

        //private static bool WriteToConsole(string messageString, bool message, bool warning, bool error, int messageType)
        public bool WriteToConsole(string messageString, bool message, bool warning, bool error, int messageType)
        {
            bool writeToConsoleReturn = false;

            Console.ForegroundColor = ConsoleColor.Gray;

            if (messageString != null && messageString != string.Empty)
            {
                if (message && messageType == 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (error && messageType == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (warning && messageType == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.WriteLine(DateTime.Now.ToShortDateString() + " - " + messageString);

                Thread.Sleep(1500);

                writeToConsoleReturn = true;
            }

            return writeToConsoleReturn;
        }
    }
}