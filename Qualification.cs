using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_11.Model
{
    class Qualification
    {
        public int ID { get; set; }
        public string NameQualification { get; set; }

        public Qualification() { }

        public Qualification(int id, string nameQualification)
        {
            this.ID = id;
            this.NameQualification = nameQualification;
        }
        public Qualification ShallowCopy()
        {
            return (Qualification)this.MemberwiseClone();
        }
    }
}
