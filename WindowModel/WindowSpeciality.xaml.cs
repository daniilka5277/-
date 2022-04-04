using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для WindowSpeciality.xaml
    /// </summary>
    public partial class WindowSpeciality : Window
    {
        SpecialityViewModel vmSpec = new SpecialityViewModel();
        public WindowSpeciality()
        {
            InitializeComponent();
            WNPSpeciality.ItemsSource = vmSpec.ListSpeciality;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewSpeciality wnspec = new WindowNewSpeciality
            {
                Title = "Новое направление подготовки",
                Owner = this
            };
            int maxIdspec = vmSpec.MaxId() + 1;
            Speciality sp = new Speciality
            {
                ID = maxIdspec
            };
            wnspec.DataContext = sp;
            if (wnspec.ShowDialog() == true)
            {
                vmSpec.ListSpeciality.Add(sp);
            }
        }

        
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewSpeciality wnspec = new WindowNewSpeciality
            {
                Title = "Редактирование",
                Owner = this
            };
            Speciality sp = WNPSpeciality.SelectedItem as Speciality;
            if (sp != null)
            {
                Speciality speciality = sp.ShallowCopy();
                wnspec.DataContext = speciality;
                if (wnspec.ShowDialog() == true)
                {
                    sp.NameSpeciality= speciality.NameSpeciality;
                    sp.Profile = speciality.Profile;


                    WNPSpeciality.ItemsSource = null;
                    WNPSpeciality.ItemsSource = vmSpec.ListSpeciality;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать поле для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Speciality Spec = (Speciality)WNPSpeciality.SelectedItem;
            if (Spec != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить " +
                Spec.NameSpeciality, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmSpec.ListSpeciality.Remove(Spec);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать поле для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
