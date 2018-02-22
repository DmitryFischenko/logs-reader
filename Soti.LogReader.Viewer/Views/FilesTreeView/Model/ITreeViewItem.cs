using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soti.LogReader.Viewer.Views.FilesTreeView.Model
{
    public interface ITreeViewItem
    {
        string Title { get;  }
        bool IsExpandable { get;  }
        IEnumerable<object> GetChildren();

        string Tooltip { get; }
    }
}
