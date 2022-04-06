using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variant_11.Model;

namespace Variant_11.ViewModel
{
    class FormEducationViewModel
    {
        public ObservableCollection<FormEducation> ListFormEducation { get; set; } = new ObservableCollection<FormEducation>();
        public FormEducationViewModel()
        {
            this.ListFormEducation.Add(new FormEducation
            {
                ID = 1,
                NameForm = "Очная",
                
            });
            this.ListFormEducation.Add(new FormEducation
            {
                ID = 2,
                NameForm = "Дистанционная",
               
            });
           
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var l in this.ListFormEducation)
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
