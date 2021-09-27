using System;
using System.Windows;
using System.Windows.Controls;


namespace CalculadoraBasica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void CalcularButton_Click(object sender, RoutedEventArgs e)
        {
            int operando1 = int.Parse(Operando1TextBox.Text); 
            int operando2 = int.Parse(Operando2TextBox.Text);
            int resultado = default;

            switch (OperadorTextBox.Text)
            {
                case "+":
                    resultado = operando1 + operando2;
                    break;
                case "-":
                    resultado = operando1 - operando2;
                    break;
                case "*":
                    resultado = operando1 * operando2;
                    break;
                case "/":
                    resultado = operando1 / operando2;
                    break;
                default:
                    ResultadoTextBox.Text = "ERROR";
                    break;
            }
            ResultadoTextBox.Text = resultado.ToString();
        }
        public void ValidaOperador()
        {
            string[] operadores = new string[] { "-", "+", "/", "*" };
            bool esOperadorValido = false;

            try
            {
                foreach (string op in operadores)
                {
                    if (Equals(op, OperadorTextBox.Text))
                    {
                        esOperadorValido = true;
                        break;
                    }
                }
                if (esOperadorValido) CalcularButton.IsEnabled = true;
                else CalcularButton.IsEnabled = false;
            }
            catch (Exception) { CalcularButton.IsEnabled = false; }
        }

        private void OperadorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidaOperador();
        }

        private void ResultadoButton_Click(object sender, RoutedEventArgs e)
        {
            OperadorTextBox.Clear();
            Operando1TextBox.Clear();
            Operando2TextBox.Clear();
            ResultadoTextBox.Clear();
            CalcularButton.IsEnabled = false;
        }
    }
}
