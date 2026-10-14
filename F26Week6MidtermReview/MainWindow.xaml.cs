using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace F26Week6MidtermReview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> _employees;

        public MainWindow()
        {
            InitializeComponent();
            GenerateEmployeeData();
        }

        private void GenerateEmployeeData()
        {
            _employees = new List<Employee>()
            {
                // hourly emps
                new HourlyEmployee(1, "John", true, 40, 30),
                new HourlyEmployee(2, "Anne", true, 55, 25),
                new HourlyEmployee(3, "Mark", false, 35, 20),

                // commission emps
                new CommissionEmployee(4, "Alice", false, 10000, 0.12),
                new CommissionEmployee(5, "James", true, 12000, 0.15),
                new CommissionEmployee(6, "Lucy", false, 15000, 0.08)
            };
        }

        private void btnGetEmps_Click(object sender, RoutedEventArgs e)
        {
            if (rdoHrEmp.IsChecked == true)
            {
                grdEmployees.ItemsSource = _employees.OfType<HourlyEmployee>();
            }
            else
            {
                grdEmployees.ItemsSource = _employees.OfType<CommissionEmployee>();
            }

            // reorder columns in a DataGrid
            grdEmployees.Columns[0].DisplayIndex = 2;
            grdEmployees.Columns[1].DisplayIndex = 3;
            grdEmployees.Columns[2].DisplayIndex = 0;
            grdEmployees.Columns[3].DisplayIndex = 1;
        }

        private void txtEmployeeId_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtEmployeeId.Text.Length > 0)
                btnFind.IsEnabled = true;
            else
                btnFind.IsEnabled = false;
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            int empId = Convert.ToInt32(txtEmployeeId.Text);
            var emp = _employees.Find(e => e.Id == empId);

            if (emp != null)
            {
                lblName.Content = emp.Name;
                chkIsUnionMember.IsChecked = emp.IsUnionMember;
                lblGrossEarnings.Content = emp.Earnings().ToString("C");

                if (emp is HourlyEmployee hrEmp)
                {
                    rdoHrEmp.IsChecked = true;

                    //HourlyEmployee hrEmp = emp as HourlyEmployee;

                    lblHoursOrGrossSales.Content = hrEmp.Hours;
                    lblWageOrCommRate.Content = hrEmp.Wage.ToString("C");

                    hoursOrGrossSalesLabel.Content = "Hours";
                    wageOrCommRateLabel.Content = "Wage";

                    // if you need to show/hide a control
                    //chkIsUnionMember.Visibility = Visibility.Visible;
                }
                else if (emp is CommissionEmployee commEmp)
                {
                    rdoCommEmp.IsChecked = true;

                    lblHoursOrGrossSales.Content = commEmp.GrossSales.ToString("C");
                    lblWageOrCommRate.Content = commEmp.CommissionRate.ToString("P");

                    hoursOrGrossSalesLabel.Content = "Gross Sales";
                    wageOrCommRateLabel.Content = "Commission Rate";

                    // if you need to show/hide a control
                    //chkIsUnionMember.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                lblName.Content = "";
                lblHoursOrGrossSales.Content = "";
                lblWageOrCommRate.Content = "";
                lblGrossEarnings.Content = "";
                chkIsUnionMember.IsChecked = false;
                rdoHrEmp.IsChecked = true;

                MessageBox.Show("Invalid ID. Please trya again.");
            }
        }
    }
}