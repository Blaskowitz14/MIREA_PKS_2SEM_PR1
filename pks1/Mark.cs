class Mark
{
    public string student_code {  get; set; }
    public string subject_code { get; set; }
    public int mark { get; set; }

    public Mark(string student_code, string subject_code, int mark ) {
        this.student_code = student_code;
        this.subject_code = subject_code;
        this.mark = mark;
    }
}

