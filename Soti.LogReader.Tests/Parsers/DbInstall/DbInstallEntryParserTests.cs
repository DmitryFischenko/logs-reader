using System;
using NUnit.Framework;
using Soti.LogReader.Parsers;

namespace Soti.LogReader.Tests.Parsers.DbInstall
{
    [TestFixture]
    public class DbInstallEntryParserTests
    {
        private const string RegularEntry = @"2016/11/23 16:20:16.048(0x00000b98): 	EVENT: Add shared file: type=8, name=NET_686_1400M.SIF";

        private const string RegularEntry1 = @"2016/11/08 10:58:30.636(0x00001610):    ERROR: DACPAC deployment failed with error -1";
        private const string NotParsebleEntry = @"20qqq16/qqq11/23 16:20:16.048(0x00000b98): 	EVENT: Add shared file: type=8, name=NET_686_1400M.SIF";

        [Test]
        public void RegularEntryTest()
        {
            var parser = new DbInstallEntryParser();
            var entry = parser.Parse(RegularEntry);
            Assert.That(entry.TimeCreated, Is.EqualTo(new DateTime(2016, 11, 23, 16, 20, 16, 48)));

            entry = parser.Parse(RegularEntry1);
            Assert.That(entry.TimeCreated, Is.EqualTo(new DateTime(2016, 11, 08, 10, 58, 30, 636)));
        }

        [Test]
        public void ParseErrorTest()
        {
            var parser = new DbInstallEntryParser();
            var entry = parser.Parse(NotParsebleEntry);
            Assert.That(entry.IsParseError, Is.True, "Has to have 'IsParseError' set to true");
            Assert.That(entry.FullText, Is.EqualTo(NotParsebleEntry));
        }
    }
}
