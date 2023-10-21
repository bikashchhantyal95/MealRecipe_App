using System;
using System.Globalization;
using Humanizer;

namespace MovieRecipeMobileAPp.Converters
{
	public class DateConvertor: IValueConverter
	{
	

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                TimeSpan timeSince = DateTime.Now - dateTime;

                if (timeSince.TotalMinutes < 1)
                {
                    return "just now";
                }
                if (timeSince.TotalMinutes < 60)
                {
                    int minutes = (int)timeSince.TotalMinutes;
                    return $"{minutes} {(minutes == 1 ? "min" : "mins")} ago";
                }
                if (timeSince.TotalHours < 24)
                {
                    int hours = (int)timeSince.TotalHours;
                    return $"{hours} {(hours == 1 ? "hour" : "hours")} ago";
                }
                if (timeSince.TotalDays < 30)
                {
                    int days = (int)timeSince.TotalDays;
                    return $"{days} {(days == 1 ? "day" : "days")} ago";
                }
                if (timeSince.TotalDays < 365)
                {
                    int months = (int)(timeSince.TotalDays / 30);
                    return $"{months} {(months == 1 ? "month" : "months")} ago";
                }

                int years = (int)(timeSince.TotalDays / 365);
                return $"{years} {(years == 1 ? "year" : "years")} ago";
            }

            return "N/A";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

