using System.Collections.Generic;
using Soti.CommTracer;
using Soti.CommTracer.Model;
using Soti.LogReader.Entries;
using WeifenLuo.WinFormsUI.Docking;

namespace Soti.LogReader.Viewer.Views.CommTracerView
{
    public partial class CommTracerView : DockContent
    {
        private Client _client;
        private ICollection<CommMessage> _data = new List<CommMessage>();

        public CommTracerView()
        {
            InitializeComponent();
        }

        private void CommTracerView_Load(object sender, System.EventArgs e)
        {
            fastObjectListView1.SetObjects(_data);
            fastObjectListView1.UseOverlays = false;

            _client = new Client();
            _client.OnMessageRecived += (m) =>
            {
                fastObjectListView1.AddObject(m);
            };

            _client.Connect("localhost", 5494);
        }

        private void fastObjectListView1_SelectionChanged(object sender, System.EventArgs e)
        {
            if (fastObjectListView1.SelectedObject is CommMessage selected)
                EventBus.Bus.GetEvent<CommTracerMessageSelected>().Publish(selected);
        }
    }
}
