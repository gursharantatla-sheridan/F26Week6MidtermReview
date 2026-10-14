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

            grdEmployees.Columns[0].DisplayIndex = 2;
            grdEmployees.Columns[1].DisplayIndex = 3;
            grdEmployees.Columns[2].DisplayIndex = 0;
            grdEmployees.Columns[3].DisplayIndex = 1;
        }
    }
}