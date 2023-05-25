using Moq;
using SEMS.Domain;
using System.Collections.ObjectModel;


namespace SEMSTests
{
    [TestClass]
    public class CacheTests
    {
        [TestMethod]
        public void getPlaceholderEmployees_NoInput_ReturnsAllEmployees() 
        { 
            // Capture
            var mock = new Mock<DataHandler>();
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>
            {
               employee_Max_Mustermann()
            };
            mock.Setup(p => p.getEmployeesByName("")).Returns(employees);

            // Arrange
            Cache target = new Cache(mock.Object);

            // Act 

            var actual_employees = target.getPlaceholderEmployees();
            var actual_employee = actual_employees.ElementAt(0);
            // Assert
            Assert.AreEqual(actual_employee.Name, employees[0].Name);
            Assert.AreEqual(actual_employee.Surname, employees[0].Surname);

            //Verify
            mock.Verify();
        }
        [TestMethod]
        public void getPlaceholderDepartments_NoInput_ReturnsAllDepartments()
        {
            // Capture
            var mock = new Mock<DataHandler>();
            ObservableCollection<Department> depts = new ObservableCollection<Department>
            {
               department_Sales()
            };
            mock.Setup(p => p.getDepartmentsByName("")).Returns(depts);

            // Arrange
            Cache target = new Cache(mock.Object);

            // Act 

            var actual_employees = target.getPlaceholderDepartments();
            var actual_employee = actual_employees.ElementAt(0);
            // Assert
            Assert.AreEqual(actual_employee.Name, depts[0].Name);
            Assert.AreEqual(actual_employee.Description, depts[0].Description);

            //Verify
            mock.Verify();
        }
        public Department department_Sales()
        {
            Department dept = new Department("Sales", "Does Sales.", "0001");
            return dept;
        }

        public Employee employee_Max_Mustermann()
        {
            // Es wird nur nach Namen gesucht die anderen Werte sind hier irrelevant
            Employee employee = new Employee("Max", "Mustermann", "", null, "", "", "", "", "", "", null, null, null, null);
            return employee;
        }

       
    }
}
