﻿using System.Data;
using System.Data.SqlClient;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace HighSchoolSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-4SNMTAT; Initial Catalog=HighSchool; Integrated Security=true");

            //EF
            //Scaffold - DbContext "Server=DESKTOP-4SNMTAT;Database=HighSchool;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models

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

                    case "0":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}