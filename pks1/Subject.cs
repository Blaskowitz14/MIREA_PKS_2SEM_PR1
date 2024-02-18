class Subject
{
    public string title { get; set; }
    public string code { get; set; }
    public string lectures_h { get; set; }
    public string practice_h { get; set; }

    public Subject(string title, string code, string lectures_h, string practice_h) { 
        this.title = title;
        this.code = code;
        this.lectures_h = lectures_h; 
        this.practice_h = practice_h;
    }
}

