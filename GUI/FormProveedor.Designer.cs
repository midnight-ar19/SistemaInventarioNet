namespace GUI
{
    partial class FormProveedor
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
            this.labelNombreProveedor = new System.Windows.Forms.Label();
            this.labelIDProveedor = new System.Windows.Forms.Label();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.textBoxNombreProveedor = new System.Windows.Forms.TextBox();
            this.textBoxIDProveedor = new System.Windows.Forms.TextBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.labelContacto = new System.Windows.Forms.Label();
            this.textBoxContacto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelNombreProveedor
            // 
            this.labelNombreProveedor.AutoSize = true;
            this.labelNombreProveedor.Location = new System.Drawing.Point(72, 45);
            this.labelNombreProveedor.Name = "labelNombreProveedor";
            this.labelNombreProveedor.Size = new System.Drawing.Size(113, 13);
            this.labelNombreProveedor.TabIndex = 0;
            this.labelNombreProveedor.Text = "Nombre De Proveedor";
            // 
            // labelIDProveedor
            // 
            this.labelIDProveedor.AutoSize = true;
            this.labelIDProveedor.Location = new System.Drawing.Point(72, 89);
            this.labelIDProveedor.Name = "labelIDProveedor";
            this.labelIDProveedor.Size = new System.Drawing.Size(87, 13);
            this.labelIDProveedor.TabIndex = 1;
            this.labelIDProveedor.Text = "ID De Proveedor";
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Location = new System.Drawing.Point(72, 170);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(52, 13);
            this.labelDireccion.TabIndex = 2;
            this.labelDireccion.Text = "Dirección";
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Location = new System.Drawing.Point(72, 209);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(49, 13);
            this.labelTelefono.TabIndex = 3;
            this.labelTelefono.Text = "Teléfono";
            // 
            // textBoxNombreProveedor
            // 
            this.textBoxNombreProveedor.Location = new System.Drawing.Point(239, 42);
            this.textBoxNombreProveedor.Name = "textBoxNombreProveedor";
            this.textBoxNombreProveedor.Size = new System.Drawing.Size(214, 20);
            this.textBoxNombreProveedor.TabIndex = 4;
            // 
            // textBoxIDProveedor
            // 
            this.textBoxIDProveedor.Location = new System.Drawing.Point(239, 86);
            this.textBoxIDProveedor.Name = "textBoxIDProveedor";
            this.textBoxIDProveedor.Size = new System.Drawing.Size(214, 20);
            this.textBoxIDProveedor.TabIndex = 5;
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(239, 167);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(214, 20);
            this.textBoxDireccion.TabIndex = 6;
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(239, 206);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(214, 20);
            this.textBoxTelefono.TabIndex = 7;
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(71, 271);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregar.TabIndex = 8;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            //this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(235, 271);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 9;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            //this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(520, 271);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(75, 23);
            this.buttonEliminar.TabIndex = 10;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
           // this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Location = new System.Drawing.Point(352, 271);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(75, 23);
            this.buttonActualizar.TabIndex = 11;
            this.buttonActualizar.Text = "Actualizar";
            this.buttonActualizar.UseVisualStyleBackColor = true;
           // this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // labelContacto
            // 
            this.labelContacto.AutoSize = true;
            this.labelContacto.Location = new System.Drawing.Point(72, 127);
            this.labelContacto.Name = "labelContacto";
            this.labelContacto.Size = new System.Drawing.Size(50, 13);
            this.labelContacto.TabIndex = 12;
            this.labelContacto.Text = "Contacto";
            // 
            // textBoxContacto
            // 
            this.textBoxContacto.Location = new System.Drawing.Point(239, 124);
            this.textBoxContacto.Name = "textBoxContacto";
            this.textBoxContacto.Size = new System.Drawing.Size(214, 20);
            this.textBoxContacto.TabIndex = 13;
            // 
            // FormProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxContacto);
            this.Controls.Add(this.labelContacto);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.textBoxTelefono);
            this.Controls.Add(this.textBoxDireccion);
            this.Controls.Add(this.textBoxIDProveedor);
            this.Controls.Add(this.textBoxNombreProveedor);
            this.Controls.Add(this.labelTelefono);
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.labelIDProveedor);
            this.Controls.Add(this.labelNombreProveedor);
            this.Name = "FormProveedor";
            this.Text = "FormProveedor";
           // this.Load += new System.EventHandler(this.FormProveedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNombreProveedor;
        private System.Windows.Forms.Label labelIDProveedor;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.TextBox textBoxNombreProveedor;
        private System.Windows.Forms.TextBox textBoxIDProveedor;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.Label labelContacto;
        private System.Windows.Forms.TextBox textBoxContacto;
    }
}