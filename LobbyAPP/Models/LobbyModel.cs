using System.ComponentModel.DataAnnotations;

namespace LobbyAPP.Models
{
    public class LobbyModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome da quadra")]
        public string Quadra { get; set; }
        [Required(ErrorMessage = "Digite o endereço da quadra")]
        public string Endereco{ get; set; }
        [Required(ErrorMessage = "Digite as modalidades da quadra") ]
        public string Modalidades { get; set; }

    }
}
