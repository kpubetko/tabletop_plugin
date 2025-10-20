using Kompas6API5;
using System;
using System.Runtime.InteropServices;

namespace Table_Top_Plugin.Services
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
        public bool IsConnected = false;

        /// <summary>
        /// Подключение к КОМПАС-3D
        /// </summary>
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