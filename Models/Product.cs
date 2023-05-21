using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Column("product_name")] // Specify the column name in the database
    public string Name { get; set; }

    [Column("product_price")] // Specify the column name in the database

    public decimal Price { get; set; }
}
