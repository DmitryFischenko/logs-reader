using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Soti.LogReader.Log;
using WeifenLuo.WinFormsUI.Docking;

namespace Soti.LogReader.Viewer.Views
{
    public class ViewManager
    {
        private static ViewManager _instance;

        readonly Dictionary<LogFile, DockContent> _map = new Dictionary<LogFile, DockContent>();

        private ViewManager()
        {

        }

        public static ViewManager Instance => _instance ?? (_instance = new ViewManager());

        public void Init()
        {
            EventBus.Bus.GetEvent<OpenLogFile>().Subscribe(AddDocument);

            EventBus.Bus.GetEvent<ViewRemoved>().Subscribe(
                (view) =>
                {
                    _map.Remove(_map.First(m => m.Value == view).Key);
                });
        }

        private void AddDocument(LogFile logFile)
        {
            if (_map.ContainsKey(logFile))
                EventBus.Bus.GetEvent<ActivateView>().Publish(_map[logFile]);
            else
            {
                var view = new FileTableView.FileTableView(logFile);
                view.FormClosed += (o, e) =>
                {
                    _map.Remove(logFile);
                };
                _map.Add(logFile, view);
                EventBus.Bus.GetEvent<AddView>().Publish(view);
            }
        }

    }
}
