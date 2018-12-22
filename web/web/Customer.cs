
using System.ComponentModel.DataAnnotations;

namespace web
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}