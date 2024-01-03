using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp3
{
    internal class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }

        static void Main(String[] args)
        {
            List<Student> students = ReadDataFromFile("\"C:\\Users\\nishc\\Documents\\pp3.txt\"");

            // Sort students by name
            students = students.OrderBy(s => s.Name).ToList();

            DisplayStudents(students);

            // Search for a student by name
            Console.Write("Enter student name to search: ");
            string searchName = Console.ReadLine();
            SearchAndDisplayStudents(students, searchName);
        }

        static List<Student> ReadDataFromFile(string filePath)
        {
            List<Student> students = new List<Student>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] data = line.Split(',');
                    students.Add(new Student { Name = data[0].Trim(), Class = data[1].Trim() });        
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return students;
        }

        static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine("Sorted Student Data:");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Class: {student.Class}");
            }
            Console.WriteLine();
        }

        static void SearchAndDisplayStudents(List<Student> students, string searchName)
        {
            Student foundStudent = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
            if (foundStudent != null)
            {
                Console.WriteLine($"Found student: {foundStudent.Name}, Class: {foundStudent.Class}");
            }
            else
            {
                Console.WriteLine($"Student '(searchName)' not found.");
            }
        }
    }

    
}

