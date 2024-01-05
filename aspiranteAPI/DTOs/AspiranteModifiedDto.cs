namespace aspiranteAPI.DTOs
{
    //Hacemos un DTO para modificar solo los campos que deben permitirse
    //ser modificados
    public class AspiranteModifiedDto
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public decimal Estatura { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
    }
}
