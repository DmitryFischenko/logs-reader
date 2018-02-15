using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Soti.LogReader.Log;
using WeifenLuo.WinFormsUI.Docking;

namespace Soti.LogReader.Viewer.Views
{
    class ViewManager
    {
        readonly Dictionary<LogFile, DockContent> _map = new Dictionary<LogFile, DockContent>();
        public ViewManager()
        {
            EventBus.Bus.GetEvent<LogFileDoubleClick>().Subscribe(AddDocument);

            EventBus.Bus.GetEvent<ViewRemoved>().Subscribe(
                (view) => _map.Remove(_map.First(m => m.Value == view).Key)
            );
        }

        private void AddDocument(LogFile logFile)
        {
            if (_map.ContainsKey(logFile))
                EventBus.Bus.GetEvent<ActivateView>().Publish(_map[logFile]);
            else
            {
                var view = new FileTableView.FileTableView(logFile);
                _map.Add(logFile, view);
                EventBus.Bus.GetEvent<AddView>().Publish(view);
            }
        }

    }
}
