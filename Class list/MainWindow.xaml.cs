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

namespace Class_list
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        Student selectedStudent = null;

        List<Teacher> teachers = new List<Teacher>();
        Teacher selectedteacher = null;

        List<Course> courses = new List<Course>();
        Course selectedcourse = null;
        public MainWindow()
        {
            InitializeComponent();
            InitializeStudent();
            InitializeCourse();
        }

        private void InitializeCourse()
        {
            Teacher teacher1=new Teacher("陳定宏"); //先宣告teacher實例
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", Type = "選修", Point = 3, OpeningClass = "四技二甲" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", Type = "選修", Point = 3, OpeningClass = "四技二乙" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", Type = "選修", Point = 3, OpeningClass = "四技二丙" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", Type = "必修", Point = 3, OpeningClass = "五專三甲" });

            Teacher teacher2 = new Teacher("李育強");
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "計算機數學", Type = "必修", Point = 3, OpeningClass = "四技三甲" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "計算機數學", Type = "必修", Point = 3, OpeningClass = "四技三乙" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "計算機數學", Type = "必修", Point = 3, OpeningClass = "五專四甲" });

            Teacher teacher3 = new Teacher("陳福坤");
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "計算機概論", Type = "必修", Point = 3, OpeningClass = "資工一甲" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "計算機概論", Type = "必修", Point = 3, OpeningClass = "資工一乙" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "計算機概論", Type = "必修", Point = 3, OpeningClass = "資工一丙" });

            teachers.Add(teacher1);
            teachers.Add(teacher2);
            teachers.Add(teacher3);

            tvTeacher.ItemsSource= teachers; //宣告給treeview使用

            foreach (Teacher teacher in teachers) //抓teacher.TeachingCourses集中
            {
                foreach(Course course in teacher.TeachingCourses)
                {
                    courses.Add(course);
                }
            }
            lbCourse.ItemsSource= courses; //宣告給labelbox使用
        }

        private void InitializeStudent()
        {
            students.Add(new Student { StudentId = "A1234", StudentName = "你" });
            students.Add(new Student { StudentId = "A1234a", StudentName = "你1" });
            students.Add(new Student { StudentId = "A1234b", StudentName = "你2" });
            cmbStudent.ItemsSource = students;
            cmbStudent.SelectedIndex = 0;
        }

        private void cmbStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)cmbStudent.SelectedItem;
            DisplayStatus(selectedStudent.ToString());
        }

        private void DisplayStatus(string v)
        {
            lbStatus.Content = $"選取學生: {v}";
        }

        private void tvTeacher_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (tvTeacher.SelectedItem is Teacher)
            {
                selectedteacher = (Teacher)tvTeacher.SelectedItem;
                lbStatus.Content = $"選取老師: {selectedteacher.ToString()}";
            }

            if (tvTeacher.SelectedItem is Course)
            {
                selectedcourse = (Course)tvTeacher.SelectedItem;
                lbStatus.Content = $"選取課程: {selectedcourse.ToString()}";
            }

        }
    }
}
