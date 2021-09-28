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
            try
            {
                double operando1 = double.Parse(Operando1TextBox.Text);
                double operando2 = double.Parse(Operando2TextBox.Text);
                double resultado = default;

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
                resultado = Math.Round(resultado, 2);
                ResultadoTextBox.Text = resultado.ToString();
            }
            catch (Exception)
            {
                CalcularButton.IsEnabled = false;
                MessageBox.Show("Se ha producido un error.\nRevise los comandos");
            }


        }
        public void ValidaOperador()
        {
            string[] operadores = new string[] { "-", "+", "/", "*" };

            foreach (string op in operadores)
            {
                if (Equals(op, OperadorTextBox.Text))
                {
                    CalcularButton.IsEnabled = true;
                    break;
                }
                else CalcularButton.IsEnabled = false;
            }

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
