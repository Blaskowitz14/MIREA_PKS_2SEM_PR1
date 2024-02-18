class Student
{
    public string name { get; set; }
    public string surname { get; set; }
    public string middle_name { get; set; }
    public string code { get; set; }

    public Student(string name, string surname, string middle_name, string code) {
        this.name = name;
        this.surname = surname;
        this.middle_name = middle_name;
        this.code = code;
    }
}

