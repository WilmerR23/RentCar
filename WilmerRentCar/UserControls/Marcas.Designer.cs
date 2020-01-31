using System;
using System.Windows.Forms;

namespace WilmerRentCar.UserControls
{
    partial class Marcas
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
            this.labelNombre = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(10, 13);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 5;
            this.labelNombre.Text = "Nombre";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(13, 29);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(183, 20);
            this.textBoxNombre.TabIndex = 4;
            // 
            // Marca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.textBoxNombre);
            this.Name = "Marca";
            this.Size = new System.Drawing.Size(209, 62);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox textBoxNombre;
    }
}
