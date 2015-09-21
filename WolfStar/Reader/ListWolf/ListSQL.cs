

namespace WolfStar.Reader
{
    class ListSQL
    {
        
                
        private string nameSQL;

        private string nameArh;

        public ListSQL(string nameSQL, string nameArh)
        {
           
            this.nameSQL = nameSQL;
            this.nameArh = nameArh;
        }
               

        public string NameSQL
        {
            get
            {
                return nameSQL;
            }

            set
            {
                nameSQL = value;
            }
        }

        public string NameArh
        {
            get
            {
                return nameArh;
            }

            set
            {
                nameArh = value;
            }
        }
    }
}
