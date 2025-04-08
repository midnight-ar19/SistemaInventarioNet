namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categorias",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdCategoria)
                .Index(t => t.nombre, unique: true);
            
            CreateTable(
                "dbo.inventario",
                c => new
                    {
                        IdInventario = c.Int(nullable: false, identity: true),
                        id_producto = c.Int(nullable: false),
                        stock = c.Int(nullable: false),
                        stock_minimo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdInventario)
                .ForeignKey("dbo.productos", t => t.id_producto, cascadeDelete: true)
                .Index(t => t.id_producto);
            
            CreateTable(
                "dbo.productos",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                        descripcion = c.String(),
                        precio_compra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        precio_venta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id_categoria = c.Int(),
                        id_proveedor = c.Int(),
                        id_marca = c.Int(),
                    })
                .PrimaryKey(t => t.IdProducto)
                .ForeignKey("dbo.categorias", t => t.id_categoria)
                .ForeignKey("dbo.marcas", t => t.id_marca)
                .ForeignKey("dbo.proveedores", t => t.id_proveedor)
                .Index(t => t.id_categoria)
                .Index(t => t.id_proveedor)
                .Index(t => t.id_marca);
            
            CreateTable(
                "dbo.marcas",
                c => new
                    {
                        IdMarca = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdMarca)
                .Index(t => t.nombre, unique: true);
            
            CreateTable(
                "dbo.proveedores",
                c => new
                    {
                        IdProveedor = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                        contacto = c.String(maxLength: 100),
                        telefono = c.String(maxLength: 20),
                        direccion = c.String(),
                    })
                .PrimaryKey(t => t.IdProveedor);
            
            CreateTable(
                "dbo.movimientos_inventario",
                c => new
                    {
                        IdMovimiento = c.Int(nullable: false, identity: true),
                        id_producto = c.Int(nullable: false),
                        tipo = c.String(nullable: false, maxLength: 7),
                        cantidad = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        id_usuario = c.Int(),
                        observacion = c.String(),
                    })
                .PrimaryKey(t => t.IdMovimiento)
                .ForeignKey("dbo.productos", t => t.id_producto, cascadeDelete: true)
                .ForeignKey("dbo.usuarios", t => t.id_usuario)
                .Index(t => t.id_producto)
                .Index(t => t.id_usuario);
            
            CreateTable(
                "dbo.usuarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                        usuario = c.String(nullable: false, maxLength: 50),
                        contrasena = c.String(nullable: false, maxLength: 255),
                        rol = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .Index(t => t.usuario, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.movimientos_inventario", "id_usuario", "dbo.usuarios");
            DropForeignKey("dbo.movimientos_inventario", "id_producto", "dbo.productos");
            DropForeignKey("dbo.inventario", "id_producto", "dbo.productos");
            DropForeignKey("dbo.productos", "id_proveedor", "dbo.proveedores");
            DropForeignKey("dbo.productos", "id_marca", "dbo.marcas");
            DropForeignKey("dbo.productos", "id_categoria", "dbo.categorias");
            DropIndex("dbo.usuarios", new[] { "usuario" });
            DropIndex("dbo.movimientos_inventario", new[] { "id_usuario" });
            DropIndex("dbo.movimientos_inventario", new[] { "id_producto" });
            DropIndex("dbo.marcas", new[] { "nombre" });
            DropIndex("dbo.productos", new[] { "id_marca" });
            DropIndex("dbo.productos", new[] { "id_proveedor" });
            DropIndex("dbo.productos", new[] { "id_categoria" });
            DropIndex("dbo.inventario", new[] { "id_producto" });
            DropIndex("dbo.categorias", new[] { "nombre" });
            DropTable("dbo.usuarios");
            DropTable("dbo.movimientos_inventario");
            DropTable("dbo.proveedores");
            DropTable("dbo.marcas");
            DropTable("dbo.productos");
            DropTable("dbo.inventario");
            DropTable("dbo.categorias");
        }
    }
}
