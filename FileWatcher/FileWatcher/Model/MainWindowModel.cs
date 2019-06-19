using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace FileWatcher.Model
{
    class MainWindowModel : IDisposable
    {

        private readonly string DirectoryPath = Directory.GetCurrentDirectory();
        private readonly string FileFilter = "*.txt";
        public FileSystemWatcher Watcher { get; }

        public MainWindowModel()
        {
            Watcher = new FileSystemWatcher(DirectoryPath, FileFilter)
            {
                EnableRaisingEvents = true
            };
        }

        public void Dispose()
        {
            Watcher?.Dispose();
        }
    }
}
