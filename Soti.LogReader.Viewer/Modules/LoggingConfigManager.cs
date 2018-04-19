using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Soti.LogReader.Viewer.Modules
{
    public static class LoggingConfigManager
    {
        private static readonly string _msConfigPath;
        private static readonly string _dsConfigPath;

        static LoggingConfigManager()
        {
            var path = McInstallationLocator.Locate().InstallPath;
            _msConfigPath = Path.Combine(path, "Soti.MobiControl.ManagementService.Host.exe.config");
            _dsConfigPath = Path.Combine(path, "MCDeplSvr.exe.config");
        }

        public static void Read()
        {
            //var xDoc = XDocument.Load(GetPath());
            //var switches = xDoc.Descendants("switches").First().Elements().ToDictionary(a => a.Attribute("name")?.Value, a => a.Attribute("value")?.Value);
            //xDoc.Descendants("switches").First().Elements().First(a => a.Attribute("name").Value == "AccessControl").Attribute("value").Value = "Verbose";
            //Update(xDoc);
        }

        public static void SetSwitchValue(string key, string value)
        {
            
        }

        public static void TurnOffBufferedLogAppenders()
        {
            TurnOffBufferedLogAppender(_msConfigPath);
            TurnOffBufferedLogAppender(_dsConfigPath);
        }

        private static void Update(XDocument xDoc, string path)
        {
            using (var writer = XmlWriter.Create(path, new XmlWriterSettings() { Indent = true }))
            {
                xDoc.WriteTo(writer);
            }
        }

        private static void TurnOffBufferedLogAppender(string path)
        {
            var xDoc = XDocument.Load(path);
            var log4NetSection = xDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "log4net");
            if (log4NetSection == null) return;

            var root = log4NetSection.Elements("root");
            var appenders = root.Elements("appender-ref");
            var bufferedAppender = appenders.FirstOrDefault(a => a.Attribute("ref")?.Value == "BufferingForwardingAppender");
            if (bufferedAppender == null) return;

            bufferedAppender.Attribute("ref").Value = "FileAppender";
            Update(xDoc, path);
        }
    }
}
