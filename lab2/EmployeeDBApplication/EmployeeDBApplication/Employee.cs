using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeDBApplication
{
    class Employee
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string firstname;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }


        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        private double salary;

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public override string ToString()
        {
            //return base.ToString();
            return "Employee    ID:" + this.id;
        }

    }
}
