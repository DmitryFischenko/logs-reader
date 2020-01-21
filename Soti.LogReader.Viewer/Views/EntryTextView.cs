using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;
using Soti.LogReader.Entries;
using WeifenLuo.WinFormsUI.Docking;
using Clipboard = System.Windows.Clipboard;

namespace Soti.LogReader.Viewer.Views
{
    public partial class EntryTextView : DockContent
    {
        private LogEntry _currentEntry;
        List<LogFormatter> _formatters = new List<LogFormatter>();

        public EntryTextView()
        {
            InitializeComponent();
            this.Text = "Message";

            _formatters.Add(new LogFormatter()
            {
                MatchPredictae = o => o.Message.Contains(@"{""Snapshot"":"),
                Formatter = msg => msg.Replace(",", Environment.NewLine)
            });

            _formatters.Add(new LogFormatter()
            {
                MatchPredictae = o=>o.Message.StartsWith(@"SAML2 response:") || o.Message.StartsWith(@"SAML2 request:"),
                Formatter = msg =>
                {
                    var doc = XDocument.Parse(msg.Replace("SAML2 response: ", string.Empty).Replace("SAML2 request: ", string.Empty));
                    return doc.ToString();
                }
            });

            _formatters.Add(new LogFormatter()
            {
                MatchPredictae = o => o.Message.Contains("<plist "),
                Formatter = msg =>
                {
                    var startIndex = msg.IndexOf("<plist", StringComparison.Ordinal);
                    var lastIndex = msg.IndexOf("</plist>", StringComparison.Ordinal) + "</plist>".Length;
                    if (startIndex < 0 || lastIndex < 0)
                        return msg;

                    var xml = msg.Substring(startIndex, lastIndex - startIndex);
                    var formattedXml = XDocument.Parse(xml).ToString();
                    return msg.Replace(xml, formattedXml);
                }
            });

            _formatters.Add(new LogFormatter()
            {
                MatchPredictae = o => o.Message.Contains(@"DeviceInfoMsg: {""Snapshot"":"),
                Formatter = msg => msg.Replace(",", Environment.NewLine)
            });

            filterBySelectedBtn.Enabled = false;
            EventBus.Bus.GetEvent<LogEntrySelected>().Subscribe(log =>
            {
                _currentEntry = log;
                richTextBox1.Text = log?.Message ?? string.Empty;
            });

            EventBus.Bus.GetEvent<CommTracerMessageSelected>().Subscribe(msg =>
            {
                richTextBox1.Text = JsonHelper.FormatJson(msg.Message);
            });
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
            try
            {
                Process.Start("Notepad++", "-nosession");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running Notepad++ : " + ex.Message);
            }
        }

        private void richTextBox1_SelectionChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.SelectedText))
            {
                filterBySelectedBtn.Enabled = false;
            }
            else
            {
                filterBySelectedBtn.Enabled = true;
            }
        }

        private void filterBySelectedBtn_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.SelectedText))
                return;

            EventBus.Bus.GetEvent<FilterByText>().Publish(richTextBox1.SelectedText);
        }

        private void EntryTextView_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

        }

        private void formatBtn_Click(object sender, EventArgs e)
        {
            foreach (var logFormatter in _formatters)
            {
                if (logFormatter.MatchPredictae(_currentEntry))
                    richTextBox1.Text = logFormatter.Formatter(_currentEntry.Message);
            }
        }

        private void removeFormatBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = _currentEntry.Message;
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.W)
            {
                richTextBox1.WordWrap = !richTextBox1.WordWrap;
            }
        }
    }

    public class LogFormatter
    {
        public Predicate<LogEntry> MatchPredictae { get; set; }

        public Func<string, string> Formatter { get; set; }
    }
}
