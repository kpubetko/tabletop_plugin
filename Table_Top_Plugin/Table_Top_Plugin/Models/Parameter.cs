using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table_Top_Plugin.Models
{
    public class Parameter
    {
        double _value;
        double _minValue;
        double _maxValue;
        List<Action> _actionsIfItChanged = new List<Action>();

        public Parameter(double min, double max, Action act = null)
        {
            SetBoundaries(min, max);
            if(act != null)
            {
                _actionsIfItChanged.Add(act);
            }
        }
        public void AddAction(Action act)
        {
            if (act != null)
            {
                _actionsIfItChanged.Add(act);
            }
        }
        //public void CallActions()
        //{
        //    if (_actionsIfItChanged.Count != 0)
        //    {
        //        foreach (Action action in _actionsIfItChanged)
        //        {
        //            action.Invoke();
        //        }
        //    }
        //}
        public double SetValue
        {
            set
            {
                if(_minValue == null || _maxValue == null)
                {
                    return;
                }
                if(value > _maxValue || value < _minValue)
                {
                    return;
                }
                _value = value;
                if(_actionsIfItChanged.Count != 0)
                {
                    foreach(Action action in _actionsIfItChanged)
                    {
                        action.Invoke();
                    }
                }
            }
        }
        public double GetValue
        {
            get
            {
                return _value;
            }
        }


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
            if (_actionsIfItChanged.Count != 0)
            {
                foreach (Action action in _actionsIfItChanged)
                {
                    action.Invoke();
                }
            }
        }
        public double GetMin
        {
            get
            {
                return _minValue;
            }
        }
        public double GetMax
        {
            get
            {
                return _maxValue;
            }
        }
    }
}
