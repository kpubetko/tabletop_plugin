namespace TableTopPlugin.Models
{
    /// <summary>
    /// Параметры столешницы
    /// </summary>
    public class TableTopParameters
    {
        /// <summary>
        /// Словарь параметров столешницы
        /// </summary>
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
        /// - Амплитуда волны: от 0 до 0 мм (неактивно до установки размеров)
        /// </remarks>
        public TableTopParameters()
        {
            _parameters = new Dictionary<ParametersList, Parameter>()
            {
                { ParametersList.Length, new Parameter(1000, 2500) },
                { ParametersList.Width, new Parameter(1000, 2500) },
                { ParametersList.Height, new Parameter(15, 50) },
                { ParametersList.CornerRadius, new Parameter(0, 0) },
                { ParametersList.ChamferRadius, new Parameter(0, 0) },
                { ParametersList.WaveAmplitude, new Parameter(0, 0) }
            };
            _parameters[ParametersList.Length].ParameterChanged
                += LengthOrWidthChanged;
            _parameters[ParametersList.Width].ParameterChanged
                += LengthOrWidthChanged;
            _parameters[ParametersList.Height].ParameterChanged
                += HeightChanged;
            _parameters[ParametersList.WaveAmplitude].ParameterChanged
                += WaveAmplitudeChanged;
        }

        /// <summary>
        /// Обработчик изменения длины или ширины столешницы
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        /// <remarks>
        /// Автоматически обновляет максимальное значение радиуса скругления углов
        /// в зависимости от меньшего из размеров (длины или ширины).
        /// Если волна включена (амплитуда больше 0), максимум радиуса ограничивается 1/4 от размера,
        /// иначе 1/2 от размера.
        /// Также обновляет максимальную амплитуду волны (не более 1/3 от меньшего размера)
        /// </remarks>
        private void LengthOrWidthChanged(object sender, EventArgs e)
        {
            double minSize = Math.Min(
                _parameters[ParametersList.Length].Value,
                _parameters[ParametersList.Width].Value);

            double cornerRadiusDivisor = 
                _parameters[ParametersList.WaveAmplitude].Value > 0 ? 4 : 2;

            if (_parameters[ParametersList.Length].Value <
                _parameters[ParametersList.Width].Value)
            {
                _parameters[ParametersList.CornerRadius].SetBoundaries(
                    _parameters[ParametersList.CornerRadius].Min,
                    _parameters[ParametersList.Length].Value / 
                    cornerRadiusDivisor);
            }
            else
            {
                _parameters[ParametersList.CornerRadius].SetBoundaries(
                    _parameters[ParametersList.CornerRadius].Min,
                    _parameters[ParametersList.Width].Value / 
                    cornerRadiusDivisor);
            }

            _parameters[ParametersList.WaveAmplitude].SetBoundaries(
                0,
                minSize / 3);
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
            _parameters[ParametersList.ChamferRadius].SetBoundaries(
                _parameters[ParametersList.ChamferRadius].Min,
                _parameters[ParametersList.Height].Value / 2);
        }

        /// <summary>
        /// Обработчик изменения амплитуды волны
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        /// <remarks>
        /// При изменении амплитуды волны обновляет максимальное значение радиуса скругления углов.
        /// Если волна включена (амплитуда больше 0), максимум ограничивается 1/4 от меньшего размера,
        /// иначе 1/2 от меньшего размера
        /// </remarks>
        private void WaveAmplitudeChanged(object sender, EventArgs e)
        {
            double minSize = Math.Min(
                _parameters[ParametersList.Length].Value,
                _parameters[ParametersList.Width].Value);

            double cornerRadiusDivisor = 
                _parameters[ParametersList.WaveAmplitude].Value > 0 ? 4 : 2;

            _parameters[ParametersList.CornerRadius].SetBoundaries(
                _parameters[ParametersList.CornerRadius].Min,
                minSize / cornerRadiusDivisor);
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
        /// Максимальное значение автоматически ограничивается в зависимости от наличия волны:
        /// - Если волна отключена (амплитуда = 0): максимум = 1/2 от меньшего размера
        /// - Если волна включена (амплитуда больше 0): максимум = 1/4 от меньшего размера
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

        /// <summary>
        /// Получает параметр амплитуды волны по периметру
        /// </summary>
        /// <remarks>
        /// Максимальное значение автоматически ограничивается 1/3 от меньшего размера (длины или ширины).
        /// При значении 0 строится прямоугольник без волн
        /// </remarks>
        public Parameter WaveAmplitude
        {
            get
            {
                return _parameters[ParametersList.WaveAmplitude];
            }
        }
    }
}