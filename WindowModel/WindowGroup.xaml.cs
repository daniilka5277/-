using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Variant_11.Model;
using Variant_11.NewWindow;
using Variant_11.ViewModel;

namespace Variant_11.WindowModel
{
    /// <summary>
    /// Логика взаимодействия для WindowGroup.xaml
    /// </summary>
    public partial class WindowGroup : Window
    {
        private GroupViewModel vmgroup;
        private FormEducationViewModel vmformeducation;               
        private QualificationViewModel vmqual;
        private SpecialityViewModel vmspec;

        private ObservableCollection<GroupDPO> groupDPO;

        private List<FormEducation> FormeducationList;
        private List<Qualification> QualList;
        private List<Speciality> SpecList;
        public WindowGroup()
        {
            InitializeComponent();
            vmgroup = new GroupViewModel();
            vmformeducation = new FormEducationViewModel();
            vmqual = new QualificationViewModel();
            vmspec = new SpecialityViewModel();

            FormeducationList = vmformeducation.ListFormEducation.ToList();
            QualList = vmqual.ListQualification.ToList();
            SpecList = vmspec.ListSpeciality.ToList();

            groupDPO = new ObservableCollection<GroupDPO>();
            foreach (var i in vmgroup.ListGroup)
            {
                GroupDPO gr = new GroupDPO();
                gr = gr.CopyFromGroup(i);
                groupDPO.Add(gr);
            }
            WNPGroup.ItemsSource = groupDPO;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewGroup wngroup = new WindowNewGroup
            {
                Title = "Новая группа",
                Owner = this
            };
            int maxIdgroup = vmgroup.MaxId() + 1;
            GroupDPO gro = new GroupDPO
            {
                ID = maxIdgroup
            };
            wngroup.DataContext = gro;
            wngroup.WNPFormEducation.ItemsSource = FormeducationList;
            wngroup.WNPNameQualification.ItemsSource = QualList;
            wngroup.WNPSpeciality.ItemsSource = SpecList;
            if (wngroup.ShowDialog() == true)
            {
                Qualification q = (Qualification)wngroup.WNPNameQualification.SelectedValue;
                FormEducation educ = (FormEducation)wngroup.WNPFormEducation.SelectedValue;
                Speciality spec = (Speciality)wngroup.WNPSpeciality.SelectedValue;

                gro.QualificationID = q.NameQualification;
                gro.FormEducationID = educ.NameForm;
                gro.SpecialityID = spec.NameSpeciality;

                groupDPO.Add(gro);

                Group group = new Group();
                group = group.CopyFromGroupDPO(gro);
                vmgroup.ListGroup.Add(group);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            GroupDPO gr = (GroupDPO)WNPGroup.SelectedItem;
            if (gr != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные : \n" + gr.Name,
                "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    groupDPO.Remove(gr);
                    Group group = new Group();
                    group = group.CopyFromGroupDPO(gr);
                    vmgroup.ListGroup.Remove(group);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
