using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Option_ROR
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _optionPrice;
        public double OptionPrice //per contract -- 100 shares
        {
            get => _optionPrice;
            set
            {
                SetField(ref _optionPrice, value);
                CalculateRor();
            }
        }

        private double _sharePrice;
        public double SharePrice
        {
            get => _sharePrice;
            set
            {
                SetField(ref _sharePrice, value);
                CalculateRor();
            }
        }

        private int _numberOfDays = 7;
        public int NumberOfDays
        {
            get => _numberOfDays;
            set
            {
                SetField(ref _numberOfDays, value);
                CalculateRor();
            }
        }

        private double _ror;
        public double Ror
        {
            get => _ror;
            set => SetField(ref _ror, value);
        }

        public MainViewModel() { }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CalculateRor()
        {
            if (SharePrice > 0 && NumberOfDays > 0)
            {
                Ror = ((OptionPrice / 100) / SharePrice) * (365f / NumberOfDays);
            }
            else
            {
                Ror = 0;
            }
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
