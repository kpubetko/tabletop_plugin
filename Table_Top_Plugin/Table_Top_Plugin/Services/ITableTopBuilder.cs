using TableTopPluginModels.Models;

namespace TableTopPlugin.Services
{
    /// <summary>
    /// Интерфейс построителя столешницы в КОМПАС-3D
    /// </summary>
    public interface ITableTopBuilder
    {
        /// <summary>
        /// Построение столешницы
        /// </summary>
        /// <param name="tableTopParameters">Параметры столешницы</param>
        void Build(TableTopParameters tableTopParameters);
    }
}