using Table_Top_Plugin.Models;
using Table_Top_Plugin.Services;
using Table_Top_Plugin.UI.UserControls;

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
            parameterItem_Length.ChangeValueText("0");
            parameterItem_Width.ChangeNameText("Введите ширину:");
            parameterItem_Width.SetParameter(_parameters.GetWidth);
            parameterItem_Width.ChangeValueText("0");
            parameterItem_Height.ChangeNameText("Введите высоту:");
            parameterItem_Height.SetParameter(_parameters.GetHeight);
            parameterItem_Height.ChangeValueText("0");
            parameterItem_CornerRadius.ChangeNameText("Введите скругление углов:");
            parameterItem_CornerRadius.SetParameter(_parameters.GetCornerRadius);
            parameterItem_CornerRadius.ChangeValueText("0");
            parameterItem_ChamferRadius.ChangeNameText("Введите скругление фаски:");
            parameterItem_ChamferRadius.SetParameter(_parameters.GetChamferRadius);
            parameterItem_ChamferRadius.ChangeValueText("0");
        }


        private bool CheckValues()
        {
            bool ok = true;
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is ParameterItem item)
                {
                    if (!item.Ok)
                    {
                        ok = false;
                        break;
                    }
                }
            }
            return ok;
        }
      

        private async void button_Build_Click(object sender, EventArgs e)
        {

            if (CheckValues())
            {
                progressBar1.Visible = true;

                await Task.Run(() =>
                {
                    if (!_kompas.IsConnected)
                    {
                        _kompas.Connect();
                        _builder = new TableTopBuilder(_kompas.Kompas);
                    }
                    _builder.Build(_parameters);
                });

                progressBar1.Visible = false;
            }
        }
    }
}