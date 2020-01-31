using System;
using System.Windows.Forms;

namespace WilmerRentCar.UserControls
{
    partial class RentaDevolucions
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
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMontoDia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.cbVehículo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDias = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTotalRenta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Fecha renta*";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(12, 70);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(211, 20);
            this.dtpFechaInicio.TabIndex = 15;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Monto dia*";
            // 
            // textBoxMontoDia
            // 
            this.textBoxMontoDia.Location = new System.Drawing.Point(12, 119);
            this.textBoxMontoDia.Name = "textBoxMontoDia";
            this.textBoxMontoDia.Size = new System.Drawing.Size(211, 20);
            this.textBoxMontoDia.TabIndex = 13;
            this.textBoxMontoDia.TextChanged += new System.EventHandler(this.textBoxMontoDia_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Vehiculo*";
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(9, 2);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(43, 13);
            this.labelCliente.TabIndex = 11;
            this.labelCliente.Text = "Cliente*";
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(12, 18);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(211, 21);
            this.cbCliente.TabIndex = 10;
            // 
            // cbVehículo
            // 
            this.cbVehículo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVehículo.FormattingEnabled = true;
            this.cbVehículo.Location = new System.Drawing.Point(242, 18);
            this.cbVehículo.Name = "cbVehículo";
            this.cbVehículo.Size = new System.Drawing.Size(211, 21);
            this.cbVehículo.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Fecha devolución*";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Location = new System.Drawing.Point(242, 70);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(211, 20);
            this.dtpFechaFinal.TabIndex = 17;
            this.dtpFechaFinal.ValueChanged += new System.EventHandler(this.dtpFechaFinal_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Dias*";
            // 
            // textBoxDias
            // 
            this.textBoxDias.Enabled = false;
            this.textBoxDias.Location = new System.Drawing.Point(242, 119);
            this.textBoxDias.Name = "textBoxDias";
            this.textBoxDias.Size = new System.Drawing.Size(211, 20);
            this.textBoxDias.TabIndex = 19;
            this.textBoxDias.TextChanged += new System.EventHandler(this.textBoxDias_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Total renta*";
            // 
            // textBoxTotalRenta
            // 
            this.textBoxTotalRenta.Enabled = false;
            this.textBoxTotalRenta.Location = new System.Drawing.Point(12, 167);
            this.textBoxTotalRenta.Name = "textBoxTotalRenta";
            this.textBoxTotalRenta.Size = new System.Drawing.Size(211, 20);
            this.textBoxTotalRenta.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(214, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Los campos con asteriscos son obligatorios.";
            // 
            // RentaDevolucions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxTotalRenta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxDias);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMontoDia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.cbVehículo);
            this.Name = "RentaDevolucions";
            this.Size = new System.Drawing.Size(461, 210);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMontoDia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.ComboBox cbVehículo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDias;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTotalRenta;
        private Label label7;
    }
}
