using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ZipFileImageViewerFullScreen
{
    internal struct ImageItemStruct
    {
        public string name;
        public BitmapImage image;
    }

    internal class ImageItem : NotifyPropertyChanged, IComparable
    {
        private ImageItemStruct item;

        public string Name
        {
            get
            {
                return item.name;
            }
            set
            {
                item.name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public BitmapImage Image
        {
            get
            {
                return item.image;
            }
            set
            {
                item.image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public ImageItem(string name, byte[] imageBytes)
        {
            Name = name;
            Image = new BitmapImage();
            Image.BeginInit();
            Image.StreamSource = new MemoryStream(imageBytes);
            Image.DownloadCompleted += (sender, e) => OnPropertyChanged(nameof(Image));
            Image.EndInit();
        }

        public int CompareTo(object obj)
        {
            if (!(obj is ImageItem))
                throw new ArgumentException();
            return string.Compare(Name, (obj as ImageItem).Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
