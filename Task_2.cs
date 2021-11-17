using System;
using System.IO;

namespace Final_task_8._2
{
    class Task_2
    {
        static void Main(string[] args)
        {
            string dir_path = DirSelect();
            double dir_size = 0;
            dir_size = FolderSize(dir_path, ref dir_size);

            if (dir_size != 0)
            {
                Console.WriteLine("\nРазмер каталога {0} составляет {1} байт", dir_path, dir_size);
            }
            else
            {
                Console.WriteLine("\nКаталог {0} пуст.", dir_path);
            }
        }



        static double FolderSize(string dir_path, ref double dir_size)
        {
            DirectoryInfo di = new DirectoryInfo(dir_path);
            DirectoryInfo[] Array_di = di.GetDirectories();
            FileInfo[] fi = di.GetFiles();

            try
            {

                foreach (FileInfo f in fi)
                {
                    dir_size += f.Length;
                }

                foreach (DirectoryInfo df in Array_di)
                {
                    FolderSize(df.FullName, ref dir_size);
                }
                return (dir_size);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Возникла некоторая исключительная ситуация. Выполнение программы прервано!");
                Console.ResetColor();
                return 0;
            }
        }


        static string DirSelect()
        {
            Console.WriteLine("\nУкажите путь до каталога: ");
            string dir_path = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            if (Directory.Exists(dir_path))
                Console.WriteLine($"\nКаталог существует, он был создан: {Directory.GetCreationTime(dir_path)} \n" +
                                    $"Время последней записи в данный каталог: {Directory.GetLastWriteTime(dir_path)} \n" +
                                    $"Время последнего обращения к данному каталогу: {Directory.GetLastAccessTime(dir_path)}");
            else
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nКаталога по данному адресу не существует!\nПожалуйста, укажите путь до каталога еще раз: ");
                    Console.ResetColor();
                    dir_path = Console.ReadLine();
                }
                while (!Directory.Exists(dir_path));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nКаталог существует, он был создан: {Directory.GetCreationTime(dir_path)} \n" +
                                    $"Время последней записи в данный каталог: {Directory.GetLastWriteTime(dir_path)} \n" +
                                    $"Время последнего обращения к данному каталогу: {Directory.GetLastAccessTime(dir_path)}");
            }
            Console.ResetColor();
            return (dir_path);
        }
    }
}
