using Caliburn.Micro;
using HydroAcousticApp_1.ViewModels.Signals;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using LiveCharts;
using LiveCharts.Wpf;

namespace HydroAcousticApp_1.Converters
{
    class SignalViewModelToLineSeries : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Этот конвертер рассчитан на то, чтобы преобразовать не элементы, а коллекцию элементов.
            // Хотя элементы тоже нужно преобразовать.
            // Но сначала коллекции. Проверяем что входное значение и ожидаемый тип соответствуют:
            if(value is IObservableCollection<BaseSignalViewModel> signals && targetType == typeof(SeriesCollection))
            {
                // Создаём экземляр коллекции, которую нужно вернуть в качестве результата конверсии
                var result = new SeriesCollection();
                // Собственно конверсия
                foreach (var signal in signals)
                {
                    result.Add(ConvertSignal(signal));
                }
                // Но поскольку коллекции могут динамически меняться, то нужно уметь обрабатывать и это,
                // чтобы новые или удалённые элементы автоматически добавлялись/удалялись из представления.
                //
                // Важный нюанс - этот анонимный метод использует переменную result, значение которой задаётся снаружи метода.
                // Нужно ВСЕГДА понимать и помнить, что такое захваченные переменные и обращать на них внимание.
                // Захваченная переменная захватывается только один, в момент её определения.
                // Если бы этот обработчик присваивался в цикле несколько раз с разными значениями result,
                // то внутри всех этих обработчиков значение result будет одинаковым, а именно там будет значение, которое было в последней итерации цикла.
                // Здесь цикла нет, при каждом вызове Convert() захват переменной производится заново, поэтому здесь всё хорошо.
                // Но в целом важно с самого начала всегда помнить об этой особенности захваченных переменных.
                // Подробнее: https://medium.com/@unicorn_dev/how-to-capture-a-variable-in-c-and-not-to-shoot-yourself-in-the-foot-d169aa161aa6
                signals.CollectionChanged += (sender, args) =>
                {
                    // Удаляем из представления элементы, которые удалились.
                    if (args.OldItems != null)
                        foreach (var signal in args.OldItems.OfType<BaseSignalViewModel>())
                            result.Remove(result.OfType<LineSeries>().FirstOrDefault(x => x.Tag == signal));
                    // Добавляем добавленные элементы.
                    if (args.NewItems != null)
                        foreach (var signal in args.NewItems.OfType<BaseSignalViewModel>())
                            result.Add(ConvertSignal(signal));
                };
                return result;
            }
            return null;
        }

        // Нам нужно в итоге получить из коллекции BaseSignalViewModel коллекцию LineSeries.
        // Но это происходит в двух местах - при вызове Convert и при изменении коллекции BaseSignalViewModel, в обработчике (анонимном методе).
        // Так что чтобы не писать преобразование два раза, лучше вынести его в отдельный метод:
        private LineSeries ConvertSignal(BaseSignalViewModel signal)
        {
            var series = new LineSeries();
            series.Values = signal.SignalPoints;
            // Чтобы потом можно было понять какой LineSeries соответствует какой BaseSignalViewModel, запоминаем вью-модель в поле Tag:
            series.Tag = signal;
            return series;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
