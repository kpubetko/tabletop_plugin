using TableTopPlugin.Models;
using TableTopPlugin.Services;
using TableTopPluginUI.UI.UserControls;

namespace TableTopPluginUI.UI
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly TableTopParameters _parameters = new TableTopParameters();
        private TableTopBuilder _builder = new TableTopBuilder();

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        /// <remarks>
        /// Инициализирует элементы управления параметрами и устанавливает начальные значения
        /// </remarks>
        public MainForm()
        {
            InitializeComponent();
            parameterItem_Length.ChangeNameText("Введите длину:");
            parameterItem_Length.SetParameter(_parameters.Length);
            parameterItem_Length.ChangeValueText("0");
            parameterItem_Width.ChangeNameText("Введите ширину:");
            parameterItem_Width.SetParameter(_parameters.Width);
            parameterItem_Width.ChangeValueText("0");
            parameterItem_Height.ChangeNameText("Введите высоту:");
            parameterItem_Height.SetParameter(_parameters.Height);
            parameterItem_Height.ChangeValueText("0");
            parameterItem_CornerRadius.ChangeNameText("Введите скругление углов:");
            parameterItem_CornerRadius.SetParameter(_parameters.CornerRadius);
            parameterItem_CornerRadius.ChangeValueText("0");
            parameterItem_ChamferRadius.ChangeNameText("Введите скругление фаски:");
            parameterItem_ChamferRadius.SetParameter(_parameters.ChamferRadius);
            parameterItem_ChamferRadius.ChangeValueText("0");
        }

        /// <summary>
        /// Проверяет корректность значений во всех элементах управления параметрами
        /// </summary>
        /// <returns>true, если все значения корректны; иначе false</returns>
        private bool CheckValues()
        {
            bool ok = true;
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is ParameterItem item)
                {
                    if (!item.IsItCorrect)
                    {
                        ok = false;
                        break;
                    }
                }
            }
            return ok;
        }

        /// <summary>
        /// Обработчик нажатия кнопки построения столешницы
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Данные события</param>
        /// <remarks>
        /// Проверяет корректность введенных значений и запускает асинхронное построение модели
        /// </remarks>
        private async void button_Build_Click(object sender, EventArgs e)
        {
            if (CheckValues())
            {
                progressBarMain.Visible = true;

                await Task.Run(() =>
                {
                    _builder.Build(_parameters);
                });

                progressBarMain.Visible = false;
            }
        }
    }
}