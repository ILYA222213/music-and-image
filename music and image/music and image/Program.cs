using System.Diagnostics;

internal class Program
{
    private static async Task Main(string args)
    {
        HttpClient client = new(); // Создание экземпляра HttpClient

        Console.WriteLine("Введите ссылку для скачивания картинки: ");
        string nameWebsite = Console.ReadLine(); // Ввод пользователем ссылки для скачивания картинки

        HttpResponseMessage response = await client.GetAsync(nameWebsite); // Выполнение HTTP GET запроса для получения картинки
        byte data = await response.Content.ReadAsByteArrayAsync(); // Чтение данных картинки в виде массива байтов

        Console.WriteLine("Введите путь сохранения: ");
        string link = Console.ReadLine(); // Ввод пользователем пути для сохранения картинки
        await File.WriteAllBytesAsync(link, data); // Сохранение картинки на жесткий диск

        Process.Start(new ProcessStartInfo { FileName = link, UseShellExecute = true }); // Открытие картинки с помощью программы по умолчанию

        HttpClient client1 = new HttpClient(); // Создание нового экземпляра HttpClient

        Console.WriteLine("Введите ссылку для скачивания песни: ");
        string nameWebsite1 = Console.ReadLine(); // Ввод пользователем ссылки для скачивания песни

        HttpResponseMessage response1 = await client1.GetAsync(nameWebsite1); // Выполнение HTTP GET запроса для получения песни
        byte data1 = response1.Content.ReadAsByteArrayAsync().Result; // Чтение данных песни в виде массива байтов (используется результат синхронно)

        Console.WriteLine("Введите путь сохранения: ");
        string link1 = Console.ReadLine(); // Ввод пользователем пути для сохранения песни
        File.WriteAllBytes(link1, data1); // Сохранение песни на жесткий диск

        Process.Start(new ProcessStartInfo { FileName = link1, UseShellExecute = true }); // Открытие песни с помощью программы по умолчанию
    }
}
