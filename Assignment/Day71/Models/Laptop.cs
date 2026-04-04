using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Day71.Models;

public sealed class Laptop
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [Required]
    [Display(Name = "Model Name")]
    public string ModelName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Serial Number")]
    public string SerialNumber { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "1000000", ErrorMessage = "Price must be greater than zero.")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
}
