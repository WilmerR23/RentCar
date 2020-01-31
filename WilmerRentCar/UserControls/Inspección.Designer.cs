using System;
using System.Windows.Forms;

namespace WilmerRentCar.UserControls
{
    partial class Inspección
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
            this.cbVehiculo = new System.Windows.Forms.ComboBox();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCantidadCombustible = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInspeccion = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.clbInspeccion = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // cbVehiculo
            // 
            this.cbVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVehiculo.Enabled = false;
            this.cbVehiculo.FormattingEnabled = true;
            this.cbVehiculo.Location = new System.Drawing.Point(3, 63);
            this.cbVehiculo.Name = "cbVehiculo";
            this.cbVehiculo.Size = new System.Drawing.Size(156, 21);
            this.cbVehiculo.TabIndex = 0;
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(3, 16);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(156, 21);
            this.cbCliente.TabIndex = 2;
            this.cbCliente.SelectedIndexChanged += new System.EventHandler(this.cbCliente_SelectedIndexChanged);
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(0, 0);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(39, 13);
            this.labelCliente.TabIndex = 3;
            this.labelCliente.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vehiculo";
            // 
            // textBoxCantidadCombustible
            // 
            this.textBoxCantidadCombustible.Location = new System.Drawing.Point(3, 117);
            this.textBoxCantidadCombustible.Name = "textBoxCantidadCombustible";
            this.textBoxCantidadCombustible.Size = new System.Drawing.Size(137, 20);
            this.textBoxCantidadCombustible.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cantidad Combustible";
            // 
            // dtpFechaInspeccion
            // 
            this.dtpFechaInspeccion.Location = new System.Drawing.Point(3, 165);
            this.dtpFechaInspeccion.Name = "dtpFechaInspeccion";
            this.dtpFechaInspeccion.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInspeccion.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha Inspección";
            // 
            // clbInspeccion
            // 
            this.clbInspeccion.FormattingEnabled = true;
            this.clbInspeccion.Items.AddRange(new object[] {
            "Ralladuras",
            "Goma Repuesta",
            "Gato",
            "Rotura de cristales",
            "Goma izquierda frente",
            "Goma derecha frente",
            "Goma izquierda atras",
            "Goma derecha atras"});
            this.clbInspeccion.Location = new System.Drawing.Point(243, 1);
            this.clbInspeccion.Name = "clbInspeccion";
            this.clbInspeccion.Size = new System.Drawing.Size(182, 184);
            this.clbInspeccion.TabIndex = 9;
            // 
            // Inspección
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.clbInspeccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFechaInspeccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCantidadCombustible);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.cbVehiculo);
            this.Name = "Inspección";
            this.Size = new System.Drawing.Size(434, 195);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        



        #endregion

        private System.Windows.Forms.ComboBox cbVehiculo;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCantidadCombustible;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInspeccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox clbInspeccion;
    }
}
