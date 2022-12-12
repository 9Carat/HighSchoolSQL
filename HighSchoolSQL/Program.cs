using HighSchoolSQL.Data;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                        SqlDataAdapter sqlDat5 = new SqlDataAdapter("SELECT course_name, grade, first_name, last_name\r\nFROM Course\r\nJOIN\r\nStudent\r\nON Student.stud_id = Course.FK_stud_id\r\nWHERE grade_date > '2022-11-06'", sqlcon);
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
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "6":
                        SqlDataAdapter sqlDat6 = new SqlDataAdapter("SELECT course_name, AVG(grade) AS average_grade, MAX(grade) AS max_grade, MIN(grade) AS min_grade\r\nFROM Course\r\nGROUP BY course_name", sqlcon);
                        DataTable dtTable6 = new DataTable();
                        sqlDat6.Fill(dtTable6);

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
                        //Console.WriteLine("Do you want to order the students by firstname or lastname?");
                        //Console.WriteLine("1. Firstname");
                        //Console.WriteLine("2. Lastname");
                        //string input1 = Console.ReadLine();
                        //string order(string input1) => input = "1" ? "first_name : last_name;"
                        //Console.WriteLine("Do you want to sort the list in ascending or descending order?");
                        //string sortOrder = Console.ReadLine();

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
                                    Console.WriteLine(student.FirstName + " " + student.LastName);
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
                                    Console.WriteLine(student.FirstName + " " + student.LastName);
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
                                    Console.WriteLine(student.FirstName + " " + student.LastName);
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
                                    Console.WriteLine(student.FirstName + " " + student.LastName);
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

                    case "0":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}