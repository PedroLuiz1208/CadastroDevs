using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cadastro_de_Devs
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    ///     
    public partial class MainWindow : Window
    {
        MainViewModel ViewModel = new MainViewModel();
        public MainWindow()
        {
            DataContext = ViewModel;

            InitializeComponent();
        }

        private void Ajustar_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.Ajustar(long);

        }

        private void AjustarSelecionados_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.Ajustar(long);

        }

        private void Incluir_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.Incluir();
        }

        private void Alterar_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.Alterar();

        }
    }
}
