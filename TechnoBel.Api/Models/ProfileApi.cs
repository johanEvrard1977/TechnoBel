using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoBel.Api.Models
{
    public class ProfileApi
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int? UserId { get; set; }
        public int AuteurId { get; set; }
        public int? ImageId { get { return ProfileImages.FirstOrDefault()?.ImageId; } }
        public int StatutId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual UserApi User { get; set; }
        public virtual StatutApi Statut { get; set; }
        public virtual IEnumerable<Hobby_ProfileApi> Hobby_Profiles { get; set; }
        public virtual IEnumerable<ProfileTechnologieApi> ProfileTechnologies { get; set; }
        public virtual IEnumerable<Profile_ImageApi> ProfileImages { get; set; }
    }
}
