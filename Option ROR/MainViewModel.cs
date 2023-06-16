using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Option_ROR
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _typeMultiplier;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CallPutToggledCommand { get; set; }

        public MainViewModel()
        {
            CallPutToggledCommand = new Command<bool>(CallPutToggled);
            _typeMultiplier = 1;
        }

        private void CallPutToggled(bool isCall)
        {
            _typeMultiplier = isCall ? 1 : -1;
            CalculateDerived();
        }

        private double _optionPrice;
        public double OptionPrice
        {
            get => _optionPrice;
            set
            {
                SetField(ref _optionPrice, value);
                CalculateDerived();
            }
        }

        private double _strikePrice;
        public double StrikePrice
        {
            get => _strikePrice;
            set
            {
                SetField(ref _strikePrice, value);
                CalculateDerived();
            }
        }


        private double _sharePrice;
        public double SharePrice
        {
            get => _sharePrice;
            set
            {
                SetField(ref _sharePrice, value);
                CalculateDerived();
            }
        }

        private int _numberOfDays = 7;
        public int NumberOfDays
        {
            get => _numberOfDays;
            set
            {
                SetField(ref _numberOfDays, value);
                CalculateDerived();
            }
        }

        private double _intrinsicValue;
        public double IntrinsicValue
        {
            get => _intrinsicValue;
            set => SetField(ref _intrinsicValue, value);
        }

        private double _extrinsicValue;
        public double ExtrinsicValue
        {
            get => _extrinsicValue;
            set => SetField(ref _extrinsicValue, value);
        }

        private double _capitalGain;
        public double CapitalGain
        {
            get => _capitalGain;
            set => SetField(ref _capitalGain, value);
        }

        private double _totalGain;
        public double TotalGain
        {
            get => _totalGain;
            set => SetField(ref _totalGain, value);
        }

        private double _movementToStrike;
        public double MovementToStrike
        {
            get => _movementToStrike;
            set => SetField(ref _movementToStrike, value);
        }

        private double _extrinsicRor;
        public double ExtrinsicRor
        {
            get => _extrinsicRor;
            set => SetField(ref _extrinsicRor, value);
        }

        private double _totalRor;
        public double TotalRor
        {
            get => _totalRor;
            set => SetField(ref _totalRor, value);
        }

        private void CalculateDerived()
        {
            IntrinsicValue = Math.Max(_typeMultiplier * (SharePrice - StrikePrice), 0);
            ExtrinsicValue = OptionPrice - IntrinsicValue;
            CapitalGain = Math.Max(StrikePrice - SharePrice, 0);
            TotalGain = CapitalGain + ExtrinsicValue;

            if (SharePrice > 0)
            {
                MovementToStrike = ((StrikePrice - SharePrice) / SharePrice) * 100;
            }
            else
            {
                MovementToStrike = 0;
            }

            if (NumberOfDays > 0 && SharePrice > 0)
            {
                TotalRor = ((TotalGain / SharePrice) * (365f / NumberOfDays)) * 100;
                ExtrinsicRor = ((ExtrinsicValue / SharePrice) * (365f / NumberOfDays)) * 100;
            }
            else
            {
                ExtrinsicRor = 0;
                TotalRor = 0;
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
