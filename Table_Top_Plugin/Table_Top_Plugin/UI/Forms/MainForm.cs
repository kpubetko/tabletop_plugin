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
        private KompasConnector _kompas = new KompasConnector();
        private TableTopBuilder _builder;

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            parameterItem_Length.ChangeNameText("Введите длину:");
            parameterItem_Length.SetParameter(_parameters.GetLength);
            parameterItem_Width.ChangeNameText("Введите ширину:");
            parameterItem_Width.SetParameter(_parameters.GetWidth);
            parameterItem_Height.ChangeNameText("Введите высоту:");
            parameterItem_Height.SetParameter(_parameters.GetHeight);
            parameterItem_CornerRadius.ChangeNameText("Введите скругление углов:");
            parameterItem_CornerRadius.SetParameter(_parameters.GetCornerRadius);
            parameterItem_ChamferRadius.ChangeNameText("Введите скругление фаски:");
            parameterItem_ChamferRadius.SetParameter(_parameters.GetChamferRadius);
            _builder = new TableTopBuilder(_kompas.Kompas);
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


      

        private async void button_Build_Click(object sender, EventArgs e)
        {

            //// Установка параметров
            //_parameters.Length = double.Parse(textBox_LengthValue.Text);
            //_parameters.Width = double.Parse(textBox_WidthValue.Text);
            //_parameters.Height = double.Parse(textBox_HeightValue.Text);
            //_parameters.CornerRadius = double.Parse(textBox_CornerRadiusValue.Text);
            //_parameters.ChamferRadius = double.Parse(textBox_ChamferRadiusValue.Text);

            //if (_parameters.CheckValues())
            //{
            //    // Обновление значений в текстовых полях (после возможной корректировки)
            //    textBox_LengthValue.Text = _parameters.Length.ToString();
            //    textBox_WidthValue.Text = _parameters.Width.ToString();
            //    textBox_HeightValue.Text = _parameters.Height.ToString();
            //    textBox_CornerRadiusValue.Text = _parameters.CornerRadius.ToString();
            //    textBox_ChamferRadiusValue.Text = _parameters.ChamferRadius.ToString();

            //    progressBar1.Visible = true;

            //    await Task.Run(() =>
            //    {
            //        if (!_kompas.IsConnected)
            //        {
            //            _kompas.Connect();
            //        }
            //        _builder.Build(_parameters.Length, _parameters.Width, _parameters.Height, _parameters.CornerRadius, _parameters.ChamferRadius);
            //    });

            //    progressBar1.Visible = false;
            //}
            //else
            //{
            //    FindExceptions();
            //}
        }
    }
}