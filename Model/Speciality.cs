using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_11.Model
{
    class Speciality
    {
        public int ID { get; set; }
        public string NameSpeciality { get; set; }
        public string Profile { get; set; }

        public Speciality() { }

        public Speciality(int id, string nameSpeciality, string profile)
        {
            this.ID = id;
            this.NameSpeciality = nameSpeciality;
            this.Profile = profile;
        }
        public Speciality ShallowCopy()
        {
            return (Speciality)this.MemberwiseClone();
        }
    }
}
