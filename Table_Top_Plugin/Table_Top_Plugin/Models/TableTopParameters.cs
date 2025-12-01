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

        private void LengthOrWidthChanged(object sender, EventArgs e)
        {
            if(_parameters[ParametersList.Length].GetValue < _parameters[ParametersList.Width].GetValue)
            {
                _parameters[ParametersList.CornerRadius].SetBoundaries(_parameters[ParametersList.CornerRadius].GetMin, 
                    _parameters[ParametersList.Length].GetValue / 2);
            }
            else
            {
                _parameters[ParametersList.CornerRadius].SetBoundaries(_parameters[ParametersList.CornerRadius].GetMin, 
                    _parameters[ParametersList.Width].GetValue / 2);
            }
        }

        public void HeightChanged(object sender, EventArgs e)
        {
            _parameters[ParametersList.ChamferRadius].SetBoundaries(_parameters[ParametersList.ChamferRadius].GetMin, 
                _parameters[ParametersList.Height].GetValue/2);
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
    }
}