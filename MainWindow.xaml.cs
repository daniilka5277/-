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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Variant_11.WindowModel;

namespace Variant_11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Group_Click(object sender, RoutedEventArgs e)
        {
            WindowGroup gr = new WindowGroup();
            gr.Show();
        }

        private void Qualification_Click(object sender, RoutedEventArgs e)
        {
            WindowQualification q = new WindowQualification();
            q.Show();
        }

        private void Speciality_Click(object sender, RoutedEventArgs e)
        {
            WindowSpeciality sp = new WindowSpeciality();
            sp.Show();
        }

        private void FormEducation_Click(object sender, RoutedEventArgs e)
        {
            WindowFormEducation edu = new WindowFormEducation();
            edu.Show();
        }
    }
}
