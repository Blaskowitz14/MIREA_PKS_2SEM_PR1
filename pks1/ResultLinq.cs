class ResultLinq
{ 
    public string subject_name { get; set; }
    public int mark { get; set; }
    public ResultLinq (string subject_name, int mark)
    {
        this.subject_name = subject_name;
        this.mark = mark;
    }
}
