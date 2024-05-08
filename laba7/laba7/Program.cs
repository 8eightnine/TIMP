namespace laba7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр клиента
            Client client = new Client();

            // Создаем часы со стрелками
            AnalogClock analogClock = new AnalogClock();

            // Создаем адаптер и передаем ему часы со стрелками
            IClock clock = new AnalogClockAdapter(analogClock);

            // Вводим текущее время на аналоговых часах
            Console.Write("Введите текущее время на аналоговых часах (в формате HH:MM): ");
            string currentTimeInput = Console.ReadLine();
            string[] currentTimeParts = currentTimeInput.Split(':');
            int currentHours = int.Parse(currentTimeParts[0]);
            int currentMinutes = int.Parse(currentTimeParts[1]);

            // Устанавливаем текущее время с использованием адаптера
            client.SetClockTime(clock, currentHours, currentMinutes);

            Console.WriteLine("");

            // Запрашиваем время, на которое нужно перенести часы
            Console.Write("Введите время, на которое нужно перенести часы (в формате HH:MM): ");
            string newTimeInput = Console.ReadLine();
            string[] newTimeParts = newTimeInput.Split(':');
            int newHours = int.Parse(newTimeParts[0]);
            int newMinutes = int.Parse(newTimeParts[1]);

            // Устанавливаем новое время с использованием адаптера
            client.SetClockTime(clock, newHours, newMinutes);

            Console.WriteLine("");

            // Вычисляем углы поворота стрелок от текущего времени до нового времени и выводим их
            int hourAngleDifference = Math.Abs((newHours - currentHours) * 30); // Каждый час = 30 градусов
            int minuteAngleDifference = Math.Abs((newMinutes - currentMinutes) * 6); // Каждая минута = 6 градусов

            Console.WriteLine($"Углы поворота стрелок от текущего времени до нового времени:");
            Console.WriteLine($"Разница угла часовой стрелки: {hourAngleDifference} градусов");
            Console.WriteLine($"Разница угла минутной стрелки: {minuteAngleDifference} градусов");
        }
    }
}