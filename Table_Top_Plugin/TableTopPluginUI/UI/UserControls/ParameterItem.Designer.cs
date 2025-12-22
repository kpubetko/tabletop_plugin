namespace TableTopPluginUI.UI.UserControls
{
    partial class ParameterItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            label_Name = new Label();
            textBox_Value = new TextBox();
            label_Bounds = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(label_Name, 0, 0);
            tableLayoutPanel1.Controls.Add(textBox_Value, 1, 0);
            tableLayoutPanel1.Controls.Add(label_Bounds, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(664, 52);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label_Name
            // 
            label_Name.Anchor = AnchorStyles.Left;
            label_Name.AutoSize = true;
            label_Name.Location = new Point(3, 10);
            label_Name.Name = "label_Name";
            label_Name.Size = new Size(78, 32);
            label_Name.TabIndex = 0;
            label_Name.Text = "Name";
            // 
            // textBox_Value
            // 
            textBox_Value.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_Value.Location = new Point(169, 6);
            textBox_Value.Name = "textBox_Value";
            textBox_Value.Size = new Size(326, 39);
            textBox_Value.TabIndex = 1;
            textBox_Value.TextChanged += textBox_Value_TextChanged;
            textBox_Value.Validating += textBox_Value_Validating;
            // 
            // label_Bounds
            // 
            label_Bounds.Anchor = AnchorStyles.Left;
            label_Bounds.AutoSize = true;
            label_Bounds.Location = new Point(501, 10);
            label_Bounds.Name = "label_Bounds";
            label_Bounds.Size = new Size(94, 32);
            label_Bounds.TabIndex = 2;
            label_Bounds.Text = "Bounds";
            label_Bounds.TextChanged += label_Bounds_TextChanged;
            // 
            // ParameterItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ParameterItem";
            Size = new Size(664, 52);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label_Name;
        private TextBox textBox_Value;
        private Label label_Bounds;
    }
}
