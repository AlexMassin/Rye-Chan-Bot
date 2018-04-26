using System;
using System.Collections.ObjectModel;

namespace RyeChanMacOS.HelperFunctions
{
    public class DateFormat
    {
        public static String getFormatted(DateTimeOffset dtOffset)
        {
            DateTimeOffset DTO = dtOffset.ToLocalTime();
            String M = "AM";
            int hour = DTO.Hour;
            if (hour > 12)
            {
                M = "PM";
                hour -= 12;
            }
            if (hour == 0)
            {
                hour = 12;
            }
            int month = DTO.Month;
            String Month = "";
            #region Month Cases
            switch (month)
            {
                case 1:
                    Month = "Jan";
                    break;

                case 2:
                    Month = "Feb";
                    break;

                case 3:
                    Month = "Mar";
                    break;

                case 4:
                    Month = "Apr";
                    break;

                case 5:
                    Month = "May";
                    break;

                case 6:
                    Month = "Jun";
                    break;

                case 7:
                    Month = "Jul";
                    break;

                case 8:
                    Month = "Aug";
                    break;

                case 9:
                    Month = "Sep";
                    break;

                case 10:
                    Month = "Oct";
                    break;

                case 11:
                    Month = "Nov";
                    break;

                case 12:
                    Month = "Dec";
                    break;
            }
            #endregion
            String offset = DTO.ToString();
            offset = offset.Substring(offset.Length-6);
            return Month + " " + DTO.Day + ", " + DTO.Year + " at " + hour + ":" + DTO.Minute.ToString("00") + ":" + DTO.Second.ToString("00") + " " + M + "  (UTC" + offset + ")[EST]";
        }
    }
}
