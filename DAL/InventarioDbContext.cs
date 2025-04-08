namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using EL;

    public class InventarioDbContext : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'InventarioDbContext' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'DAL.InventarioDbContext' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'InventarioDbContext'  en el archivo de configuración de la aplicación.
        public InventarioDbContext()
            : base("name=InventarioDbContext")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Categoria> Categorias { get; set; }

        public virtual DbSet<Inventario> Inventario { get; set; }

        public virtual DbSet<Marca> Marcas { get; set; }

        public virtual DbSet<MovimientoInventario> MovimientoInventario { get; set; }

        public virtual DbSet<Producto> Productos { get; set; }

        public virtual DbSet<Proveedor> Proveedores { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}