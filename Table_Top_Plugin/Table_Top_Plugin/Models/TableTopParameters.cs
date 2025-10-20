﻿namespace Table_Top_Plugin.Models
{
    /// <summary>
    /// Параметры столешницы
    /// </summary>
    public class TableTopParameters
    {
        /// <summary>Длина столешницы</summary>
        private double _length = -1;

        /// <summary>Ширина столешницы</summary>
        private double _width = -1;

        /// <summary>Высота столешницы</summary>
        private double _height = -1;

        /// <summary>Радиус скругления углов</summary>
        private double _cornerRadius = -1;

        /// <summary>Радиус фаски</summary>
        private double _chamferRadius = -1;

        /// <summary>Минимальные и максимальные границы длины</summary>
        public readonly double[] LengthBoundaries = [1000, 2500];

        /// <summary>Минимальные и максимальные границы ширины</summary>
        public readonly double[] WidthBoundaries = [1000, 2500];

        /// <summary>Минимальные и максимальные границы высоты</summary>
        public readonly double[] HeightBoundaries = [15, 50];

        /// <summary>Минимальные и максимальные границы радиуса углов</summary>
        public readonly double[] CornerRadiusBoundaries = [0, 1000];

        /// <summary>Минимальные и максимальные границы радиуса фаски</summary>
        public readonly double[] ChamferRadiusBoundaries = [0, 25];

        /// <summary>
        /// Длина столешницы
        /// </summary>
        public double Length
        {
            set
            {
                double min = LengthBoundaries[0];
                double max = LengthBoundaries[1];
                if (value < min || value > max)
                {
                    _length = -1;
                    return;
                }
                else
                {
                    _length = value;
                    CheckLengthWidth();
                }
            }
            get
            {
                return _length;
            }
        }

        /// <summary>
        /// Ширина столешницы
        /// </summary>
        public double Width
        {
            set
            {
                double min = WidthBoundaries[0];
                double max = WidthBoundaries[1];
                if (value < min || value > max)
                {
                    _width = -1;
                    return;
                }
                else
                {
                    _width = value;
                    RefreshCornerRadius();
                    CheckLengthWidth();
                }
            }
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// Высота столешницы
        /// </summary>
        public double Height
        {
            set
            {
                double min = HeightBoundaries[0];
                double max = HeightBoundaries[1];
                if (value < min || value > max)
                {
                    _height = -1;
                    return;
                }
                else
                {
                    _height = value;
                    RefreshChamferRadius();
                }
            }
            get
            {
                return _height;
            }
        }

        /// <summary>
        /// Радиус скругления углов
        /// </summary>
        public double CornerRadius
        {
            set
            {
                double min = CornerRadiusBoundaries[0];
                double max = CornerRadiusBoundaries[1];
                if (value < min || value > max)
                {
                    _cornerRadius = -1;
                    return;
                }
                else
                {
                    _cornerRadius = value;
                    RefreshCornerRadius();
                }
            }
            get
            {
                return _cornerRadius;
            }
        }

        /// <summary>
        /// Радиус фаски
        /// </summary>
        public double ChamferRadius
        {
            set
            {
                double min = ChamferRadiusBoundaries[0];
                double max = ChamferRadiusBoundaries[1];
                if (value < min || value > max)
                {
                    _chamferRadius = -1;
                    return;
                }
                else
                {
                    _chamferRadius = value;
                    RefreshChamferRadius();
                }
            }
            get
            {
                return _chamferRadius;
            }
        }

        /// <summary>
        /// Проверка и корректировка длины и ширины
        /// </summary>
        private void CheckLengthWidth()
        {
            if (_length < _width)
            {
                double tempValue = _length;
                _length = _width;
                _width = tempValue;
                RefreshCornerRadius();
            }
        }

        /// <summary>
        /// Обновление радиуса скругления углов
        /// </summary>
        private void RefreshCornerRadius()
        {
            if (_cornerRadius > (_width / 2))
            {
                _cornerRadius = (_width / 2);
            }
        }

        /// <summary>
        /// Обновление радиуса фаски
        /// </summary>
        private void RefreshChamferRadius()
        {
            if (_chamferRadius > (_height / 2))
            {
                _chamferRadius = (_height / 2);
            }
        }

        /// <summary>
        /// Проверка корректности всех значений
        /// </summary>
        /// <returns>True если все значения корректны, иначе False</returns>
        public bool CheckValues()
        {
            if (_length == -1 || _width == -1 || _height == -1 || _cornerRadius == -1 || _chamferRadius == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}