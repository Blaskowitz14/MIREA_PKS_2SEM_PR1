class ObjectLists
{
    public List<Student> students { get; set; }
    public List<Subject> subjects { get; set; }
    public List<Mark> marks { get; set; }

    public ObjectLists(List<Student> students, List<Subject> subjects, List<Mark> marks) {
        this.students = students;
        this.subjects = subjects;
        this.marks = marks;
    }
}

