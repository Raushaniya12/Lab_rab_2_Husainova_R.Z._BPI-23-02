using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //double result = 0.0;

                if (Radio1.IsChecked == true)
                {
                    double a = ParseDouble(R1TextA.Text);
                    int f = GetIntFromComboBox(R1CombF);
                    //result = Function.Function1(a, f);
                    this.Title = "Ответ: " + Function.Function1(a,f);
                }
                else if (Radio2.IsChecked == true)
                {
                    double a = ParseDouble(R2TextA.Text);
                    double b = ParseDouble(R2TextB.Text);
                    int f = GetIntFromComboBox(R2CombF);
                    //result = Function.Function2(a, b, f);
                    this.Title = "Ответ: " + Function.Function2(a, b, f);
                }
                else if (Radio3.IsChecked == true)
                {
                    double a = ParseDouble(R3TextA.Text);
                    double b = ParseDouble(R3TextB.Text);
                    int c = GetIntFromComboBox(R3CombC);
                    int d = GetIntFromComboBox(R3CombD);
                    //result = Function.Function3(a, b, c, d);
                    this.Title = "Ответ: " + Function.Function3(a, b, c, d);
                }
                else if (Radio4.IsChecked == true)
                {
                    double a = ParseDouble(R4TextA.Text);
                    int c = GetIntFromComboBox(R4CombC);
                    double dVal = ParseDouble(R4TextD.Text);
                    int d = (int)Math.Round(dVal);
                    //result = Function.Function4(a, c, d);
                    this.Title = "Ответ: " + Function.Function4(a, c, d);
                }
                else if (Radio5.IsChecked == true)
                {
                    double x = ParseDouble(R5TextX.Text);
                    double y = ParseDouble(R5TextY.Text);
                    int N = (int)Math.Round(ParseDouble(R5TextN.Text));
                    int K = (int)Math.Round(ParseDouble(R5TextK.Text));

                    if (N < 1 || K < 1)
                        throw new ArgumentException("N и K должны быть ≥ 1");

                    //result = Function.Function5(x, y, N, K);
                    this.Title = "Ответ: " + Function.Function5(x, y, N, K);
                }
                else
                {
                    MessageBox.Show("Выберите одну из функций", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                //this.Title = $"Ответ:{result:F6}";

                //MessageBox.Show($"Результат: {result:F6}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Ошибка ввода: {ex.Message} Убедитесь, что все поля заполнены корректными числами", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Слишком большое число", "Переполнение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Недопустимое значение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double ParseDouble(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new FormatException("Поле не должно быть пустым");

            string trimmed = text.Trim();
            string normalized = trimmed.Replace(',', '.');

            if (double.TryParse(normalized, System.Globalization.NumberStyles.Float,
                               System.Globalization.CultureInfo.InvariantCulture, out double value))
            {
                return value;
            }

            throw new FormatException($"Не удалось распознать число: '{text}'");
        }

        private int GetIntFromComboBox(ComboBox comboBox)
        {
            if (comboBox.SelectedItem is ComboBoxItem item && item.Content != null)
            {
                string content = item.Content.ToString();
                if (int.TryParse(content, out int value))
                    return value;

                throw new FormatException($"Не удалось преобразовать '{content}' в целое число");
            }

            throw new InvalidOperationException("Выбранный элемент не является ComboBoxItem или не содержит значения");
        }

        private bool IsValidNumberInput(string text)
        {
            if (string.IsNullOrEmpty(text) || text == "-")
                return true;

            string normalized = text.Replace(',', '.');
            return double.TryParse(normalized,
                System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture,
                out _);
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            string newText = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength)
                                        .Insert(textBox.SelectionStart, e.Text);

            e.Handled = !IsValidNumberInput(newText);
        }

    }
}