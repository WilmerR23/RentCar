using System;
using System.Windows.Forms;

namespace WilmerRentCar.UserControls
{
    partial class Vehículo
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
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPlaca = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMotor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxChassis = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.cbModelo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTipoCombustible = new System.Windows.Forms.ComboBox();
            this.cbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Placa*";
            // 
            // textBoxPlaca
            // 
            this.textBoxPlaca.Location = new System.Drawing.Point(3, 168);
            this.textBoxPlaca.Name = "textBoxPlaca";
            this.textBoxPlaca.Size = new System.Drawing.Size(211, 20);
            this.textBoxPlaca.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Motor*";
            // 
            // textBoxMotor
            // 
            this.textBoxMotor.Location = new System.Drawing.Point(233, 120);
            this.textBoxMotor.Name = "textBoxMotor";
            this.textBoxMotor.Size = new System.Drawing.Size(211, 20);
            this.textBoxMotor.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Chassis*";
            // 
            // textBoxChassis
            // 
            this.textBoxChassis.Location = new System.Drawing.Point(3, 120);
            this.textBoxChassis.Name = "textBoxChassis";
            this.textBoxChassis.Size = new System.Drawing.Size(211, 20);
            this.textBoxChassis.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Modelo*";
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(0, 3);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(41, 13);
            this.labelCliente.TabIndex = 25;
            this.labelCliente.Text = "Marca*";
            // 
            // cbMarca
            // 
            this.cbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(3, 19);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(211, 21);
            this.cbMarca.TabIndex = 24;
            this.cbMarca.SelectedIndexChanged += new System.EventHandler(this.cbMarca_SelectedIndexChanged);
            // 
            // cbModelo
            // 
            this.cbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModelo.Enabled = false;
            this.cbModelo.FormattingEnabled = true;
            this.cbModelo.Location = new System.Drawing.Point(233, 19);
            this.cbModelo.Name = "cbModelo";
            this.cbModelo.Size = new System.Drawing.Size(211, 21);
            this.cbModelo.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Tipo Vehiculo*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Tipo Combustible*";
            // 
            // cbTipoCombustible
            // 
            this.cbTipoCombustible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCombustible.FormattingEnabled = true;
            this.cbTipoCombustible.Location = new System.Drawing.Point(3, 70);
            this.cbTipoCombustible.Name = "cbTipoCombustible";
            this.cbTipoCombustible.Size = new System.Drawing.Size(211, 21);
            this.cbTipoCombustible.TabIndex = 38;
            // 
            // cbTipoVehiculo
            // 
            this.cbTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoVehiculo.FormattingEnabled = true;
            this.cbTipoVehiculo.Location = new System.Drawing.Point(233, 70);
            this.cbTipoVehiculo.Name = "cbTipoVehiculo";
            this.cbTipoVehiculo.Size = new System.Drawing.Size(211, 21);
            this.cbTipoVehiculo.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(214, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Los campos con asteriscos son obligatorios.";
            // 
            // Vehículo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbTipoCombustible);
            this.Controls.Add(this.cbTipoVehiculo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPlaca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxMotor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxChassis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.cbMarca);
            this.Controls.Add(this.cbModelo);
            this.Name = "Vehículo";
            this.Size = new System.Drawing.Size(453, 212);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        



        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPlaca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMotor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxChassis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.ComboBox cbModelo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTipoCombustible;
        private System.Windows.Forms.ComboBox cbTipoVehiculo;
        private Label label7;
    }
}
