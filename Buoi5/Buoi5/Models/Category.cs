using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Buoi5.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Tên chủ đề là bắt buộc")]
        [StringLength(150, ErrorMessage = "Tên chủ đề không được vượt quá 150 ký tự")]
        public string CategoryName { get; set; } = string.Empty;

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
