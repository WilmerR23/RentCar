namespace WilmerRentCar.UserControls
{
    partial class Empleadoes
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
            this.labelComision = new System.Windows.Forms.Label();
            this.labelTanda = new System.Windows.Forms.Label();
            this.textBoxTanda = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelCedula = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxCedula = new System.Windows.Forms.MaskedTextBox();
            this.textBoxComision = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // labelComision
            // 
            this.labelComision.AutoSize = true;
            this.labelComision.Location = new System.Drawing.Point(246, 55);
            this.labelComision.Name = "labelComision";
            this.labelComision.Size = new System.Drawing.Size(49, 13);
            this.labelComision.TabIndex = 15;
            this.labelComision.Text = "Comisión";
            // 
            // labelTanda
            // 
            this.labelTanda.AutoSize = true;
            this.labelTanda.Location = new System.Drawing.Point(246, -1);
            this.labelTanda.Name = "labelTanda";
            this.labelTanda.Size = new System.Drawing.Size(38, 13);
            this.labelTanda.TabIndex = 14;
            this.labelTanda.Text = "Tanda";
            // 
            // textBoxTanda
            // 
            this.textBoxTanda.Location = new System.Drawing.Point(247, 15);
            this.textBoxTanda.Name = "textBoxTanda";
            this.textBoxTanda.Size = new System.Drawing.Size(216, 20);
            this.textBoxTanda.TabIndex = 13;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(0, 55);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 11;
            this.labelNombre.Text = "Nombre";
            // 
            // labelCedula
            // 
            this.labelCedula.AutoSize = true;
            this.labelCedula.Location = new System.Drawing.Point(0, -1);
            this.labelCedula.Name = "labelCedula";
            this.labelCedula.Size = new System.Drawing.Size(40, 13);
            this.labelCedula.TabIndex = 10;
            this.labelCedula.Text = "Cédula";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(3, 71);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(216, 20);
            this.textBoxNombre.TabIndex = 16;
            // 
            // textBoxCedula
            // 
            this.textBoxCedula.Location = new System.Drawing.Point(3, 15);
            this.textBoxCedula.Name = "textBoxCedula";
            this.textBoxCedula.Size = new System.Drawing.Size(216, 20);
            this.textBoxCedula.TabIndex = 17;
            this.textBoxCedula.TextChanged += new System.EventHandler(this.textBoxCedula_TextChanged);
            // 
            // textBoxComision
            // 
            this.textBoxComision.Location = new System.Drawing.Point(247, 71);
            this.textBoxComision.Name = "textBoxComision";
            this.textBoxComision.Size = new System.Drawing.Size(216, 20);
            this.textBoxComision.TabIndex = 18;
            // 
            // Empleadoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.textBoxComision);
            this.Controls.Add(this.textBoxCedula);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelComision);
            this.Controls.Add(this.labelTanda);
            this.Controls.Add(this.textBoxTanda);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelCedula);
            this.Name = "Empleadoes";
            this.Size = new System.Drawing.Size(479, 109);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelComision;
        private System.Windows.Forms.Label labelTanda;
        private System.Windows.Forms.TextBox textBoxTanda;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelCedula;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.MaskedTextBox textBoxCedula;
        private System.Windows.Forms.MaskedTextBox textBoxComision;
    }
}
