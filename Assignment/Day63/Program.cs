using Day63.BLL;
using Day63.DAL;
using Day63.Models;

IStudentRepository repository = SelectRepository();
var service = new StudentService(repository);

Console.WriteLine("\nStudent Management System");
Console.WriteLine("-------------------------");

while (true)
{
	ShowMenu();
	Console.Write("Choose an option: ");
	string? choice = Console.ReadLine();

	switch (choice)
	{
		case "1":
			AddStudent(service);
			break;
		case "2":
			ViewAllStudents(service);
			break;
		case "3":
			ViewStudentById(service);
			break;
		case "4":
			UpdateStudent(service);
			break;
		case "5":
			DeleteStudent(service);
			break;
		case "0":
			Console.WriteLine("Exiting application.");
			return;
		default:
			Console.WriteLine("Invalid choice. Please try again.");
			break;
	}

	Console.WriteLine();
}

static IStudentRepository SelectRepository()
{
	while (true)
	{
		Console.WriteLine("Select Storage Mode:");
		Console.WriteLine("1. In-Memory (List)");
		Console.WriteLine("2. JSON File (students.json)");
		Console.Write("Enter choice (1 or 2): ");

		string? selection = Console.ReadLine();
		if (selection == "1")
		{
			return new ListStudentRepository();
		}

		if (selection == "2")
		{
			string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "students.json");
			Console.WriteLine($"JSON file path: {jsonFilePath}");
			return new JsonStudentRepository(jsonFilePath);
		}

		Console.WriteLine("Invalid input. Please enter 1 or 2.\n");
	}
}

static void ShowMenu()
{
	Console.WriteLine("Menu:");
	Console.WriteLine("1. Add Student");
	Console.WriteLine("2. View All Students");
	Console.WriteLine("3. View Student By Id");
	Console.WriteLine("4. Update Student");
	Console.WriteLine("5. Delete Student");
	Console.WriteLine("0. Exit");
}

static void AddStudent(StudentService service)
{
	Console.Write("Enter Id: ");
	if (!int.TryParse(Console.ReadLine(), out int id))
	{
		Console.WriteLine("Invalid Id.");
		return;
	}

	Console.Write("Enter Name: ");
	string name = Console.ReadLine() ?? string.Empty;

	Console.Write("Enter Grade (0-100): ");
	if (!double.TryParse(Console.ReadLine(), out double grade))
	{
		Console.WriteLine("Invalid Grade.");
		return;
	}

	string? error = service.AddStudent(new Student { Id = id, Name = name, Grade = grade });
	Console.WriteLine(error is null ? "Student added successfully." : $"Error: {error}");
}

static void ViewAllStudents(StudentService service)
{
	List<Student> students = service.GetAllStudents();
	if (students.Count == 0)
	{
		Console.WriteLine("No students found.");
		return;
	}

	Console.WriteLine("Students:");
	foreach (Student student in students)
	{
		Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Grade: {student.Grade}");
	}
}

static void ViewStudentById(StudentService service)
{
	Console.Write("Enter Id: ");
	if (!int.TryParse(Console.ReadLine(), out int id))
	{
		Console.WriteLine("Invalid Id.");
		return;
	}

	Student? student = service.GetStudentById(id);
	if (student is null)
	{
		Console.WriteLine("Student not found.");
		return;
	}

	Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Grade: {student.Grade}");
}

static void UpdateStudent(StudentService service)
{
	Console.Write("Enter Id of student to update: ");
	if (!int.TryParse(Console.ReadLine(), out int id))
	{
		Console.WriteLine("Invalid Id.");
		return;
	}

	Student? existingStudent = service.GetStudentById(id);
	if (existingStudent is null)
	{
		Console.WriteLine("Student not found.");
		return;
	}

	Console.Write($"Enter New Name (current: {existingStudent.Name}): ");
	string name = Console.ReadLine() ?? string.Empty;

	Console.Write($"Enter New Grade (0-100, current: {existingStudent.Grade}): ");
	if (!double.TryParse(Console.ReadLine(), out double grade))
	{
		Console.WriteLine("Invalid Grade.");
		return;
	}

	string? error = service.UpdateStudent(new Student { Id = id, Name = name, Grade = grade });
	Console.WriteLine(error is null ? "Student updated successfully." : $"Error: {error}");
}

static void DeleteStudent(StudentService service)
{
	Console.Write("Enter Id of student to delete: ");
	if (!int.TryParse(Console.ReadLine(), out int id))
	{
		Console.WriteLine("Invalid Id.");
		return;
	}

	bool deleted = service.DeleteStudent(id);
	Console.WriteLine(deleted ? "Student deleted successfully." : "Student not found.");
}
