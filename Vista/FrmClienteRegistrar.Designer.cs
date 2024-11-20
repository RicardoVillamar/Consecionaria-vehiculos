namespace Vista
{
    partial class FrmClienteRegistrar
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClienteRegistrar));
            this.lbNomCliente = new System.Windows.Forms.Label();
            this.lbApeCliente = new System.Windows.Forms.Label();
            this.lbCedCliente = new System.Windows.Forms.Label();
            this.lbTelCliente = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lbCoCliente = new System.Windows.Forms.Label();
            this.btnRegistrarCliente = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbNomCliente
            // 
            this.lbNomCliente.AutoSize = true;
            this.lbNomCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomCliente.Location = new System.Drawing.Point(64, 136);
            this.lbNomCliente.Name = "lbNomCliente";
            this.lbNomCliente.Size = new System.Drawing.Size(161, 20);
            this.lbNomCliente.TabIndex = 0;
            this.lbNomCliente.Text = "Nombres del Cliente";
            // 
            // lbApeCliente
            // 
            this.lbApeCliente.AutoSize = true;
            this.lbApeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApeCliente.Location = new System.Drawing.Point(64, 222);
            this.lbApeCliente.Name = "lbApeCliente";
            this.lbApeCliente.Size = new System.Drawing.Size(161, 20);
            this.lbApeCliente.TabIndex = 1;
            this.lbApeCliente.Text = "Apellidos del Cliente";
            // 
            // lbCedCliente
            // 
            this.lbCedCliente.AutoSize = true;
            this.lbCedCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCedCliente.Location = new System.Drawing.Point(424, 136);
            this.lbCedCliente.Name = "lbCedCliente";
            this.lbCedCliente.Size = new System.Drawing.Size(61, 20);
            this.lbCedCliente.TabIndex = 2;
            this.lbCedCliente.Text = "Cédula";
            // 
            // lbTelCliente
            // 
            this.lbTelCliente.AutoSize = true;
            this.lbTelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTelCliente.Location = new System.Drawing.Point(424, 222);
            this.lbTelCliente.Name = "lbTelCliente";
            this.lbTelCliente.Size = new System.Drawing.Size(73, 20);
            this.lbTelCliente.TabIndex = 3;
            this.lbTelCliente.Text = "Teléfono";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(64, 158);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(304, 26);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(68, 244);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(304, 26);
            this.txtApellido.TabIndex = 5;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(424, 158);
            this.txtCedula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(304, 26);
            this.txtCedula.TabIndex = 6;
            this.txtCedula.TextChanged += new System.EventHandler(this.txtCedula_TextChanged);
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(424, 244);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(304, 26);
            this.txtTelefono.TabIndex = 7;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(68, 336);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(659, 26);
            this.txtCorreo.TabIndex = 8;
            // 
            // lbCoCliente
            // 
            this.lbCoCliente.AutoSize = true;
            this.lbCoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCoCliente.Location = new System.Drawing.Point(64, 314);
            this.lbCoCliente.Name = "lbCoCliente";
            this.lbCoCliente.Size = new System.Drawing.Size(149, 20);
            this.lbCoCliente.TabIndex = 9;
            this.lbCoCliente.Text = "Correo Electrónico";
            // 
            // btnRegistrarCliente
            // 
            this.btnRegistrarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarCliente.Location = new System.Drawing.Point(253, 402);
            this.btnRegistrarCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistrarCliente.Name = "btnRegistrarCliente";
            this.btnRegistrarCliente.Size = new System.Drawing.Size(268, 50);
            this.btnRegistrarCliente.TabIndex = 10;
            this.btnRegistrarCliente.Text = "Registrar";
            this.btnRegistrarCliente.UseVisualStyleBackColor = true;
            this.btnRegistrarCliente.Click += new System.EventHandler(this.btnRegistrarCliente_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(236, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(287, 36);
            this.label6.TabIndex = 11;
            this.label6.Text = "Registro de Cliente";
            // 
            // FrmClienteRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 488);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRegistrarCliente);
            this.Controls.Add(this.lbCoCliente);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lbTelCliente);
            this.Controls.Add(this.lbCedCliente);
            this.Controls.Add(this.lbApeCliente);
            this.Controls.Add(this.lbNomCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClienteRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRegistrarCliente";
            this.Load += new System.EventHandler(this.FrmClienteRegistrar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNomCliente;
        private System.Windows.Forms.Label lbApeCliente;
        private System.Windows.Forms.Label lbCedCliente;
        private System.Windows.Forms.Label lbTelCliente;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lbCoCliente;
        private System.Windows.Forms.Button btnRegistrarCliente;
        private System.Windows.Forms.Label label6;
    }
}