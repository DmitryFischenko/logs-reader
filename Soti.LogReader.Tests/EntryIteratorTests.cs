using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Soti.LogReader.Entries;
using Soti.LogReader.Locators;

namespace Soti.LogReader.Tests
{
    [TestFixture]
    internal class EntryIteratorTests
    {
        [Test]
        public void ShouldIterateProperly()
        {
            var list = new List<LogEntry>();
            list.Add(new LogEntry() { Message = "1" });
            list.Add(new LogEntry() { Message = "2" });
            list.Add(new LogEntry() { Message = "3" });
            list.Add(new LogEntry() { Message = "4" });

            var iterator = new EntryIterator<LogEntry>();
            iterator.SetList(list.ToArray());

            Assert.That(iterator.Current.Message, Is.EqualTo("1"));
            iterator.Next();
            Assert.That(iterator.Current.Message, Is.EqualTo("2"));
            iterator.Last();
            Assert.That(iterator.Current.Message, Is.EqualTo("4"));
            iterator.Next();
            Assert.That(iterator.Current.Message, Is.EqualTo("4"));
            iterator.Previous();
            Assert.That(iterator.Current.Message, Is.EqualTo("3"));
            iterator.Reset();
            Assert.That(iterator.Current.Message, Is.EqualTo("1"));
            iterator.Previous();
            Assert.That(iterator.Current.Message, Is.EqualTo("1"));
        }

        [Test]
        public void ShouldReturnNullAsCurrentForEmptyList()
        {
            var iterator = new EntryIterator<LogEntry>();
            iterator.SetList(new List<LogEntry>().ToArray());
            Assert.That(iterator.Current, Is.Null);
        }
    }
}
