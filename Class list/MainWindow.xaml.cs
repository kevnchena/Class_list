using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        Course selectedCourse = null;

        List<Record> records = new List<Record>();
        Record selectedRecord = null; 

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

            ////為了給tree view.ItemSource 使用的前置作業
            tvTeacher.ItemsSource= teachers;

            foreach (Teacher teacher in teachers) //抓teacher.TeachingCourses集中
            {
                foreach(Course course in teacher.TeachingCourses)
                {
                    courses.Add(course);
                }
            }
            lbCourse.ItemsSource= courses;
            /////////////////////////////////////////
        }

        private void InitializeStudent()
        {
            students.Add(new Student { StudentId = "A1G348", StudentName = "陳曉明" });
            students.Add(new Student { StudentId = "A1F599", StudentName = "王大偉" });
            students.Add(new Student { StudentId = "A1S400", StudentName = "李忠盧" });
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
                selectedCourse = (Course)tvTeacher.SelectedItem;
                lbStatus.Content = $"選取課程: {selectedCourse.ToString()}";
            }

        }

        private void lbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCourse = (Course)tvTeacher.SelectedItem;
            lbStatus.Content = $"選取課程: {selectedCourse.ToString()}";
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
               if(selectedStudent==null || selectedCourse == null)
            {
                MessageBox.Show("請選取學生或課程");
                return;
            }
            else
            {
                Record newRecord = new Record
                {
                    SelectedCourse = selectedCourse,
                    SelectedStudent = selectedStudent,
                };

                foreach(Record r in records)
                {
                    if (r.Equals(newRecord))
                    {
                        MessageBox.Show($"{selectedStudent.StudentName}已經選過\n{selectedCourse.CourseName}課程");
                        return;
                    }
                }

                records.Add(newRecord);
                lvRecord.ItemsSource = records;
                lvRecord.Items.Refresh();
            }

        }

        private void lvRecord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRecord = (Record)lvRecord.SelectedItem;
            if (selectedRecord == null)return;
            lbStatus.Content = $"{selectedRecord.ToString()}";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecord != null)
            {
                records.Remove(selectedRecord);
                lvRecord.ItemsSource = records;
                lvRecord.Items.Refresh();

            }
            else
            {
                MessageBox.Show("請選擇要刪除的紀錄");
                return;
            }
        }

        private void saveRecord_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json Files(*.jaon)|*.txt|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string json = JsonSerializer.Serialize(records);
                File.WriteAllText(saveFileDialog.FileName,json);
            }
        
        }
    }
}
