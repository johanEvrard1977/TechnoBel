using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBel.Dal.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public int AuteurId { get; set; }
        public int? ImageId { get { return ProfileImages.FirstOrDefault()?.ImageId; } }
        public int StatutId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual User User { get; set; }
        public virtual Statut Statut { get; set; }
        public virtual IEnumerable<Hobby_Profile> Hobby_Profiles { get; set; }
        public virtual IEnumerable<Profile_Image> ProfileImages { get; set; }
        public virtual IEnumerable<ProfileTechnologie> ProfileTechnologies { get; set; }
    }
}
