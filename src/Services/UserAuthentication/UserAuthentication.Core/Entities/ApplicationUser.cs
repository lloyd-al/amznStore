using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace amznStore.Services.UserAuthentication.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        // Returns true if the specified refresh token belongs to the account.
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }

        public ICollection<UserAddress> UserAddresses { get; set; }
        public ICollection<UserPaymentCard> UserPaymentCards { get; set; }

    }
}
