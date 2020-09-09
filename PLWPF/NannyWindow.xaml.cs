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
using BE;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for NannyWindow.xaml
    /// </summary>
    public partial class NannyWindow : Window
    {
        BE.Nanny nanny;
        BL.IBL bl;
        private List<string> errorMessages;

        //constractor
        public NannyWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBl.getBl();
            option.SelectionChanged += Option_SelectionChanged;
            nanny = new BE.Nanny();
            nanny.bDay = DateTime.Now.AddYears(-40);
            this.NannyGrid.DataContext = nanny;
            this.idComboBox.ItemsSource = null;
            this.idComboBox.ItemsSource = bl.getNannies();
            idComboBox.DisplayMemberPath = "idAndName";
            idComboBox.SelectedValuePath = "id";
            this.daysOffPropComboBox.ItemsSource = Enum.GetValues(typeof(BE.DaysOff));
            errorMessages = new List<string>();
        }

        //איזו פעולה המשתמש רוצה לעשות 
        private void Option_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (option.SelectedIndex == 0)//add
            {
                idComboBox.IsEnabled = false;
                idTextBox.IsEnabled = true;
                NannyGrid.IsEnabled = true;

            }
            else
            {
                if (option.SelectedIndex == 1)//update
                {
                    idComboBox.IsEnabled = true;
                    idTextBox.IsEnabled = false;
                    NannyGrid.IsEnabled = true;
                }
                else//remove
                {
                    idComboBox.IsEnabled = true;
                    idTextBox.IsEnabled = false;
                    NannyGrid.IsEnabled = false;
                }
            }
            
            refreshData();
        }


        //בחירת מטפלתת ועידכון הפרטים בתצוגה
        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.idComboBox.SelectedItem is Nanny)
            {
                this.nanny = ((Nanny)this.idComboBox.SelectedItem).getCopyNanny();
                this.NannyGrid.DataContext = nanny;
                this.sundayStart.Text = nanny.hoursOfWork[0, 0].ToString();
                this.sundayEnd.Text = nanny.hoursOfWork[1, 0].ToString();
                this.mondayStart.Text = nanny.hoursOfWork[0, 1].ToString();
                this.mondayEnd.Text = nanny.hoursOfWork[1, 1].ToString();
                this.tuesdayStart.Text = nanny.hoursOfWork[0, 2].ToString();
                this.tuesdayEnd.Text = nanny.hoursOfWork[1, 2].ToString();
                this.wednesdayStart.Text = nanny.hoursOfWork[0, 3].ToString();
                this.wednesdayEnd.Text = nanny.hoursOfWork[1, 3].ToString();
                this.thursdayStart.Text = nanny.hoursOfWork[0, 4].ToString();
                this.thursdayEnd.Text = nanny.hoursOfWork[1, 4].ToString();
                this.fridayStart.Text = nanny.hoursOfWork[0, 5].ToString();
                this.fridayEnd.Text = nanny.hoursOfWork[1, 5].ToString();
            }
        }

        
        //add nanny
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
                    updateData();
                    bl.addNanny(nanny);
                    refreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //update nanny
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
                    updateData();
                    bl.reNanny(nanny);
                    MessageBox.Show(nanny.ToString(), "successfully update!", MessageBoxButton.OK, MessageBoxImage.Information);
                    refreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //remove nanny
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
                bl.deleteNanny(nanny);
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
            nanny = new Nanny();
            nanny.bDay = DateTime.Now.AddYears(-40);
            this.NannyGrid.DataContext = nanny;
            idComboBox.ItemsSource = null;
            idComboBox.ItemsSource = bl.getNannies();
            daysOffPropComboBox.SelectedIndex = -1;

            this.sundayStart.ClearValue(TextBox.TextProperty);
            this.sundayEnd.ClearValue(TextBox.TextProperty);
            this.mondayStart.ClearValue(TextBox.TextProperty);
            this.mondayEnd.ClearValue(TextBox.TextProperty);
            this.tuesdayStart.ClearValue(TextBox.TextProperty);
            this.tuesdayEnd.ClearValue(TextBox.TextProperty);
            this.wednesdayStart.ClearValue(TextBox.TextProperty);
            this.wednesdayEnd.ClearValue(TextBox.TextProperty);
            this.thursdayStart.ClearValue(TextBox.TextProperty);
            this.thursdayEnd.ClearValue(TextBox.TextProperty);
            this.fridayStart.ClearValue(TextBox.TextProperty);
            this.fridayEnd.ClearValue(TextBox.TextProperty);
        }

        //updating data without binding data
        private void updateData()
        {
            if (this.sunday.IsChecked.Value)
            {
                nanny.hoursOfWork[0, 0] = double.Parse(this.sundayStart.Text);
                nanny.hoursOfWork[1, 0] = double.Parse(this.sundayEnd.Text);
            }
            if (this.monday.IsChecked.Value)
            {
                nanny.hoursOfWork[0, 1] = double.Parse(this.mondayStart.Text);
                nanny.hoursOfWork[1, 1] = double.Parse(this.mondayEnd.Text);
            }
            if (this.tuesday.IsChecked.Value)
            {
                nanny.hoursOfWork[0, 2] = double.Parse(this.tuesdayStart.Text);
                nanny.hoursOfWork[1, 2] = double.Parse(this.tuesdayEnd.Text);
            }
            if (this.wednesday.IsChecked.Value)
            {
                nanny.hoursOfWork[0, 3] = double.Parse(this.wednesdayStart.Text);
                nanny.hoursOfWork[1, 3] = double.Parse(this.wednesdayEnd.Text);
            }
            if (this.thursday.IsChecked.Value)
            {
                nanny.hoursOfWork[0, 4] = double.Parse(this.thursdayStart.Text);
                nanny.hoursOfWork[1, 4] = double.Parse(this.thursdayEnd.Text);
            }
            if (this.friday.IsChecked.Value)
            {
                nanny.hoursOfWork[0, 5] = double.Parse(this.fridayStart.Text);
                nanny.hoursOfWork[1, 5] = double.Parse(this.fridayEnd.Text);
            }
        }
        //תפיסת שגיאות שקטות 
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add(e.Error.Exception.Message);
            else
                errorMessages.Remove(e.Error.Exception.Message);

        }
    }
 
}
