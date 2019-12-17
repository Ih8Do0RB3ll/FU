﻿using System;
using System.Collections.Generic;

namespace Самолеты
{
    struct Plane               ////////////////////////
    {
        string type;
        string company;
        public string owner;

        public Plane(string _type, string _kompan, string _owner)
        {
            type    = _type;
            company = _kompan;
            owner   = _owner;
        }


        public Plane(Plane obj)
        {
            this = obj;           ///////////////////////////////
        }

        public override string ToString()
        {
            return string.Format("Тип самолета: {0}, Компания: {1}, владелец: {2}",
                type, company, owner); 
        }

    }
    class Program
    {
        static void Main()
        {
            Plane pl1 = new Plane("Ту-154", "Аэрофлот", "Владелец");
            Plane pl2 = new Plane("Ту-134", "Аэрофлот", "Арендатор");
            Plane pl3 = new Plane("Ил-96", "Сибирь", "Владелец");
            Plane pl4 = new Plane(pl1);
            Plane pl5;                //////////////////
            Plane pl6 = new Plane();   //////////////////

            List<Plane> lst = new List<Plane>();
            lst.Add(pl1);
            lst.Add(pl2);
            lst.Add(pl3);
            lst.Add(pl4);

            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].owner == "Арендатор")
                    Console.WriteLine(lst[i].ToString());
            }

            //Console.WriteLine(pl5.ToString());
            Console.WriteLine(pl6.ToString());

        }

    }
}