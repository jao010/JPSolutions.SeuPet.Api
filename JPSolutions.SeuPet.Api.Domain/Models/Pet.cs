using System.Collections.Generic;

namespace JPSolutions.SeuPet.Api.Domain.Models
{
    public partial class Pet : Entity
    {
        public Pet()
        {
            FotosPet = new HashSet<FotosPet>();
            PetXTagPet = new HashSet<PetXTagPet>();
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public bool IsVenda { get; set; }
        public decimal? Valor { get; set; }
        public long CategoriaPetId { get; set; }
        public long UsuarioId { get; set; }

        public virtual CategoriaPet CategoriaPet { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<FotosPet> FotosPet { get; set; }
        public virtual ICollection<PetXTagPet> PetXTagPet { get; set; }
    }
}
