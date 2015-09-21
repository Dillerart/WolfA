using System;
using System.Collections.Generic;
using System.IO;
using WolfStar.Writer;

namespace WolfStar.Reader
{
    class ReadFile:IniFile
    {
        //для записи в лог файл
        private string folderNotFound = @".\WolfFolder.ini -> file not found: " + DateTime.Now.ToString("hh:mm:ss dd-MM-yyyy");
        //для записи в лог файл
        private string sqlNotFound = @".\WolfSQL.ini -> file not found: " + DateTime.Now.ToString("hh:mm:ss dd-MM-yyyy");

        //пути к архивным папкам
        private string pathBackUpSQL;

        private string pathBackUpFolder;

        //Connection string to SQLServer
        private string connectionString;

        //Пути к инишникам
        private const string INI_FILE_FOLDER = @".\WolfFolder.ini";

        private const string INI_FILE_SQL = @".\WolfSQL.ini";

        //Главные секции для архивирования
        private const string MAIN_SECTION_FOLDER = "FOLDER";

        private const string MAIN_SECTION_SQL = "SQL";

        //Строка подключения
        private const string KEY_CONNECTION_SECTION_SQL = "CONNECTION_STRING";

        //Кол-во SQL баз
        private const string KEY_COUNT_SECTION_SQL = "COUNT_SQL";

        //Имена БД
        private const string KEY_NAME_SECTION_SQL = "NAME_DATE_BASE";

        //Путь к архиву
        private const string KEY_BACKUP_SECTION_SQL = "BACKUP_SQL";

        //Ключ для старта(Если True то архивируем, False -нет)
        private const string KEY_START_SECTION_SQL = "START";

        //Множество архивируемых папок и их имена
        private const string KEY_PATH_SECTION_FOLDER = "PATH_FOLDER";

        private const string KEY_NAME_SECTION_FOLDER = "NAME_FOLDER";

        //Кол-во архивов
        private const string KEY_COUNT_SECTION_FOLDER = "COUNT_FOLDER";

        //Пароль для архива
        private const string KEY_PASS_SECTION_FOLDER = "PASS_FOLDER";

        //Ключ для старта(Если True то архивируем, False -нет)
        private const string KEY_START_SECTION_FOLDER = "START";

        //Куда будем складывать архивы
        private const string KEY_BACKUP_SECTION_FOLDER = "BACKUP_FOLDER";

        private const string KEY_NAME_SQL = "NAME_BACKUP";

        //За счет этого мы загрузим список данных folderList
        private List<ListFolder> folderList = new List<ListFolder>();

        //За счет этого мы загрузим список данных sqlList
        private List<ListSQL> sqlList = new List<ListSQL>();
                
        public string PathBackUpSQL
        {
            get
            {
                return pathBackUpSQL;
            }

            set
            {
                pathBackUpSQL = value;
            }
        }

        public string PathBackUpFolder
        {
            get
            {
                return pathBackUpFolder;
            }

            set
            {
                pathBackUpFolder = value;
            }
        }

        internal List<ListFolder> FolderList
        {
            get
            {
                return folderList;
            }

            set
            {
                folderList = value;
            }
        }

        internal List<ListSQL> SqlList
        {
            get
            {
                return sqlList;
            }

            set
            {
                sqlList = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }

            set
            {
                connectionString = value;
            }
        }

        //Копирую Данные из ини файла и передаю их в массив Папок
        public void readFileFolder()
        {
            if (File.Exists(INI_FILE_FOLDER))
            {
                if (start(INI_FILE_FOLDER, MAIN_SECTION_FOLDER, KEY_START_SECTION_FOLDER))
                {
                    for (int i = 1; i < count(INI_FILE_FOLDER, MAIN_SECTION_FOLDER, KEY_COUNT_SECTION_FOLDER); i++)
                    {
                        folderList.Add(new ListFolder(readKeySection(INI_FILE_FOLDER, MAIN_SECTION_FOLDER, KEY_PATH_SECTION_FOLDER+i),
                                                      readKeySection(INI_FILE_FOLDER, MAIN_SECTION_FOLDER, KEY_NAME_SECTION_FOLDER+i),
                                                      readKeySection(INI_FILE_FOLDER, MAIN_SECTION_FOLDER, KEY_PASS_SECTION_FOLDER+i)));
                    }
                    PathBackUpFolder = readKeySection(INI_FILE_FOLDER, MAIN_SECTION_FOLDER, KEY_BACKUP_SECTION_FOLDER);
                }

            }
            else
            {
                saveToLog(folderNotFound); 
            }
        }

        //Копирую Данные из ини файла и передаю их в массив SQL
        public void readFileSQL()
        {
            if (File.Exists(INI_FILE_SQL))
            {
                if (start(INI_FILE_SQL, MAIN_SECTION_SQL, KEY_START_SECTION_SQL))
                {
                    for (int i = 1; i < count(INI_FILE_SQL, MAIN_SECTION_SQL, KEY_COUNT_SECTION_SQL); i++)
                    {
                        SqlList.Add(new ListSQL(readKeySection(INI_FILE_SQL, MAIN_SECTION_SQL, KEY_NAME_SECTION_SQL+i),
                                                readKeySection(INI_FILE_SQL, MAIN_SECTION_SQL, KEY_NAME_SQL+i)));
                    }
                    ConnectionString = readKeySection(INI_FILE_SQL, MAIN_SECTION_SQL, KEY_CONNECTION_SECTION_SQL);
                    PathBackUpSQL = readKeySection(INI_FILE_SQL, MAIN_SECTION_SQL, KEY_BACKUP_SECTION_SQL);
                }
            }
            else
            {
                saveToLog(sqlNotFound);
            }
        }

        //Кол-во архивируемых
        private int count(string fileName, string nameSection, string keySection)
        {
            Path = fileName;
            return int.Parse(IniReadValue(nameSection, keySection))+1;
        }

        //получени строки
        private string readKeySection(string fileName, string nameSection, string keySection)
        {
            Path = fileName;
            return IniReadValue(nameSection, keySection);
        }

        //получение задания на архив
        private bool start(string fileName, string nameSection, string keySection)
        {
            Path = fileName;
            return bool.Parse(IniReadValue(nameSection, keySection));
        }

        private void saveToLog(string log)
        {
            new WolfLog().serverLogFile(log);
        }

    }
}
