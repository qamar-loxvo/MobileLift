using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileLift.hyperin
{
    public class MobileSpecificContent
    {
        private int id;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private int hoursToShowAgain;
        private string linkText;
        private string linkURL;
        private string title;

        public int Id
        {

            set;
            get;

        }

        public string LinkURL
        {
            set;
            get;
        }
        public string Description
        {
            set;
            get;
        }



        public DateTime StartDate
        {
            set;
            get;

        }

        public DateTime EndDate
        {
            set;
            get;

        }
        public int HoursToShowAgain
        {
            set;
            get;


        }

        public string LinkText
        {
            set;
            get;
        }

        public string Title
        {
            set;
            get;
        }

    }
}
