# A: Равные подстроки
#
# Дана строка S=s1s2…sn (индексация символов подстроки начинается с числа 1!) и множество запросов вида (l1,r1,l2,r2).
# Для каждого такого запроса нужно ответить, равны ли подстроки sl1…sr1 и sl2…sr2.
#
# В первой строке записана строка S, состоящая из строчных латинских букв.
# Эта строка непустая и имеет длину не более 100000 символов.
# Во второй строке записано целое число q (1≤q≤100000) — количество запросов.
# В каждой из следующих q строк записаны числа l1,r1,l2,r2 (1≤l1≤r1≤|S|; 1≤l2≤r2≤|S|).
#
# Для каждого запроса выведите “+”, если соответствующие подстроки равны, и “-” в противном случае.
#

S = "abacaba"
q = 4
requests = [[1, 1, 7, 7],
            [1, 3, 5, 7],
            [3, 4, 4, 5],
            [1, 7, 1, 7]]

for item in requests:
    if S[item[0] - 1:item[1]] == S[item[2] - 1:item[3]]:
        print("+", end="", sep="")
    else:
        print("-", end="", sep="")
