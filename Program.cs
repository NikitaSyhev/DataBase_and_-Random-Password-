using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Final_Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // System OI - задача с файловой системой и поиском файлов по названию и краткому описанию ( псевдониму ) 
            var path = Environment.CurrentDirectory;
            Console.WriteLine(path); // вывели полный путь к файлу
            var myDoc = Environment.SpecialFolder.MyDocuments; // путь к текущей папке
          
            DirectoryInfo dir = new DirectoryInfo(path); // получили путь к каталогу, который задали
            var files = dir.EnumerateFiles(); // Возвращает перечисляемую коллекцию полных имен файлов,


            foreach (var file in files) // вывели список всех файлов
            {
                //var FullFileName = path + "\\" + file;
                FileInfo fileInfoo = new FileInfo(file.ToString());
                Console.WriteLine($"{file} {fileInfoo.LastWriteTime}");
            }



            // задача с паролем
            string tmp = "ABCD";
            int number;
            Random random = new Random();
            StringBuilder sb = new  StringBuilder();
            for(int i = 0; i < 10; i++) // создали Random 
            {
                number = random.Next(1, 100);
                Thread.Sleep(300); // вывод с задержкой

                //Структура DateTimeOffset содержит DateTime значение вместе со свойством Offset , которое определяет разницу между датой и временем текущего DateTimeOffset экземпляра и временем в формате UTC. Так как он точно определяет дату и время относительно UTC, DateTimeOffset структура не включает Kind элемент, как DateTime и структура. Он представляет даты и время со значениями, utc которых варьируется от 12:00:00 до полуночи, 1 января 0001 г. Анно Домини (общая эра), до 11:59:59:59, 31 декабря 9999 г. (C.E.).
                DateTimeOffset dto = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
                number = (number + dto.Millisecond)%100;
                sb.Append(number + " ");
                Console.WriteLine(number);
            }
            using (StreamWriter sw = new StreamWriter("output.txt", true)) // записали в файл
            {
                sw.WriteLine(sb);
            }
            using (StreamReader sr = new StreamReader("output.txt"))
            {
                
                Console.WriteLine(sr.ReadToEnd());
            }



            FileInfo fileInfo = new FileInfo(path);


            Console.ReadKey();
        }
    }
}
