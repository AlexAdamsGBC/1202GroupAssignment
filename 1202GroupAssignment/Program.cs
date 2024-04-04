using System;
using System.Collections.Generic;


// AI GENERATED step 1 in order to complete steps 2-3.
class Program
{
    static void Main(string[] args)
    {
        CollegeManager collegeManager = new CollegeManager();

        
        DisplayMainMenu(collegeManager);
    }

    // AI GENERATED step 1 in order to complete steps 2-3.
    static void DisplayMainMenu(CollegeManager collegeManager)
    {
        while (true)
        {
            Console.WriteLine("College Student Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Professor");
            Console.WriteLine("3. Add Course");
            Console.WriteLine("4. Enroll Student in Class");
            Console.WriteLine("5. View Enrolled Students in Class");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddStudent(collegeManager);
                        break;
                    case 2:
                        AddProfessor(collegeManager);
                        break;
                    case 3:
                        AddClass(collegeManager);
                        break;
                    case 4:
                        EnrollStudent(collegeManager);
                        break;
                    case 5:
                        ViewEnrolledStudents(collegeManager);
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            Console.WriteLine();
        }
    }

    // AI GENERATED step 1 in order to complete steps 2-3.

    static void AddStudent(CollegeManager collegeManager)
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();
        collegeManager.AddStudent(name);
        Console.WriteLine("Student added successfully.");
    }

    static void AddProfessor(CollegeManager collegeManager)
    {
        Console.Write("Enter professor name: ");
        string name = Console.ReadLine();
        collegeManager.AddProfessor(name);
        Console.WriteLine("Professor added successfully.");
    }

    static void AddClass(CollegeManager collegeManager)
    {
        Console.Write("Enter course name: ");
        string className = Console.ReadLine();
        collegeManager.AddCourse(className);
        Console.WriteLine("Class added successfully.");
    }
    // AI GENERATED step 1 in order to complete steps 2-3.

    static void EnrollStudent(CollegeManager collegeManager)
    {
        Console.Write("Enter student ID: ");
        int studentID;
        if (!int.TryParse(Console.ReadLine(), out studentID))
        {
            Console.WriteLine("Invalid input. Student ID must be a number.");
            return;
        }

        Console.Write("Enter class name: ");
        string className = Console.ReadLine();

        string result = collegeManager.EnrollStudent(studentID, className);
        Console.WriteLine(result);
    }

    static void ViewEnrolledStudents(CollegeManager collegeManager)
    {
        Console.Write("Enter class name: ");
        string className = Console.ReadLine();

        collegeManager.DisplayEnrolledStudents(className);
    }
}

// My code starts here  My code starts here My code starts here My code starts here
// My code starts here  My code starts here My code starts here My code starts here
// My code starts here  My code starts here My code starts here My code starts here
// My code starts here  My code starts here My code starts here My code starts here



// Manager for managing students, professors, and courses
class CollegeManager
{
    private List<Student> students;
    private List<Professor> professors;
    private List<Course> courses;

    // initialize the lists of students, professors, courses
    public CollegeManager()
    {
        students = new List<Student>();
        professors = new List<Professor>();
        courses = new List<Course>();
    }

    // add a new student to the system
    public void AddStudent(string name)
    {
        int studentID = students.Count + 1;  // Automatic ID assignment
        students.Add(new Student(studentID, name));
    }

    // add a new professor
    public void AddProfessor(string name)
    {
        int professorID = professors.Count + 1; // Automatic ID assignment
        professors.Add(new Professor(professorID, name));
    }

    // add a new course
    public void AddCourse(string courseName)
    {
        courses.Add(new Course(courseName));
    }

    // Method to enroll a student in the course
    public string EnrollStudent(int studentID, string courseName)
    {
        if (studentID <= 0 || studentID > students.Count)
            return "Invalid student ID.";

        Student student = students[studentID - 1];

        Course selectedCourse = courses.Find(c => c.CourseName == courseName);
        if (selectedCourse == null)
            return "Course not found.";

        if (selectedCourse.IsFull())
            return "Course is full.";

        if (selectedCourse.IsStudentEnrolled(studentID))
            return "Student is already enrolled in course.";

        selectedCourse.EnrollStudent(studentID);
        student.EnrollInCourse(courseName);
        return "Student enrolled in course.";
    }

    // Method to display enrolled students 
    public void DisplayEnrolledStudents(string courseName)
    {
        Course selectedCourse = courses.Find(c => c.CourseName == courseName);
        if (selectedCourse != null)
        {
            Console.WriteLine($"Enrolled students in {courseName}:");
            foreach (int studentID in selectedCourse.EnrolledStudents)
            {
                Student student = students[studentID - 1];
                Console.WriteLine($"Student ID: {student.StudentID}, Name: {student.Name}");
            }
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }
}

// Classes for representing students, professors, courses
class Student
{
    public int StudentID { get; }       // Student ID
    public string Name { get; }         // Student name
    public List<string> Courses { get; } // List of courses the student is enrolled in

    // initialize student properties
    public Student(int studentID, string name)
    {
        StudentID = studentID;
        Name = name;
        Courses = new List<string>();
    }

    // enroll the student in a course
    public void EnrollInCourse(string courseName)
    {
        Courses.Add(courseName);
    }
}

// Class to represent professor
class Professor
{
     public int ProfessorID { get; } // Professor ID
    public string Name { get; }     // Professors name

    // initialize professor properties
    public Professor(int professorID, string name)
    {
        ProfessorID = professorID;
        Name = name;
    }
}

// Class to represent a course
class Course
{
    public string CourseName { get; } // Course name
    private const int MaxStudentsPerCourse = 5; // Maximum number of students
     private int[,] enrolledStudents; // Array to store enrolled students

    // Constructor to initialize course properties
    public Course(string courseName)
    {
        CourseName = courseName;
        enrolledStudents = new int[MaxStudentsPerCourse, 1];
    }

    // Method to check if the course is fulll
    public bool IsFull()
    {
        return GetNumberOfEnrolledStudents() >= MaxStudentsPerCourse;
    }

    // Method to check if a student is already enrolled in the course
    public bool IsStudentEnrolled(int studentID)
    {
        for (int i = 0; i < MaxStudentsPerCourse; i++)
        {
            if (enrolledStudents[i, 0] == studentID)
                return true;
        }
        return false;
    }

    // Method to enroll a student in the course
    public void EnrollStudent(int studentID)
    {
        for (int i = 0; i < MaxStudentsPerCourse; i++)
        {
            if (enrolledStudents[i, 0] == 0)
            {
                enrolledStudents[i, 0] = studentID;
                break;
            }
        }
    }

    // Method to get the number of enrolled students
    private int GetNumberOfEnrolledStudents()
    {
        int count = 0;
        for (int i = 0; i < MaxStudentsPerCourse; i++)
        {
            if (enrolledStudents[i, 0] != 0)
                count++;
        }
        return count;
    }

    // Property to get a list of enrolled student IDs
    public List<int> EnrolledStudents
    {
        get
        {
            List<int> enrolledStudentIDs = new List<int>();
            for (int i = 0; i < MaxStudentsPerCourse; i++)
            {
                if (enrolledStudents[i, 0] != 0)
                    enrolledStudentIDs.Add(enrolledStudents[i, 0]);
            }
            return enrolledStudentIDs;
        }
    }
}


