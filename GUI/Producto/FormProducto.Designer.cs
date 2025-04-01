namespace GUI.Producto
{
    partial class FormProducto
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
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.txtDescripcionProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioCompraProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioVentaProducto = new System.Windows.Forms.TextBox();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(37, 415);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.Size = new System.Drawing.Size(1372, 274);
            this.dgvProductos.TabIndex = 0;
            // 
            // txtDescripcionProducto
            // 
            this.txtDescripcionProducto.Location = new System.Drawing.Point(155, 133);
            this.txtDescripcionProducto.Name = "txtDescripcionProducto";
            this.txtDescripcionProducto.Size = new System.Drawing.Size(227, 22);
            this.txtDescripcionProducto.TabIndex = 2;
            // 
            // txtPrecioCompraProducto
            // 
            this.txtPrecioCompraProducto.Location = new System.Drawing.Point(155, 198);
            this.txtPrecioCompraProducto.Name = "txtPrecioCompraProducto";
            this.txtPrecioCompraProducto.Size = new System.Drawing.Size(227, 22);
            this.txtPrecioCompraProducto.TabIndex = 3;
            // 
            // txtPrecioVentaProducto
            // 
            this.txtPrecioVentaProducto.Location = new System.Drawing.Point(155, 271);
            this.txtPrecioVentaProducto.Name = "txtPrecioVentaProducto";
            this.txtPrecioVentaProducto.Size = new System.Drawing.Size(227, 22);
            this.txtPrecioVentaProducto.TabIndex = 4;
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(155, 64);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(227, 22);
            this.txtNombreProducto.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(96, 319);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 38);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(301, 319);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(81, 38);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(199, 319);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(81, 38);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // FormProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 720);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNombreProducto);
            this.Controls.Add(this.txtPrecioVentaProducto);
            this.Controls.Add(this.txtPrecioCompraProducto);
            this.Controls.Add(this.txtDescripcionProducto);
            this.Controls.Add(this.dgvProductos);
            this.Name = "FormProducto";
            this.Text = "FormProducto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtDescripcionProducto;
        private System.Windows.Forms.TextBox txtPrecioCompraProducto;
        private System.Windows.Forms.TextBox txtPrecioVentaProducto;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
    }
}