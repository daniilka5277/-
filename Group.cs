using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variant_11.ViewModel;

namespace Variant_11.Model
{
    class Group
    {
        public int ID { get; set; }
        public int SpecialityID { get; set; }
        public int QualificationID { get; set; }
        public int FormEducationID { get; set; }
        public string Faculty { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }
        public int CountStudent { get; set; }
        public int CountSubGroup { get; set; }

        public Group() { }

        public Group(int id, int specialityID, int qualificationID, int formEducationID, string faculty, string name, int course, int countStudent, int countSubGroup)
        {
            this.ID = id;
            this.SpecialityID = specialityID;
            this.QualificationID = qualificationID;
            this.FormEducationID = formEducationID;
            this.Faculty = faculty;
            this.Name = name;
            this.Course = course;
            this.CountStudent = countStudent;
            this.CountSubGroup = countSubGroup;
        }

        public Group CopyFromGroupDPO(GroupDPO groupdpo)
        {
            FormEducationViewModel vmform = new FormEducationViewModel();
            int Formid = 0;
            foreach (var it in vmform.ListFormEducation)
            {
                if (it.NameForm == groupdpo.FormEducationID)
                {
                    Formid = it.ID;
                    break;
                }
            }

            QualificationViewModel vmQual = new QualificationViewModel();
            int qualid = 0;
            foreach (var qq in vmQual.ListQualification)
            {
                if (qq.NameQualification == groupdpo.QualificationID)
                {
                    qualid = qq.ID;
                    break;
                }
            }

            SpecialityViewModel vmspec = new SpecialityViewModel();
            int specid = 0;
            foreach (var ww in vmspec.ListSpeciality)
            {
                if (ww.NameSpeciality == groupdpo.SpecialityID)
                {
                    specid = ww.ID;
                    break;
                }
            }

            if ((Formid != 0) && (qualid != 0) && (specid != 0))
            {
                this.ID = groupdpo.ID;
                this.FormEducationID = Formid;
                this.QualificationID = qualid;
                this.SpecialityID = specid;
                this.Faculty = groupdpo.Faculty;
                this.Name = groupdpo.Name;
                this.Course = groupdpo.Course;
                this.CountStudent = groupdpo.CountStudent;
                this.CountSubGroup = groupdpo.CountSubGroup;
            }
            return this;
        }

    }
}
