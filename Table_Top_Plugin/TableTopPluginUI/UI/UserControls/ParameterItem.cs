using System.ComponentModel;
using TableTopPlugin.Models;

namespace TableTopPluginUI.UI.UserControls
{
    /// <summary>
    /// Пользовательский контрол для ввода и отображения параметра
    /// </summary>
    public partial class ParameterItem : UserControl
    {
        private Parameter _parameter;
        private string _unit = "мм";
        private bool _isItCorrect = false;
        private ToolTip _toolTip;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ParameterItem"/>
        /// </summary>
        public ParameterItem()
        {
            InitializeComponent();
            _toolTip = new ToolTip();
            _toolTip.SetToolTip(textBox_Value, "");
        }

        /// <summary>
        /// Получает флаг корректности значения параметра
        /// </summary>
        public bool IsItCorrect
        {
            get
            {
                return _isItCorrect;
            }
        }

        /// <summary>
        /// Устанавливает параметр для управления
        /// </summary>
        /// <param name="param">Объект параметра</param>
        public void SetParameter(Parameter param)
        {
            _parameter = param;
            _parameter.ParameterChanged += ChangeBoundsText;
            ChangeBoundsText();
        }

        /// <summary>
        /// Изменяет текст в поле значения
        /// </summary>
        /// <param name="value">Новое значение</param>
        public void ChangeValueText(string value)
        {
            textBox_Value.Text = value;
        }

        /// <summary>
        /// Изменяет текст названия параметра
        /// </summary>
        /// <param name="name">Новое название</param>
        public void ChangeNameText(string name)
        {
            label_Name.Text = name;
        }

        /// <summary>
        /// Обновляет текст с границами допустимых значений
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        public void ChangeBoundsText(object sender = null, EventArgs e = null)
        {
            label_Bounds.Text = "от " + Math.Round(_parameter.Min, 0).
                ToString() + " до " + Math.Round(_parameter.Max, 1).
                ToString() + " " + _unit;
        }

        private void textBox_Value_Validating(object sender, CancelEventArgs e)
        {
            if (!double.TryParse(textBox_Value.Text, out double value))
            {
                e.Cancel = true;
                textBox_Value.Text = "0";
            }
        }

        private void textBox_Value_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox_Value.Text, out double value))
            {

            }
            else
            {
                _parameter.Value = double.Parse(textBox_Value.Text);
                if (double.Parse(textBox_Value.Text) < _parameter.Min
                    || double.Parse(textBox_Value.Text) > _parameter.Max)
                {
                    string message;
                    if (double.Parse(textBox_Value.Text) < _parameter.Min)
                    {
                        message = "Значение должно быть не меньше " +
                            _parameter.Min.ToString();
                        _toolTip.Show(message, textBox_Value);
                    }
                    else
                    {
                        message = "Значение должно быть не больше " +
                            _parameter.Max.ToString();
                        _toolTip.Show(message, textBox_Value);
                    }
                    textBox_Value.BackColor = Color.Pink;
                    _isItCorrect = false;
                }
                else
                {
                    textBox_Value.BackColor = SystemColors.Control;
                    _toolTip.Show("", textBox_Value);
                    _isItCorrect = true;
                }

            }
        }
    }
}