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
        fileStream.Close();
        return list1;
    }
    public void json_serialize() {
        FileStream fileStream = new FileStream(file_adress, FileMode.Truncate);
        JsonSerializer.Serialize<ObjectLists>(fileStream, list);
        fileStream.Close();
    }
    public List<ResultLinq> get_student_marks(string student_code) {
        var list1 = from variable in list.marks
                         from subj in list.subjects
                         where variable.student_code == student_code
                         where variable.subject_code == subj.code
                         select new 
                         {
                             subj.title,
                             variable.mark
                         };
        List<ResultLinq> result = new List<ResultLinq>(1);
        foreach (var subj in list1)
        {
            ResultLinq obj = new ResultLinq(subj.title, subj.mark);
            result.Add(obj);
        }
        return result;
    }

    public void print_student_statistics(List<ResultLinq> list) {
        List<float> grades = new List<float>(5) { 0, 0, 0, 0, 0 };
        float total_grades_ammount = list.Count();

        foreach (ResultLinq obj in list) {
            Console.WriteLine($"Предмет: {obj.subject_name} Оценка: {obj.mark}");
            switch (obj.mark) {
                case 2:
                    grades[0]++;
                    break;
                case 3:
                    grades[1]++;
                    break;
                case 4:
                    grades[2]++;
                    break;
                case 5:
                    grades[3]++;
                    break;
            }
        }
        Console.WriteLine("Процент оценок:");
        for (int i = 0; i < 4; i++) {
            if (grades[i] > 0) {
                Console.WriteLine($"{i + 2}: {(grades[i] / total_grades_ammount) * 100}%");
            }
            else { Console.WriteLine($"{i + 2}: 0%"); }
        }
    }

    public void add_mark(string student_code, string subject_code, int mark) {
        Mark new_mark = new Mark(student_code, subject_code, mark);
        list.marks.Add(new_mark);
        json_serialize();
        json_deserialize(file_adress);
    }
}

