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
        private const double GigabyteInByte = 
            0.000000000931322574615478515625;

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

            Console.WriteLine();
            Console.WriteLine("Select test duration mode:");
            Console.WriteLine("1 - By number of iterations");
            Console.WriteLine("2 - By time (minutes)");
            Console.Write("Your choice: ");

            var durationChoice = Console.ReadLine();

            int? buildCount = null;
            double? durationMinutes = null;

            if (durationChoice == "1")
            {
                Console.Write("\nEnter number of builds: ");
                if (!int.TryParse(Console.ReadLine(), out int count)
                    || count <= 0)
                {
                    Console.WriteLine("Invalid number! " +
                        "Using default value: 1000");
                    buildCount = 1000;
                }
                else
                {
                    buildCount = count;
                }
            }
            else if (durationChoice == "2")
            {
                Console.Write("\nEnter test duration (minutes): ");
                if (!double.TryParse(Console.ReadLine(),
                    out double minutes) || minutes <= 0)
                {
                    Console.WriteLine("Invalid duration! Using default" +
                        " value: 5 minutes");
                    durationMinutes = 5;
                }
                else
                {
                    durationMinutes = minutes;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice! Using" +
                    " iterations mode with 1000 builds");
                buildCount = 1000;
            }

            switch (choice)
            {
                case "1":
                    RunStressTest("minimal", GetMinimalParameters(),
                        buildCount, durationMinutes);
                    break;
                case "2":
                    RunStressTest("average", GetAverageParameters(),
                        buildCount, durationMinutes);
                    break;
                case "3":
                    RunStressTest("maximal", GetMaximalParameters(),
                        buildCount, durationMinutes);
                    break;
                case "4":
                    RunStressTest("minimal", GetMinimalParameters(),
                        buildCount, durationMinutes);
                    RunStressTest("average", GetAverageParameters(),
                        buildCount, durationMinutes);
                    RunStressTest("maximal", GetMaximalParameters(),
                        buildCount, durationMinutes);
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
        /// <param name="buildCount">Количество построений (если задано)</param>
        /// <param name="durationMinutes">Длительность теста в минутах (если задано)</param>
        private static void RunStressTest(string testName,
            TableTopParameters parameters,
            int? buildCount, double? durationMinutes)
        {
            Console.WriteLine();
            Console.WriteLine($"=== Starting test: {testName} ===");
            Console.WriteLine("Parameters:");
            Console.WriteLine($"  Length: {parameters.Length.Value} mm");
            Console.WriteLine($"  Width: {parameters.Width.Value} mm");
            Console.WriteLine($"  Height: {parameters.Height.Value} mm");
            Console.WriteLine($"  Corner radius: " +
                $"{parameters.CornerRadius.Value} mm");
            Console.WriteLine($"  Chamfer radius: " +
                $"{parameters.ChamferRadius.Value} mm");
            Console.WriteLine($"  Wave amplitude: " +
                $"{parameters.WaveAmplitude.Value} mm");

            if (buildCount.HasValue)
            {
                Console.WriteLine($"  Mode: {buildCount.Value} iterations");
            }
            else if (durationMinutes.HasValue)
            {
                Console.WriteLine($"  Mode: " +
                    $"{durationMinutes.Value} minutes");
            }
            Console.WriteLine();

            var fileName =
                $"log_{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            var streamWriter = new StreamWriter(fileName);
            streamWriter.WriteLine("№\tTime (ms)\tRAM (GB)");

            var computerInfo = new ComputerInfo();
            var initialMemory = (computerInfo.TotalPhysicalMemory
                - computerInfo.AvailablePhysicalMemory)
                * GigabyteInByte;
            streamWriter.WriteLine($"0\t0\t{initialMemory:F9}");
            streamWriter.Flush();

            var builder = new TableTopBuilder();
            var stopWatch = new Stopwatch();
            var testStopwatch = new Stopwatch();
            int count = 0;

            try
            {
                testStopwatch.Start();

                if (buildCount.HasValue)
                {
                    for (count = 1; count <= buildCount.Value; count++)
                    {
                        stopWatch.Start();
                        builder.Build(parameters);
                        stopWatch.Stop();

                        builder.CloseDocument();

                        var usedMemory = (computerInfo.TotalPhysicalMemory
                            - computerInfo.AvailablePhysicalMemory)
                            * GigabyteInByte;

                        var timeMs = stopWatch.Elapsed.TotalMilliseconds;

                        streamWriter.WriteLine
                            ($"{count}\t{timeMs:F0}\t{usedMemory:F9}");
                        streamWriter.Flush();

                        if (count % 10 == 0 || count == buildCount.Value)
                        {
                            Console.Write($"\rProgress: " +
                                $"{count}/{buildCount.Value} " +
                                $"({(count * 100.0 /
                                buildCount.Value):F1}%) | "
                                + $"Time: {timeMs:F0} ms | " +
                                $"RAM: {usedMemory:F2} GB");
                        }

                        stopWatch.Reset();
                    }
                }
                else if (durationMinutes.HasValue)
                {
                    var targetDuration =
                        TimeSpan.FromMinutes(durationMinutes.Value);
                    count = 0;

                    while (testStopwatch.Elapsed < targetDuration)
                    {
                        count++;
                        stopWatch.Start();
                        builder.Build(parameters);
                        stopWatch.Stop();

                        builder.CloseDocument();

                        var usedMemory = (computerInfo.TotalPhysicalMemory
                            - computerInfo.AvailablePhysicalMemory)
                            * GigabyteInByte;

                        var timeMs = stopWatch.Elapsed.TotalMilliseconds;

                        streamWriter.WriteLine
                            ($"{count}\t{timeMs:F0}\t{usedMemory:F9}");
                        streamWriter.Flush();

                        if (count % 10 == 0)
                        {
                            var elapsed = testStopwatch.Elapsed;
                            var remaining = targetDuration - elapsed;
                            Console.Write($"\rProgress: {count} builds | " +
                                $"Elapsed: {elapsed.Minutes:D2}:" +
                                $"{elapsed.Seconds:D2} / "
                                + $"{durationMinutes.Value:F1} min | " +
                                $"Remaining: {remaining.Minutes:D2}:" +
                                $"{remaining.Seconds:D2} | " +
                                $"Time: {timeMs:F0} ms | " +
                                $"RAM: {usedMemory:F2} GB");
                        }

                        stopWatch.Reset();
                    }
                }

                testStopwatch.Stop();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                streamWriter.Close();
                streamWriter.Dispose();

                var totalTime = testStopwatch.Elapsed;
                Console.WriteLine
                    ($"\nTest finished. Models built: {count - 1}");
                Console.WriteLine($"Total time: " +
                    $"{totalTime.Minutes:D2}:{totalTime.Seconds:D2}");
                if (count > 0)
                {
                    Console.WriteLine($"Average time per build:" +
                        $" {totalTime.TotalMilliseconds / count:F0} ms");
                }
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