﻿using System;
using Soti.LogReader.Entries;
using Soti.LogReader.Model;

namespace Soti.LogReader.Components.DbInstall
{
    /// <summary>
    /// Ex. 1:  2016/11/23 16:20:16.048(0x00000b98): 	EVENT: Add shared file: type=8, name=NET_686_1400M.SIF
    /// Ex. 2:  2016-11-08 10:54:43.117:	DACPAC: Pending [2]: Registering metadata for database
    /// </summary>
    public class DbInstallEntryParser : IEntryParser<DbInstallLogEntry>
    {
        public DbInstallLogEntry Parse(string text)
        {
            var entry = new DbInstallLogEntry();
            var dateStr = text.Substring(0, 23).Replace('/','-');
            DateTime timeCreate;
            if (!DateTime.TryParse(dateStr, out timeCreate))
            {
                entry.IsParseError = true;
                entry.FullText = text;
                return entry;
            }
            entry.TimeCreated = timeCreate;
            var tabIndex = text.IndexOf("\t", StringComparison.Ordinal);

            var colonIndex = text.IndexOf(":", tabIndex, StringComparison.Ordinal);
            var type = text.Substring(tabIndex + 1, colonIndex - tabIndex-1);
            Level level;
            if (Enum.TryParse(type, true, out level))
                entry.Level = level;
            else
                Console.WriteLine("Unknown level : {0}", type);

            entry.Message = text.Substring(colonIndex + 1).Trim();

            return entry;
        }
    }
}
