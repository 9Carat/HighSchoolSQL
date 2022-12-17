using HighSchoolSQL.Data;
using HighSchoolSQL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HighSchoolSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-5I099SK; Initial Catalog=HighSchool; Integrated Security=true");

            string selection = "1";

            while (selection != "0")
            {
                Console.WriteLine("Please select one of the folowing options:");
                Console.WriteLine("1. Show all staff members.");
                Console.WriteLine("2. Show the principal.");
                Console.WriteLine("3. Show all teachers.");
                Console.WriteLine("4. Show all janitors.");
                Console.WriteLine("5. Show all grades in the latest month");
                Console.WriteLine("6. Show a list of all courses together with the average, highest and lowest grade ");
                Console.WriteLine("7. Display a list of all students");
                Console.WriteLine("8. Display a list of all students in a selected class");
                Console.WriteLine("9. Add students");
                Console.WriteLine("10. Add staff members");
                Console.WriteLine("0. Exit the program.");
                selection = Console.ReadLine();
                Console.Clear();

                switch (selection)
                {
                    case "1":
                        SqlDataAdapter sqlDat = new SqlDataAdapter("Select * From Staff", sqlcon);
                        DataTable dtTable = new DataTable();
                        sqlDat.Fill(dtTable);

                        foreach (DataRow dr in dtTable.Rows)
                        {
                            Console.Write(dr["first_name"]);
                            Console.Write(" ");
                            Console.Write(dr["last_name"]);
                            Console.Write(" - ");
                            Console.Write(dr["staff_role"]);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "2":
                        SqlDataAdapter sqlDat2 = new SqlDataAdapter("Select * From Staff where staff_role = 'Principal'", sqlcon);
                        DataTable dtTable2 = new DataTable();
                        sqlDat2.Fill(dtTable2);

                        foreach (DataRow dr in dtTable2.Rows)
                        {
                            Console.Write(dr["first_name"]);
                            Console.Write(" ");
                            Console.Write(dr["last_name"]);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        SqlDataAdapter sqlDat3 = new SqlDataAdapter("Select * From Staff where staff_role = 'Teacher'", sqlcon);
                        DataTable dtTable3 = new DataTable();
                        sqlDat3.Fill(dtTable3);

                        foreach (DataRow dr in dtTable3.Rows)
                        {
                            Console.Write(dr["first_name"]);
                            Console.Write(" ");
                            Console.Write(dr["last_name"]);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "4":
                        SqlDataAdapter sqlDat4 = new SqlDataAdapter("Select * From Staff where staff_role = 'Janitor'", sqlcon);
                        DataTable dtTable4 = new DataTable();
                        sqlDat4.Fill(dtTable4);

                        foreach (DataRow dr in dtTable4.Rows)
                        {
                            Console.Write(dr["first_name"]);
                            Console.Write(" ");
                            Console.Write(dr["last_name"]);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "5":

                        SqlDataAdapter sqlDat5 = new SqlDataAdapter("select * from last_months_grades", sqlcon);
                        DataTable dtTable5 = new DataTable();
                        sqlDat5.Fill(dtTable5);

                        foreach (DataRow dr in dtTable5.Rows)
                        {
                            Console.Write(dr["first_name"]);
                            Console.Write(" ");
                            Console.Write(dr["last_name"]);
                            Console.Write(" - ");
                            Console.Write(dr["course_name"]);
                            Console.Write(" - ");
                            Console.Write(dr["grade"]);
                            Console.Write(" - ");
                            Console.Write(dr["grade_date"]);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "6":

                        SqlDataAdapter sqlDat6 = new SqlDataAdapter("select * from avg_min_max_grade", sqlcon);
                        DataTable dtTable6 = new DataTable();
                        sqlDat6.Fill(dtTable6);

                        Console.Write("Course name");
                        Console.Write(" - ");
                        Console.Write("Average grade");
                        Console.Write(" - ");
                        Console.Write("Max grade");
                        Console.Write(" - ");
                        Console.Write("Min grade");
                        Console.WriteLine();

                        foreach (DataRow dr in dtTable6.Rows)
                        {
                            Console.Write(dr["course_name"]);
                            Console.Write(" - ");
                            Console.Write(dr["average_grade"]);
                            Console.Write(" - ");
                            Console.Write(dr["max_grade"]);
                            Console.Write(" - ");
                            Console.Write(dr["min_grade"]);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "7":
                       
                        Console.WriteLine("Do you want to order the students by firstname or lastname?");
                        Console.WriteLine("1. Firstname");
                        Console.WriteLine("2. Lastname");
                        string selection2 = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Do you want to sort the list in ascending or descending order?");
                        Console.WriteLine("1. Ascending order");
                        Console.WriteLine("2. Descending order");
                        string selection3 = Console.ReadLine();
                        Console.Clear();

                        if(selection2 == "1" && selection3 == "1")
                        {
                            using (var context = new HSContext())
                            {
                                var students = from c in context.Students
                                               select c;
                                var studentList = students.OrderBy(i => i.FirstName);
                                foreach (var student in studentList)
                                {
                                    Console.Write(student.FirstName + " ");
                                    Console.Write(student.LastName + " - ");
                                    Console.Write(student.PersonalNumber + " - ");
                                    Console.Write(student.Class);
                                    Console.WriteLine();
                                }
                            }
                        }
                        else if(selection2 == "2" && selection3 == "1")
                        {
                            using (var context = new HSContext())
                            {
                                var students = from c in context.Students
                                               select c;
                                var studentList = students.OrderBy(i => i.LastName);
                                foreach (var student in studentList)
                                {
                                    Console.Write(student.FirstName + " ");
                                    Console.Write(student.LastName + " - ");
                                    Console.Write(student.PersonalNumber + " - ");
                                    Console.Write(student.Class);
                                    Console.WriteLine();
                                }
                            }
                        }
                        else if (selection2 == "1" && selection3 == "2")
                        {
                            using (var context = new HSContext())
                            {
                                var students = from c in context.Students
                                               select c;
                                var studentList = students.OrderByDescending(i => i.FirstName);
                                foreach (var student in studentList)
                                {
                                    Console.Write(student.FirstName + " ");
                                    Console.Write(student.LastName + " - ");
                                    Console.Write(student.PersonalNumber + " - ");
                                    Console.Write(student.Class);
                                    Console.WriteLine();
                                }
                            }
                        }
                        else if(selection2 == "2" && selection3 == "2")
                        {
                            using (var context = new HSContext())
                            {
                                var students = from c in context.Students
                                               select c;
                                var studentList = students.OrderByDescending(i => i.LastName);
                                foreach (var student in studentList)
                                {
                                    Console.Write(student.FirstName + " ");
                                    Console.Write(student.LastName + " - ");
                                    Console.Write(student.PersonalNumber + " - ");
                                    Console.Write(student.Class);
                                    Console.WriteLine();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong input! Please try again.");
                        }

                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "8":
                        Console.WriteLine("Select one of the following classes.");
                        Console.WriteLine("NA21A");
                        Console.WriteLine("NA21B");
                        string selection4 = Console.ReadLine().ToUpper();
                        Console.Clear();

                        using (var context = new HSContext())
                        {
                            var students = from c in context.Students
                                           select c;
                            var studentList = students.Where(i => i.Class == selection4);
                            foreach (var student in studentList)
                            {
                                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Class);
                            }
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "9":
                        {
                            Console.WriteLine("Enter the student's first name:");
                            string fName = Console.ReadLine();
                            Console.WriteLine("Enter the student's last name:");
                            string lName = Console.ReadLine();
                            Console.WriteLine("Enter the student's personal number:");
                            string personalNum = Console.ReadLine();
                            Console.WriteLine("Enter the student's class:");
                            string className = Console.ReadLine();

                            using HSContext context = new HSContext();
                            Student s1 = new Student();
                            s1.FirstName = fName;
                            s1.LastName = lName;
                            s1.PersonalNumber = personalNum;
                            s1.Class = className;
                            context.Students.Add(s1);
                            context.SaveChanges();
                            Console.WriteLine("Database updated!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                        
                    case "10":
                        {
                            Console.WriteLine("Enter the staff member's first name:");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Enter the staff member's last name:");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Enter the staff member's role :");
                            string role = Console.ReadLine();
                            
                            using HSContext context = new HSContext();
                            staff s1 = new staff();
                            s1.FirstName = firstName;
                            s1.LastName = lastName;
                            s1.StaffRole = role;
                            context.staff.Add(s1);
                            context.SaveChanges();
                            Console.WriteLine("Database updated!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}