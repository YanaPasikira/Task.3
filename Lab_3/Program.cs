﻿using System;
using System.Collections.Generic;

// Клас Дорога
class Дорога
{
    public double Довжина { get; set; }
    public double Ширина { get; set; }
    public int КількістьСмуг { get; set; }
    public double ПоточнийРівеньТрафіку { get; set; } // Значення від 0 до 1, де 1 - максимальний трафік

    public Дорога(double довжина, double ширина, int кількістьСмуг, double поточнийРівеньТрафіку)
    {
        Довжина = довжина;
        Ширина = ширина;
        КількістьСмуг = кількістьСмуг;
        ПоточнийРівеньТрафіку = поточнийРівеньТрафіку;
    }
}

// Інтерфейс IDriveable
interface IDriveable
{
    void Рухатися();
    void Зупинитися();
}

// Клас ТранспортнийЗасіб
abstract class ТранспортнийЗасіб : IDriveable
{
    public double Швидкість { get; set; }
    public double Розмір { get; set; }
    public string Тип { get; set; } 

    public ТранспортнийЗасіб(double швидкість, double розмір, string тип)
    {
        Швидкість = швидкість;
        Розмір = розмір;
        Тип = тип;
    }

    public virtual void Рухатися()
    {
        Console.WriteLine($"{Тип} рухається зі швидкістю {Швидкість} км/год.");
    }

    public virtual void Зупинитися()
    {
        Console.WriteLine($"{Тип} зупинився.");
    }
}

// Клас Автомобіль як приклад транспортного засобу
class Автомобіль : ТранспортнийЗасіб
{
    public Автомобіль(double швидкість, double розмір) : base(швидкість, розмір, "Автомобіль") { }
}

// Клас для моделювання руху
class МоделюванняРуху
{
    private Дорога _дорога;
    private List<ТранспортнийЗасіб> _транспортніЗасоби;

    public МоделюванняРуху(Дорога дорога)
    {
        _дорога = дорога;
        _транспортніЗасоби = new List<ТранспортнийЗасіб>();
    }

    public void ДодатиТранспортнийЗасіб(ТранспортнийЗасіб транспортнийЗасіб)
    {
        _транспортніЗасоби.Add(транспортнийЗасіб);
    }

    public void ПочатиРух()
    {
        Console.WriteLine("Початок моделювання руху на дорозі...");
        foreach (var транспортнийЗасіб in _транспортніЗасоби)
        {
            if (_дорога.ПоточнийРівеньТрафіку < 0.8)
            {
                транспортнийЗасіб.Рухатися();
            }
            else
            {
                Console.WriteLine($"{транспортнийЗасіб.Тип} стоїть через затори.");
                транспортнийЗасіб.Зупинитися();
            }
        }
    }
}

// test
class Program
{
    static void Main(string[] args)
    {
        // Створення дороги
        Дорога дорога = new Дорога(5000, 10, 5, 0.6);

        // Створення транспортних засобів
        ТранспортнийЗасіб автомобіль = new Автомобіль(60, 4);

        // Моделювання руху
        МоделюванняРуху моделювання = new МоделюванняРуху(дорога);
        моделювання.ДодатиТранспортнийЗасіб(автомобіль);
        моделювання.ПочатиРух();
    }
}
