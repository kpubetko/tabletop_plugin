using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table_Top_Plugin.Models
{
    //TODO: XML
    public class Parameter
    {
        //TODO: RSDN
        double _value;
        double _minValue;
        double _maxValue;

        public event EventHandler ParameterChanged;

        public Parameter(double min, double max)
        {
            SetBoundaries(min, max);
        }

        protected virtual void OnParameterChanged()
        {
            ParameterChanged?.Invoke(this, EventArgs.Empty);
        }

        //TODO: refactor
        public double SetValue
        {
            set
            {
                if(value > _maxValue || value < _minValue)
                {
                    return;
                }
                _value = value;
                OnParameterChanged();
            }
        }

        //TODO: refactor
        public double GetValue
        {
            get
            {
                return _value;
            }
        }

        //TODO: XML
        public void SetBoundaries(double min, double max)
        {
            if(min > max)
            {
                double temp = min;
                min = max;
                max = temp;
            }
            _minValue = min;
            _maxValue = max;
            OnParameterChanged();
        }

        //TODO: refactor
        public double GetMin
        {
            get
            {
                return _minValue;
            }
        }

        //TODO: refactor
        public double GetMax
        {
            get
            {
                return _maxValue;
            }
        }
    }
}
