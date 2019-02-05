﻿using System.Data;

namespace UnikMarketing.Integration.Tools.Extensions
{
    public static class SqlDataRecordExtension
    {
        public static string SafeGetString(this IDataRecord dataRecord, string column)
        {
            if (dataRecord.IsDBNull(dataRecord.GetOrdinal(column)))
            {
                return null;
            }
            return (string)dataRecord[column];
        }

        public static decimal? SafeGetDecimal(this IDataRecord dataRecord, string column)
        {
            if (dataRecord.IsDBNull((dataRecord.GetOrdinal(column))))
            {
                return null;
            }
            return (decimal?)dataRecord[column];
        }

        public static string SafeGetDateTime(this IDataRecord dataRecord, string column)
        {
            int index = dataRecord.GetOrdinal(column);
            if (dataRecord.IsDBNull(index))
            {
                return null;
            }
            return dataRecord.GetDateTime(index).ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}