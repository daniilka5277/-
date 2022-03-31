# -
Разработка и сопровождение программных приложений
# -
Разработка и сопровождение программных приложений
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


__________________________________
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
____________________________
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
___________________________
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
_____________________________
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
____________________________
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
_________________________
         using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_11.Model
{
    class Qualification
    {
        public int ID { get; set; }
        public string NameQualification { get; set; }

        public Qualification() { }

        public Qualification(int id, string nameQualification)
        {
            this.ID = id;
            this.NameQualification = nameQualification;
        }
        public Qualification ShallowCopy()
        {
            return (Qualification)this.MemberwiseClone();
        }
    }
}
_____________________
                   using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_11.Model
{
    class Speciality
    {
        public int ID { get; set; }
        public string NameSpeciality { get; set; }
        public string Profile { get; set; }

        public Speciality() { }

        public Speciality(int id, string nameSpeciality, string profile)
        {
            this.ID = id;
            this.NameSpeciality = nameSpeciality;
            this.Profile = profile;
        }
        public Speciality ShallowCopy()
        {
            return (Speciality)this.MemberwiseClone();
        }
    }
}
            _______________________
                               using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

// Общие сведения об этой сборке предоставляются следующим набором
// набор атрибутов. Измените значения этих атрибутов, чтобы изменить сведения,
// связанные со сборкой.
[assembly: AssemblyTitle("Variant 11")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Variant 11")]
[assembly: AssemblyCopyright("Copyright ©  2021")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Установка значения False для параметра ComVisible делает типы в этой сборке невидимыми
// для компонентов COM. Если необходимо обратиться к типу в этой сборке через
// из модели COM, установите атрибут ComVisible для этого типа в значение true.
[assembly: ComVisible(false)]

//Чтобы начать создание локализуемых приложений, задайте
//<UICulture>CultureYouAreCodingWith</UICulture> в файле .csproj
//в <PropertyGroup>. Например, при использовании английского (США)
//в своих исходных файлах установите <UICulture> в en-US.  Затем отмените преобразование в комментарий
//атрибута NeutralResourceLanguage ниже.  Обновите "en-US" в
//строка внизу для обеспечения соответствия настройки UICulture в файле проекта.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //где расположены словари ресурсов по конкретным тематикам
                                     //(используется, если ресурс не найден на странице,
                                     // или в словарях ресурсов приложения)
    ResourceDictionaryLocation.SourceAssembly //где расположен словарь универсальных ресурсов
                                              //(используется, если ресурс не найден на странице,
                                              // в приложении или в каких-либо словарях ресурсов для конкретной темы)
)]


// Сведения о версии для сборки включают четыре следующих значения:
//
//      Основной номер версии
//      Дополнительный номер версии
//      Номер сборки
//      Номер редакции
//
// Можно задать все значения или принять номера сборки и редакции по умолчанию 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
___________________
  //------------------------------------------------------------------------------
// <auto-generated>
//     Этот код был создан программным средством.
//     Версия среды выполнения: 4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильному поведению и будут утрачены, если
//     код создан повторно.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Variant_11.Properties
{
    /// <summary>
    ///   Класс ресурсов со строгим типом для поиска локализованных строк и пр.
    /// </summary>
    // Этот класс был автоматически создан при помощи StronglyTypedResourceBuilder
    // класс с помощью таких средств, как ResGen или Visual Studio.
    // Для добавления или удаления члена измените файл .ResX, а затем перезапустите ResGen
    // с параметром /str или заново постройте свой VS-проект.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources()
        {
        }

        /// <summary>
        ///   Возврат кэшированного экземпляра ResourceManager, используемого этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if ((resourceMan == null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Variant_11.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Переопределяет свойство CurrentUICulture текущего потока для всех
        ///   подстановки ресурсов с помощью этого класса ресурсов со строгим типом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }
    }
}
_____________
  //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Variant_11.Properties
{
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {

        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }
    }
}
