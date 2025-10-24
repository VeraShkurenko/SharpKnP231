using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKnP231.Library
{
    public class Library
    {
        private List<Literature> Funds { get; set; } = [];

        public Library()
        {
            Funds.Add(new Book()
            {
                Author = "D. Knuth",
                Title = "The art of programming",
                Publisher = "Київ, Наукова Думка",
                Year = 2000
            });
            Funds.Add(new Book()
            {
                Author = "J. Richter",
                Title = "CLR via C#",
                Publisher = "Microsoft Press",
                Year = 2013
            });
            Funds.Add(new Journal()
            {
                Title = "ArgC & ArgV",
                Number = "2(113), 2000",
                Publisher = "https://journals.ua/technology/argc-argv/"
            });
            Funds.Add(new Newspaper()
            {
                Title = "Gazette de Leopol",
                Publisher = "First Ukrainian press in Ukraine",
                Date = new DateOnly(1776, 1, 15)
            });
            Funds.Add(new Booklet()
            {
                Title = "Безпечний інтернет для дітей",
                Publisher = "ГО «Центр цифрової грамотності»",
                Year = 2024,
                Organization = "Міністерство освіти і науки України"
            });
            Funds.Add(new Newspaper
            {
                Title="Урядовий кур'єр",
                Date= new DateOnly(2025,10,23), // як діє оператор new на структури
                // оскільки структура - ValueType, то значення змінюється в області
                // змінної шляхом перезапуску конструктора структури
                Publisher="Газета Кабінету Міністрів України"
            });
            Funds.Add(new Hologram
            {
                Title = "Скіфське мистецтво",
                ArtItem = "Пектораль",
                Publisher = "Студія 'Лазер'"
            });
        }

        public void PrintCatalog()
        {
            foreach (Literature literature in Funds)
            {
                Console.WriteLine(literature.GetCard());
            }
        }
        public void PrintPeriodic()
        {
            foreach (Literature literature in Funds)
            {
                if (literature is IPeriodic lit)
                {
                    // Прямо через literature метод GetPeriod не доступний
                    // (хоча ми певні, що він там є, бо умова "IPeriodic" виконана)
                    // Для доступу до методу інтерфейсу необхідно перетворити
                    // тип змінної до інтерфейсного
                    // literature as IPeriodic -- референсе (мяке) перетворення
                    // (IPeriodic) literature -- "жорстке" перетворення 
                    // pattern matching 
                    Console.Write("Раз у " + lit.GetPeriod() + ": ");
                    Console.WriteLine(literature.GetCard());
                }
                
            }
        }
        public void PrintNonPeriodic()
        {
            foreach (Literature literature in Funds)
            {
                if (literature is not IPeriodic)
                {
                        Console.WriteLine(literature.GetCard());
                }
            
            }
        }
    }
}
/*
 * [] - оперативна память
 * () - програма (збірка)
 * {} - постійна память (диск, BIOS)
 *
 *
 * Запуск                    Value Type                Refference Type
 * {(program), ...}          { (32bot), ...}           { (*64bot), ...}
 *       |
 *       v                      x = 10                    x = new ()
 * [ (program), ... ]        [ (10), ... ]             [ (addr), ... (obj#addr)]
 *                                                          \__________/
 *                            x = new(20)?
 *                          перезапуск конструктора
 *                          без створення додаткових обєктів
 *                          [ (20), ... ]
 */