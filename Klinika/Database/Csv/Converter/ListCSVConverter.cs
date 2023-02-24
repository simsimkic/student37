using System;
using System.Collections.Generic;
using System.Linq;

namespace Klinika.Database.Csv.Converter
{
    public static class IdListCSVConverter
    {
        public static string convertToCSVFormat(IEnumerable<IIdentifiable<long>> entities)
        {
            if (entities == null) return "";
            List<string> stringEntities = new List<string>();
            foreach(IIdentifiable<long> entity in entities)
            {
                stringEntities.Add(entity.GetId().ToString());
            }
            return string.Join(";", stringEntities.ToArray());
        }
        public static string convertToCSVFormat(IEnumerable<IIdentifiable<string>> entities)
        {
            List<string> stringEntities = new List<string>();
            foreach (IIdentifiable<string> entity in entities)
            {
                stringEntities.Add(entity.GetId());
            }
            return string.Join(";", stringEntities.ToArray());
        }

        public static List<long> convertToLongList(string csvList)
        {
            List<long> idsList = new List<long>();
            if (csvList.Equals(""))
            {
                return idsList;
            }
            List<string> tokens = csvList.Split(';').ToList();
            tokens.ForEach(token => idsList.Add(long.Parse(token)));
            return idsList;
        }

        public static List<string> convertToStringList(string csvList)
        {
            List<string> idsList = new List<string>();
            if(csvList.Equals(""))
            {
                return idsList;
            }
            idsList = csvList.Split(';').ToList();
            return idsList;
        }


    }

}
