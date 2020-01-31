using System.Windows.Forms;

namespace WilmerRentCar.UserControls
{
    partial class Clientes
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
            this.labelCedula = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelTarjeta = new System.Windows.Forms.Label();
            this.labelLimite = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCedula = new System.Windows.Forms.MaskedTextBox();
            this.textBoxTarjeta = new System.Windows.Forms.MaskedTextBox();
            this.textBoxLimite = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(3, 76);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(216, 20);
            this.textBoxNombre.TabIndex = 1;
            // 
            // labelCedula
            // 
            this.labelCedula.AutoSize = true;
            this.labelCedula.Location = new System.Drawing.Point(0, 4);
            this.labelCedula.Name = "labelCedula";
            this.labelCedula.Size = new System.Drawing.Size(44, 13);
            this.labelCedula.TabIndex = 2;
            this.labelCedula.Text = "Cédula*";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(0, 60);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(48, 13);
            this.labelNombre.TabIndex = 3;
            this.labelNombre.Text = "Nombre*";
            // 
            // labelTarjeta
            // 
            this.labelTarjeta.AutoSize = true;
            this.labelTarjeta.Location = new System.Drawing.Point(244, 4);
            this.labelTarjeta.Name = "labelTarjeta";
            this.labelTarjeta.Size = new System.Drawing.Size(44, 13);
            this.labelTarjeta.TabIndex = 6;
            this.labelTarjeta.Text = "Tarjeta*";
            // 
            // labelLimite
            // 
            this.labelLimite.AutoSize = true;
            this.labelLimite.Location = new System.Drawing.Point(244, 60);
            this.labelLimite.Name = "labelLimite";
            this.labelLimite.Size = new System.Drawing.Size(38, 13);
            this.labelLimite.TabIndex = 7;
            this.labelLimite.Text = "Limite*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Los campos con asteriscos son obligatorios.";
            // 
            // textBoxCedula
            // 
            this.textBoxCedula.Location = new System.Drawing.Point(3, 20);
            this.textBoxCedula.Name = "textBoxCedula";
            this.textBoxCedula.Size = new System.Drawing.Size(216, 20);
            this.textBoxCedula.TabIndex = 9;
            this.textBoxCedula.TextChanged += new System.EventHandler(this.textBoxCedula_TextChanged);
            // 
            // textBoxTarjeta
            // 
            this.textBoxTarjeta.Location = new System.Drawing.Point(247, 20);
            this.textBoxTarjeta.Name = "textBoxTarjeta";
            this.textBoxTarjeta.Size = new System.Drawing.Size(216, 20);
            this.textBoxTarjeta.TabIndex = 10;
            // 
            // textBoxLimite
            // 
            this.textBoxLimite.Location = new System.Drawing.Point(247, 76);
            this.textBoxLimite.Name = "textBoxLimite";
            this.textBoxLimite.Size = new System.Drawing.Size(216, 20);
            this.textBoxLimite.TabIndex = 11;
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.textBoxLimite);
            this.Controls.Add(this.textBoxTarjeta);
            this.Controls.Add(this.textBoxCedula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLimite);
            this.Controls.Add(this.labelTarjeta);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelCedula);
            this.Controls.Add(this.textBoxNombre);
            this.Name = "Clientes";
            this.Size = new System.Drawing.Size(472, 190);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelCedula;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelTarjeta;
        private System.Windows.Forms.Label labelLimite;
        private System.Windows.Forms.Label label1;
        private MaskedTextBox textBoxCedula;
        private MaskedTextBox textBoxTarjeta;
        private MaskedTextBox textBoxLimite;
    }
}
