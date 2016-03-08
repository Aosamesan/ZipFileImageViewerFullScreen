using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Text.RegularExpressions;

namespace ZipFileImageViewerFullScreen
{
    internal class SortedObservableCollection<T> : ObservableCollection<T> where T : IComparable
    {
        public new void Add(T item)
        {
            if (Count == 0)
                base.Add(item);
            else if (this[0].CompareTo(item) > 0)
                Insert(0, item);
            else if (this[Count - 1].CompareTo(item) < 0)
                base.Add(item);
            else
            {
                int idx = GetIndex(item, 0, Count - 1);
                Insert(idx, item);
            }
        }

        protected int GetIndex(T item, int start, int end)
        {
            // 1 ~ Count - 1
            if (start >= end)
                if (this[start].CompareTo(item) > 0)
                    return start;
                else
                    return start + 1;

            int mid = (start + end) / 2;
            int comp = this[mid].CompareTo(item);
            if (comp > 0)
                return GetIndex(item, start, mid - 1);
            else
                return GetIndex(item, mid + 1, end);

        }
    }

    internal class ImageCollectionViewModel : NotifyPropertyChanged
    {
        public static readonly string ImageFileExtensions;
        public static readonly Regex ImageFileExtensionRegex;
        public OpenCommand OpenCommand { get; set; }
        public SortedObservableCollection<ImageItem> ImageItems { get; set; }
        public string ZipFilePath { get; set; }
        public event Action AfterFileOpened;

        static ImageCollectionViewModel()
        {
            // For RegularExpression
            ImageFileExtensions = @"\.(jpg|jpeg|png|bmp|gif)$";
            ImageFileExtensionRegex = new Regex(ImageFileExtensions, RegexOptions.IgnoreCase);
        }

        public ImageCollectionViewModel()
        {
            ImageItems = new SortedObservableCollection<ImageItem>();
            OpenCommand = new OpenCommand(AddItems);
        }

        private void AddItems(string zipFilePath)
        {
            if (File.Exists(zipFilePath))
            {
                ImageItems.Clear();
                using (var fs = File.Open(zipFilePath, FileMode.Open))
                using (var archive = new ZipArchive(fs))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (ImageFileExtensionRegex.IsMatch(entry.Name))
                        {
                            byte[] imageBytes = null;
                            using (MemoryStream ms = new MemoryStream())
                            using (var file = entry.Open())
                            {
                                file.CopyTo(ms);
                                imageBytes = ms.ToArray();
                            }
                            if (imageBytes != null)
                                ImageItems.Add(new ImageItem(entry.Name, imageBytes));
                        }
                    }
                }
                ZipFilePath = zipFilePath.Split('\\').Last();
                OnPropertyChanged(nameof(ZipFilePath));
                AfterFileOpened?.Invoke();
            }
        }
    }
}
