using Table_Top_Plugin.Models;
using Table_Top_Plugin.Services;

namespace Table_Top_Plugin
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly TableTopParameters _parameters = new TableTopParameters();
        private readonly ToolTip _toolTipLength = new ToolTip();
        private readonly ToolTip _toolTipWidth = new ToolTip();
        private readonly ToolTip _toolTipHeight = new ToolTip();
        private readonly ToolTip _toolTipCornerRadius = new ToolTip();
        private readonly ToolTip _toolTipChamfer = new ToolTip();
        private readonly KompasConnector _kompas = new KompasConnector();

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Получение строки с ограничениями
        /// </summary>
        /// <param name="constraints">Массив ограничений</param>
        /// <returns>Строка с ограничениями</returns>
        private string GetConstraintsString(double[] constraints)
        {
            string constraintsToReturn = "";
            if (constraints.Length == 2)
            {
                constraintsToReturn += "от " + constraints[0].ToString() + " до " + constraints[1].ToString();
            }
            return constraintsToReturn;
        }

        private void textBox_LengthValue_Enter(object sender, EventArgs e)
        {
            _toolTipLength.ToolTipTitle = "Ограничение ввода длины";
            _toolTipLength.ToolTipIcon = ToolTipIcon.Info;
            _toolTipLength.IsBalloon = true;
            _toolTipLength.ShowAlways = true;
            _toolTipLength.SetToolTip(textBox_LengthValue, GetConstraintsString(_parameters.LengthBoundaries));
            _toolTipLength.Active = true;
        }

        private void textBox_LengthValue_Leave(object sender, EventArgs e)
        {
            _toolTipLength.Active = false;
        }

        private void textBox_WidthValue_Enter(object sender, EventArgs e)
        {
            _toolTipWidth.ToolTipTitle = "Ограничение ввода ширины";
            _toolTipWidth.ToolTipIcon = ToolTipIcon.Info;
            _toolTipWidth.IsBalloon = true;
            _toolTipWidth.ShowAlways = true;
            _toolTipWidth.SetToolTip(textBox_WidthValue, GetConstraintsString(_parameters.WidthBoundaries));
            _toolTipWidth.Active = true;
        }

        private void textBox_WidthValue_Leave(object sender, EventArgs e)
        {
            _toolTipWidth.Active = false;
        }

        private void textBox_HeightValue_Enter(object sender, EventArgs e)
        {
            _toolTipHeight.ToolTipTitle = "Ограничение ввода высоты";
            _toolTipHeight.ToolTipIcon = ToolTipIcon.Info;
            _toolTipHeight.IsBalloon = true;
            _toolTipHeight.ShowAlways = true;
            _toolTipHeight.SetToolTip(textBox_HeightValue, GetConstraintsString(_parameters.HeightBoundaries));
            _toolTipHeight.Active = true;
        }

        private void textBox_HeightValue_Leave(object sender, EventArgs e)
        {
            _toolTipHeight.Active = false;
        }

        private void textBox_CornerRadiusValue_Enter(object sender, EventArgs e)
        {
            _toolTipCornerRadius.ToolTipTitle = "Ограничение ввода углов";
            _toolTipCornerRadius.ToolTipIcon = ToolTipIcon.Info;
            _toolTipCornerRadius.IsBalloon = true;
            _toolTipCornerRadius.ShowAlways = true;
            _toolTipCornerRadius.SetToolTip(textBox_CornerRadiusValue, GetConstraintsString(_parameters.CornerRadiusBoundaries));
            _toolTipCornerRadius.Active = true;
        }

        private void textBox_CornerRadiusValue_Leave(object sender, EventArgs e)
        {
            _toolTipCornerRadius.Active = false;
        }

        private void textBox_ChamferRadiusValue_Enter(object sender, EventArgs e)
        {
            _toolTipChamfer.ToolTipTitle = "Ограничение ввода фасок";
            _toolTipChamfer.ToolTipIcon = ToolTipIcon.Info;
            _toolTipChamfer.IsBalloon = true;
            _toolTipChamfer.ShowAlways = true;
            _toolTipChamfer.SetToolTip(textBox_ChamferRadiusValue, GetConstraintsString(_parameters.ChamferRadiusBoundaries));
            _toolTipChamfer.Active = true;
        }

        private void textBox_ChamferRadiusValue_Leave(object sender, EventArgs e)
        {
            _toolTipChamfer.Active = false;
        }

        private void textBox_LengthValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!double.TryParse(textBox_LengthValue.Text, out double value))
            {
                e.Cancel = true;
                textBox_LengthValue.Text = "0";
            }
        }

        /// <summary>
        /// Поиск исключений в введенных данных
        /// </summary>
        private void FindExceptions()
        {
            if (double.TryParse(textBox_LengthValue.Text, out double lengthValue))
            {
                if (lengthValue < _parameters.LengthBoundaries[0] || lengthValue > _parameters.LengthBoundaries[1])
                {
                    textBox_LengthValue.BackColor = Color.Orange;
                }
            }
            else
            {
                textBox_LengthValue.BackColor = Color.Orange;
            }

            if (double.TryParse(textBox_WidthValue.Text, out double widthValue))
            {
                if (widthValue < _parameters.WidthBoundaries[0] || widthValue > _parameters.WidthBoundaries[1])
                {
                    textBox_WidthValue.BackColor = Color.Orange;
                }
            }
            else
            {
                textBox_WidthValue.BackColor = Color.Orange;
            }

            if (double.TryParse(textBox_HeightValue.Text, out double heightValue))
            {
                if (heightValue < _parameters.HeightBoundaries[0] || heightValue > _parameters.HeightBoundaries[1])
                {
                    textBox_HeightValue.BackColor = Color.Orange;
                }
            }
            else
            {
                textBox_HeightValue.BackColor = Color.Orange;
            }

            if (double.TryParse(textBox_CornerRadiusValue.Text, out double cornerRadiusValue))
            {
                if (cornerRadiusValue < _parameters.CornerRadiusBoundaries[0] || cornerRadiusValue > _parameters.CornerRadiusBoundaries[1])
                {
                    textBox_CornerRadiusValue.BackColor = Color.Orange;
                }
            }
            else
            {
                textBox_CornerRadiusValue.BackColor = Color.Orange;
            }

            if (double.TryParse(textBox_ChamferRadiusValue.Text, out double chamferRadiusValue))
            {
                if (chamferRadiusValue < _parameters.ChamferRadiusBoundaries[0] || chamferRadiusValue > _parameters.ChamferRadiusBoundaries[1])
                {
                    textBox_ChamferRadiusValue.BackColor = Color.Orange;
                }
            }
            else
            {
                textBox_ChamferRadiusValue.BackColor = Color.Orange;
            }
        }

        private async void button_Build_Click(object sender, EventArgs e)
        {
            // Сброс цветов фона
            textBox_LengthValue.BackColor = SystemColors.Control;
            textBox_WidthValue.BackColor = SystemColors.Control;
            textBox_HeightValue.BackColor = SystemColors.Control;
            textBox_CornerRadiusValue.BackColor = SystemColors.Control;
            textBox_ChamferRadiusValue.BackColor = SystemColors.Control;

            // Установка параметров
            _parameters.Length = double.Parse(textBox_LengthValue.Text);
            _parameters.Width = double.Parse(textBox_WidthValue.Text);
            _parameters.Height = double.Parse(textBox_HeightValue.Text);
            _parameters.CornerRadius = double.Parse(textBox_CornerRadiusValue.Text);
            _parameters.ChamferRadius = double.Parse(textBox_ChamferRadiusValue.Text);

            if (_parameters.CheckValues())
            {
                // Обновление значений в текстовых полях (после возможной корректировки)
                textBox_LengthValue.Text = _parameters.Length.ToString();
                textBox_WidthValue.Text = _parameters.Width.ToString();
                textBox_HeightValue.Text = _parameters.Height.ToString();
                textBox_CornerRadiusValue.Text = _parameters.CornerRadius.ToString();
                textBox_ChamferRadiusValue.Text = _parameters.ChamferRadius.ToString();

                progressBar1.Visible = true;

                await Task.Run(() =>
                {
                    if (!_kompas.IsConnected)
                    {
                        _kompas.Connect();
                    }
                    var builder = new TableTopBuilder(_kompas.Kompas);
                    builder.Build(_parameters.Length, _parameters.Width, _parameters.Height, _parameters.CornerRadius, _parameters.ChamferRadius);
                });

                progressBar1.Visible = false;
            }
            else
            {
                FindExceptions();
            }
        }
    }
}