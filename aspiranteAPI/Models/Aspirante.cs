using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspiranteAPI.Models
{
    [Table("Aspirantes", Schema = "aspiranteUser")]
    public class Aspirante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDAspirante { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public decimal Estatura { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
    }
}
