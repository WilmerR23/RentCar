namespace WilmerRentCar.UserControls
{
    partial class Usuarios
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxClave = new System.Windows.Forms.TextBox();
            this.cbEmpleado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clave";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(38, 48);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(194, 20);
            this.textBoxNombre.TabIndex = 2;
            // 
            // textBoxClave
            // 
            this.textBoxClave.Location = new System.Drawing.Point(249, 48);
            this.textBoxClave.Name = "textBoxClave";
            this.textBoxClave.Size = new System.Drawing.Size(195, 20);
            this.textBoxClave.TabIndex = 3;
            this.textBoxClave.UseSystemPasswordChar = true;
            // 
            // cbEmpleado
            // 
            this.cbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpleado.FormattingEnabled = true;
            this.cbEmpleado.Location = new System.Drawing.Point(38, 100);
            this.cbEmpleado.Name = "cbEmpleado";
            this.cbEmpleado.Size = new System.Drawing.Size(194, 21);
            this.cbEmpleado.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Empleado";
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbEmpleado);
            this.Controls.Add(this.textBoxClave);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Usuarios";
            this.Size = new System.Drawing.Size(480, 148);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxClave;
        private System.Windows.Forms.ComboBox cbEmpleado;
        private System.Windows.Forms.Label label3;
    }
}
