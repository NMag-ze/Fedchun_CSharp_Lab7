using System;

namespace Lab7_1
{
    class Person
    {
        //поля (все закрыты)
        string fam = "", status = "", health = "";
        int age = 0, salary = 0;
        //методы - свойства
        //стратегия: Read,Write-once (Чтение, запись при 
        //первом обращении)
        public string Fam
        {
            set { if (fam == "") fam = value; }
            get { return (fam); }
        }

        //стратегия: Read-only(Только чтение)
        public string Status
        {
            get { return (status); }
        }

        //стратегия: Read,Write (Чтение, запись)
        public int Age
        {
            set
            {
                age = value;
                if (age < 7) status = "ребенок";
                else if (age < 17) status = "школьник";
                else if (age < 22) status = "студент";
                else status = "служащий";
            }
            get { return (age); }
        }

        //стратегия: Write-only (Только запись)
        public int Salary
        {
            set { salary = value; }
        }
        ~Person()
        {
            
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        Person pers1 = new Person();
        pers1.Fam = "Петров";
        pers1.Age = 21;
        pers1.Salary = 1000;
        Console.WriteLine("Фам={0}, возраст={1}, статус={2}",
            pers1.Fam, pers1.Age, pers1.Status);
        pers1.Fam = "Иванов"; pers1.Age += 1;
        Console.WriteLine("Фам={0}, возраст={1}, статус={2}",
            pers1.Fam, pers1.Age, pers1.Status);
        }
    }
}
