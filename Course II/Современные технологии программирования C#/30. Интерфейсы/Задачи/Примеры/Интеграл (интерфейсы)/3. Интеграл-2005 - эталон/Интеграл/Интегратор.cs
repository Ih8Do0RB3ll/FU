﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Интеграл
{
    //Вычисление приближенного значения определенного интеграла
    //методом прямоугольников
    class Интегратор
    {
        double       нижний,    //Нижний  предел интегрирования
                         верхний;  //Верхний предел интегрирования
        int             отрезки;   //Количество отрезков
        object  подинтегральная; //Интерфейсная ссылка на объект, 
                                   //в котором реализована подинтегральная функция

        object первообразная;    //Интерфейсная ссылка на объект, 
                                    //в котором реализована первообразная
        public Интегратор(double нижний, double верхний, int отрезки,
            object подинтегральная, object первообразная)
        {
            this.нижний = нижний;
            this.верхний = верхний;
            this.отрезки = отрезки;
            this.подинтегральная = подинтегральная;
            this.первообразная = первообразная;
        }

        public double ВычислитьПриближенно()
        {
            if (!(подинтегральная is IФормула))
            {
                //throw new Exception("Не реализован интерфейс IФормула для подинтегральной функции!");
                MessageBox.Show("Не реализован интерфейс IФормула для подинтегральной функции!");
                return 1.0;
            }

            double шаг,        //Шаг интегрирования 
                       x,           //Текущее значение аргумента функции
                       сумма;   //Сумма значений функции в середине отрезка
            шаг = (верхний - нижний) / отрезки;
            x = нижний + шаг * 0.5;
            сумма = 0;
            for (int i = 0; i < отрезки; i++)
            {
                сумма += ((IФормула)подинтегральная).f(x); //Вызов метода через интерфейсную ссылку
                x += шаг;
            }
            return сумма * шаг;
        }

        public double ВычислитьТочно()
        {
            return ((IФормула)первообразная).f(верхний) - ((IФормула)первообразная).f(нижний); 
        }
    }
}
