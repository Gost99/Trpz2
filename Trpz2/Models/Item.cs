using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Trpz2.Models
{
    public class Item: INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private double _price;

        public string Name { 
            get => _name;
            set {
                _name = value;
                OnPropertyChanged();
            } 
        }

        public string Description { 
            get => _description;
            set {
                _description = value;
                OnPropertyChanged();
            } 
        }

        public double? Price { get => _price;
            set {
                if(value.HasValue)
                {
                    _price = value.Value;
                }
                OnPropertyChanged();
            } }

        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
