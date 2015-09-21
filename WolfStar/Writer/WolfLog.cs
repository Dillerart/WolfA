using System.IO;

namespace WolfStar.Writer
{
    class WolfLog
    {
        private const string PATH_TO_FOLDER = @".\MailFolder";

        private const string MAIL_LOG_FILE = @"\MailLogFile.log";

        private const string SERVER_LOG_FILE = @"\ServerLogFile.log";

        private const string PATH_TO_SRV = @".\ServerLogFile";

        public WolfLog()
        {
            if (!Directory.Exists(PATH_TO_SRV))
            {
                Directory.CreateDirectory(PATH_TO_SRV);
            }
            if (!Directory.Exists(PATH_TO_FOLDER))
            {
                Directory.CreateDirectory(PATH_TO_FOLDER);
            }          
        }

        public void mailLogFile(string textToLogFile)
        {
            using (StreamWriter writeLogFile = File.AppendText(PATH_TO_FOLDER + MAIL_LOG_FILE))
            {
                writeLogFile.WriteLine(textToLogFile);
            }
                
        }

        public void serverLogFile(string textToLogFile)
        {
            using (StreamWriter writeLogFile = File.AppendText(PATH_TO_SRV + SERVER_LOG_FILE))
            {
                writeLogFile.WriteLine(textToLogFile);
            }          
        }
    }
}
