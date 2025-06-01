using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuessNumberWPF
{
    public partial class MainWindow : Window
    {
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                PlayGame();
            } while (AskToPlayAgain());
        }

        private void PlayGame()
        {
            int low = 1;
            int high = 2000;
            int attempts = 0;
            bool guessed = false;

            while (!guessed && low <= high)
            {
                int mid = (low + high) / 2;
                attempts++;

                // Спрашиваем у пользователя, больше или равно ли его число mid
                MessageBoxResult result = MessageBox.Show(
                    $"Ваше число больше или равно {mid}?",
                    "Угадай число",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Число >= mid
                    // Спрашиваем, равно ли число mid
                    MessageBoxResult equalResult = MessageBox.Show(
                        $"Ваше число равно {mid}?",
                        "Угадай число",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if (equalResult == MessageBoxResult.Yes)
                    {
                        // Угадали
                        guessed = true;
                        ResultText.Text = $"Число угадано за {attempts} попыток!";
                        MessageBox.Show($"Я угадал ваше число {mid} за {attempts} попыток!", "Победа", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }
                    else
                    {
                        // Число больше mid
                        low = mid + 1;
                    }
                }
                else if (result == MessageBoxResult.No)
                {
                    // Число < mid
                    high = mid - 1;
                }
                else
                {
                    // Отмена или закрытие окна - прерываем игру
                    return;
                }
            }

            if (!guessed)
            {
                // Если не удалось угадать (например, пользователь ошибся)
                ResultText.Text = $"Не удалось угадать число.";
                MessageBox.Show("Похоже, вы ошиблись или данные противоречивы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool AskToPlayAgain()
        {
            var result = MessageBox.Show("Хотите сыграть еще раз?", "Повторить игру", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}