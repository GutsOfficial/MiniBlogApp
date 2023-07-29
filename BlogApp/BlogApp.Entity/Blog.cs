using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public DateTime? Date { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public bool IsSlider { get; set; }
        public string? Image { get; set; }
        public int? CategoryId { get; set; }
        public Category? kategory { get; set; }
    }
}
