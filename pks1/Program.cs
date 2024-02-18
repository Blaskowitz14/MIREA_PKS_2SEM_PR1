JsonLinq js = new JsonLinq("C:\\Users\\Blaskowitz\\source\\repos\\pks_sem2_pr1\\MIREA_PKS_2SEM_PR1\\pks1\\students.json");
List<ResultLinq> result = js.get_student_marks("1487D");
js.print_student_statistics(result);
js.add_mark("1487D", "1589S", 2);
List<ResultLinq> result1 = js.get_student_marks("1487D");
js.print_student_statistics(result1);