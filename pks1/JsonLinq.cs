class JsonLinq
{
    public string json_string { get; set; }
    public string file_adress { get; set; }
    ObjectLists list;

    public JsonLinq(string file_adress) {
        this.file_adress = file_adress;
        this.json_string = string.Empty;
        list = json_deserialize(this.file_adress);
    }
    public ObjectLists json_deserialize(string file_adress) {
        FileStream fileStream = new FileStream(file_adress, FileMode.Open);
        ObjectLists? list1 = JsonSerializer.Deserialize<ObjectLists>(fileStream);
        return list1;
    }
    public void json_serialize() {
        FileStream fileStream = new FileStream(file_adress, FileMode.Open);
        JsonSerializer.Serialize<ObjectLists>(fileStream, list);
    }
    public List<Mark> get_student_marks(string student_code) {
        var marks_list = from variable in list.marks
                        where variable.student_code == student_code
                        select variable;
        List<Mark> marks_list1 = marks_list.ToList();
        return marks_list1;
    }

    public void print_student_statistics(List<Mark> marks) {
        int grade_two_quantity = 0;
        int grade_three_quantity = 0;
        int grade_four_quantity = 0;
        int grade_five_quantity = 0;
        float grade_two_frequency = 0;
        float grade_three_frequency = 0;
        float grade_four_frequency = 0;
        float grade_five_frequency = 0;
        int grades_total_quantity = marks.Count();

        foreach (Mark mark in marks) {
            switch (mark.mark) {
                case 2:
                    ++grade_two_quantity;
                    break;
                case 3:
                    ++grade_three_quantity;
                    break;
                case 4:
                    ++grade_four_quantity;
                    break;
                case 5:
                    ++grade_five_quantity;
                    break;

            }
        }

        grade_two_frequency = grade_two_quantity / grades_total_quantity;
        grade_three_frequency = grade_three_quantity / grades_total_quantity;
        grade_four_frequency = grade_four_quantity / grades_total_quantity;
        grade_five_frequency = grade_five_quantity / grades_total_quantity;

        Console.WriteLine($"Количество оценок 5: {grade_five_quantity} \nКоличестов оценок 4: {grade_four_quantity} \nКоличество оценок 3: {grade_three_quantity} \nКоличество оценок 2: {grade_two_quantity}");
        Console.WriteLine(&"")



    }

    public void add_mark(string student_code, string subject_code, int mark) {
        Mark new_mark = new Mark(student_code, subject_code, mark);
        list.marks.Add(new_mark);
        json_serialize();
    }
}

