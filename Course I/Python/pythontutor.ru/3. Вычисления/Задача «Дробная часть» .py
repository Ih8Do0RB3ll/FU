#	Дано положительное действительное число X. Выведите его дробную часть.
print((lambda x: x % 1)(float(input('Введите дробное число: '))))