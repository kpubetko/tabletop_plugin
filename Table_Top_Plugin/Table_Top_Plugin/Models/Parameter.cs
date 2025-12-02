namespace TableTopPlugin.Models
{
    //TODO: XML +
    /// <summary>
    /// Представляет параметр с ограниченным диапазоном значений
    /// </summary>
    public class Parameter
    {
        //TODO: RSDN +
        private double _value;
        private double _minValue;
        private double _maxValue;

        /// <summary>
        /// Событие, возникающее при изменении параметра
        /// </summary>
        public event EventHandler ParameterChanged;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Parameter"/>
        /// </summary>
        /// <param name="min">Минимальное значение параметра</param>
        /// <param name="max">Максимальное значение параметра</param>
        public Parameter(double min, double max)
        {
            SetBoundaries(min, max);
        }

        /// <summary>
        /// Вызывает событие <see cref="ParameterChanged"/>
        /// </summary>
        protected virtual void OnParameterChanged()
        {
            ParameterChanged?.Invoke(this, EventArgs.Empty);
        }

        //TODO: refactor +
        //public double SetValue
        //{
        //    set
        //    {
        //        if(value > _maxValue || value < _minValue)
        //        {
        //            return;
        //        }
        //        _value = value;
        //        OnParameterChanged();
        //    }
        //}

        //TODO: refactor +
        //public double GetValue
        //{
        //    get
        //    {
        //        return _value;
        //    }
        //}

        /// <summary>
        /// Получает или задает текущее значение параметра
        /// </summary>
        /// <remarks>
        /// При установке значения проверяется его соответствие допустимому диапазону
        /// </remarks>
        public double Value
        {
            set
            {
                if (value > _maxValue || value < _minValue)
                {
                    return;
                }
                _value = value;
                OnParameterChanged();
            }
            get
            {
                return _value;
            }
        }

        //TODO: XML +
        /// <summary>
        /// Устанавливает границы допустимых значений параметра
        /// </summary>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <remarks>
        /// Если min больше max, значения автоматически меняются местами
        /// </remarks>
        public void SetBoundaries(double min, double max)
        {
            if (min > max)
            {
                double temp = min;
                min = max;
                max = temp;
            }
            _minValue = min;
            _maxValue = max;
            OnParameterChanged();
        }

        //TODO: refactor +
        /// <summary>
        /// Получает минимальное значение параметра
        /// </summary>
        public double Min
        {
            get
            {
                return _minValue;
            }
        }

        //TODO: refactor +
        /// <summary>
        /// Получает максимальное значение параметра
        /// </summary>
        public double Max
        {
            get
            {
                return _maxValue;
            }
        }
    }
}