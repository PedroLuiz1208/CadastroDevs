using Cadastro_de_Devs.Devs;
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
            LinkTable();

        }

        public void LinkTable()
        {
            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = ViewModel.Desenvolvedores;
        }
        private async void Ajustar_Click(object sender, RoutedEventArgs e)
        {
            Cursor = System.Windows.Input.Cursors.Wait;
            await ViewModel.Ajustar();
            await AtualizaLista();
            Cursor = null;
        }

        private async void Incluir_Click(object sender, RoutedEventArgs e)
        {
            Cursor = System.Windows.Input.Cursors.Wait;
            await ViewModel.Incluir();
            ViewModel.Desenvolvedores.Add(ViewModel.Desenvolvedor);
            await AtualizaLista();
            Cursor = null;
        }

        private async void Alterar_Click(object sender, RoutedEventArgs e)
        {
            Cursor = System.Windows.Input.Cursors.Wait;
            await ViewModel.Alterar();
            await AtualizaLista();
            Cursor = null;
        }

        private async Task AtualizaLista()
        {
            LinkTable();
            BindingExpression binding = ListaDevs.GetBindingExpression(DataGrid.ItemsSourceProperty);
            binding.UpdateSource();
        }
        private async void BuscarDev_Click(object sender, RoutedEventArgs e)
        {
            Cursor = System.Windows.Input.Cursors.Wait;
            var t = await ViewModel.BuscarDev(NomeDev.Text);
            AtualizaDev(sender, e);
            Cursor = null;
        }

        private void SelecionaDev(object sender, MouseButtonEventArgs e)
        {
            ListaDevs.Focus();
            Cursor = System.Windows.Input.Cursors.Wait;
            var dataGrid = (DataGrid)sender;
            if (dataGrid?.Items == null || dataGrid?.Items?.Count == 0)
                return;
            var dev = (Dev)dataGrid.Items.CurrentItem;
            ViewModel.Desenvolvedor = dev;
            DevUnico.Focus();
            AtualizaDev(sender, e);
            Cursor = null;

        }

        private void AtualizaDev(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = IdDev.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateTarget();
            binding = IdDev.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateTarget();
            binding = NomeDev.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateTarget();
            binding = AvatarDev.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateTarget();
            binding = SquadDev.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateTarget();
            binding = LoginDev.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateTarget();
            binding = EmailDev.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateTarget();
            binding = DataDev.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateTarget();

        }

        private void AnyLostDocus(object sender, RoutedEventArgs e)
        {
            return;
        }

    }
}
