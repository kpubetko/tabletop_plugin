namespace TableTopPlugin.Models
{
    /// <summary>
    /// Представляет параметр с ограниченным диапазоном значений
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Текущее значение параметра
        /// </summary>
        private double _value;

        /// <summary>
        /// Минимально допустимое значение параметра
        /// </summary>
        private double _minValue;

        /// <summary>
        /// Максимально допустимое значение параметра
        /// </summary>
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