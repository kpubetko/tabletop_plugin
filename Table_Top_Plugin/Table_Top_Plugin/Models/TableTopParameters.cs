namespace TableTopPlugin.Models
{
    /// <summary>
    /// Параметры столешницы
    /// </summary>
    public class TableTopParameters
    {
        private Dictionary<ParametersList, Parameter> _parameters;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="TableTopParameters"/> с параметрами по умолчанию
        /// </summary>
        /// <remarks>
        /// Устанавливает начальные границы для всех параметров столешницы:
        /// - Длина: от 1000 до 2500 мм
        /// - Ширина: от 1000 до 2500 мм
        /// - Высота: от 15 до 50 мм
        /// - Радиус скругления углов: от 0 до 0 мм (неактивно до установки размеров)
        /// - Радиус фаски: от 0 до 0 мм (неактивно до установки высоты)
        /// </remarks>
        public TableTopParameters()
        {
            _parameters = new Dictionary<ParametersList, Parameter>()
            {
                { ParametersList.Length, new Parameter(1000, 2500) },
                { ParametersList.Width, new Parameter(1000, 2500) },
                { ParametersList.Height, new Parameter(15, 50) },
                { ParametersList.CornerRadius, new Parameter(0, 0) },
                { ParametersList.ChamferRadius, new Parameter(0, 0) }
            };
            _parameters[ParametersList.Length].ParameterChanged += LengthOrWidthChanged;
            _parameters[ParametersList.Width].ParameterChanged += LengthOrWidthChanged;
            _parameters[ParametersList.Height].ParameterChanged += HeightChanged;
        }

        /// <summary>
        /// Обработчик изменения длины или ширины столешницы
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        /// <remarks>
        /// Автоматически обновляет максимальное значение радиуса скругления углов
        /// в зависимости от меньшего из размеров (длины или ширины)
        /// </remarks>
        private void LengthOrWidthChanged(object sender, EventArgs e)
        {
            if (_parameters[ParametersList.Length].Value < _parameters[ParametersList.Width].Value)
            {
                _parameters[ParametersList.CornerRadius].SetBoundaries(_parameters[ParametersList.CornerRadius].Min,
                    _parameters[ParametersList.Length].Value / 2);
            }
            else
            {
                _parameters[ParametersList.CornerRadius].SetBoundaries(_parameters[ParametersList.CornerRadius].Min,
                    _parameters[ParametersList.Width].Value / 2);
            }
        }

        /// <summary>
        /// Обработчик изменения высоты столешницы
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        /// <remarks>
        /// Автоматически обновляет максимальное значение радиуса фаски
        /// в зависимости от половины высоты столешницы
        /// </remarks>
        public void HeightChanged(object sender, EventArgs e)
        {
            _parameters[ParametersList.ChamferRadius].SetBoundaries(_parameters[ParametersList.ChamferRadius].Min,
                _parameters[ParametersList.Height].Value / 2);
        }

        /// <summary>
        /// Получает параметр длины столешницы
        /// </summary>
        public Parameter Length
        {
            get
            {
                return _parameters[ParametersList.Length];
            }
        }

        /// <summary>
        /// Получает параметр ширины столешницы
        /// </summary>
        public Parameter Width
        {
            get
            {
                return _parameters[ParametersList.Width];
            }
        }

        /// <summary>
        /// Получает параметр высоты столешницы
        /// </summary>
        public Parameter Height
        {
            get
            {
                return _parameters[ParametersList.Height];
            }
        }

        /// <summary>
        /// Получает параметр радиуса скругления углов
        /// </summary>
        /// <remarks>
        /// Максимальное значение автоматически ограничивается половиной меньшего размера (длины или ширины)
        /// </remarks>
        public Parameter CornerRadius
        {
            get
            {
                return _parameters[ParametersList.CornerRadius];
            }
        }

        /// <summary>
        /// Получает параметр радиуса фаски
        /// </summary>
        /// <remarks>
        /// Максимальное значение автоматически ограничивается половиной высоты столешницы
        /// </remarks>
        public Parameter ChamferRadius
        {
            get
            {
                return _parameters[ParametersList.ChamferRadius];
            }
        }
    }
}