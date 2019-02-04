using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SfTreeGridDemo
{
    public class ViewModel
    {
        #region Private Variables
        private ObservableCollection<EmployeeInfo> _employees;
        private ObservableCollection<MenuItem> _menu;
        #endregion

        #region ctr

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
           this.Employees = GetEmployeesDetails();
        }

        #endregion

        #region Public properties
        /// <summary>
        /// Contains the details of Employees
        /// </summary>
        public ObservableCollection<EmployeeInfo> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
            }
        }

        public ObservableCollection<MenuItem> Menu
        {
            get { return _menu; }
            set { this._menu = value; }
        }
        private BaseCommand _myCommand;
        public BaseCommand MyCommand
        {
            get { return _myCommand; }
            set
            {
                _myCommand = value;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the Employee details 
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<EmployeeInfo> GetEmployeesDetails()
        {
            ObservableCollection<EmployeeInfo> employeeDetails = new ObservableCollection<EmployeeInfo>();
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ferando", LastName = "Joseph", Title = "Management", Salary = 2000000, ReportsTo = -1, ID = 2 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "John", LastName = null, Title = "Accounts", Salary = 2000000, ReportsTo = -1, ID = 3 });

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ferando1", LastName = "Joseph1", Title = "Management1", Salary = 20000000, ReportsTo = -1, ID = 4 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "John1", LastName = null, Title = "Accounts1", Salary = 20000000, ReportsTo = -1, ID = 5 });

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ferando2", LastName = "Joseph2", Title = "Management2", Salary = 20000001, ReportsTo = -1, ID = 6 });


            employeeDetails.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "Fuller", ID = 9, Salary = 1200000, ReportsTo = 2, Title = "Vice President" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Janet", LastName = "Leverling", ID = 10, Salary = 1000000, ReportsTo = 2, Title = "GM" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Steven", LastName = "Buchanan", ID = 11, Salary = 900000, ReportsTo = 2, Title = "Manager" });

            // Accounts
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Nancy", LastName = "Davolio", ID = 12, Salary = 850000, ReportsTo = 3, Title = "Accounts Manager" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Margaret", LastName = "Peacock", ID = 13, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Suyama", ID = 14, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Robert", LastName = "King", ID = 15, Salary = 650000, ReportsTo = 3, Title = "Accountant" });

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Nancy1", LastName = "Davolio1", ID = 16, Salary = 850000, ReportsTo = 4, Title = "Accounts Manager1" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Margaret1", LastName = "Peacock1", ID = 17, Salary = 700000, ReportsTo = 4, Title = "Accountant1" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael1", LastName = "Suyama1", ID = 18, Salary = 700000, ReportsTo = 4, Title = "Accountant1" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Robert1", LastName = "King1", ID = 19, Salary = 650000, ReportsTo = 5, Title = "Accountant1" });

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Nancy2", LastName = "Davolio2", ID = 20, Salary = 850000, ReportsTo = 5, Title = "Accounts Manager2" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Margaret2", LastName = "Peacock2", ID = 21, Salary = 700000, ReportsTo = 5, Title = "Accountant2" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael2", LastName = "Suyama2", ID = 22, Salary = 700000, ReportsTo = 5, Title = "Accountant2" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Robert2", LastName = "King2", ID = 23, Salary = 650000, ReportsTo = 5, Title = "Accountant2" });

            employeeDetails.Add(new EmployeeInfo() { FirstName = "Nancy3", LastName = "Davolio3", ID = 24, Salary = 850000, ReportsTo = 6, Title = "Accounts Manager3" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Margaret3", LastName = "Peacock3", ID = 25, Salary = 700000, ReportsTo = 6, Title = "Accountant3" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael3", LastName = "Suyama3", ID = 26, Salary = 700000, ReportsTo = 6, Title = "Accountant3" });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Robert3", LastName = "King3", ID = 27, Salary = 650000, ReportsTo = 6, Title = "Accountant3" });

            Menu = new ObservableCollection<MenuItem>();
            Menu.Add(new MenuItem { Header = "CopyColumn" });
            Menu.Add(new MenuItem { Header = "PasteColumn" });
            MyCommand = new BaseCommand(Execute);
            return employeeDetails;
        }

        private void Execute(object obj)
        {
            IList item = obj as IList;
            string command = (item[0] as MenuItem).Header.ToString();
            switch (command)
            {
                case "CopyColumn":
                    OnCopyColumn(item[1]);
                    break;

                case "PasteColumn":
                    OnPasteColumn(item[1]);
                    break;
            }
        }

        public static TreeGridColumn CopiedColumn;
        private static void OnCopyColumn(object obj)
        {

            if (obj is TreeGridColumnContextMenuInfo)
            {
                //The selected column stored in to CopiedColumn
                CopiedColumn = (obj as TreeGridColumnContextMenuInfo).Column;
            }
        }

        private static void OnPasteColumn(object obj)
        {
            if (obj is TreeGridColumnContextMenuInfo && CopiedColumn != null)
            {
                var grid = (obj as TreeGridColumnContextMenuInfo).TreeGrid;
                //  Get the index for corresponding column
                var index = grid.Columns.IndexOf((obj as TreeGridColumnContextMenuInfo).Column);
                // Copied column inserted based on the index position
                grid.Columns.Insert(index + 1, new TreeGridTextColumn() { MappingName = CopiedColumn.MappingName });
            }
        }
        #endregion
    }
}
