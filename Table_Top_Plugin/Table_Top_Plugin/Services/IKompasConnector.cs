namespace TableTopPlugin.Services
{
    /// <summary>
    /// Интерфейс коннектора для подключения к КОМПАС-3D
    /// </summary>
    public interface IKompasConnector
    {
        /// <summary>
        /// Флаг подключения к КОМПАС-3D
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Подключение к КОМПАС-3D
        /// </summary>
        void Connect();
    }
}