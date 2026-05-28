using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi5.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sách là bắt buộc")]
        [StringLength(150, ErrorMessage = "Tên sách không được vượt quá 150 ký tự")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên tác giả là bắt buộc")]
        [StringLength(150, ErrorMessage = "Tên tác giả không được vượt quá 150 ký tự")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Giá là bắt buộc")]
        [Range(1, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        [Column(TypeName = "decimal(18,0)")]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        [StringLength(100)]
        public string? Image { get; set; }

        [Required(ErrorMessage = "Chủ đề là bắt buộc")]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
