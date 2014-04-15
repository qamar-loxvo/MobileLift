using MobileLift.hyperin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MobileLift.Utility
{

    

    public class XMLParser
    {

        public static string KEY_ID = "id";
        public static string KEY_MOBILE_LIFTS = "mobileLifts";
        public static string KEY_MOBILE_LIFT = "mobileLift";
        public static string KEY_DESCRIPTION = "description";
        public static string KEY_STARTDATE = "startDate";
        public static string KEY_ENDDATE = "endDate";
        public static string KEY_TITLE = "title";
        public static string KEY_HOURS_TO_SHOW = "hoursToShowAgain";
        public static string KEY_LINK_TExT = "linkText";
        public static string KEY_LINK_URL = "linkUrl";



        public static List<MobileSpecificContent> ParseMobileLift(String response){

            List<MobileSpecificContent> mobileContents = new List<MobileSpecificContent>();

            XDocument doc = XDocument.Parse(response);
            
            var contents =  doc.Descendants(KEY_MOBILE_LIFT);

            foreach(var content in contents)
            {
                MobileSpecificContent mobSpecificContent = new MobileSpecificContent();
                mobSpecificContent.Id = int.Parse( content.Attribute(KEY_ID).Value);
                if(content.Element(KEY_DESCRIPTION)!=null){
                    mobSpecificContent.Description = content.Element(KEY_DESCRIPTION).Value;
                }
                if (content.Element(KEY_TITLE) != null)
                {
                    mobSpecificContent.Title = content.Element(KEY_TITLE).Value;
                }
                if (content.Element(KEY_HOURS_TO_SHOW) != null)
                {
                    mobSpecificContent.HoursToShowAgain =int.Parse( content.Element(KEY_HOURS_TO_SHOW).Value);
                }
                if (content.Element(KEY_LINK_TExT) != null)
                {
                    mobSpecificContent.LinkText = content.Element(KEY_LINK_TExT).Value;
                }
                if (content.Element(KEY_STARTDATE) != null)
                {
                    mobSpecificContent.StartDate = DateTime.Parse(content.Element(KEY_STARTDATE).Value);
                }
                if (content.Element(KEY_ENDDATE) != null)
                {
                    mobSpecificContent.EndDate = DateTime.Parse(content.Element(KEY_ENDDATE).Value);
                }

                if (content.Element(KEY_LINK_URL) != null)
                {
                    mobSpecificContent.LinkURL = content.Element(KEY_LINK_URL).Value;
                }

                mobileContents.Add(mobSpecificContent);
            }
            return mobileContents;
        }

    }
}
