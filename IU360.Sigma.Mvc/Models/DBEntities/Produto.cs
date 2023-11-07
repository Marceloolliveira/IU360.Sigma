using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IU360.Sigma.Mvc.Models.DBEntities
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
