using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frameworks.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Price}";
        }
    }
}
