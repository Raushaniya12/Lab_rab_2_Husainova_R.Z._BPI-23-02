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
                var parameters = new FunctionParameters();

                BaseFunction func = null;

                if (Radio1.IsChecked == true)
                {
                    parameters.A = ParseDouble(R1TextA.Text);
                    parameters.F = GetIntFromComboBox(R1CombF);
                    func = new Function1();
                }
                else if (Radio2.IsChecked == true)
                {
                    parameters.A = ParseDouble(R2TextA.Text);
                    parameters.B = ParseDouble(R2TextB.Text);
                    parameters.F = GetIntFromComboBox(R2CombF);
                    func = new Function2();
                }
                else if (Radio3.IsChecked == true)
                {
                    parameters.A = ParseDouble(R3TextA.Text);
                    parameters.B = ParseDouble(R3TextB.Text);
                    parameters.C = GetIntFromComboBox(R3CombC);
                    parameters.D = GetIntFromComboBox(R3CombD);
                    func = new Function3();
                }
                else if (Radio4.IsChecked == true)
                {
                    parameters.A = ParseDouble(R4TextA.Text);
                    parameters.C = GetIntFromComboBox(R4CombC);
                    parameters.D = (int)Math.Round(ParseDouble(R4TextD.Text));
                    func = new Function4();
                }
                else if (Radio5.IsChecked == true)
                {
                    parameters.X = ParseDouble(R5TextX.Text);
                    parameters.Y = ParseDouble(R5TextY.Text);
                    parameters.N = (int)Math.Round(ParseDouble(R5TextN.Text));
                    parameters.K = (int)Math.Round(ParseDouble(R5TextK.Text));
                    if (parameters.N < 1 || parameters.K < 1)
                        throw new ArgumentException("N и K должны быть ≥ 1");
                    func = new Function5();
                }
                else
                {
                    MessageBox.Show("Выберите одну из функций", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double result = func.Calculate(parameters);
                this.Title = "Ответ: " + result;
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Ошибка ввода: {ex.Message}\nУбедитесь, что все поля заполнены корректными числами.",
                    "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Слишком большое число", "Переполнение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Недопустимое значение", MessageBoxButton.OK, MessageBoxImage.Error);
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
            return double.TryParse(normalized, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out _);
        }
        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;
            string newText = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength).Insert(textBox.SelectionStart, e.Text);
            e.Handled = !IsValidNumberInput(newText);
        }

    }
}