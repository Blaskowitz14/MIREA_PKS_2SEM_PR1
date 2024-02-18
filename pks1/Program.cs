JsonLinq js = new JsonLinq("C:\\Users\\Blaskowitz\\source\\repos\\pks1\\pks1\\students.json");
List<Mark> marks = js.get_student_marks("1487D");

foreach (Mark mark in marks) {
    Console.WriteLine(mark.mark);
}
