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
using BL;
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ContractWindow.xaml
    /// </summary>

    public partial class ContractWindow : Window
    {
        BE.Contract contract;
        BL.IBL bl;
        private List<string> errorMessages;
        //c-tor
        public ContractWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBl.getBl();
            option.SelectionChanged += Option_SelectionChanged;
            contract = new BE.Contract();
            this.gridContract.DataContext = contract;
            numContractComboBox.ItemsSource = null;
            this.numContractComboBox.ItemsSource = bl.getContracts();
            numContractComboBox.DisplayMemberPath = "NumContract";
            numContractComboBox.SelectedValuePath = "NumContract";
            this.idChildComboBox.ItemsSource = bl.getChildren();
            idChildComboBox.DisplayMemberPath = "idAndName";
            idChildComboBox.SelectedValuePath = "id";
            this.idNannyComboBox.ItemsSource = bl.getNannies();
            idNannyComboBox.DisplayMemberPath = "idAndName";
            idNannyComboBox.SelectedValuePath = "id";
            contract.BeginWork = DateTime.Now;
            contract.EndWork = DateTime.Now.AddYears(1);
            this.hourOrMonthComboBox.ItemsSource = Enum.GetValues(typeof(BE.EHourOrMonth));

            errorMessages = new List<string>();
        }

        //איזו פעולה המשתמש רוצה לעשות
        private void Option_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (option.SelectedIndex == 0)
            {           
                numContractComboBox.IsEnabled = false;
                idChildComboBox.IsEnabled = true;
                gridContract.IsEnabled = true;
            }
            else
            {
                if (option.SelectedIndex == 1)
                {                  
                    numContractComboBox.IsEnabled = true;
                    numContractComboBox.SelectedIndex = -1;
                    idChildComboBox.IsEnabled = false;
                    gridContract.IsEnabled = true;
                    
                }
                else
                {
                    numContractComboBox.IsEnabled = true;
                    numContractComboBox.SelectedIndex = -1;
                    gridContract.IsEnabled = false;
                }
            }
            refreshData();
        }
        //בחירת מטפלת 
        private void idNannyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (idNannyComboBox.SelectedIndex == -1)
            {
                return;
            }
            contract.IdNanny = (int)idNannyComboBox.SelectedValue;
            if (((Nanny)idNannyComboBox.SelectedItem).allowsHourlyRate)
            {
                hourOrMonthComboBox.IsEnabled = true;
            }
            else
            {
                hourOrMonthComboBox.IsEnabled = false;
                MessageBox.Show("The nanny allow only monthly payment");
                hourOrMonthComboBox.SelectedIndex = 1;
            }
        }
        //מאפס את השדות
        private void refreshData()
        {
            contract = new Contract();
            contract.BeginWork = DateTime.Now;
            contract.EndWork = DateTime.Now.AddYears(1);
            this.gridContract.DataContext = contract;
            numContractComboBox.ItemsSource = null;
            this.numContractComboBox.ItemsSource = bl.getContracts();
            idChildComboBox.SelectedIndex = -1;
            idNannyComboBox.SelectedIndex = -1;
            hourOrMonthComboBox.SelectedIndex = -1;
            BestNannies.IsEnabled = false;
            BestNannies_WithCompromise.IsEnabled = false;
            bestNanniesComboBox.IsEnabled = false;
        }
        //add contract 
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
                    bl.addContract(contract);
                    MessageBox.Show("Your contract's number is: "+ contract.NumContract);
                    refreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //update contract
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
                    bl.reContract(contract);
                    MessageBox.Show(contract.ToString(), "successfully update!", MessageBoxButton.OK, MessageBoxImage.Information);
                    refreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //remove contract
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
                bl.deleteContract(contract);
                refreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //uodate salary and age of the child
        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateDataContract(contract);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //בחירת מספר חוזה
        private void numContractComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.numContractComboBox.SelectedItem is Contract)
            {
                this.contract = ((Contract)this.numContractComboBox.SelectedItem).GetCopy();
                this.gridContract.DataContext = contract;
                idChildComboBox.SelectedItem = bl.getChildren(x => x.id == contract.IdChild).First();
                idNannyComboBox.SelectedItem = bl.getNannies(x => x.id == contract.IdNanny).First();
                if (contract.HourOrMonth)
                {
                    hourOrMonthComboBox.SelectedIndex = 0;
                }
                else
                {
                    hourOrMonthComboBox.SelectedIndex = 1;                   
                }
                BestNannies.IsEnabled = true;
                BestNannies_WithCompromise.IsEnabled = true;
                bestNanniesComboBox.IsEnabled = true;
                bestNanniesComboBox.ItemsSource = null;
                bl.updateDataContract(contract);

            }
        }

        //קריאה לחיפוש המטלפות הטובות ביותר
        private void BestNannies_Click(object sender, RoutedEventArgs e)
        {
             bestNannies(false);
        }

        //קריאה לחיפוש חמשת המטפלות הקרובות ביותר
        private void BestNannies_WithCompromise_Click(object sender, RoutedEventArgs e)
        {

            bestNannies(true);
        }

        //בחירת מטפלת מהממולצות
        private void bestNanniesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            idNannyComboBox.SelectedItem = bestNanniesComboBox.SelectedItem;
        }
        //מציאת מטפלות לפי הדרישה
        private void bestNannies(bool flag)
        {           

            try
            {
                Mother mom;
                if (option.SelectedIndex==0)
                {
                    mom = bl.getMothers(x => x.id == ((Child)idChildComboBox.SelectedItem).idMom).First();

                }
                else
                {
                    mom = bl.getMothers(x => x.id ==contract.IdMom).First();

                }
                Thread t = new Thread(() =>
                {
                    try
                    {
                        List<Nanny> v = new List<Nanny>();
                        if (!flag)
                        {
                            v = bl.nanniesByConstraints(mom).ToList();
                        }
                        else
                        {
                            v = bl.nanniesByConstraintsWithCompromise(mom).ToList();
                        }
                        Action<IEnumerable<Nanny>> a = showMatch;
                        Dispatcher.BeginInvoke(a, v);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });

                t.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //הפעלת חיפוש מטפלות והצגתן על המסך
        private void showMatch(IEnumerable<Nanny> v)
        {
            try
            {
                this.bestNanniesComboBox.ItemsSource = v;
                bestNanniesComboBox.DisplayMemberPath = "idAndName";
                bestNanniesComboBox.SelectedValuePath = "id";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //בחירת ילד
        private void idChildComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (idChildComboBox.SelectedIndex == -1)
            {
                return;
            }
            contract.IdChild = (int)idChildComboBox.SelectedValue;
            BestNannies.IsEnabled = true;
            BestNannies_WithCompromise.IsEnabled = true;
            bestNanniesComboBox.IsEnabled = true;
            bestNanniesComboBox.ItemsSource = null;

        }
    } 
}
