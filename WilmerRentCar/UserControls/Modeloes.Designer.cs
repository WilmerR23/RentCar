using System.Windows.Forms;

namespace WilmerRentCar.UserControls
{
    partial class Modeloes
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
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(3, 22);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(183, 20);
            this.textBoxNombre.TabIndex = 6;
            // 
            // cbMarca
            // 
            this.cbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(214, 21);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(206, 21);
            this.cbMarca.TabIndex = 8;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(0, 6);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 9;
            this.labelNombre.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Marca";
            // 
            // Modeloes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.cbMarca);
            this.Controls.Add(this.textBoxNombre);
            this.Name = "Modeloes";
            this.Size = new System.Drawing.Size(435, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label label1;
    }
}
