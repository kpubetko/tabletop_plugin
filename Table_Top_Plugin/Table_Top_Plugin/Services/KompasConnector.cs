using Kompas6API5;

namespace TableTopPlugin.Services
{
    /// <summary>
    /// Коннектор для подключения к КОМПАС-3D
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Объект КОМПАС-3D
        /// </summary>
        public KompasObject Kompas { get; private set; }

        /// <summary>
        /// Флаг подключения к КОМПАС-3D
        /// </summary>
        public bool IsConnected { get; private set; } = false;

        /// <summary>
        /// Подключение к КОМПАС-3D
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Возникает при невозможности создания экземпляра КОМПАС-3D
        /// </exception>
        /// <remarks>
        /// Метод пытается создать экземпляр КОМПАС-3D через COM-интерфейс.
        /// При успешном подключении делает приложение видимым.
        /// </remarks>
        public void Connect()
        {
            if (IsConnected) return;

            try
            {
                Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                Kompas = (KompasObject)Activator.CreateInstance(type);
                Kompas.Visible = true;
                IsConnected = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Ошибка подключения: {ex.Message}");
                IsConnected = false;
                throw;
            }
        }
    }
}