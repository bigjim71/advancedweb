using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace EmployeeDBApplication
{
    class Program
    {

        private static string database_name = "leicester";
        private static string user_id = "leicester";
        private static string password = "leicester1";
        private static string dataSource = "192.168.5.131";

        static void Main(string[] args)
        {


            Program app = new Program();
            // The loop will print every employee in the list
            foreach
            (Employee e in app.getAllEmployees())
            {
                Console
                .WriteLine(e);
                // Employee overrided ToString() method 
            }

            string s = Console.ReadLine();     //Pause
        }

        static MySqlConnection getConnection()
        {
            //this static method will return a connection constructed by connection string
            string myConnectionString = "Database=" + database_name + ";DataSource="+dataSource+";User Id=" + user_id + ";Password=" + password;
            MySqlConnection connection = new MySqlConnection(myConnectionString);
            return connection;
        }

        public List<Employee> getAllEmployees() { //a list of employees
            List<Employee> employees = new List<Employee>();
            try
                {
                    //Open connection
                    MySqlConnection connection = getConnection();
                    connection.Open();
                    // SQL query assignment
                    MySqlCommand mycm = new MySqlCommand
                        ("select * from employee", connection);
                    //execute query
                    MySqlDataReader msdr = mycm.ExecuteReader();
                    while(msdr.Read()){
                        if(msdr.HasRows){
                            Employee e = new Employee();       
                            //read each column and assign value to corresponding property of Employee
                            e.Id = msdr.GetInt32("id");
                            e.Firstname = msdr.GetString("firstname");
                            e.Lastname = msdr.GetString("lastname");
                            e.Salary = msdr.GetDouble("salary");
                            e.Address = msdr.GetString("address");
                            //add this employee to the list
                            employees.Add(e);
                        }
                    }
                    msdr.Close();
                    connection.Close();
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.ToString());           
                }
                //return employee list
                return employees;       
        }

        public List<Employee> advancedSearch(string key) { 
           //a list of employees 
            List<Employee> employees = new List<Employee>(); 
            try 
            {     
                if (key.Contains('*')) 
                {    //replace wild card character with '%' 
                    key = key.Replace('*', '%'); 
                } 
                else {    
                    //look up keyword in the whole string if it doesn't contain wild card, 
                    key = "%" + key + "%"; 
                } 
                //Open connection 
                MySqlConnection connection = getConnection(); 
                connection.Open(); 
                //assign SQL query 
                MySqlCommand mycm = new MySqlCommand("select * from employee where lower(address) like '"+key.ToLower()+"'", connection); 
                //execute query 
                MySqlDataReader msdr = mycm.ExecuteReader(); 
                while (msdr.Read())  
                { 
                    if (msdr.HasRows) 
                    { 
                        Employee e = new Employee(); 
                        //read each column and assign value to corresponding property of Employee 
                        e.Id = msdr.GetInt32("id"); 
                        e.Firstname = msdr.GetString("firstname"); 
                        e.Lastname = msdr.GetString("lastname"); 
                        e.Salary = msdr.GetDouble("salary"); 
                        e.Address = msdr.GetString("address"); 
                        //add this employee to the list 
                        employees.Add(e);
                    }
                }
                msdr.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //return employee list 
            return employees;
        }

        public bool deleteEmployeeById(int id) {
            try 
            { 
                MySqlConnection connection = getConnection(); 
                connection.Open(); 
                MySqlCommand mycm = new MySqlCommand("", connection); 
                mycm.Prepare(); 
                mycm.CommandText = String.Format("delete from employee where id=?id_para"); 
                mycm.Parameters.AddWithValue("?id_para", id); 
                mycm.ExecuteNonQuery(); 
                connection.Close(); 
                return true; //successful 
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString()); 
                return false; //fail 
            }     
        }

    }
}