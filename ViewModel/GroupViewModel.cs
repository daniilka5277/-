using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variant_11.Model;

namespace Variant_11.ViewModel
{
    class GroupViewModel
    {
        public ObservableCollection<Group> ListGroup { get; set; } = new ObservableCollection<Group>();
        public GroupViewModel()
        {
            this.ListGroup.Add(new Group
            {
                ID = 1,
                SpecialityID = 1,
                QualificationID = 1,
                FormEducationID = 1,
                Faculty = "Экономический",
                Name = "Группа №25",
                Course = 1,
                CountStudent = 115,
                CountSubGroup = 5

            });

            this.ListGroup.Add(new Group
            {
                ID = 2,
                SpecialityID = 2,
                QualificationID = 2,
                FormEducationID = 2,
                Faculty = "Химия и биотехнологии",
                Name = "Группа №33",
                Course = 4,
                CountStudent = 60,
                CountSubGroup = 3

            });
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var a in this.ListGroup)
            {
                if (max < a.ID)
                {
                    max = a.ID;
                };
            }
            return max;
        }
    }
}
