using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcommerce.AspNetCore.Api.Domain
{
    public sealed class Product
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        [Column(TypeName = "numeric(18,2)")]
        public decimal Price { get; set; }
    }
}
