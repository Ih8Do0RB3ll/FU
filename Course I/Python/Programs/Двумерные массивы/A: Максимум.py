# A: Максимум
#
# Найдите индексы первого вхождения максимального элемента.
# Выведите два числа: номер строки и номер столбца, в которых стоит наибольший элемент в двумерном массиве.
# Если таких элементов несколько, то выводится тот, у которого меньше номер строки, а если номера строк равны то тот,
# у которого меньше номер столбца.
#

data = [[0, 3, 2, 4],
        [2, 3, 5, 5],
        [5, 1, 3, 5]]

number, a, b = 0, 0, 0
for i in range(len(data)):
    for j in range(len(data[i])):
        if data[i][j] > number:
            number, a, b = data[i][j], i, j

print(a, b)