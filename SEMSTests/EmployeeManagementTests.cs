
using SEMS.Domain;
using Moq;
using System.Collections.ObjectModel;

namespace SEMSTests
{
    [TestClass]
    public class EmployeeManagementTests
    {
        [TestMethod]
        public void GetAllDepartments_ReturnsCorrectResult()
        {
            // Capture
            var mock = new Mock<DataHandler>();
            ObservableCollection<Employee> employees = new ObservableCollection<Employee> 
            {
               employee_Max_Mustermann()
            };
            mock.Setup(p => p.getEmployeesByName("")).Returns(employees);
            
            // Arrange
            EmployeeManagement target = new EmployeeManagement(mock.Object);
            
            // Act 

            var actual_employees = target.GetAllEmployees();
            var actual_employee = actual_employees.ElementAt(0);
            // Assert
            Assert.AreEqual(actual_employee.Name, employees[0].Name);
            Assert.AreEqual(actual_employee.Surname, employees[0].Surname);

            //Verify
            mock.Verify();
        }

      
        public Employee employee_Max_Mustermann()
        {
            // Es wird nur nach Namen gesucht die anderen Werte sind hier irrelevant
            Employee employee = new Employee("Max", "Mustermann", "", null, "", "", "", "", "", "", null, null, null, null);
            return employee;
        }
    }
}
