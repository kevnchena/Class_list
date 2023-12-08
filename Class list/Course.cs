namespace Class_list
{
    class Course
    {
        public string CourseName { get; set; }
        public string Type { get; set; }
        public int Point { get; set; }
        public string OpeningClass { get; set; }
        public Teacher Tutor { get; set; }

        public Course(Teacher tutor) 
        { 
            Tutor = tutor;
        }

        public override string ToString()
        {
            return $"{CourseName}: {OpeningClass} {Type} {Point}學分";
        }
    }   
}
