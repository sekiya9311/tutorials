using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcher.Util
{
    public static class FileSystemWatcherExtensions
    {
        public static IObservable<FileSystemEventArgs> CreatedToObservable(this FileSystemWatcher source)
            => Observable.FromEvent<FileSystemEventHandler, FileSystemEventArgs>(
                h => (s, e) => h(e),
                h => source.Created += h,
                h => source.Created -= h);

        public static IObservable<FileSystemEventArgs> DeletedToObservable(this FileSystemWatcher source)
            => Observable.FromEvent<FileSystemEventHandler, FileSystemEventArgs>(
                h => (s, e) => h(e),
                h => source.Deleted += h,
                h => source.Deleted -= h);

        public static IObservable<FileSystemEventArgs> ChangedToObservable(this FileSystemWatcher source)
            => Observable.FromEvent<FileSystemEventHandler, FileSystemEventArgs>(
                h => (s, e) => h(e),
                h => source.Changed += h,
                h => source.Changed -= h);

        public static IObservable<RenamedEventArgs> RenamedToObservable(this FileSystemWatcher source)
            => Observable.FromEvent<RenamedEventHandler, RenamedEventArgs>(
                h => (s, e) => h(e),
                h => source.Renamed += h,
                h => source.Renamed -= h);
    }
}
