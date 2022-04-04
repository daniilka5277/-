using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_11.Model
{
    class FormEducation
    {
        public int ID { get; set; }
        public string NameForm { get; set; }

        public FormEducation() { }

        public FormEducation(int id, string nameForm)
        {
            this.ID = id;
            this.NameForm = nameForm;
        }
    }
}
