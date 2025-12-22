using TableTopPluginModels.Models;
using TableTopPlugin.Services;
using TableTopPluginUI.UI.UserControls;

namespace TableTopPluginUI.UI
{
    public partial class MainForm : Form
    {
        private readonly TableTopParameters _parameters 
            = new TableTopParameters();
        private TableTopBuilder _builder = new TableTopBuilder();

        public MainForm()
        {
            InitializeComponent();

            // Привязка всех параметров к контролам
            parameterItem_Length.ChangeNameText("Введите длину:");
            parameterItem_Length.SetParameter(_parameters.Length);
            parameterItem_Length.ChangeValueText("0");

            parameterItem_Width.ChangeNameText("Введите ширину:");
            parameterItem_Width.SetParameter(_parameters.Width);
            parameterItem_Width.ChangeValueText("0");

            parameterItem_Height.ChangeNameText("Введите высоту:");
            parameterItem_Height.SetParameter(_parameters.Height);
            parameterItem_Height.ChangeValueText("0");

            parameterItem_CornerRadius.ChangeNameText
                ("Введите скругление углов:");
            parameterItem_CornerRadius.SetParameter
                (_parameters.CornerRadius);
            parameterItem_CornerRadius.ChangeValueText("0");

            parameterItem_ChamferRadius.ChangeNameText
                ("Введите скругление фаски:");
            parameterItem_ChamferRadius.SetParameter
                (_parameters.ChamferRadius);
            parameterItem_ChamferRadius.ChangeValueText("0");

            parameterItem_WaveRadius.ChangeNameText
                ("Введите радиус волны:");
            parameterItem_WaveRadius.SetParameter(_parameters.WaveAmplitude);
            parameterItem_WaveRadius.ChangeValueText("0");

        }

        private bool CheckValues()
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is ParameterItem item && !item.IsItCorrect)
                    return false;
            }
            return true;
        }

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
