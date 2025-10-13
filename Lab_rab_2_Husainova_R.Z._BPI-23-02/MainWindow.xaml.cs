using System;
using System.Linq;
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
                BaseFunction func = null;

                if (Radio1.IsChecked == true)
                {
                    var f1 = new Function1();
                    f1.A = ParseDouble(R1TextA.Text);
                    f1.F = GetIntFromComboBox(R1CombF);
                    func = f1;
                }
                else if (Radio2.IsChecked == true)
                {
                    var f2 = new Function2();
                    f2.A = ParseDouble(R2TextA.Text);
                    f2.B = ParseDouble(R2TextB.Text);
                    f2.F = GetIntFromComboBox(R2CombF);
                    func = f2;
                }
                else if (Radio3.IsChecked == true)
                {
                    var f3 = new Function3();
                    f3.A = ParseDouble(R3TextA.Text);
                    f3.B = ParseDouble(R3TextB.Text);
                    f3.C = GetIntFromComboBox(R3CombC);
                    f3.D = GetIntFromComboBox(R3CombD);
                    func = new Function3();
                }
                else if (Radio4.IsChecked == true)
                {
                    var f4 = new Function4();
                    f4.y = ParseDouble(R4TextA.Text);
                    f4.z = GetIntFromComboBox(R4CombC);
                    f4.x = (int)Math.Round(ParseDouble(R4TextD.Text));
                    func = new Function4();
                }
                else if (Radio5.IsChecked == true)
                {
                    var f5 = new Function5();
                    f5.X = ParseDouble(R5TextX.Text);
                    f5.Y = ParseDouble(R5TextY.Text);
                    f5.N = (int)Math.Round(ParseDouble(R5TextN.Text));
                    f5.K = (int)Math.Round(ParseDouble(R5TextK.Text));
                    if (f5.N < 1 || f5.K < 1)
                        throw new ArgumentException("N и K должны быть ≥ 1");
                    func = new Function5();
                }
                else
                {
                    MessageBox.Show("Выберите одну из функций", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double result = func.Calculate();
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
        private void SwitchTheme(string themeName)
        {
            var uri = new Uri($"Themes/{themeName}.xaml", UriKind.Relative);
            var theme = new ResourceDictionary { Source = uri };

            var oldTheme = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source?.OriginalString.Contains("Theme") == true);
            if (oldTheme != null)
                Application.Current.Resources.MergedDictionaries.Remove(oldTheme);

            Application.Current.Resources.MergedDictionaries.Add(theme);
        }
        private void BtnLight_Click(object sender, RoutedEventArgs e)
        {
            SwitchTheme("LightTheme");
            BtnLight.Tag = "Active";
            BtnDark.Tag = null;
        }

        private void BtnDark_Click(object sender, RoutedEventArgs e)
        {
            SwitchTheme("DarkTheme");
            BtnDark.Tag = "Active";
            BtnLight.Tag = null;
        }
    }
}