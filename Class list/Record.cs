using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_list
{
    internal class Record
    {
        public Student SelectedStudent { get; set; }
        public Course SelectedCourse { get; set; }

        public override string ToString()
        {
                return $"選擇紀錄: {SelectedStudent.StudentName} / {SelectedCourse.CourseName}";
        }

        public bool Equals(Record record)
        {
            if(SelectedStudent.StudentId== record.SelectedStudent.StudentId && SelectedCourse.CourseName==record.SelectedCourse.CourseName) 
            {
                return true;
            }else 
                return false;
        }
    }
}
