using System.Diagnostics;
using System.Windows;
using WeifenLuo.WinFormsUI.Docking;

namespace Soti.LogReader.Viewer.Views
{
    public partial class EntryTextView : DockContent
    {
        public EntryTextView()
        {
            InitializeComponent();
            this.Text = "Message";
            filterBySelectedBtn.Enabled = false;
            EventBus.Bus.GetEvent<LogEntrySelected>().Subscribe(log => richTextBox1.Text = log?.Message ?? string.Empty);
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
            Process.Start("Notepad++","-nosession");
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
    }
}
