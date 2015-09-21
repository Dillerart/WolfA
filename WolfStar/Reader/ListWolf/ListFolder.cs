

namespace WolfStar.Reader
{
    class ListFolder
    {       
        private string pathFolder;

        private string nameFolder;
        
        private string passFolder;

        public ListFolder(string pathFolder, string nameFolder, string passFolder)
        {
            this.pathFolder = pathFolder;
            this.nameFolder = nameFolder;
            this.passFolder = passFolder;
        }

        public string PathFolder
        {
            get
            {
                return pathFolder;
            }

            set
            {
                pathFolder = value;
            }
        }

        public string NameFolder
        {
            get
            {
                return nameFolder;
            }

            set
            {
                nameFolder = value;
            }
        }

        public string PassFolder
        {
            get
            {
                return passFolder;
            }

            set
            {
                passFolder = value;
            }
        }
    }
}
