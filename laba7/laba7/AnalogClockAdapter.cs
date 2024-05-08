namespace laba7
{
    internal class AnalogClockAdapter : IClock
    {
        private AnalogClock analogClock;

        public AnalogClockAdapter(AnalogClock analogClock)
        {
            this.analogClock = analogClock;
        }

        public void SetTime(int hours, int minutes)
        {
            // Преобразуем часы и минуты в углы поворота стрелок
            int hourHandAngle = hours * 30; // В предположении, что 12 часов = 360 градусов
            int minuteHandAngle = minutes * 6; // В предположении, что 60 минут = 360 градусов

            // Вызываем метод установки позиции стрелок у часов со стрелками
            analogClock.SetHandsPosition(hourHandAngle, minuteHandAngle);
        }
    }
}