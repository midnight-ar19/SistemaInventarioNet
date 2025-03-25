using System;
using System.ComponentModel.DataAnnotations;

public class Usuario
{
    [Key]
    public int UniqueID { get; set; }  

    [Required]
    [StringLength(50)]
    public string NombreUsuario { get; set; }  

    [Required]
    [StringLength(100)]
    public string Contraseña { get; set; }  

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string Correo { get; set; }  

    [StringLength(20)]
    public string Telefono { get; set; }  

    public DateTime FechaRegistro { get; set; } = DateTime.Now;  

    [StringLength(10)]
    public string Estado { get; set; } = "Activo";  
}