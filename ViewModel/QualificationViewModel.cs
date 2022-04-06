using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variant_11.Model;

namespace Variant_11.ViewModel
{
    class QualificationViewModel
    {
        public ObservableCollection<Qualification> ListQualification { get; set; } = new ObservableCollection<Qualification>();
        public QualificationViewModel()
        {
            this.ListQualification.Add(new Qualification
            {
                ID = 1,
                NameQualification = "Магистр",

            });
            this.ListQualification.Add(new Qualification
            {
                ID = 2,
                NameQualification = "Специалист",

            });

        }
        public int MaxId()
        {
            int max = 0;
            foreach (var l in this.ListQualification)
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
