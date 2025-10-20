namespace Table_Top_Plugin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBox_ChamferRadiusValue = new TextBox();
            textBox_CornerRadiusValue = new TextBox();
            textBox_HeightValue = new TextBox();
            textBox_WidthValue = new TextBox();
            label_Length = new Label();
            label_Width = new Label();
            label_Height = new Label();
            label_CornerRadius = new Label();
            label_ChamferRadius = new Label();
            button_Build = new Button();
            label_UnitLength = new Label();
            label_UnitWidth = new Label();
            label_UnitHeight = new Label();
            label_UnitCornerRadius = new Label();
            label_UnitChamferRadius = new Label();
            textBox_LengthValue = new TextBox();
            progressBar1 = new ProgressBar();
            toolStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(914, 42);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(46, 36);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.03341F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.96659F));
            tableLayoutPanel1.Controls.Add(textBox_ChamferRadiusValue, 1, 4);
            tableLayoutPanel1.Controls.Add(textBox_CornerRadiusValue, 1, 3);
            tableLayoutPanel1.Controls.Add(textBox_HeightValue, 1, 2);
            tableLayoutPanel1.Controls.Add(textBox_WidthValue, 1, 1);
            tableLayoutPanel1.Controls.Add(label_Length, 0, 0);
            tableLayoutPanel1.Controls.Add(label_Width, 0, 1);
            tableLayoutPanel1.Controls.Add(label_Height, 0, 2);
            tableLayoutPanel1.Controls.Add(label_CornerRadius, 0, 3);
            tableLayoutPanel1.Controls.Add(label_ChamferRadius, 0, 4);
            tableLayoutPanel1.Controls.Add(button_Build, 0, 5);
            tableLayoutPanel1.Controls.Add(label_UnitLength, 2, 0);
            tableLayoutPanel1.Controls.Add(label_UnitWidth, 2, 1);
            tableLayoutPanel1.Controls.Add(label_UnitHeight, 2, 2);
            tableLayoutPanel1.Controls.Add(label_UnitCornerRadius, 2, 3);
            tableLayoutPanel1.Controls.Add(label_UnitChamferRadius, 2, 4);
            tableLayoutPanel1.Controls.Add(textBox_LengthValue, 1, 0);
            tableLayoutPanel1.Controls.Add(progressBar1, 0, 6);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 42);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.Size = new Size(914, 944);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // textBox_ChamferRadiusValue
            // 
            textBox_ChamferRadiusValue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_ChamferRadiusValue.BackColor = SystemColors.Control;
            textBox_ChamferRadiusValue.BorderStyle = BorderStyle.FixedSingle;
            textBox_ChamferRadiusValue.Location = new Point(468, 403);
            textBox_ChamferRadiusValue.Name = "textBox_ChamferRadiusValue";
            textBox_ChamferRadiusValue.Size = new Size(286, 39);
            textBox_ChamferRadiusValue.TabIndex = 15;
            textBox_ChamferRadiusValue.Text = "0";
            textBox_ChamferRadiusValue.Enter += textBox_ChamferRadiusValue_Enter;
            textBox_ChamferRadiusValue.Leave += textBox_ChamferRadiusValue_Leave;
            // 
            // textBox_CornerRadiusValue
            // 
            textBox_CornerRadiusValue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_CornerRadiusValue.BackColor = SystemColors.Control;
            textBox_CornerRadiusValue.BorderStyle = BorderStyle.FixedSingle;
            textBox_CornerRadiusValue.Location = new Point(468, 309);
            textBox_CornerRadiusValue.Name = "textBox_CornerRadiusValue";
            textBox_CornerRadiusValue.Size = new Size(286, 39);
            textBox_CornerRadiusValue.TabIndex = 14;
            textBox_CornerRadiusValue.Text = "0";
            textBox_CornerRadiusValue.Enter += textBox_CornerRadiusValue_Enter;
            textBox_CornerRadiusValue.Leave += textBox_CornerRadiusValue_Leave;
            // 
            // textBox_HeightValue
            // 
            textBox_HeightValue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_HeightValue.BackColor = SystemColors.Control;
            textBox_HeightValue.BorderStyle = BorderStyle.FixedSingle;
            textBox_HeightValue.Location = new Point(468, 215);
            textBox_HeightValue.Name = "textBox_HeightValue";
            textBox_HeightValue.Size = new Size(286, 39);
            textBox_HeightValue.TabIndex = 13;
            textBox_HeightValue.Text = "0";
            textBox_HeightValue.Enter += textBox_HeightValue_Enter;
            textBox_HeightValue.Leave += textBox_HeightValue_Leave;
            // 
            // textBox_WidthValue
            // 
            textBox_WidthValue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_WidthValue.BackColor = SystemColors.Control;
            textBox_WidthValue.BorderStyle = BorderStyle.FixedSingle;
            textBox_WidthValue.Location = new Point(468, 121);
            textBox_WidthValue.Name = "textBox_WidthValue";
            textBox_WidthValue.Size = new Size(286, 39);
            textBox_WidthValue.TabIndex = 12;
            textBox_WidthValue.Text = "0";
            textBox_WidthValue.Enter += textBox_WidthValue_Enter;
            textBox_WidthValue.Leave += textBox_WidthValue_Leave;
            // 
            // label_Length
            // 
            label_Length.Anchor = AnchorStyles.Left;
            label_Length.AutoSize = true;
            label_Length.Location = new Point(3, 31);
            label_Length.Name = "label_Length";
            label_Length.Size = new Size(328, 32);
            label_Length.TabIndex = 0;
            label_Length.Text = "Введите длину столешницы:";
            // 
            // label_Width
            // 
            label_Width.Anchor = AnchorStyles.Left;
            label_Width.AutoSize = true;
            label_Width.Location = new Point(3, 125);
            label_Width.Name = "label_Width";
            label_Width.Size = new Size(349, 32);
            label_Width.TabIndex = 1;
            label_Width.Text = "Введите ширину столешницы:";
            // 
            // label_Height
            // 
            label_Height.Anchor = AnchorStyles.Left;
            label_Height.AutoSize = true;
            label_Height.Location = new Point(3, 219);
            label_Height.Name = "label_Height";
            label_Height.Size = new Size(339, 32);
            label_Height.TabIndex = 2;
            label_Height.Text = "Введите высоту столешницы:";
            // 
            // label_CornerRadius
            // 
            label_CornerRadius.Anchor = AnchorStyles.Left;
            label_CornerRadius.AutoSize = true;
            label_CornerRadius.Location = new Point(3, 313);
            label_CornerRadius.Name = "label_CornerRadius";
            label_CornerRadius.Size = new Size(455, 32);
            label_CornerRadius.TabIndex = 3;
            label_CornerRadius.Text = "Введите скругление углов столешницы:";
            // 
            // label_ChamferRadius
            // 
            label_ChamferRadius.Anchor = AnchorStyles.Left;
            label_ChamferRadius.AutoSize = true;
            label_ChamferRadius.Location = new Point(3, 407);
            label_ChamferRadius.Name = "label_ChamferRadius";
            label_ChamferRadius.Size = new Size(459, 32);
            label_ChamferRadius.TabIndex = 4;
            label_ChamferRadius.Text = "Введите скругление фасок столешницы:";
            // 
            // button_Build
            // 
            button_Build.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            tableLayoutPanel1.SetColumnSpan(button_Build, 3);
            button_Build.Location = new Point(229, 473);
            button_Build.Name = "button_Build";
            button_Build.Size = new Size(455, 88);
            button_Build.TabIndex = 5;
            button_Build.Text = "Построить объект";
            button_Build.UseVisualStyleBackColor = true;
            button_Build.Click += button_Build_Click;
            // 
            // label_UnitLength
            // 
            label_UnitLength.Anchor = AnchorStyles.Left;
            label_UnitLength.AutoSize = true;
            label_UnitLength.Location = new Point(760, 31);
            label_UnitLength.Name = "label_UnitLength";
            label_UnitLength.Size = new Size(56, 32);
            label_UnitLength.TabIndex = 6;
            label_UnitLength.Text = "mm";
            // 
            // label_UnitWidth
            // 
            label_UnitWidth.Anchor = AnchorStyles.Left;
            label_UnitWidth.AutoSize = true;
            label_UnitWidth.Location = new Point(760, 125);
            label_UnitWidth.Name = "label_UnitWidth";
            label_UnitWidth.Size = new Size(56, 32);
            label_UnitWidth.TabIndex = 7;
            label_UnitWidth.Text = "mm";
            // 
            // label_UnitHeight
            // 
            label_UnitHeight.Anchor = AnchorStyles.Left;
            label_UnitHeight.AutoSize = true;
            label_UnitHeight.Location = new Point(760, 219);
            label_UnitHeight.Name = "label_UnitHeight";
            label_UnitHeight.Size = new Size(56, 32);
            label_UnitHeight.TabIndex = 8;
            label_UnitHeight.Text = "mm";
            // 
            // label_UnitCornerRadius
            // 
            label_UnitCornerRadius.Anchor = AnchorStyles.Left;
            label_UnitCornerRadius.AutoSize = true;
            label_UnitCornerRadius.Location = new Point(760, 313);
            label_UnitCornerRadius.Name = "label_UnitCornerRadius";
            label_UnitCornerRadius.Size = new Size(56, 32);
            label_UnitCornerRadius.TabIndex = 9;
            label_UnitCornerRadius.Text = "mm";
            // 
            // label_UnitChamferRadius
            // 
            label_UnitChamferRadius.Anchor = AnchorStyles.Left;
            label_UnitChamferRadius.AutoSize = true;
            label_UnitChamferRadius.Location = new Point(760, 407);
            label_UnitChamferRadius.Name = "label_UnitChamferRadius";
            label_UnitChamferRadius.Size = new Size(56, 32);
            label_UnitChamferRadius.TabIndex = 10;
            label_UnitChamferRadius.Text = "mm";
            // 
            // textBox_LengthValue
            // 
            textBox_LengthValue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_LengthValue.BackColor = SystemColors.Control;
            textBox_LengthValue.BorderStyle = BorderStyle.FixedSingle;
            textBox_LengthValue.Location = new Point(468, 27);
            textBox_LengthValue.Name = "textBox_LengthValue";
            textBox_LengthValue.Size = new Size(286, 39);
            textBox_LengthValue.TabIndex = 11;
            textBox_LengthValue.Text = "0";
            textBox_LengthValue.Enter += textBox_LengthValue_Enter;
            textBox_LengthValue.Leave += textBox_LengthValue_Leave;
            textBox_LengthValue.Validating += textBox_LengthValue_Validating;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top;
            tableLayoutPanel1.SetColumnSpan(progressBar1, 3);
            progressBar1.Location = new Point(229, 567);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(455, 30);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 16;
            progressBar1.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 986);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            Text = "Плагин \"Столешница\" КОМПАС-3D";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label_Length;
        private Label label_Width;
        private Label label_Height;
        private Label label_CornerRadius;
        private Label label_ChamferRadius;
        private Button button_Build;
        private TextBox textBox_ChamferRadiusValue;
        private TextBox textBox_CornerRadiusValue;
        private TextBox textBox_HeightValue;
        private TextBox textBox_WidthValue;
        private Label label_UnitLength;
        private Label label_UnitWidth;
        private Label label_UnitHeight;
        private Label label_UnitCornerRadius;
        private Label label_UnitChamferRadius;
        private TextBox textBox_LengthValue;
        private ProgressBar progressBar1;
    }
}
