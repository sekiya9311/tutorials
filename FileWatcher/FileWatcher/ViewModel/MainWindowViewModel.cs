using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Reactive.Bindings;

using FileWatcher.Model;
using FileWatcher.Util;

namespace FileWatcher.ViewModel
{
    class MainWindowViewModel
    {
        private readonly MainWindowModel _model;

        public ReadOnlyReactiveProperty<string> WatchFileState { get; }

        public MainWindowViewModel()
        {
            _model = new MainWindowModel();

            WatchFileState = Observable.Merge(
                _model.Watcher.CreatedToObservable(),
                _model.Watcher.DeletedToObservable(),
                _model.Watcher.ChangedToObservable(),
                _model.Watcher.RenamedToObservable()).Select(e =>
                {
                    switch (e.ChangeType)
                    {
                        case System.IO.WatcherChangeTypes.Created:
                            return "新しく作られた！";
                        case System.IO.WatcherChangeTypes.Deleted:
                            return "消された！";
                        case System.IO.WatcherChangeTypes.Changed:
                            return "なんか変わった！";
                        case System.IO.WatcherChangeTypes.Renamed:
                            return "名前変わった！";
                        case System.IO.WatcherChangeTypes.All:
                            return "全部!?";
                        default:
                            return "知らない子ですね";
                    }
                }).ToReadOnlyReactiveProperty();
        }
    }
}
