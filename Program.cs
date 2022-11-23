using System;
using System.Linq;
using System.Collections.Generic;

namespace NorthWind.Linq
{
    internal class Program
    {
     
        static void Main(string[] args)
        {
            var repo = EmployeeRepository.CreateInstance();
            var employees = repo.GetAllEmployees();

            // Q-1. Find the total number of Employees present. 

            employees.Count().Dump();

            Console.WriteLine("----------------------------------------");

            // Q-2. Print only the First Name and Last Name of all the Employees . 


            var emp = employees.Select(c => new Employee { FirstName = c.FirstName, LastName = c.LastName }).ToList();

            foreach (var item in employees)
            {
                ///Console.WriteLine(item.FirstName +' '+ item.LastName);                      
            }

            Console.WriteLine("----------------------------------------");

            // Q-3. Print all the Employees whose Title is “Accountant” .


            List<Employee> emp3 = (from user in employees where user.Title == "Accountant" select user).ToList();

            foreach (var user in emp3)
            {
               /// Console.WriteLine(user.Dump());
            }

            

            Console.WriteLine("----------------------------------------");

            // Q-4. Print the Display Name along with their joining Date of all the Employees who are in “Operations”.

            List<Employee> employeeee = (from user in employees where user.Team == "Operations" select user).ToList();

            foreach (var user in employeeee)
            {
                ///Console.WriteLine(user.DisplayName + ' ' + user.HireDate);
            }

            Console.WriteLine("----------------------------------------");


            // Q-5. Print the total numbers of Titles available in the data.


            string[] emp5 = (from user in employees select user.Title).Distinct().ToArray();

            Console.WriteLine(emp5.Count());

            

            Console.WriteLine("----------------------------------------");


            // Q-6. Print all the Titles available. Make sure you do not print any title twice.

            string[] emp6 = (from user in employees select user.Title).Distinct().ToArray();

            foreach (var abcd in emp6)
            {
                Console.WriteLine(abcd);
            }

            Console.WriteLine("----------------------------------------");

            // Q-7. Print the Employees in Sorted Order. 

            var emp7 = from xyz in employees orderby xyz.CommonId select xyz;

            foreach (var user in emp7)
            {
                ///Console.WriteLine(user.Dump());
            }      
            

            Console.WriteLine("----------------------------------------");

            // Q-8. Print the Employees in Sorted Order whose Name begins with “J”

            var emp8 = from xyz in employees orderby xyz.FirstName where xyz.FirstName.Contains('J') select xyz;

            foreach (var j in emp8)
            {
               Console.WriteLine(j.Dump());
            }


            Console.WriteLine("----------------------------------------");

            // Q-9. Find the Employee who was hired First

            var emp9 = employees.OrderByDescending(x => x.HireDate).FirstOrDefault();
           
            Console.WriteLine(emp9.Dump()); 


            

            Console.WriteLine("----------------------------------------");

            // Q-10. List the Titles And the number of Employees belonging to that title in Descending Order.
            //   Make sure we don't have an empty title

            var emp10=from r in employees orderby r.Title group r by r.Title into grp select new
            {
              
                Titles=grp.Key,NumberOfEmployee=grp.Count()
            };   

            foreach (var item in emp10)
            {                                               //  GroupBy
                ///Console.WriteLine(item.Dump());
            }

            Console.WriteLine("----------------------------------------");

            // Q-11. Find the Team Leader who has the highest and lowest number of employees under him/her.

            var emp11= employees.GroupBy(employee => employee.TeamLeader).Select(gr => new
                          {   TeamLeader = gr.Key,
                              Employee = gr.Max(x => x.DisplayName)
                          });
            Console.WriteLine(emp11.Dump());


            Console.WriteLine("----------------------------------------");

            // Q-12. Find all the employees who does not have a Team Leader.

            var emp12 = employees.Where(x => x.TeamLeader == "").ToList();
           
            foreach (var item in emp12)
            {
                ///Console.WriteLine(emp12.Dump());
            }
            Console.WriteLine("----------------------------------------");

            // Q-13. Print the Team Leaders Name and Their employees names in the following format

            Employee[] arrEmp1 = employees;

            Dictionary<string, List<string>> dictleader = new Dictionary<string, List<string>>();
            foreach (Employee employee in arrEmp1)
            {
                if (!employee.TeamLeader.Equals(""))
                {
                    List<string> employee_list;
                    if (dictleader.ContainsKey(employee.TeamLeader))
                    {
                        employee_list = dictleader[employee.TeamLeader];
                    }
                    else
                    {
                        employee_list = new List<string>();
                    }
                    employee_list.Add(employee.FirstName);
                    dictleader[employee.TeamLeader] = employee_list;
                }
            }
            foreach (KeyValuePair<string, List<string>> entry in dictleader)
            {
                Console.WriteLine(entry.Key);
                Console.WriteLine("------------------------------");
                string temp = "";
                foreach (string name in entry.Value)
                {
                    temp += name + ",";
                }
                temp = temp.Substring(0, temp.Length - 1) + "\n";
                ///Console.WriteLine(temp);
            }

            Console.WriteLine("----------------------------------------");

            // Q-14. Find the 3 three year in which highest number of Employees are hired. Also print the number against each year.

            var emp14 = employees.GroupBy(x => x.HireDate);
            
           /// Console.WriteLine(emp14.Dump());

            

            Console.WriteLine("----------------------------------------");

            // Q-16.Sort the Employees as per their Display Name, Remove empty display names, Show the records with pagination. Each page should contain 10 records. 

            //var emp16 = from xyz in employees orderby xyz.DisplayName select xyz;
            
            List<Employee> empList=employees.ToList();  
            empList.Sort(delegate(Employee A,Employee B)
            {
                return A.DisplayName.CompareTo(B.DisplayName);
            }            
            ); 

            int pageNumber = 1;

            for (int i = 0; i < empList.Count(); i++)
            {
                if (i==0||i%10==0)
                {
                    Console.WriteLine("Page Number" + pageNumber);
                    Console.WriteLine("---------------");
                    //Console.WriteLine("  ");
                }
                Console.WriteLine("\"" + empList[i].DisplayName + "\"");
                if (((i + 1) % 10) == 0)
                {
                    Console.WriteLine("  ");
                    pageNumber++;
                }
            }
                
            

            Console.WriteLine("----------------------------------------");

            // Q-17. Find the Sum of Days in Office of all the employees who joined after 1st Jan 2012.


            Employee[] arrEmp = employees;
            int sum = 0;
            for (int i = 0; i < arrEmp.Length; i++)
            {
                Employee employee = arrEmp[i];
                if (employee != null && employee.HireDate != null && ((DateTime)employee.HireDate).Year >= 2012)
                {
                    sum = sum + Numberofdays((DateTime)arrEmp[i].HireDate);
                }
            }
            Console.WriteLine(sum);
           
            //Console.ReadKey();

            
        }
        public static int Numberofdays(DateTime start)
        {
            int days = -1;
            DateTime end = DateTime.Now;
            days = (int)(end - start).TotalDays;
            return days;
        }


    }
    
}

 