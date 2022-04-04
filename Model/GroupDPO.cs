using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variant_11.ViewModel;

namespace Variant_11.Model
{
    class GroupDPO
    {
        public int ID { get; set; }
        public string SpecialityID { get; set; }
        public string QualificationID { get; set; }
        public string FormEducationID { get; set; }
        public string Faculty { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }
        public int CountStudent { get; set; }
        public int CountSubGroup { get; set; }

        public GroupDPO() { }

        public GroupDPO(int id, string specialityID, string qualificationID, string formEducationID, string faculty, string name, int course, int countStudent, int countSubGroup)
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

        public GroupDPO CopyFromGroup(Group group)
        {
            GroupDPO DPOgroup = new GroupDPO();

            FormEducationViewModel vmform = new FormEducationViewModel();
            string FormStr = string.Empty;
            foreach (var str in vmform.ListFormEducation)
            {
                if (str.ID == group.FormEducationID)
                {
                    FormStr = str.NameForm;
                    break;
                }
            }

            QualificationViewModel vmQual = new QualificationViewModel();
            string qualstr = string.Empty;
            foreach (var qq in vmQual.ListQualification)
            {
                if (qq.ID == group.QualificationID)
                {
                    qualstr = qq.NameQualification;
                    break;
                }
            }

            SpecialityViewModel vmspec = new SpecialityViewModel();
            string specstr = string.Empty;
            foreach (var ww in vmspec.ListSpeciality)
            {
                if (ww.ID == group.SpecialityID)
                {
                    specstr = ww.NameSpeciality;
                    break;
                }
            }

            if ((FormStr != string.Empty) && (qualstr != string.Empty) && (specstr != string.Empty))
            {
                DPOgroup.ID = group.ID;
                DPOgroup.FormEducationID = FormStr;
                DPOgroup.QualificationID = qualstr;
                DPOgroup.SpecialityID = specstr;
                DPOgroup.Faculty = group.Faculty;
                DPOgroup.Name = group.Name;
                DPOgroup.Course = group.Course;
                DPOgroup.CountStudent = group.CountStudent;
                DPOgroup.CountSubGroup = group.CountSubGroup;
            }
            return DPOgroup;
        }
    }
}
