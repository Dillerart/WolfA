using Ionic.Zip;
using System;
using System.IO;
using WolfStar.Writer;

namespace WolfStar.Star
{
    class ArhiveFolder
    {
        public void createArhive(string pathFolder, string nameFolder, string passFolder, string pathBackUpFolder)
        {
            string backUp = pathBackUpFolder + nameFolder+"_"+DateTime.Now.ToString("dd_MM_yyyy")+".zip";           
            ZipFile createFile = new ZipFile();
            try
            {
                createFile.UseZip64WhenSaving = Zip64Option.AsNecessary;
                createFile.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                createFile.Password = passFolder;
                createFile.AddDirectory(pathFolder);
                createFile.Save(backUp);                
                new WolfLog().mailLogFile(createMessegeLog(backUp));
                new WolfLog().serverLogFile(createMessegeLog(backUp));
            }
            catch(Exception ex) 
            {
                new WolfLog().mailLogFile(DateTime.Now.ToString("hh:mm:ss dd-MM-yyyy") + " -> " + ex.ToString());
                new WolfLog().serverLogFile(DateTime.Now.ToString("hh:mm:ss dd-MM-yyyy") + " -> " + ex.ToString());
            }
            

        }

        private string createMessegeLog(string file)
        {
            string inform;
            if (File.Exists(file))
            {
                FileInfo info = new FileInfo(file);
                double size = info.Length / 1048576;
                return inform = DateTime.Now.ToString("hh:mm:ss dd-MM-yyyy") + " -> " + "Файл был создан. Путь к файлу: " +file+ " | Вес файла: " +size+ "Mb";
            }
            else
            {
                return inform = DateTime.Now.ToString("hh:mm:ss dd-MM-yyyy")+" -> " + "Файл не создан";
            }
             
        }
      
    }
}
