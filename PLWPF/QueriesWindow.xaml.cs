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
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for QueriesWindow.xaml
    /// </summary>
    public partial class QueriesWindow : Window
    {
        BL.IBL bl;
        bool flag=true;

        //c-tor
        public QueriesWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBl.getBl();
            idMomComboBox.ItemsSource = bl.getMothers();
            idMomComboBox.DisplayMemberPath = "idAndName";
        }

        //find children in the system without nanny
        private void ChildrenNoNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                reset();
                AllChildrenNoNanny uc = new AllChildrenNoNanny();
                uc.Source = bl.getChildrenWithoutNanny();
                this.page.Content = uc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //חיפוש המטפלות הטובות ביותר
        private void BestNannies_Click(object sender, RoutedEventArgs e)
        {
            reset();
            flag = true;
            idMomComboBox.IsEnabled = true;
            MessageBox.Show("Please choose a mother, check that the Internet is connected and wait patiently...");
        }
        //חיפוש חמשת המטפלות הקרובות 
        private void BestNannies_WithCompromise_Click(object sender, RoutedEventArgs e)
        {
            reset();
            flag = false;
            idMomComboBox.IsEnabled = true;
            MessageBox.Show("Please choose a mother");
        }
        private void showMatch(IEnumerable<Nanny> v)
        {
            try
            {
                BestNannies uc = new BestNannies();
                uc.Source = v;
                this.page.Content = uc;
                idMomComboBox.ItemsSource = bl.getMothers();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //בחירת אמא
        private void idMomComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (idMomComboBox.SelectedIndex==-1)
            {
                return;
            }
            
            try
            {
                
                Mother mom = ((Mother)idMomComboBox.SelectedItem);
                Thread t = new Thread(() =>
                  {
                      try
                      {
                          List<Nanny> v=new List<Nanny>();
                          if (flag)
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
        //החזרת כל המטפלות לפי הגיל המקסימלי או המינמלי של הילדים שהיא מקבלת 
        private void nanniesByAgeChildren_Click(object sender, RoutedEventArgs e)
        {
            reset();
            minOrMax.IsEnabled = true;
            MessageBox.Show("Please choose min or max");
        }

        //בחירת מינימום או מקסימום בשביל הצגת המטפלות
        private void minOrMax_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                bool minOrMaxBool;
                if (this.minOrMax.SelectedIndex == 0||minOrMax.SelectedIndex==2)
                {
                    minOrMaxBool = true;
                }
                else
                {
                    minOrMaxBool = false;
                }
                nanniesByAgeChildrenUserControl uc = new nanniesByAgeChildrenUserControl();
                if (this.minOrMax.SelectedIndex <=1)
                {
                    uc.Source = bl.nanniesByAgeChildren(minOrMaxBool);
                }
                else
                {
                    uc.Source = bl.nanniesByAgeChildren(minOrMaxBool, true);
                }
                this.page.Content = uc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        
        // החוזים ממוינים לפי מרחק
        private void contractByDistanceSort_Click(object sender, RoutedEventArgs e)
        {
            contractByDistance_Click(true);
        }

        //חוזרים לפי מרחק
        private void contractByDistanceNotSort_Click(object sender, RoutedEventArgs e)
        {
            contractByDistance_Click();

        }

        //הצגת החוזים לפי המרחק בין האמא למטפלת
        private void contractByDistance_Click(bool flag=false)
        {
            try
            {

                Thread t = new Thread(() =>
                {
                    try
                    {
                        List<IGrouping<int, Contract>> v = new List<IGrouping<int, Contract>>();
                        v = bl.contractsByDistance(flag).ToList();
                        Action<IEnumerable<IGrouping<int, Contract>>> a = showDistance;
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
        //הפעלת התהליכון והצגת החוזים לפי מרחק 
        private void showDistance(IEnumerable<IGrouping<int, Contract>> v)
        {
            try
            {
                contractsByDistanceUserControl uc = new contractsByDistanceUserControl();
                uc.Source = v;
                this.page.Content = uc;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //מאפס את הכפתורים
        private void reset()
        {
            page.Content = null;
            idMomComboBox.IsEnabled = false;
            minOrMax.IsEnabled = false;
            minOrMax.SelectedIndex = -1;
            idMomComboBox.SelectedIndex = -1;
        }

        
    }
}
