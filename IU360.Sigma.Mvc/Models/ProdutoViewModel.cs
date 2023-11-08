using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IU360.Sigma.Mvc.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Price")]
        [Range(1, int.MaxValue, ErrorMessage ="Only positive number allowed")]
        public float Price { get; set; }

        [DisplayName("Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]

        public int Quantity { get; set; }

        [DisplayName("Created Date")]
        public DateTime? CreatedDate { get; set; }

    }
}
