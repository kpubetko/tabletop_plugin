namespace Table_Top_Plugin.Models
{
    /// <summary>
    /// Параметры столешницы
    /// </summary>
    public class TableTopParameters
    {
        private Dictionary<ParametersList, Parameter> _parameters;

        public TableTopParameters()
        {
            _parameters = new Dictionary<ParametersList, Parameter>()
            {
                { ParametersList.Length, new Parameter(1000, 2500, LengthOrWidthChanged) },
                { ParametersList.Width, new Parameter(1000, 2500, LengthOrWidthChanged) },
                { ParametersList.Height, new Parameter(15, 50, HeightChanged) },
                { ParametersList.CornerRadius, new Parameter(0, 0) },
                { ParametersList.ChamferRadius, new Parameter(0, 0) }
            };
        }

        
        public void LengthOrWidthChanged()
        {
            if(_parameters[ParametersList.Length].GetValue < _parameters[ParametersList.Width].GetValue)
            {
                _parameters[ParametersList.CornerRadius].SetBoundaries(_parameters[ParametersList.CornerRadius].GetMin, _parameters[ParametersList.Length].GetValue / 2);
            }
            else
            {
                _parameters[ParametersList.CornerRadius].SetBoundaries(_parameters[ParametersList.CornerRadius].GetMin, _parameters[ParametersList.Width].GetValue / 2);
            }
        }
        public void HeightChanged()
        {
            _parameters[ParametersList.ChamferRadius].SetBoundaries(_parameters[ParametersList.ChamferRadius].GetMin, _parameters[ParametersList.Height].GetValue/2);
        }
        public Parameter GetLength
        {
            get
            {
                return _parameters[ParametersList.Length];
            }
        }

        public Parameter GetWidth
        {
            get
            {
                return _parameters[ParametersList.Width];
            }
        }

        public Parameter GetHeight
        {
            get
            {
                return _parameters[ParametersList.Height];
            }
        }

        public Parameter GetCornerRadius
        {
            get
            {
                return _parameters[ParametersList.CornerRadius];
            }
        }

        public Parameter GetChamferRadius
        {
            get
            {
                return _parameters[ParametersList.ChamferRadius];
            }
        }
        /// <summary>
        /// Длина столешницы
        /// </summary>
        //    public double Length
        //    {
        //        set
        //        {
        //            double min = LengthBoundaries[0];
        //            double max = LengthBoundaries[1];
        //            if (value < min || value > max)
        //            {
        //                _length = -1;
        //                return;
        //            }
        //            else
        //            {
        //                _length = value;
        //                CheckLengthWidth();
        //            }
        //        }
        //        get
        //        {
        //            return _length;
        //        }
        //    }

        //    /// <summary>
        //    /// Ширина столешницы
        //    /// </summary>
        //    public double Width
        //    {
        //        set
        //        {
        //            double min = WidthBoundaries[0];
        //            double max = WidthBoundaries[1];
        //            if (value < min || value > max)
        //            {
        //                _width = -1;
        //                return;
        //            }
        //            else
        //            {
        //                _width = value;
        //                RefreshCornerRadius();
        //                CheckLengthWidth();
        //            }
        //        }
        //        get
        //        {
        //            return _width;
        //        }
        //    }

        //    /// <summary>
        //    /// Высота столешницы
        //    /// </summary>
        //    public double Height
        //    {
        //        set
        //        {
        //            double min = HeightBoundaries[0];
        //            double max = HeightBoundaries[1];
        //            if (value < min || value > max)
        //            {
        //                _height = -1;
        //                return;
        //            }
        //            else
        //            {
        //                _height = value;
        //                RefreshChamferRadius();
        //            }
        //        }
        //        get
        //        {
        //            return _height;
        //        }
        //    }

        //    /// <summary>
        //    /// Радиус скругления углов
        //    /// </summary>
        //    public double CornerRadius
        //    {
        //        set
        //        {
        //            double min = CornerRadiusBoundaries[0];
        //            double max = CornerRadiusBoundaries[1];
        //            if (value < min || value > max)
        //            {
        //                _cornerRadius = -1;
        //                return;
        //            }
        //            else
        //            {
        //                _cornerRadius = value;
        //                RefreshCornerRadius();
        //            }
        //        }
        //        get
        //        {
        //            return _cornerRadius;
        //        }
        //    }

        //    /// <summary>
        //    /// Радиус фаски
        //    /// </summary>
        //    public double ChamferRadius
        //    {
        //        set
        //        {
        //            double min = ChamferRadiusBoundaries[0];
        //            double max = ChamferRadiusBoundaries[1];
        //            if (value < min || value > max)
        //            {
        //                _chamferRadius = -1;
        //                return;
        //            }
        //            else
        //            {
        //                _chamferRadius = value;
        //                RefreshChamferRadius();
        //            }
        //        }
        //        get
        //        {
        //            return _chamferRadius;
        //        }
        //    }

        //    /// <summary>
        //    /// Проверка и корректировка длины и ширины
        //    /// </summary>
        //    private void CheckLengthWidth()
        //    {
        //        if (_length < _width)
        //        {
        //            double tempValue = _length;
        //            _length = _width;
        //            _width = tempValue;
        //            RefreshCornerRadius();
        //        }
        //    }

        //    /// <summary>
        //    /// Обновление радиуса скругления углов3
        //    /// </summary>
        //    private void RefreshCornerRadius()
        //    {
        //        if (_cornerRadius > (_width / 2))
        //        {
        //            _cornerRadius = (_width / 2);
        //        }
        //    }

        //    /// <summary>
        //    /// Обновление радиуса фаски
        //    /// </summary>
        //    private void RefreshChamferRadius()
        //    {
        //        if (_chamferRadius > (_height / 2))
        //        {
        //            _chamferRadius = (_height / 2);
        //        }
        //    }

        //    /// <summary>
        //    /// Проверка корректности всех значений
        //    /// </summary>
        //    /// <returns>True если все значения корректны, иначе False</returns>
        //    public bool CheckValues()
        //    {
        //        if (_length == -1 || _width == -1 || _height == -1 || _cornerRadius == -1 || _chamferRadius == -1)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
    }
}