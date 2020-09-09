using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BL;
using BE;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MotherWindow.xaml
    /// </summary>
    public partial class MotherWindow : Window
    {
        BE.Mother mother;
        BL.IBL bl;
        private List<string> errorMessages;
        //constractor
        public MotherWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBl.getBl();
            option.SelectionChanged += Option_SelectionChanged;
            mother = new BE.Mother();
            this.MotherDetailsGrid.DataContext = mother;
            idComboBox.ItemsSource = null;
            this.idComboBox.ItemsSource = bl.getMothers();
            idComboBox.DisplayMemberPath = "idAndName";
            idComboBox.SelectedValuePath = "id";
            errorMessages = new List<string>();
        }
        //איזו פעולה המשתמש רוצה לעשות
        private void Option_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (option.SelectedIndex == 0)//add
            {             
                idComboBox.IsEnabled = false;
                Id.IsEnabled = true;
                MotherDetailsGrid.IsEnabled = true;

            }
            else
            {
                if (option.SelectedIndex == 1)//update
                {
                    idComboBox.IsEnabled = true;
                    Id.IsEnabled = false;
                    MotherDetailsGrid.IsEnabled = true;
                }
                else//remove
                {
                    idComboBox.IsEnabled = true;
                    Id.IsEnabled = false;
                    MotherDetailsGrid.IsEnabled = false;
                }
            }
             refreshData();
        }

        //בחירת אמא ועדכון הפרטים שלה בתצוגה
        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.idComboBox.SelectedItem is Mother)
            {
                this.mother = ((Mother)this.idComboBox.SelectedItem).getCopyMother();
                this.MotherDetailsGrid.DataContext = mother;
                start_phone.Text = mother.startPhone;
                this.sundayStart.Text = mother.neededHours[0, 0].ToString();
                this.sundayEnd.Text = mother.neededHours[1, 0].ToString();
                this.mondayStart.Text = mother.neededHours[0, 1].ToString();
                this.mondayEnd.Text = mother.neededHours[1, 1].ToString();
                this.tuesdayStart.Text = mother.neededHours[0, 2].ToString();
                this.tuesdayEnd.Text = mother.neededHours[1, 2].ToString();
                this.wednesdayStart.Text = mother.neededHours[0, 3].ToString();
                this.wednesdayEnd.Text = mother.neededHours[1, 3].ToString();
                this.thursdayStart.Text = mother.neededHours[0, 4].ToString();
                this.thursdayEnd.Text = mother.neededHours[1, 4].ToString();
                this.fridayStart.Text = mother.neededHours[0, 5].ToString();
                this.fridayEnd.Text = mother.neededHours[1, 5].ToString();
            }
        }

        //add mother
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
                    bl.addMother(mother);
                    refreshData();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //update mother
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
                    bl.reMother(mother);
                    MessageBox.Show(mother.ToString(), "successfully update!", MessageBoxButton.OK, MessageBoxImage.Information);
                    refreshData();                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //remove mother
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
                bl.deleteMother(mother);
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
            mother = new Mother();
            this.MotherDetailsGrid.DataContext = mother;
            idComboBox.ItemsSource = null;
            idComboBox.ItemsSource = bl.getMothers();

            this.start_phone.SelectedIndex = -1;
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

        //updating data who dosen't has binding data
        private void updateData()
        {
            mother.phone = int.Parse(this.start_phone.SelectionBoxItem + this.end_phone.Text);
            if (this.sunday.IsChecked.Value)
            {
                mother.neededHours[0, 0] = double.Parse(this.sundayStart.Text);
                mother.neededHours[1, 0] = double.Parse(this.sundayEnd.Text);
            }
            if (this.monday.IsChecked.Value)
            {
                mother.neededHours[0, 1] = double.Parse(this.mondayStart.Text);
                mother.neededHours[1, 1] = double.Parse(this.mondayEnd.Text);
            }
            if (this.Tuesday.IsChecked.Value)
            {
                mother.neededHours[0, 2] = double.Parse(this.tuesdayStart.Text);
                mother.neededHours[1, 2] = double.Parse(this.tuesdayEnd.Text);
            }
            if (this.Wednesday.IsChecked.Value)
            {
                mother.neededHours[0, 3] = double.Parse(this.wednesdayStart.Text);
                mother.neededHours[1, 3] = double.Parse(this.wednesdayEnd.Text);
            }
            if (this.Thursday.IsChecked.Value)
            {
                mother.neededHours[0, 4] = double.Parse(this.thursdayStart.Text);
                mother.neededHours[1, 4] = double.Parse(this.thursdayEnd.Text);
            }
            if (this.Friday.IsChecked.Value)
            {
                mother.neededHours[0, 5] = double.Parse(this.fridayStart.Text);
                mother.neededHours[1, 5] = double.Parse(this.fridayEnd.Text);
            }
        }
        //בדיקה האם קיימות שגיאות שקטות
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add(e.Error.Exception.Message);
            else
                errorMessages.Remove(e.Error.Exception.Message);

        }

        
    }
}
