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
using Variant_11.ViewModel;

namespace Variant_11.WindowModel
{
    /// <summary>
    /// Логика взаимодействия для WindowFormEducation.xaml
    /// </summary>
    public partial class WindowFormEducation : Window
    {
        public WindowFormEducation()
        {
            InitializeComponent();
            FormEducationViewModel vmform = new FormEducationViewModel();
            WNPFormEducation.ItemsSource = vmform.ListFormEducation;
        }
    }
}
