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
    /// Логика взаимодействия для WindowQualification.xaml
    /// </summary>
    public partial class WindowQualification : Window
    {
        QualificationViewModel vmQual = new QualificationViewModel();
        public WindowQualification()
        {
            InitializeComponent();
            WNPQualification.ItemsSource = vmQual.ListQualification;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewQualification wnqual = new WindowNewQualification
            {
                Title = "Новая квалификация",
                Owner = this
            };
            int maxIdqual = vmQual.MaxId() + 1;
            Qualification qualification = new Qualification
            {
                ID = maxIdqual
            };
            wnqual.DataContext = qualification;
            if (wnqual.ShowDialog() == true)
            {
                vmQual.ListQualification.Add(qualification);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Qualification qual = (Qualification)WNPQualification.SelectedItem;
            if (qual != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить " +
                qual.NameQualification, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmQual.ListQualification.Remove(qual);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать поле для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewQualification wnqual = new WindowNewQualification
            {
                Title = "Редактирование",
                Owner = this
            };
            Qualification qualification = WNPQualification.SelectedItem as Qualification;
            if (qualification != null)
            {
                Qualification qqq = qualification.ShallowCopy();
                wnqual.DataContext = qqq;
                if (wnqual.ShowDialog() == true)
                {
                    qualification.NameQualification = qqq.NameQualification;
                    

                    WNPQualification.ItemsSource = null;
                    WNPQualification.ItemsSource = vmQual.ListQualification;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать поле для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
