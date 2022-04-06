using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variant_11.Model;

namespace Variant_11.ViewModel
{
    class SpecialityViewModel
    {
        public ObservableCollection<Speciality> ListSpeciality { get; set; } = new ObservableCollection<Speciality>();
        public SpecialityViewModel()
        {
            this.ListSpeciality.Add(new Speciality
            {
                ID = 1,
                NameSpeciality = "Химия",
                Profile = "Химическая технология"

            });
            this.ListSpeciality.Add(new Speciality
            {
                ID = 2,
                NameSpeciality = "Математика",
                Profile = "Прикладная математика и информатика"

            });

        }
        public int MaxId()
        {
            int max = 0;
            foreach (var l in this.ListSpeciality)
            {
                if (max < l.ID)
                {
                    max = l.ID;
                };
            }
            return max;
        }
    }
}
