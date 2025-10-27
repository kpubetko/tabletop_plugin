using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Table_Top_Plugin.Models;
using Table_Top_Plugin.Services;

namespace Table_Top_Plugin.UI.UserControls
{
    public partial class ParameterItem : UserControl
    {
        Parameter _parameter;
        string _unit = "мм";
        bool _ok = false;
        public ParameterItem()
        {
            InitializeComponent();
        }
        public bool Ok
        {
            get
            {
                return _ok;
            }
        }
        public void SetParameter(Parameter param)
        {
            _parameter = param;
            _parameter.AddAction(ChangeBoundsText);
            ChangeBoundsText();
        }
        public void ChangeValueText(string value)
        {
            textBox_Value.Text = value;
        }
        public void ChangeNameText(string name)
        {
            label_Name.Text = name;
        }

        public void ChangeBoundsText()
        {
            label_Bounds.Text = "от " + Math.Round(_parameter.GetMin, 0).ToString() + " до " + Math.Round(_parameter.GetMax, 1).ToString() + " " + _unit;
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
                _parameter.SetValue = double.Parse(textBox_Value.Text);
                if (double.Parse(textBox_Value.Text) < _parameter.GetMin || double.Parse(textBox_Value.Text) > _parameter.GetMax)
                {
                    textBox_Value.BackColor = Color.Pink;
                    _ok = false;
                }
                else
                {
                    textBox_Value.BackColor = SystemColors.Control;
                    _ok = true;
                }

            }
            
        }
    }
}
