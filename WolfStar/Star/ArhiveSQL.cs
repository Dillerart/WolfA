using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using WolfStar.Writer;

namespace WolfStar.Star
{
    class ArhiveSQL
    {
        public void createArhive(string connectionString, string nameDB, string nameBackUp, string pathNAMEBackUp)
        {
            string pathBackUp = pathNAMEBackUp+ nameBackUp + DateTime.Now.ToString("dd_MM_yyyy") + ".Bak";
            string commadSQLString = "USE "+ nameDB + "; BACKUP DATABASE "+ nameDB + " TO DISK = '"+ pathBackUp + "'";

           
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand sqlCommand;            
            try
            {
                connect.Open();
                sqlCommand = new SqlCommand(commadSQLString,connect);
                sqlCommand.ExecuteNonQuery();
                new WolfLog().mailLogFile(createMessegeLog(pathBackUp));
                new WolfLog().serverLogFile(createMessegeLog(pathBackUp));
            }
            catch(Exception ex)
            {

                new WolfLog().mailLogFile(DateTime.Now.ToString("hh:mm:ss dd-MM-yyyy") + " -> " + ex.ToString());
                new WolfLog().serverLogFile(DateTime.Now.ToString("hh:mm:ss dd-MM-yyyy") + " -> " + ex.ToString());
            }
            finally
            {
                connect.Close();
            }
        }


        private string createMessegeLog(string file)
        {
            string inform;
            if (File.Exists(file))
            {
                FileInfo info = new FileInfo(file);
                double size = info.Length / 1048576;
                return inform = DateTime.Now.ToString("hh:mm:ss dd-MM-yyyy") + " -> " + "Файл был создан. Путь к файлу: " + file + " | Вес файла: " + size + "Mb";
            }
            else
            {
                return inform = DateTime.Now.ToString("hh:mm:ss dd-MM-yyyy") + " -> " + "Файл не создан";
            }

        }

    }
}
