#	В некоторой школе занятия начинаются в 9:00. 
#	Продолжительность урока — 45 минут, после 1-го, 3-го, 5-го и т.д. уроков перемена 5 минут, а после 2-го, 4-го, 6-го и т.д. — 15 минут.
#	Дан номер урока (число от 1 до 10). Определите, когда заканчивается указанный урок.
#	Выведите два целых числа: время окончания урока в часах и минутах.

print(*(lambda x: [(x*45 + (x//2)*5 + ((x+1)//2-1)*15)//60 + 9, (x*45 + (x//2)*5 + ((x+1)//2-1)*15)%60])(int(input('Введите номер урока: '))))