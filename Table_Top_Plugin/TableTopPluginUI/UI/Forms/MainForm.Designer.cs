namespace TableTopPluginUI.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_Build = new Button();
            progressBarMain = new ProgressBar();
            tableLayoutPanel1 = new TableLayoutPanel();
            parameterItem_ChamferRadius = new TableTopPluginUI.UI.UserControls.ParameterItem();
            parameterItem_CornerRadius = new TableTopPluginUI.UI.UserControls.ParameterItem();
            parameterItem_Height = new TableTopPluginUI.UI.UserControls.ParameterItem();
            parameterItem_Width = new TableTopPluginUI.UI.UserControls.ParameterItem();
            parameterItem_Length = new TableTopPluginUI.UI.UserControls.ParameterItem();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button_Build
            // 
            button_Build.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            tableLayoutPanel1.SetColumnSpan(button_Build, 3);
            button_Build.Location = new Point(171, 553);
            button_Build.Name = "button_Build";
            button_Build.Size = new Size(455, 54);
            button_Build.TabIndex = 5;
            button_Build.Text = "Построить объект";
            button_Build.UseVisualStyleBackColor = true;
            button_Build.Click += button_Build_Click;
            // 
            // progressBarMain
            // 
            progressBarMain.Anchor = AnchorStyles.Top;
            tableLayoutPanel1.SetColumnSpan(progressBarMain, 3);
            progressBarMain.Location = new Point(171, 613);
            progressBarMain.Name = "progressBarMain";
            progressBarMain.Size = new Size(455, 30);
            progressBarMain.Style = ProgressBarStyle.Marquee;
            progressBarMain.TabIndex = 16;
            progressBarMain.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(parameterItem_ChamferRadius, 0, 4);
            tableLayoutPanel1.Controls.Add(parameterItem_CornerRadius, 0, 3);
            tableLayoutPanel1.Controls.Add(parameterItem_Height, 0, 2);
            tableLayoutPanel1.Controls.Add(parameterItem_Width, 0, 1);
            tableLayoutPanel1.Controls.Add(button_Build, 0, 5);
            tableLayoutPanel1.Controls.Add(progressBarMain, 0, 6);
            tableLayoutPanel1.Controls.Add(parameterItem_Length, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.MaximumSize = new Size(798, 652);
            tableLayoutPanel1.MinimumSize = new Size(798, 652);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tableLayoutPanel1.Size = new Size(798, 652);
            tableLayoutPanel1.TabIndex = 17;
            // 
            // parameterItem_ChamferRadius
            // 
            parameterItem_ChamferRadius.Dock = DockStyle.Fill;
            parameterItem_ChamferRadius.Location = new Point(3, 443);
            parameterItem_ChamferRadius.Name = "parameterItem_ChamferRadius";
            parameterItem_ChamferRadius.Size = new Size(792, 104);
            parameterItem_ChamferRadius.TabIndex = 21;
            // 
            // parameterItem_CornerRadius
            // 
            parameterItem_CornerRadius.Dock = DockStyle.Fill;
            parameterItem_CornerRadius.Location = new Point(3, 333);
            parameterItem_CornerRadius.Name = "parameterItem_CornerRadius";
            parameterItem_CornerRadius.Size = new Size(792, 104);
            parameterItem_CornerRadius.TabIndex = 20;
            // 
            // parameterItem_Height
            // 
            parameterItem_Height.Dock = DockStyle.Fill;
            parameterItem_Height.Location = new Point(3, 223);
            parameterItem_Height.Name = "parameterItem_Height";
            parameterItem_Height.Size = new Size(792, 104);
            parameterItem_Height.TabIndex = 19;
            // 
            // parameterItem_Width
            // 
            parameterItem_Width.Dock = DockStyle.Fill;
            parameterItem_Width.Location = new Point(3, 113);
            parameterItem_Width.Name = "parameterItem_Width";
            parameterItem_Width.Size = new Size(792, 104);
            parameterItem_Width.TabIndex = 18;
            // 
            // parameterItem_Length
            // 
            parameterItem_Length.Dock = DockStyle.Fill;
            parameterItem_Length.Location = new Point(3, 3);
            parameterItem_Length.Name = "parameterItem_Length";
            parameterItem_Length.Size = new Size(792, 104);
            parameterItem_Length.TabIndex = 17;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 652);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "Плагин \"Столешница\" КОМПАС-3D";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button_Build;
        private ProgressBar progressBarMain;
        private TableLayoutPanel tableLayoutPanel1;
        private UI.UserControls.ParameterItem parameterItem_ChamferRadius;
        private UI.UserControls.ParameterItem parameterItem_CornerRadius;
        private UI.UserControls.ParameterItem parameterItem_Height;
        private UI.UserControls.ParameterItem parameterItem_Width;
        private UI.UserControls.ParameterItem parameterItem_Length;
    }
}
