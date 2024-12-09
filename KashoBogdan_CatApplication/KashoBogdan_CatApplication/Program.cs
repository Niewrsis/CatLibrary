using KashoBogdan_CatFramework;

namespace KashoBogdan_CatApplication
{
    class Program
    {
        static Cat[] GenerateRandomCats(uint count)
        {
            Cat[] cats = new Cat[count];
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                bool success = false;
                while (!success)
                {
                    try
                    {
                        int fluffiness = random.Next(-20, 121);
                        if (random.Next(2) == 0)
                        {
                            int weight = random.Next(50, 161);
                            cats[i] = new Tiger(weight, fluffiness);
                        }
                        else
                        {
                            cats[i] = new CuteCat(fluffiness);
                        }
                        success = true;
                    }
                    catch (CatException ex)
                    {
                        Console.WriteLine($"Ошибка при создании кота: {ex.Message}");
                    }
                }
            }
            return cats;
        }

        static void DisplayCatInfo(Cat[] catsArr, string path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    foreach (Cat cat in catsArr)
                    {
                        string fluffinessCheckResult = cat.FluffinessCheck();
                        string catInfo = $"{cat.ToString()}\nFluffiness Check: {fluffinessCheckResult}\n";
                        Console.WriteLine(catInfo);
                        writer.WriteLine(catInfo);
                    }
                }
                Console.WriteLine($"Информация о кошках записана в файл {path}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода при записи в файл: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите количество котов: ");
            if (!uint.TryParse(Console.ReadLine(), out uint catCount))
            {
                Console.WriteLine("Некорректное количество котов.");
                return;
            }

            Cat[] cats = GenerateRandomCats(catCount);

            Console.Write("Введите путь к файлу: ");
            string filePath = Console.ReadLine();

            DisplayCatInfo(cats, filePath);

            Console.ReadKey();
        }
    }
}