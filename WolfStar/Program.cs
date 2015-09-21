using System;
using System.Threading;
using WolfStar.Reader;
using WolfStar.Star;

namespace WolfStar
{
    class Program
    {        
        static void Main(string[] args)
        {
            startCreateArhiveMess();
            Thread folder = new Thread(folderArhiveted);
            folder.Start();
            Thread sql = new Thread(sqlArhiveted);
            sql.Start();
            
        }
        //Архивируем Папку
        private static void folderArhiveted()
        {
            ReadFile reader = new ReadFile();
            reader.readFileFolder();
            ArhiveFolder create = new ArhiveFolder();
            foreach (ListFolder getString in reader.FolderList)
            {
                create.createArhive(getString.PathFolder, getString.NameFolder, getString.PassFolder, reader.PathBackUpFolder);
            }
        }
          
        //Архивируем SQL
        private static void sqlArhiveted()
        {
            ReadFile reader = new ReadFile();
            reader.readFileSQL();
            ArhiveSQL create = new ArhiveSQL();           
            foreach (ListSQL getString in reader.SqlList)
            {
                create.createArhive(reader.ConnectionString, getString.NameSQL,getString.NameArh, reader.PathBackUpSQL);
            }
                
        }
        //Окно сообщения
        private static void startCreateArhiveMess()
        {
            Console.WriteLine("Запуск Архивации.");
            Console.WriteLine("Пожалуйста подождите.");
            Console.WriteLine("Не закрывайте данное окно, оно закроется автоматически. Если необходимо работать вы можете свернуть его.");
        }
    }
}
