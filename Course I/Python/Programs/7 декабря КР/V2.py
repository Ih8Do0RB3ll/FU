###	2 вариант
# Реализовать функцию, которая по уникальному идентификатору студента возвращает его сумму баллов по каждому из контрольных мероприятий
# result.csv имеет следующие столбцы: 	0 id - уникальный идентификатор записи,
#										1 subject - идентификатор учебного предмета, 
#										2 student_id - уникальный идентификатор студента, 
#										3 att1 - результат первой аттестации, 
#										4 att2 - результат второй аттестации, 
#										5 exam - результат экзаменнационной или зачетной работы, 
#										6 total - общий результат, 
#										7 teacher_id - уникальный идентификатор преподавателя.
										
def userSum(stud_id, par_list=('att1', 'att2', 'exam', 'total'), file_name='results.csv'):
	from csv import DictReader
	with open(file_name) as result_file:
		resultDict = {i: 0 for i in par_list}
		for line in DictReader(result_file, delimiter=';'):
			if int(line['student_id']) == stud_id:
				for i in range(len(par_list)):
					resultDict[par_list[i]] = int(resultDict[par_list[i]]) +  int(line[par_list[i]])
		return resultDict
print(userSum(180825))

#Реализовать функцию, которая принимает параметры thread - поток в виде (ПИ2018), где буквами является наименование направления, а число - год поступления, необязательный параметр test, который по умолчанию равен total (список возможных значений att1, att2, exam, total), а также необязательный параметр to_json=False. Если параметр указан, то результат выполнения функции должен записываться в файл и функция возвращает True, если такого потока не существует, то возвращает None, иначе возвращает результат функции. Результатом выполнения функции является словарь с рейтингом студентов по указанному из периодов в параметре test. Ключом словаря является место студента в рейтинге, значением - словарь с информацией из файла students.csv, а также информацию, которая возвращается после выполнения первой функции.
#Написать функцию, которая принимает имя группы, год поступления и наименование предмета. Также функция принимает необязательный параметр to_json, который по умолчанию равен False и принимает имя файла. Функция должна вернуть словарь, которая содержит оценки всех студентов данной группы по данному предмету. Ключом является id студента, значением словарь, который содержит полное имя студента и итоговый балл. Если to_json указывает имя файла, то сохранить результаты в файл и функция возвращает значение True, иначе возвращает получившийся словарь.