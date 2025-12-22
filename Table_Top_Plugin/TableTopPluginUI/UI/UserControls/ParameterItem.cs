using System.ComponentModel;
using TableTopPluginModels.Models;

namespace TableTopPluginUI.UI.UserControls
{
    /// <summary>
    /// Пользовательский контрол для ввода и отображения параметра.
    /// </summary>
    public partial class ParameterItem : UserControl
    {
        /// <summary>
        /// Параметр, связанный с данным контролом.
        /// </summary>
        private Parameter _parameter;

        /// <summary>
        /// Единица измерения, отображаемая рядом с границами параметра.
        /// </summary>
        private string _unit = "мм";

        /// <summary>
        /// Флаг, указывающий, корректно ли введено значение параметра.
        /// </summary>
        private bool _isItCorrect = false;

        /// <summary>
        /// Всплывающая подсказка для вывода сообщений об ошибках ввода.
        /// </summary>
        private ToolTip _toolTip;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ParameterItem"/>.
        /// </summary>
        public ParameterItem()
        {
            InitializeComponent();
            _toolTip = new ToolTip();
            _toolTip.SetToolTip(textBox_Value, "");
        }

        /// <summary>
        /// Получает значение, указывающее, корректно ли введено значение параметра.
        /// </summary>
        public bool IsItCorrect
        {
            get
            {
                return _isItCorrect;
            }
        }

        /// <summary>
        /// Устанавливает параметр для управления.
        /// </summary>
        /// <param name="param">Объект параметра, который будет связан с контролом.</param>
        public void SetParameter(Parameter param)
        {
            _parameter = param;
            _parameter.ParameterChanged += ChangeBoundsText;
            ChangeBoundsText();
        }

        /// <summary>
        /// Изменяет текст в поле значения.
        /// </summary>
        /// <param name="value">Новое значение, отображаемое в текстовом поле.</param>
        public void ChangeValueText(string value)
        {
            textBox_Value.Text = value;
        }

        /// <summary>
        /// Изменяет текст названия параметра.
        /// </summary>
        /// <param name="name">Новое название параметра.</param>
        public void ChangeNameText(string name)
        {
            label_Name.Text = name;
        }

        /// <summary>
        /// Обновляет текст с границами допустимых значений, отображаемыми для параметра.
        /// </summary>
        /// <param name="sender">Источник события (не используется).</param>
        /// <param name="e">Данные события (не используются).</param>
        public void ChangeBoundsText(object sender = null, EventArgs e = null)
        {
            label_Bounds.Text = "от " + Math.Round(_parameter.Min, 0).
                ToString() + " до " + Math.Round(_parameter.Max, 1).
                ToString() + " " + _unit;
        }

        /// <summary>
        /// Обработчик проверки вводимого значения параметра.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Данные события проверки.</param>
        /// <remarks>
        /// При некорректном формате значения (невозможно преобразовать в число)
        /// ввод отменяется и значение сбрасывается в 0.
        /// </remarks>
        private void textBox_Value_Validating(object sender, CancelEventArgs e)
        {
            if (!double.TryParse(textBox_Value.Text, out double _))
            {
                e.Cancel = true;
                textBox_Value.Text = "0";
            }
        }

        /// <summary>
        /// Обработчик изменения текста в поле значения параметра.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Данные события.</param>
        /// <remarks>
        /// Выполняет проверку значения на соответствие числовому типу и
        /// диапазону допустимых значений параметра. В случае ошибки подсвечивает поле
        /// и отображает соответствующее сообщение.
        /// </remarks>
        private void textBox_Value_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox_Value.Text, out double parsedValue))
            {
                // Некорректное значение — оставляем обработку подсветки/подсказок на дальнейшую логику,
                // при необходимости можно дополнительно обрабатывать этот случай.
                _isItCorrect = false;
                textBox_Value.BackColor = Color.Pink;
                return;
            }

            _parameter.Value = parsedValue;

            if (parsedValue < _parameter.Min || parsedValue > _parameter.Max)
            {
                string message;
                if (parsedValue < _parameter.Min)
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
