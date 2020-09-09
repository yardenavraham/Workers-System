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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Mother_Click(object sender, RoutedEventArgs e)
        {
            Window mother = new MotherWindow();
            mother.Show();
        }
        private void Child_Click(object sender, RoutedEventArgs e)
        {
            Window Child = new ChildWindow();
            Child.Show();
        }
        private void Nanny_Click(object sender, RoutedEventArgs e)
        {
            Window Nanny = new NannyWindow();
            Nanny.Show();
        }
        private void Contract_Click(object sender, RoutedEventArgs e)
        {
            Window Contract = new ContractWindow();
            Contract.Show();
        }
        private void Queries_Click(object sender, RoutedEventArgs e)
        {
            Window Queries = new QueriesWindow();
            Queries.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
