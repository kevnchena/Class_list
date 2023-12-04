using System.Collections.ObjectModel;

namespace Class_list
{
    class Teacher
    {
        public string TeacherName { get; set;}
        public ObservableCollection<Course> TeachingCourses { get; set;}
        public Teacher(string teacherName) 
        {
            TeacherName = teacherName;
            TeachingCourses = new ObservableCollection<Course>();
        
        }

    }
}

