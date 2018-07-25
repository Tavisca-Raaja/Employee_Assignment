using System;
using System.Collections.Generic;
using System.IO;
namespace Employee
{
    public delegate void Disp(string Name, String Message);
    public class QualificationRequiredException : Exception
    {
        public QualificationRequiredException() : base()
        {
        }
        public QualificationRequiredException(String message) : base(string.Format("Enter a valid qualification"))
        {
        }

    }
    class EmployeeDetails
    {
        private string EmployeeName;
        private string EmployeeId;
        private string Qualification;
        private string Age;
        private string ContactNumber;
        private string Department;
        public EmployeeDetails()
        {
            EmployeeName = "";
            EmployeeId = "";
            Qualification = "";
            Age = "";
            ContactNumber = "";
            Department = "";
        }
        public string EName
        {
            get
            {
                return this.EmployeeName;
            }
            set
            {
                this.EmployeeName = value;

            }
        }
        public string EmpId
        {
            get
            {
                return this.EmployeeId;
            }
            set
            {
                this.EmployeeId = value;

            }
        }
        public string EmpQual
        {
            get
            {
                return this.Qualification;
            }
            set
            {
                this.Qualification = value;

            }
        }
        public string EmpAge
        {
            get
            {
                return this.Age;
            }
            set
            {
                this.Age = value;

            }
        }
        public string Number
        {
            get
            {
                return this.ContactNumber;
            }
            set
            {
                this.ContactNumber = value;

            }
        }
        public string Depart
        {
            get
            {
                return this.Department;
            }
            set
            {
                this.Department = value;

            }
        }

    }
    class Program
    {

        static List<EmployeeDetails> list = new List<EmployeeDetails>();

        public static void Display(string name, string Dpt)
        {
            Console.WriteLine("{0} added in {1} department", name, Dpt);
        }

        public static void validateQualification(String qualificationcheck)
        {
            if (qualificationcheck.Equals(""))
                throw new QualificationRequiredException(qualificationcheck);
        }

        static void Main(string[] args)
        {
            String localdepart = "";
            Console.WriteLine("Do You Want to Add Employees");
            string choice = Console.ReadLine();
            while (choice != "Exit")
            {
                EmployeeDetails emp = new EmployeeDetails();
                Console.WriteLine("Employee Name:");
                emp.EName = Console.ReadLine();
                Console.WriteLine("Employee Id:");
                emp.EmpId = Console.ReadLine();
                Console.WriteLine("Employee Age:");
                emp.EmpAge = Console.ReadLine();
                Console.WriteLine("Employee Contact Number:");
                emp.Number = Console.ReadLine();
                try
                {
                    Console.WriteLine("Employee Qualification:");
                    emp.EmpQual = Console.ReadLine();
                    validateQualification(emp.EmpQual);
                    if (emp.EmpQual.Equals("BE") || emp.EmpQual.Equals("B.SC") || emp.EmpQual.Equals("BCA"))
                    {
                        localdepart = "IT";
                    }
                    
                    else if (emp.EmpQual.Equals("B.COM") || emp.EmpQual.Equals("M.COM") || emp.EmpQual.Equals("CA"))
                    {
                        localdepart = "Accounts";
                    }

                    emp.Depart = localdepart;
                    Disp msg = new Disp(Display);
                    msg(emp.EName, emp.Depart);

                    list.Add(emp);

                }
                catch (QualificationRequiredException ex)
                {
                                   StreamWriter str = null;
                    Console.WriteLine(ex.Message);
                    using (FileStream file = new FileStream("C:\\Users\\raaja\\source\\repos\\Employee\\Employee\\log_test.txt", FileMode.Append))
                    {
                        using (str = new StreamWriter(file))
                            str.WriteLine(ex.Message + " " + DateTime.Today.ToString("yyyyMMdd"));
                    }
                   // if (str != null)
                      //  str.Close();//streamwriter is closed manually
                }
                finally
                {
                    

                    Console.WriteLine("Do You Want to Add Employees or type exit");
                    choice = Console.ReadLine();
                }

            }
            foreach (EmployeeDetails em in list)
            {
                Console.WriteLine(em.EName + " " + em.EmpId + " " + em.EmpAge + " " + em.Depart);
            }

        }
    }
}






