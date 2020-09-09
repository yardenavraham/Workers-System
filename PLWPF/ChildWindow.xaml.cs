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
using System.Windows.Shapes;
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        BE.Child child;
        BL.IBL bl;
        private List<string> errorMessages;
        //constractor
        public ChildWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBl.getBl();
            option.SelectionChanged += Option_SelectionChanged;
            child = new BE.Child();
            this.gridChild.DataContext = child;
            idComboBox.ItemsSource = null;
            this.idComboBox.ItemsSource = bl.getChildren();
            idComboBox.DisplayMemberPath = "idAndName";
            idComboBox.SelectedValuePath = "id";
            this.idMomComboBox.ItemsSource = bl.getMothers();
            idMomComboBox.DisplayMemberPath = "idAndName";
            idMomComboBox.SelectedValuePath = "id";
            child.bDay = DateTime.Now.AddYears(-1);
            errorMessages = new List<string>();
        }

        private void Option_SelectionChanged(object sender, SelectionChangedEventArgs e)//What action the user wants to do
        {
            if (option.SelectedIndex == 0)//add     
            {
                idComboBox.IsEnabled = false;
                idTextBox.IsEnabled = true;
                gridChild.IsEnabled = true;

            }
            else
            {
                if (option.SelectedIndex == 1)//update
                {
                    idComboBox.IsEnabled = true;
                    idTextBox.IsEnabled = false;
                    gridChild.IsEnabled = true;
                }
                else//remove
                {
                    idComboBox.IsEnabled = true;
                    idTextBox.IsEnabled = false;
                    gridChild.IsEnabled = false;
                }
            }

            refreshData();
        }
        //בחירת ילד ועדכון הפרטים שלו בתצוגה
        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.idComboBox.SelectedItem is Child)
            {
                this.child = ((Child)this.idComboBox.SelectedItem).GetCopy();
                this.gridChild.DataContext = child;
                idMomComboBox.SelectedItem = bl.getMothers(x => x.id == child.idMom).First() ;
                
            }
        }

        //add child
        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (errorMessages.Any()) //errorMessages.Count > 0 
                {
                    string err = "Exception:";
                    foreach (var item in errorMessages)
                        err += "\n" + item;

                    MessageBox.Show(err);
                    return;
                }

                else
                {
                    //updateData();
                    bl.addChild(child);
                    refreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //update child
        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (errorMessages.Any()) //errorMessages.Count > 0 
                {
                    string err = "Exception:";
                    foreach (var item in errorMessages)
                        err += "\n" + item;

                    MessageBox.Show(err);
                    return;
                }
                else
                {
                    bl.reChild(child);
                    MessageBox.Show(child.ToString(), "successfully update!", MessageBoxButton.OK, MessageBoxImage.Information);
                    refreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //remove child
        private void remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (errorMessages.Any()) //errorMessages.Count > 0 
                {
                    string err = "Exception:";
                    foreach (var item in errorMessages)
                        err += "\n" + item;

                    MessageBox.Show(err);
                    return;
                }
                bl.deleteChild(child);
                refreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //מאפס את הנתונים בתצוגה
        private void refreshData()
        {
            child = new Child();
            child.bDay = DateTime.Now.AddYears(-1);
            this.gridChild.DataContext = child;
            idComboBox.ItemsSource = null;
            idComboBox.ItemsSource = bl.getChildren();
            idComboBox.SelectedIndex = -1;
            idMomComboBox.SelectedIndex = -1;
        }

        //תפיסת שגיאות שקטות
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add(e.Error.Exception.Message);
            else
                errorMessages.Remove(e.Error.Exception.Message);

        }
        //בחירת אמא
        private void idMomComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (idMomComboBox.SelectedIndex==-1)
            {
                return;
            }
            child.idMom = (int)idMomComboBox.SelectedValue;
        }
    }
}
