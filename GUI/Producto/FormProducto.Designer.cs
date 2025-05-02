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
            this.components = new System.ComponentModel.Container();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.idProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciocompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioventaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcategoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idproveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmarcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventarioDBv2DataSet3 = new GUI.InventarioDBv2DataSet3();
            this.txtDescripcionProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioCompraProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioVentaProducto = new System.Windows.Forms.TextBox();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.comboCategoria = new System.Windows.Forms.ComboBox();
            this.categoriasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventarioDBv2DataSet = new GUI.InventarioDBv2DataSet();
            this.comboProveedor = new System.Windows.Forms.ComboBox();
            this.proveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventarioDBv2DataSet2 = new GUI.InventarioDBv2DataSet2();
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.marcasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventarioDBv2DataSet1 = new GUI.InventarioDBv2DataSet1();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.categoriasTableAdapter = new GUI.InventarioDBv2DataSetTableAdapters.categoriasTableAdapter();
            this.inventarioDBv2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.marcasTableAdapter = new GUI.InventarioDBv2DataSet1TableAdapters.marcasTableAdapter();
            this.proveedoresTableAdapter = new GUI.InventarioDBv2DataSet2TableAdapters.proveedoresTableAdapter();
            this.productosTableAdapter = new GUI.InventarioDBv2DataSet3TableAdapters.productosTableAdapter();
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillByToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.inventarioDB = new GUI.InventarioDB();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioDBv2DataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioDBv2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioDBv2DataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioDBv2DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioDBv2DataSetBindingSource)).BeginInit();
            this.fillByToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioDB)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.AutoGenerateColumns = false;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProductoDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.preciocompraDataGridViewTextBoxColumn,
            this.precioventaDataGridViewTextBoxColumn,
            this.idcategoriaDataGridViewTextBoxColumn,
            this.idproveedorDataGridViewTextBoxColumn,
            this.idmarcaDataGridViewTextBoxColumn});
            this.dgvProductos.DataSource = this.productosBindingSource;
            this.dgvProductos.Location = new System.Drawing.Point(83, 415);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.Size = new System.Drawing.Size(1204, 274);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            // 
            // idProductoDataGridViewTextBoxColumn
            // 
            this.idProductoDataGridViewTextBoxColumn.DataPropertyName = "IdProducto";
            this.idProductoDataGridViewTextBoxColumn.HeaderText = "IdProducto";
            this.idProductoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idProductoDataGridViewTextBoxColumn.Name = "idProductoDataGridViewTextBoxColumn";
            this.idProductoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProductoDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "nombre";
            this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.Width = 125;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.Width = 125;
            // 
            // preciocompraDataGridViewTextBoxColumn
            // 
            this.preciocompraDataGridViewTextBoxColumn.DataPropertyName = "precio_compra";
            this.preciocompraDataGridViewTextBoxColumn.HeaderText = "precio_compra";
            this.preciocompraDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.preciocompraDataGridViewTextBoxColumn.Name = "preciocompraDataGridViewTextBoxColumn";
            this.preciocompraDataGridViewTextBoxColumn.Width = 125;
            // 
            // precioventaDataGridViewTextBoxColumn
            // 
            this.precioventaDataGridViewTextBoxColumn.DataPropertyName = "precio_venta";
            this.precioventaDataGridViewTextBoxColumn.HeaderText = "precio_venta";
            this.precioventaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.precioventaDataGridViewTextBoxColumn.Name = "precioventaDataGridViewTextBoxColumn";
            this.precioventaDataGridViewTextBoxColumn.Width = 125;
            // 
            // idcategoriaDataGridViewTextBoxColumn
            // 
            this.idcategoriaDataGridViewTextBoxColumn.DataPropertyName = "id_categoria";
            this.idcategoriaDataGridViewTextBoxColumn.HeaderText = "id_categoria";
            this.idcategoriaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idcategoriaDataGridViewTextBoxColumn.Name = "idcategoriaDataGridViewTextBoxColumn";
            this.idcategoriaDataGridViewTextBoxColumn.Width = 125;
            // 
            // idproveedorDataGridViewTextBoxColumn
            // 
            this.idproveedorDataGridViewTextBoxColumn.DataPropertyName = "id_proveedor";
            this.idproveedorDataGridViewTextBoxColumn.HeaderText = "id_proveedor";
            this.idproveedorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idproveedorDataGridViewTextBoxColumn.Name = "idproveedorDataGridViewTextBoxColumn";
            this.idproveedorDataGridViewTextBoxColumn.Width = 125;
            // 
            // idmarcaDataGridViewTextBoxColumn
            // 
            this.idmarcaDataGridViewTextBoxColumn.DataPropertyName = "id_marca";
            this.idmarcaDataGridViewTextBoxColumn.HeaderText = "id_marca";
            this.idmarcaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idmarcaDataGridViewTextBoxColumn.Name = "idmarcaDataGridViewTextBoxColumn";
            this.idmarcaDataGridViewTextBoxColumn.Width = 125;
            // 
            // productosBindingSource
            // 
            this.productosBindingSource.DataMember = "productos";
            this.productosBindingSource.DataSource = this.inventarioDBv2DataSet3;
            // 
            // inventarioDBv2DataSet3
            // 
            this.inventarioDBv2DataSet3.DataSetName = "InventarioDBv2DataSet3";
            this.inventarioDBv2DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtDescripcionProducto
            // 
            this.txtDescripcionProducto.Location = new System.Drawing.Point(192, 135);
            this.txtDescripcionProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcionProducto.Name = "txtDescripcionProducto";
            this.txtDescripcionProducto.Size = new System.Drawing.Size(227, 22);
            this.txtDescripcionProducto.TabIndex = 2;
            this.txtDescripcionProducto.TextChanged += new System.EventHandler(this.txtDescripcionProducto_TextChanged);
            // 
            // txtPrecioCompraProducto
            // 
            this.txtPrecioCompraProducto.Location = new System.Drawing.Point(192, 200);
            this.txtPrecioCompraProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecioCompraProducto.Name = "txtPrecioCompraProducto";
            this.txtPrecioCompraProducto.Size = new System.Drawing.Size(227, 22);
            this.txtPrecioCompraProducto.TabIndex = 3;
            this.txtPrecioCompraProducto.TextChanged += new System.EventHandler(this.txtPrecioCompraProducto_TextChanged);
            // 
            // txtPrecioVentaProducto
            // 
            this.txtPrecioVentaProducto.Location = new System.Drawing.Point(192, 273);
            this.txtPrecioVentaProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecioVentaProducto.Name = "txtPrecioVentaProducto";
            this.txtPrecioVentaProducto.Size = new System.Drawing.Size(227, 22);
            this.txtPrecioVentaProducto.TabIndex = 4;
            this.txtPrecioVentaProducto.TextChanged += new System.EventHandler(this.txtPrecioVentaProducto_TextChanged);
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(192, 66);
            this.txtNombreProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreProducto.Multiline = true;
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(227, 22);
            this.txtNombreProducto.TabIndex = 5;
            this.txtNombreProducto.TextChanged += new System.EventHandler(this.txtNombreProducto_TextChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(133, 321);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 38);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(338, 321);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(81, 38);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(236, 321);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(81, 38);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // comboCategoria
            // 
            this.comboCategoria.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.categoriasBindingSource, "IdCategoria", true));
            this.comboCategoria.DataSource = this.categoriasBindingSource;
            this.comboCategoria.DisplayMember = "IdCategoria";
            this.comboCategoria.FormattingEnabled = true;
            this.comboCategoria.Location = new System.Drawing.Point(991, 61);
            this.comboCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.comboCategoria.Name = "comboCategoria";
            this.comboCategoria.Size = new System.Drawing.Size(296, 24);
            this.comboCategoria.TabIndex = 9;
            this.comboCategoria.ValueMember = "nombre";
            this.comboCategoria.SelectedIndexChanged += new System.EventHandler(this.comboCategoria_SelectedIndexChanged);
            // 
            // categoriasBindingSource
            // 
            this.categoriasBindingSource.DataMember = "categorias";
            this.categoriasBindingSource.DataSource = this.inventarioDBv2DataSet;
            // 
            // inventarioDBv2DataSet
            // 
            this.inventarioDBv2DataSet.DataSetName = "InventarioDBv2DataSet";
            this.inventarioDBv2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboProveedor
            // 
            this.comboProveedor.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.proveedoresBindingSource, "IdProveedor", true));
            this.comboProveedor.DataSource = this.proveedoresBindingSource;
            this.comboProveedor.DisplayMember = "nombre";
            this.comboProveedor.FormattingEnabled = true;
            this.comboProveedor.Location = new System.Drawing.Point(991, 110);
            this.comboProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.comboProveedor.Name = "comboProveedor";
            this.comboProveedor.Size = new System.Drawing.Size(296, 24);
            this.comboProveedor.TabIndex = 10;
            this.comboProveedor.ValueMember = "IdProveedor";
            // 
            // proveedoresBindingSource
            // 
            this.proveedoresBindingSource.DataMember = "proveedores";
            this.proveedoresBindingSource.DataSource = this.inventarioDBv2DataSet2;
            // 
            // inventarioDBv2DataSet2
            // 
            this.inventarioDBv2DataSet2.DataSetName = "InventarioDBv2DataSet2";
            this.inventarioDBv2DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboMarca
            // 
            this.comboMarca.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.marcasBindingSource, "IdMarca", true));
            this.comboMarca.DataSource = this.marcasBindingSource;
            this.comboMarca.DisplayMember = "nombre";
            this.comboMarca.FormattingEnabled = true;
            this.comboMarca.Location = new System.Drawing.Point(991, 154);
            this.comboMarca.Margin = new System.Windows.Forms.Padding(4);
            this.comboMarca.Name = "comboMarca";
            this.comboMarca.Size = new System.Drawing.Size(296, 24);
            this.comboMarca.TabIndex = 11;
            this.comboMarca.ValueMember = "IdMarca";
            this.comboMarca.SelectedIndexChanged += new System.EventHandler(this.comboMarca_SelectedIndexChanged);
            // 
            // marcasBindingSource
            // 
            this.marcasBindingSource.DataMember = "marcas";
            this.marcasBindingSource.DataSource = this.inventarioDBv2DataSet1;
            // 
            // inventarioDBv2DataSet1
            // 
            this.inventarioDBv2DataSet1.DataSetName = "InventarioDBv2DataSet1";
            this.inventarioDBv2DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Precio Compra";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Precio Venta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(872, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Categoria";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(872, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Proveedor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(872, 164);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Marca";
            // 
            // categoriasTableAdapter
            // 
            this.categoriasTableAdapter.ClearBeforeFill = true;
            // 
            // inventarioDBv2DataSetBindingSource
            // 
            this.inventarioDBv2DataSetBindingSource.DataSource = this.inventarioDBv2DataSet;
            this.inventarioDBv2DataSetBindingSource.Position = 0;
            // 
            // marcasTableAdapter
            // 
            this.marcasTableAdapter.ClearBeforeFill = true;
            // 
            // proveedoresTableAdapter
            // 
            this.proveedoresTableAdapter.ClearBeforeFill = true;
            // 
            // productosTableAdapter
            // 
            this.productosTableAdapter.ClearBeforeFill = true;
            // 
            // fillByToolStrip
            // 
            this.fillByToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fillByToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillByToolStripButton});
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(1371, 27);
            this.fillByToolStrip.TabIndex = 19;
            this.fillByToolStrip.Text = "fillByToolStrip";
            this.fillByToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fillByToolStrip_ItemClicked);
            // 
            // fillByToolStripButton
            // 
            this.fillByToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByToolStripButton.Name = "fillByToolStripButton";
            this.fillByToolStripButton.Size = new System.Drawing.Size(48, 24);
            this.fillByToolStripButton.Text = "FillBy";
            this.fillByToolStripButton.Click += new System.EventHandler(this.fillByToolStripButton_Click);
            // 
            // inventarioDB
            // 
            this.inventarioDB.DataSetName = "InventarioDB";
            this.inventarioDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FormProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 720);
            this.Controls.Add(this.fillByToolStrip);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboMarca);
            this.Controls.Add(this.comboProveedor);
            this.Controls.Add(this.comboCategoria);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNombreProducto);
            this.Controls.Add(this.txtPrecioVentaProducto);
            this.Controls.Add(this.txtPrecioCompraProducto);
            this.Controls.Add(this.txtDescripcionProducto);
            this.Controls.Add(this.dgvProductos);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormProducto";
            this.Text = "FormProducto";
            this.Load += new System.EventHandler(this.FormProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioDBv2DataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioDBv2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioDBv2DataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioDBv2DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioDBv2DataSetBindingSource)).EndInit();
            this.fillByToolStrip.ResumeLayout(false);
            this.fillByToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioDB)).EndInit();
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
        private System.Windows.Forms.ComboBox comboCategoria;
        private System.Windows.Forms.ComboBox comboProveedor;
        private System.Windows.Forms.ComboBox comboMarca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private InventarioDBv2DataSet inventarioDBv2DataSet;
        private System.Windows.Forms.BindingSource categoriasBindingSource;
        private InventarioDBv2DataSetTableAdapters.categoriasTableAdapter categoriasTableAdapter;
        private System.Windows.Forms.BindingSource inventarioDBv2DataSetBindingSource;
        private InventarioDBv2DataSet1 inventarioDBv2DataSet1;
        private System.Windows.Forms.BindingSource marcasBindingSource;
        private InventarioDBv2DataSet1TableAdapters.marcasTableAdapter marcasTableAdapter;
        private InventarioDBv2DataSet2 inventarioDBv2DataSet2;
        private System.Windows.Forms.BindingSource proveedoresBindingSource;
        private InventarioDBv2DataSet2TableAdapters.proveedoresTableAdapter proveedoresTableAdapter;
        private InventarioDBv2DataSet3 inventarioDBv2DataSet3;
        private System.Windows.Forms.BindingSource productosBindingSource;
        private InventarioDBv2DataSet3TableAdapters.productosTableAdapter productosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciocompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioventaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmarcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.ToolStripButton fillByToolStripButton;
        private InventarioDB inventarioDB;
    }
}