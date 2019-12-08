using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Trpz2.Models
{
    public class ProductDto: INotifyPropertyChanged
    {
        private long _id;
        private string _name;
        private string _description;
        private double _price;
        private TagDto _tag;

        public long Id { get { return _id; } set { _id = value; OnPropertyChanged(); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public string Description { get { return _description; } set { _description = value; OnPropertyChanged(); } }
        public double Price { get { return _price; } set { _price = value; OnPropertyChanged(); } }
        public TagDto Tag { get { return _tag; } set { _tag = value; OnPropertyChanged(); } }


        //public string Description { get; set; }

        //public double Price { get; set; }

        //public TagDto Tag { get; set; }

       
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
