using RoleEmployee;
using System.Data;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Data.SqlClient;
class RoleEmployeeMain
{
    static IEmployeeManager employeeManager = new FileEmployeeManager();
    static EmployeeDisplayer employeeDisplayer = new EmployeeDisplayer(employeeManager);
    static IRoleManager roleManager = new FileRoleManager();
    static RoleDisplayer roleDisplayer = new RoleDisplayer(roleManager);
    private static Role makeRole()
    {
        Console.WriteLine("Enter Employee Role Name");
        string jobTitle = string.Empty;
        bool jobTitleEntered = false;
        while (!jobTitleEntered)
        {
            jobTitle = Console.ReadLine() ?? string.Empty;
            if (Regex.IsMatch(jobTitle, "^[a-zA-Z ]+$"))
            {
                jobTitleEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid Job Title! Enter again");
            }
        }
        Console.WriteLine("Enter Employee Location");
        string location = string.Empty;
        bool locationEntered = false;
        while (!locationEntered)
        {
            location = Console.ReadLine() ?? string.Empty;
            if (Regex.IsMatch(location, "^[a-zA-Z ]+$"))
            {
                locationEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid Location! Enter again");
            }
        }
        Console.WriteLine("Enter Employee Department");
        string department = string.Empty;
        bool departmentEntered = false;
        while (!departmentEntered)
        {
            department = Console.ReadLine() ?? string.Empty;
            if (Regex.IsMatch(department, "^[a-zA-Z ]+$"))
            {
                departmentEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid Department! Enter again");
            }
        }
        Console.WriteLine("Enter Description of Job Title");
        string description = string.Empty;
        description = Console.ReadLine() ?? string.Empty;
        Role role = new()
        {
            RoleName = jobTitle,
            Description = description,
            Department = department,
            Location = location
        };
        return role;
    }
    public static void Main(string[] args)
    {
        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Employee Management");
            Console.WriteLine("2. Role Management");
            Console.WriteLine("3. Assign Employee to Role");
            Console.WriteLine("4. Deallocate Employee from Role");
            Console.WriteLine("5. View all Employees in a particular Role");
            Console.WriteLine("6. Exit");
            int choice = default;
            string choiceString = string.Empty;
            bool choiceEntered = false;
            while (!choiceEntered)
            {
                choiceString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceString, out choice))
                {
                    choiceEntered = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice! Enter again");
                }
            }
            switch (choice)
            {
                case 1:
                    EmployeeManagementMenu();
                    break;
                case 2:
                    RoleManagementMenu();
                    break;
                case 3:
                    AssignEmployeeToRole();
                    break;
                case 4:
                    DeallocateEmployeeFromRole();
                    break;
                case 5:
                    ViewAllEmpInRole();
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid Choice! Enter again");
                    break;
            }
        }
    }
    private static void EmployeeManagementMenu()
    {
        bool goBack = false;
        while (!goBack)
        {
            Console.WriteLine("Employee Management Menu");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Display All");
            Console.WriteLine("3. Display One");
            Console.WriteLine("4. Edit Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Go Back");
            int choice = default;
            string choiceString = string.Empty;
            bool choiceEntered = false;
            while (!choiceEntered)
            {
                choiceString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceString, out choice))
                {
                    choiceEntered = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice! Enter again");
                }
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Employee Number");
                    string empNo = string.Empty;
                    bool empNoEntered = false;
                    while (!empNoEntered)
                    {
                        empNo = Console.ReadLine() ?? string.Empty;
                        if (Regex.IsMatch(empNo, "TZ\\d{4}"))
                        {
                            empNoEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Employee Number! Enter again");
                        }
                    }
                    Console.WriteLine("Enter Employee First Name");
                    string firstName = string.Empty;
                    bool firstNameEntered = false;
                    while (!firstNameEntered)
                    {
                        firstName = Console.ReadLine() ?? string.Empty;
                        if (Regex.IsMatch(firstName, "^[a-zA-Z]+$"))
                        {
                            firstNameEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid First Name! Enter again");
                        }
                    }
                    Console.WriteLine("Enter Employee Last Name");
                    string lastName = string.Empty;
                    bool lastNameEntered = false;
                    while (!lastNameEntered)
                    {
                        lastName = Console.ReadLine() ?? string.Empty;
                        if (Regex.IsMatch(lastName, "^[a-zA-Z]+$"))
                        {
                            lastNameEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Last Name! Enter again");
                        }
                    }
                    Console.WriteLine("Enter Employee Date Of Birth(mm/dd/yyyy) or (Press Enter to skip)");
                    DateOnly dateOfBirth = default;
                    string? dateOfBirthString;
                    bool dateOfBirthEnteredOrSkipped = false;
                    while (!dateOfBirthEnteredOrSkipped)
                    {
                        dateOfBirthString = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(dateOfBirthString))
                        {
                            break;
                        }
                        else if (DateOnly.TryParse(dateOfBirthString, out dateOfBirth))
                        {
                            dateOfBirthEnteredOrSkipped = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Date Of Birth! Enter again (Press Enter to Skip)");
                        }
                    }
                    Console.WriteLine("Enter Employee Email");
                    string email = string.Empty;
                    bool emailEntered = false;
                    while (!emailEntered)
                    {
                        email = Console.ReadLine() ?? string.Empty;
                        if (Regex.IsMatch(email, "[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}"))
                        {
                            emailEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Email! Enter again");
                        }
                    }
                    Console.WriteLine("Enter Employee Mobile or (Press Enter to Skip)");
                    ulong mobile = default;
                    string? mobileString;
                    bool mobileEnteredOrSkipped = false;
                    while (!mobileEnteredOrSkipped)
                    {
                        mobileString = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(mobileString))
                        {
                            break;
                        }
                        else if (ulong.TryParse(mobileString, out mobile))
                        {
                            mobileEnteredOrSkipped = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid mobile! Enter again or (Press Enter to skip)");
                        }
                    }
                    Console.WriteLine("Enter Employee Joining Date(mm/dd/yyyy)");
                    DateOnly joiningDate = default;
                    string joiningDateString = string.Empty;
                    bool joiningDateEntered = false;
                    while (!joiningDateEntered)
                    {
                        joiningDateString = Console.ReadLine() ?? string.Empty;
                        if (DateOnly.TryParse(joiningDateString, out joiningDate))
                        {
                            joiningDateEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Joining Date! Enter again");
                        }
                    }
                    Console.WriteLine("Do You want to assign this Employee to a Role? (Y/N)");
                    bool assignEmployeeToRoleEntered = false;
                    string assignEmployeeToRole = string.Empty;
                    while (!assignEmployeeToRoleEntered)
                    {
                        assignEmployeeToRole = Console.ReadLine() ?? string.Empty;
                        if (Regex.IsMatch(assignEmployeeToRole, "^[a-zA-Z ]+$"))
                        {
                            assignEmployeeToRoleEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Option! Enter again");
                        }
                    }
                    Role? role = null;
                    if (assignEmployeeToRole[0].ToString().ToUpper() == "Y")
                    {
                        Console.WriteLine("Assign employee to existing role? (Y/N)");
                        string result = Console.ReadLine() ?? string.Empty;
                        while (role is null)
                        {
                            if (string.Equals(result[0].ToString(), "y", StringComparison.OrdinalIgnoreCase))
                            {
                                if(roleManager.GetAll().Count == 0)
                                {
                                    Console.WriteLine("No roles exist!");
                                    break;
                                }
                                else
                                {
                                    roleDisplayer.DisplayAll();
                                    Console.WriteLine("Choose the ID to assign");
                                    int roleId = default;
                                    string roleIdString = string.Empty;
                                    bool roleIdEntered = false;
                                    while (!roleIdEntered)
                                    {
                                        roleIdString = Console.ReadLine() ?? string.Empty;
                                        if (int.TryParse(roleIdString, out roleId))
                                        {
                                            roleIdEntered = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invaild Role Id! Enter again");
                                        }
                                    }
                                    if (roleManager.GetAll().SingleOrDefault(r => r.RoleId == roleId) is not null)
                                    {
                                        role = roleManager.GetRoleById(roleId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Role Not Found! Enter Again");
                                    }
                                } 
                            }
                            else if (string.Equals(result[0].ToString(), "n", StringComparison.OrdinalIgnoreCase))
                            {
                                role = makeRole();
                            }
                        }
                        if(role is not null)
                        {
                            Role newRole = roleManager.AddRole(role);
                        }
                    }
                    Console.WriteLine("Enter Employee Manager Name or (Press Enter to skip)");
                    string manager = string.Empty;
                    string? managerString;
                    bool managerEnteredOrSkipped = false;
                    while (!managerEnteredOrSkipped)
                    {
                        managerString = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(managerString))
                        {
                            break;
                        }
                        else if (Regex.IsMatch(managerString, "^[a-zA-Z]+$"))
                        {
                            manager = managerString;
                            managerEnteredOrSkipped = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Manager Name! Enter again or (Press Enter to Skip)");
                        }
                    }
                    Console.WriteLine("Enter Employee Project Name or (Press Enter to skip)");
                    string project = string.Empty;
                    string? projectString;
                    bool projectEnteredOrSkipped = false;
                    while (!projectEnteredOrSkipped)
                    {
                        projectString = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(projectString))
                        {
                            break;
                        }
                        else if (Regex.IsMatch(projectString, "^[a-zA-Z]+$"))
                        {
                            projectEnteredOrSkipped = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Project Name! Enter again or (Press Enter to Skip)");
                        }
                    }
                    Employee employee = new()
                    {
                        EmpNo = empNo,
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateOfBirth,
                        Email = email,
                        Mobile = mobile,
                        JoiningDate = joiningDate,
                        Role = role,
                        Manager = manager,
                        Project = project
                    };
                    employeeManager.AddEmployee(employee);
                    Console.WriteLine("Employee Added successfully");
                    break;
                case 2:
                    if (employeeManager.GetAll().Count == 0)
                    {
                        Console.WriteLine("No Employee Found!");
                    }
                    else
                    {
                        employeeDisplayer.DisplayAll();
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter Id of Employee");
                    string empNoToDisplay = string.Empty;
                    bool empNoToDisplayEntered = false;
                    while (!empNoToDisplayEntered)
                    {
                        empNoToDisplay = Console.ReadLine() ?? string.Empty;
                        if (Regex.IsMatch(empNoToDisplay, "TZ\\d{4}"))
                        {
                            empNoToDisplayEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Employee Number! Enter again");
                        }
                    }
                    if (employeeManager.GetAll().SingleOrDefault(e => e.EmpNo == empNoToDisplay) is not null)
                    {
                        employeeDisplayer.DisplayOne(empNoToDisplay);
                    }
                    else
                    {
                        Console.WriteLine("Employee Not Found");
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter the Employee Id whose details to be updated");
                    string empNoToUpdate = string.Empty;
                    bool empNoToUpdateEntered = false;
                    while (!empNoToUpdateEntered)
                    {
                        empNoToUpdate = Console.ReadLine() ?? string.Empty;
                        if (Regex.IsMatch(empNoToUpdate, "TZ\\d{4}"))
                        {
                            empNoToUpdateEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Employee Number! Enter again");
                        }
                    }
                    if (employeeManager.GetAll().SingleOrDefault(e => e.EmpNo == empNoToUpdate) is not null)
                    {
                        Employee empToUpdate = employeeManager.GetAll().Single(e => e.EmpNo == empNoToUpdate);
                        string[] validResponses = ["Y", "N", "YES", "NO"];
                        Console.WriteLine("Do you want to Edit Employee First Name(Y/N)");
                        string editEmpFirstNameChoice = string.Empty;
                        string editEmpFirstName = string.Empty;
                        bool editFirstNameChoiceEntered = false;
                        while (!editFirstNameChoiceEntered)
                        {
                            editEmpFirstNameChoice = Console.ReadLine() ?? string.Empty;
                            editEmpFirstNameChoice = editEmpFirstNameChoice.ToUpper();
                            if (Array.IndexOf(validResponses, editEmpFirstNameChoice) != -1)
                            {
                                editFirstNameChoiceEntered = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option! Enter again");
                            }
                        }
                        if (editEmpFirstNameChoice[0] == 'Y')
                        {
                            Console.WriteLine("Enter Employee First Name to be updated");
                            editEmpFirstName = Console.ReadLine() ?? string.Empty;
                            bool editEmpNameEntered = false;
                            while (!editEmpNameEntered)
                            {
                                if (Regex.IsMatch(editEmpFirstName, "^[a-zA-Z]|$"))
                                {
                                    editEmpNameEntered = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Employee First Name! Enter again");
                                }
                            }
                        }
                        else
                        {
                            editEmpFirstName = empToUpdate.FirstName;
                        }
                        Console.WriteLine("Do you want to Edit Employee Last Name(Y/N)");
                        string editEmpLastNameChoice = string.Empty;
                        string editEmpLastName = string.Empty;
                        bool editLastNameChoiceEntered = false;
                        while (!editLastNameChoiceEntered)
                        {
                            editEmpLastNameChoice = Console.ReadLine() ?? string.Empty;
                            editEmpLastNameChoice = editEmpLastNameChoice.ToUpper();
                            if (Array.IndexOf(validResponses, editEmpLastNameChoice) != -1)
                            {
                                editLastNameChoiceEntered = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option! Enter again");
                            }
                        }
                        if (editEmpLastNameChoice[0] == 'Y')
                        {
                            Console.WriteLine("Enter Employee Last Name to be updated");
                            editEmpLastName = Console.ReadLine() ?? string.Empty;
                            bool editEmpLastNameEntered = false;
                            while (!editEmpLastNameEntered)
                            {
                                if (Regex.IsMatch(editEmpLastName, "^[a-zA-Z]|$"))
                                {
                                    editEmpLastNameEntered = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Employee Last Name! Enter again");
                                }
                            }
                        }
                        else
                        {
                            editEmpLastName = empToUpdate.LastName;
                        }
                        Console.WriteLine("Do you want to Edit Employee Date Of Birth(Y/N)");
                        string editEmpDateOfBirthChoice = string.Empty;
                        DateOnly editEmpDateOfBirth = default;
                        bool editDateOfBirthChoiceEntered = false;
                        while (!editDateOfBirthChoiceEntered)
                        {
                            editEmpDateOfBirthChoice = Console.ReadLine() ?? string.Empty;
                            editEmpDateOfBirthChoice = editEmpDateOfBirthChoice.ToUpper();
                            if (Array.IndexOf(validResponses, editEmpDateOfBirthChoice) != -1)
                            {
                                editDateOfBirthChoiceEntered = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option! Enter again");
                            }
                        }
                        if (editEmpDateOfBirthChoice[0] == 'Y')
                        {
                            string editEmpDateOfBirthString = string.Empty;
                            Console.WriteLine("Enter Employee Date of birth(mm/dd/yyyy) to be updated");
                            bool editEmpDateOfBirthEntered = false;
                            while (!editEmpDateOfBirthEntered)
                            {
                                editEmpDateOfBirthString = Console.ReadLine() ?? string.Empty;
                                if (DateOnly.TryParse(editEmpDateOfBirthString, out editEmpDateOfBirth))
                                {
                                    editEmpDateOfBirthEntered = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Date of birth! Enter again");
                                }
                            }
                        }
                        else
                        {
                            editEmpDateOfBirth = empToUpdate.DateOfBirth;
                        }
                        Console.WriteLine("Do you want to Edit Employee Email(Y/N)");
                        string editEmpEmailChoice = string.Empty;
                        string editEmpEmail = string.Empty;
                        bool editEmailChoiceEntered = false;
                        while (!editEmailChoiceEntered)
                        {
                            editEmpEmailChoice = Console.ReadLine() ?? string.Empty;
                            editEmpEmailChoice = editEmpEmailChoice.ToUpper();
                            if (Array.IndexOf(validResponses, editEmpEmailChoice) != -1)
                            {
                                editEmailChoiceEntered = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option! Enter again");
                            }
                        }
                        if (editEmpEmailChoice[0] == 'Y')
                        {
                            Console.WriteLine("Enter Employee Email to be updated");
                            editEmpEmail = Console.ReadLine() ?? string.Empty;
                            bool editEmpEmailEntered = false;
                            while (!editEmpEmailEntered)
                            {
                                if (Regex.IsMatch(editEmpEmail, "[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}"))
                                {
                                    editEmpEmailEntered = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Employee Email! Enter again");
                                }
                            }
                        }
                        else
                        {
                            editEmpEmail = empToUpdate.Email;
                        }
                        Console.WriteLine("Do you want to Edit Employee Mobile(Y/N)");
                        string editEmpMobileChoice = string.Empty;
                        ulong editEmpMobile = default;
                        bool editMobileChoiceEntered = false;
                        while (!editMobileChoiceEntered)
                        {
                            editEmpMobileChoice = Console.ReadLine() ?? string.Empty;
                            editEmpMobileChoice = editEmpMobileChoice.ToUpper();
                            if (Array.IndexOf(validResponses, editEmpMobileChoice) != -1)
                            {
                                editMobileChoiceEntered = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option! Enter again");
                            }
                        }
                        if (editEmpMobileChoice[0] == 'Y')
                        {
                            string editEmpMobileString = string.Empty;
                            Console.WriteLine("Enter Employee Mobile to be updated");
                            editEmpMobileString = Console.ReadLine() ?? string.Empty;
                            bool editEmpMobileEntered = false;
                            while (!editEmpMobileEntered)
                            {
                                if (ulong.TryParse(editEmpMobileString, out editEmpMobile))
                                {
                                    editEmpMobileEntered = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Employee Mobile! Enter again");
                                }
                            }
                        }
                        else
                        {
                            editEmpMobile = empToUpdate.Mobile;
                        }
                        Console.WriteLine("Do you want to Edit Employee Joining Date(Y/N)");
                        string editEmpJoiningDateChoice = string.Empty;
                        DateOnly editEmpJoiningDate = default;
                        bool editJoiningDateChoiceEntered = false;
                        while (!editJoiningDateChoiceEntered)
                        {
                            editEmpJoiningDateChoice = Console.ReadLine() ?? string.Empty;
                            editEmpJoiningDateChoice = editEmpJoiningDateChoice.ToUpper();
                            if (Array.IndexOf(validResponses, editEmpJoiningDateChoice) != -1)
                            {
                                editJoiningDateChoiceEntered = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option! Enter again");
                            }
                        }
                        if (editEmpJoiningDateChoice[0] == 'Y')
                        {
                            string editEmpJoiningDateString = string.Empty;
                            Console.WriteLine("Enter Employee Joining Date(mm/dd/yyyy) to be updated");
                            editEmpJoiningDateString = Console.ReadLine() ?? string.Empty;
                            bool editEmpJoiningDateEntered = false;
                            while (!editEmpJoiningDateEntered)
                            {
                                if (DateOnly.TryParse(editEmpJoiningDateString, out editEmpJoiningDate))
                                {
                                    editEmpJoiningDateEntered = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Joining Date! Enter again");
                                }
                            }
                        }
                        else
                        {
                            editEmpJoiningDate = empToUpdate.JoiningDate;
                        }
                        Console.WriteLine("Do you want to Edit Employee Role(Y/N)");
                        string editEmpJobTitleChoice = string.Empty; 
                        bool editJobTitleChoiceEntered = false;
                        while (!editJobTitleChoiceEntered)
                        {
                            editEmpJobTitleChoice = Console.ReadLine() ?? string.Empty;
                            editEmpJobTitleChoice = editEmpJobTitleChoice.ToUpper();
                            if (Array.IndexOf(validResponses, editEmpJobTitleChoice) != -1)
                            {
                                editJobTitleChoiceEntered = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option! Enter again");
                            }
                        }
                        string editEmpLocation = string.Empty;
                        string editEmpDepartment = string.Empty;
                        string editEmpJobTitle = string.Empty;
                        Role? roleToUpdate = null;
                        if (editEmpJobTitleChoice[0] == 'Y')
                        {
                            Console.WriteLine("Assign employee to existing role? (Y/N)");
                            string result = Console.ReadLine() ?? string.Empty;
                            while (roleToUpdate is null)
                            {
                                if (string.Equals(result[0].ToString(), "y", StringComparison.OrdinalIgnoreCase))
                                {
                                    if (roleManager.GetAll().Count == 0)
                                    {
                                        Console.WriteLine("No roles exist!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Choose the ID to assign");
                                        roleDisplayer.DisplayAll();
                                        int roleId = default;
                                        string roleIdString = string.Empty;
                                        bool roleIdEntered = false;
                                        while (!roleIdEntered)
                                        {
                                            roleIdString = Console.ReadLine() ?? string.Empty;
                                            if (int.TryParse(roleIdString, out roleId))
                                            {
                                                roleIdEntered = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invaild Role Id! Enter again");
                                            }
                                        }
                                        if (roleManager.GetAll().SingleOrDefault(r => r.RoleId == roleId) is not null)
                                        {
                                            roleToUpdate = roleManager.GetRoleById(roleId);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Role Not Found! Enter Again");
                                        }
                                    }
                                }
                                else if (string.Equals(result[0].ToString(), "n", StringComparison.OrdinalIgnoreCase))
                                {
                                    Console.WriteLine("Enter Employee Role Name to be updated");
                                    bool editEmpJobTitleEntered = false;
                                    while (!editEmpJobTitleEntered)
                                    {
                                        editEmpJobTitle = Console.ReadLine() ?? string.Empty;
                                        if (Regex.IsMatch(editEmpJobTitle, "^[a-zA-Z ]+$"))
                                        {
                                            editEmpJobTitleEntered = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Employee JobTitle! Enter again");
                                        }
                                    }
                                    Console.WriteLine("Enter Employee Location to be updated");
                                    bool editEmpLocationEntered = false;
                                    while (!editEmpLocationEntered)
                                    {
                                        editEmpLocation = Console.ReadLine() ?? string.Empty;
                                        if (Regex.IsMatch(editEmpLocation, "^[a-zA-Z ]+$"))
                                        {
                                            editEmpLocationEntered = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Employee Location! Enter again");
                                        }
                                    }
                                    Console.WriteLine("Enter Employee Department to be updated");
                                    bool editEmpDepartmentEntered = false;
                                    while (!editEmpDepartmentEntered)
                                    {
                                        editEmpDepartment = Console.ReadLine() ?? string.Empty;
                                        if (Regex.IsMatch(editEmpDepartment, "^[a-zA-Z ]+$"))
                                        {
                                            editEmpDepartmentEntered = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Employee Department! Enter again");
                                        }
                                    }
                                    Console.WriteLine("Enter Employee Description");
                                    string editEmpDescription = Console.ReadLine() ?? string.Empty;
                                    Role updatedRole = new() { RoleName = editEmpJobTitle, Location = editEmpLocation, Department = editEmpDepartment, Description = editEmpDescription};
                                    roleToUpdate = roleManager.AddRole(updatedRole);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Option!");
                                }
                            }
                        }
                        else
                        {
                            roleToUpdate = empToUpdate.Role;
                        }
                        Console.WriteLine("Do you want to Edit Employee Manager(Y/N)");
                        string editEmpManagerChoice = string.Empty;
                        string editEmpManager = string.Empty;
                        bool editManagerChoiceEntered = false;
                        while (!editManagerChoiceEntered)
                        {
                            editEmpManagerChoice = Console.ReadLine() ?? string.Empty;
                            editEmpManagerChoice = editEmpManagerChoice.ToUpper();
                            if (Array.IndexOf(validResponses, editEmpManagerChoice) != -1)
                            {
                                editManagerChoiceEntered = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option! Enter again");
                            }
                        }
                        if (editEmpManagerChoice[0] == 'Y')
                        {
                            Console.WriteLine("Enter Employee Manager to be updated");
                            editEmpManager = Console.ReadLine() ?? string.Empty;
                            bool editEmpManagerEntered = false;
                            while (!editEmpManagerEntered)
                            {
                                if (Regex.IsMatch(editEmpManager, "^[a-zA-Z]+$"))
                                {
                                    editEmpManagerEntered = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Employee Manager! Enter again");
                                }
                            }
                        }
                        Console.WriteLine("Do you want to Edit Employee Project(Y/N)");
                        string editEmpProjectChoice = string.Empty;
                        string editEmpProject = string.Empty;
                        bool editProjectChoiceEntered = false;
                        while (!editProjectChoiceEntered)
                        {
                            editEmpProjectChoice = Console.ReadLine() ?? string.Empty;
                            editEmpProjectChoice = editEmpProjectChoice.ToUpper();
                            if (Array.IndexOf(validResponses, editEmpProjectChoice) != -1)
                            {
                                editProjectChoiceEntered = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option! Enter again");
                            }
                        }
                        if (editEmpProjectChoice[0] == 'Y')
                        {
                            Console.WriteLine("Enter Employee Project to be updated");
                            editEmpProject = Console.ReadLine() ?? string.Empty;
                            bool editEmpProjectEntered = false;
                            while (!editEmpProjectEntered)
                            {
                                if (Regex.IsMatch(editEmpProject, "^[a-zA-Z]+$"))
                                {
                                    editEmpProjectEntered = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Employee Project! Enter again");
                                }
                            }
                        }
                        Employee updatedEmployee = new()
                        {
                            EmpNo = empNoToUpdate,
                            FirstName = editEmpFirstName,
                            LastName = editEmpLastName,
                            DateOfBirth = editEmpDateOfBirth,
                            Email = editEmpEmail,
                            Mobile = editEmpMobile,
                            JoiningDate = editEmpJoiningDate,
                            Role = roleToUpdate,
                            Manager = editEmpManager,
                            Project = editEmpProject
                        };
                        employeeManager.EditEmployee(updatedEmployee);
                        Console.WriteLine("Employee Details Updated Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Employee Not Found");
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter Employee Number to Delete");
                    string empNoToDelete = string.Empty;
                    bool empNoToDeleteEntered = false;
                    while (!empNoToDeleteEntered)
                    {
                        empNoToDelete = Console.ReadLine() ?? string.Empty;
                        if (Regex.IsMatch(empNoToDelete, "^[TZ\\d{4}]"))
                        {
                            empNoToDeleteEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Employee Number");
                        }
                    }
                    if (employeeManager.GetAll().SingleOrDefault(e => e.EmpNo == empNoToDelete) is not null)
                    {
                        employeeManager.DeleteEmployee(empNoToDelete);
                        Console.WriteLine("Employee Deleted Sucessfully");
                    }
                    else
                    {
                        Console.WriteLine("Employee Not Found");
                    }
                    break;
                case 6:
                    goBack = true;
                    break;
                default:
                    Console.WriteLine("Invalid Choice! Enter Again");
                    break;
            }
        }

    }
    private static void RoleManagementMenu()
    {
        bool goBack = false;
        while (!goBack)
        {
            Console.WriteLine("Role Management Menu");
            Console.WriteLine("1. Add Role");
            Console.WriteLine("2. Display All");
            Console.WriteLine("3. Go Back");
            Console.WriteLine("Please Enter your choice");
            int choice = default;
            string choiceString = string.Empty;
            bool choiceEntered = false;
            while (!choiceEntered)
            {
                choiceString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(choiceString, out choice))
                {
                    choiceEntered = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice! Enter again");
                }
            }
            switch (choice)
            {
                case 1:
                    Role role = makeRole();
                    roleManager.AddRole(role);
                    Console.WriteLine("Role Added Successfully");
                    break;
                case 2:
                    if(roleManager.GetAll().Count == 0)
                    {
                        Console.WriteLine("No Roles Found!");
                    }
                    else
                    {
                        roleDisplayer.DisplayAll();
                    }
                    break;
                case 3:
                    goBack = true;
                    break;
                default:
                    Console.WriteLine("Invalid Choice! Enter Again");
                    break;
            }
        }
    }
    private static void AssignEmployeeToRole()
    {
        employeeDisplayer.DisplayAll();
        Console.WriteLine("Enter Employee Number");
        string empNo = string.Empty;
        bool empNoEntered = false;
        while (!empNoEntered)
        {
            empNo = Console.ReadLine() ?? string.Empty;
            if(Regex.IsMatch(empNo , "^[a-zA-Z0-9]+$"))
            {
                empNoEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid Employee Number! Enter Again");
            }
        }
        if(employeeManager.GetAll().SingleOrDefault(e => e.EmpNo == empNo) is not null)
        {
            roleDisplayer.DisplayAll();
            Console.WriteLine("Enter Role Id");
            int roleId = default;
            string roleIdString = string.Empty;
            bool roleIdEntered = false;
            while (!roleIdEntered)
            {
                roleIdString = Console.ReadLine() ?? string.Empty;
                if(int.TryParse(roleIdString , out roleId))
                {
                    roleIdEntered = true;
                }
                else
                {
                    Console.WriteLine("Invalid role Id");
                }
            }
            if(roleManager.GetAll().SingleOrDefault(r => r.RoleId == roleId) is not null)
            {
                Role role = roleManager.GetRoleById(roleId)!;
                IList<Employee> _employees = employeeManager.GetAll();
                _employees.Single(e => e.EmpNo == empNo).Role = role;
                employeeManager.SaveUpdatedData(_employees);
                Console.WriteLine($"{empNo} assigned to {roleId} succesfully");
            }
            else
            {
                Console.WriteLine("Role Not Found");
            }
        }
        else
        {
            Console.WriteLine("Employee Not Found");
        }
    }
    private static void DeallocateEmployeeFromRole()
    {
        employeeDisplayer.DisplayAll();
        Console.WriteLine("Enter Employee Number");
        string empNo = string.Empty;
        bool empNoEntered = false;
        while (!empNoEntered)
        {
            empNo = Console.ReadLine() ?? string.Empty;
            if (Regex.IsMatch(empNo, "^[a-zA-Z0-9]+$"))
            {
                empNoEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid Employee Number! Enter Again");
            }
        }
        if (employeeManager.GetAll().SingleOrDefault(e => e.EmpNo == empNo) is not null)
        {
            roleDisplayer.DisplayAll();
            Console.WriteLine("Enter Role Id");
            int roleId = default;
            string roleIdString = string.Empty;
            bool roleIdEntered = false;
            while (!roleIdEntered)
            {
                roleIdString = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(roleIdString, out roleId))
                {
                    roleIdEntered = true;
                }
                else
                {
                    Console.WriteLine("Invalid role Id");
                }
            }
            if (roleManager.GetAll().SingleOrDefault(r => r.RoleId == roleId) is not null)
            {
                if(employeeManager.GetAll().Single(e => e.EmpNo == empNo).Role?.RoleId == roleId)
                {
                    IList<Employee> _employees = employeeManager.GetAll();
                    _employees.Single(e => e.EmpNo == empNo).Role = null;
                    employeeManager.SaveUpdatedData(_employees);
                    Console.WriteLine($"{empNo} deallocated from {roleId} succesfully");
                }
                else
                {
                    Console.WriteLine("This Employee was not assigned to this role!");
                }
            }
            else
            {
                Console.WriteLine("Role Not Found");
            }
        }
        else
        {
            Console.WriteLine("Employee Not Found");
        }
    }
    private static void ViewAllEmpInRole()
    {
        roleDisplayer.DisplayAll();
        Console.WriteLine("Enter role Id to see all employees with that role");
        bool roleIdEntered = false;
        int roleId = default;
        string roleIdString = string.Empty;
        while (!roleIdEntered)
        {
            roleIdString = Console.ReadLine() ?? string.Empty;
            if(int.TryParse(roleIdString , out roleId))
            {
                roleIdEntered = true;
            }
            else
            {
                Console.WriteLine("Invalid Role Id, Enter again!");
            }
        }
        if(roleManager.GetAll().SingleOrDefault(r => r.RoleId == roleId) is not null)
        {
            employeeDisplayer.DisplayAllEmployeesInRole(roleId);
        }
        else
        {
            Console.WriteLine("Role Not Found");
        }
    }
}
