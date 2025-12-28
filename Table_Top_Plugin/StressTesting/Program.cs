using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using TableTopPluginModels.Models;
using TableTopPlugin.Services;

namespace StressTesting
{
    /// <summary>
    /// Программа для нагрузочного тестирования плагина построения столешниц
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Коэффициент преобразования байтов в гигабайты
        /// </summary>
        private const double GigabyteInByte = 0.000000000931322574615478515625;

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args">Аргументы командной строки</param>
        static void Main(string[] args)
        {
            Console.WriteLine("=== TableTop Plugin Stress Testing ===");
            Console.WriteLine();
            Console.WriteLine("Select testing mode:");
            Console.WriteLine("1 - Minimal parameters");
            Console.WriteLine("2 - Average parameters");
            Console.WriteLine("3 - Maximum parameters");
            Console.WriteLine("4 - All three modes sequentially");
            Console.Write("Your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunStressTest("minimal", GetMinimalParameters());
                    break;
                case "2":
                    RunStressTest("average", GetAverageParameters());
                    break;
                case "3":
                    RunStressTest("maximal", GetMaximalParameters());
                    break;
                case "4":
                    RunStressTest("minimal", GetMinimalParameters());
                    RunStressTest("average", GetAverageParameters());
                    RunStressTest("maximal", GetMaximalParameters());
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    return;
            }

            Console.WriteLine();
            Console.WriteLine("Testing completed!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Выполняет нагрузочное тестирование
        /// </summary>
        /// <param name="testName">Название теста</param>
        /// <param name="parameters">Параметры столешницы</param>
        private static void RunStressTest(string testName, TableTopParameters parameters)
        {
            Console.WriteLine();
            Console.WriteLine($"=== Starting test: {testName} ===");
            Console.WriteLine("Parameters:");
            Console.WriteLine($"  Length: {parameters.Length.Value} mm");
            Console.WriteLine($"  Width: {parameters.Width.Value} mm");
            Console.WriteLine($"  Height: {parameters.Height.Value} mm");
            Console.WriteLine($"  Corner radius: {parameters.CornerRadius.Value} mm");
            Console.WriteLine($"  Chamfer radius: {parameters.ChamferRadius.Value} mm");
            Console.WriteLine($"  Wave amplitude: {parameters.WaveAmplitude.Value} mm");
            Console.WriteLine();
            Console.WriteLine("Press Ctrl+C to stop the test");
            Console.WriteLine();

            var fileName = $"log_{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            var streamWriter = new StreamWriter(fileName);
            streamWriter.WriteLine("№\tTime (ms)\tRAM (GB)");

            var builder = new TableTopBuilder();
            var stopWatch = new Stopwatch();
            var count = 0;

            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                streamWriter.Close();
                streamWriter.Dispose();
                Console.WriteLine();
                Console.WriteLine($"Test stopped. Models built: {count}");
                Console.WriteLine($"Results saved to file: {fileName}");
                Environment.Exit(0);
            };

            try
            {
                while (true)
                {
                    stopWatch.Start();
                    builder.Build(parameters);
                    stopWatch.Stop();

                    var computerInfo = new ComputerInfo();
                    var usedMemory = (computerInfo.TotalPhysicalMemory
                                      - computerInfo.AvailablePhysicalMemory)
                                     * GigabyteInByte;

                    count++;
                    var timeMs = stopWatch.Elapsed.TotalMilliseconds;

                    streamWriter.WriteLine($"{count}\t{timeMs:F0}\t{usedMemory:F9}");
                    streamWriter.Flush();

                    if (count % 100 == 0)
                    {
                        Console.WriteLine($"Models built: {count}, " +
                                          $"Time: {timeMs:F0} ms, " +
                                          $"RAM: {usedMemory:F2} GB");
                    }

                    stopWatch.Reset();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                streamWriter.Close();
                streamWriter.Dispose();
                Console.WriteLine($"Test finished. Models built: {count}");
                Console.WriteLine($"Results saved to file: {fileName}");
            }
        }

        /// <summary>
        /// Получает минимальные параметры столешницы
        /// </summary>
        /// <returns>Параметры столешницы</returns>
        private static TableTopParameters GetMinimalParameters()
        {
            var parameters = new TableTopParameters();
            parameters.Length.Value = 1000;
            parameters.Width.Value = 1000;
            parameters.Height.Value = 15;
            parameters.CornerRadius.Value = 0;
            parameters.ChamferRadius.Value = 0;
            parameters.WaveAmplitude.Value = 0;
            return parameters;
        }

        /// <summary>
        /// Получает средние параметры столешницы
        /// </summary>
        /// <returns>Параметры столешницы</returns>
        private static TableTopParameters GetAverageParameters()
        {
            var parameters = new TableTopParameters();
            parameters.Length.Value = 1750;
            parameters.Width.Value = 1750;
            parameters.Height.Value = 32;
            parameters.CornerRadius.Value = 200;
            parameters.ChamferRadius.Value = 5;
            parameters.WaveAmplitude.Value = 0;
            return parameters;
        }

        /// <summary>
        /// Получает максимальные параметры столешницы
        /// </summary>
        /// <returns>Параметры столешницы</returns>
        private static TableTopParameters GetMaximalParameters()
        {
            var parameters = new TableTopParameters();
            parameters.Length.Value = 2500;
            parameters.Width.Value = 2500;
            parameters.Height.Value = 50;
            parameters.CornerRadius.Value = 250;
            parameters.ChamferRadius.Value = 10;
            parameters.WaveAmplitude.Value = 300;
            return parameters;
        }
    }
}
