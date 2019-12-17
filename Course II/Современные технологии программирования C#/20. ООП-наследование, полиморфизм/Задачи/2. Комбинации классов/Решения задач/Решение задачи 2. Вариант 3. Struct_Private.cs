﻿using System;
using System.Collections.Generic;
using System.Text;
/*
 * ПРАКТИЧЕСКОЕ ЗАНЯТИЕ 11. Задача 1.3
 * Предметная область - Авиарейсы (аналогично задаче 1.1).
 * Отличия заключаются в реализации отношения между классами.
 * Отношение агрегации реализовано на физическом уровне (композиция).
 * Поля Борт и Экипаж представляют собой полноценные объекты с заполненными
 * полями. Данная реализация моделирует ситуацию: самолеты c экипажами
 * в воздухе. Авиарейсы - справочная таблица, составленная по докладам
 * командиров экипажей в ответ на запрос авиадиспетчера.
 * ВНИМАНИЕ!!! Поля Борт и Экипаж реализованы в виде структур.
 *             Отличия в коде от исходного варианта 1.1 минимальны и сводятся
 *             к замене ключевого слова в определении понятий Самолет,
 *             Экипаж и Авиарейс. Отличия в коде от исходного варианта 1.1 
 *             отмечены  комментариями вида   //!!!!!!!!!!!!
 * ВНИМАНИЕ!!! Упрощенный вариант решения этой задачи - "3. Struct_Public.cs"
 * Упрощения: все поля открыты, свойства отсутствуют. Упрощенный
 * Вариант демонстрирует неизменность таблицы авиарейсов при изменении
 * полей исходного объекта. 
 * Упрощенный вариант рассматривается в режиме демонстрации
*/

namespace EX1_3
{
    struct Самолет   //!!!!!!!!!!!!
    {
        private int ном;  //Бортовой номер самолета
        private string тип;  //Тип самолета
        private double ост;  //Остаток ресурса
        public Самолет(int номВх, string типВх, double остВх)
        {
            ном = номВх; тип = типВх; ост = остВх;
        }
        public int Номер { get { return ном; } }
        public string Тип { get { return тип; } }
        public double Остаток { get { return ост; } }
    }

    struct Экипаж   //!!!!!!!!!!!!
    {
        private string фамКом;  //Фамилия командира экипажа
        private string фамШт;   //Фамилия штурмана
        public Экипаж(string фамКомВх, string фамШтВх)
        {
            фамКом = фамКомВх; фамШт = фамШтВх;
        }
        public string Командир { get { return фамКом; } }
        public string Штурман { get { return фамШт; } }
    }

    struct Авиарейс  //!!!!!!!!!!!!
    {
        private string рейс; //Обозначение рейса
        private Самолет сам;  //Самолет
        private Экипаж экп;  //Экипаж
        public Авиарейс(string рейсВх, Самолет самВх, Экипаж экпВх)
        {
            рейс = рейсВх;
            сам = самВх;
            экп = экпВх;
        }
        public string Рейс { get { return рейс; } }
        public Самолет Борт { get { return сам; } }
        public Экипаж ЭкипажРейса { get { return экп; } }
    }

    class Запрос
    {
        public static void Таблица(Авиарейс[] таб)
        {
            for (int i = 0; i < таб.Length; i++)
                Console.WriteLine("{0,-10}{1,-15}{2,-15}{3,-10}{4,8:d6}{5,8:f2}",
                                   таб[i].Рейс,
                                   таб[i].ЭкипажРейса.Командир,
                                   таб[i].ЭкипажРейса.Штурман,
                                   таб[i].Борт.Тип,
                                   таб[i].Борт.Номер,
                                   таб[i].Борт.Остаток);
        }

        public static void Командиры(Авиарейс[] таб, string тип)
        {
            for (int i = 0; i < таб.Length; i++)
                if (таб[i].Борт.Тип == тип)
                    Console.WriteLine("{0,-20}", таб[i].ЭкипажРейса.Командир);
        }

        public static void Номера(Авиарейс[] таб, double ост)
        {
            for (int i = 0; i < таб.Length; i++)
                if (таб[i].Борт.Остаток < ост)
                    Console.WriteLine("{0,10:d6}", таб[i].Борт.Номер);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Авиарейс[] таб;
            Самолет сам;
            Экипаж экп;
            таб = new Авиарейс[4];

            сам = new Самолет(555, "ТУ-154", 200.0);
            экп = new Экипаж("Иванов", "Петров");
            таб[0] = new Авиарейс("Б404", сам, экп);

            сам = new Самолет(333, "ИЛ-96", 500.0);
            экп = new Экипаж("Сидоров", "Климов");
            таб[1] = new Авиарейс("К685", сам, экп);

            сам = new Самолет(111, "ТУ-134", 120.0);
            экп = new Экипаж("Козлов", "Денисов");
            таб[2] = new Авиарейс("Д433", сам, экп);

            сам = new Самолет(888, "ТУ-154", 125.0);
            экп = new Экипаж("Суворов", "Смуров");
            таб[3] = new Авиарейс("Б697", сам, экп);

            Запрос.Таблица(таб);
            Console.WriteLine("Фамилии командиров экипажей на ТУ-154");
            Запрос.Командиры(таб, "ТУ-154");
            Console.WriteLine("Бортовые номера самолетов с ресурсом <150 часов");
            Запрос.Номера(таб, 150.0);
        }
    }
}
