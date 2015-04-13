using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Zim.Tech.TravelConnect.Common
{
    public static class Variables
    {
        public const string YES = "Y";
        public const string NO = "N";
        public const string DEFAULT_CURRENCY = "HKD";
        public const string DATE_FORMAT = "yyyy-MM-dd"; // Date Format YYYYMMDD
        public const string TIME_FORMAT = "HHmm";
        public const string START_TIME = "0000"; // Start Tmie 00:00
        public const string END_TIME = "2359"; // Start Tmie 23:59

        public static string NewUUID()
        {
            string uuid = string.Empty;
            System.Guid guid = System.Guid.NewGuid();
            uuid = Convert.ToBase64String(guid.ToByteArray());

            return uuid;
        }

        public static T CopyObject<S, T>(S sourceObject, T destObject)
        {
            if (sourceObject == null || destObject == null)
                return destObject;

            //  Get the type of each object
            Type sourceType = sourceObject.GetType();
            Type targetType = destObject.GetType();

            //  Loop through the source properties
            foreach (PropertyInfo sourceProp in sourceType.GetProperties())
            {
                try
                {
                    //  Get the matching property in the destination object
                    PropertyInfo destProp = targetType.GetProperty(sourceProp.Name);
                    //  If there is none, skip
                    if (destProp == null && destProp.CanWrite == false)
                        continue;
                    else if (sourceProp.CanRead == false)
                        continue;

                    //  Set the value in the destination
                    object value = sourceProp.GetValue(sourceObject, null);
                    destProp.SetValue(destObject, value, null);
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message;
                }
            }

            return destObject;
        }

    }
}
