using System.Collections.Generic;

namespace JPSolutions.SeuPet.Api.Domain.ViewModels.LoginResponse
{
    public class UserTokenViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }
}
