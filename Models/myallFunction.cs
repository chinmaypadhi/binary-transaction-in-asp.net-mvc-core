using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace binary_transaction_in_asp.net_mvc_core.Models
{
    public class myallFunction
    {
        dbsContext dbs = new dbsContext();
        College cl = new College();
        public  IEnumerable<College> disp
        {
            get
            {
                var sql = from k in dbs.Students
                          from k1 in dbs.Employees
                          where k.StudentId == k1.EmpId
                          select new
                          {
                              clgId = k.StudentId,
                              StudentName = k.StudentName,
                              StudentCity = k.StudentCity,
                              EmpName = k1.EmpName,
                              EmpSalary = k1.EmpSalary
                          };
                List<College> ds = new List<College>();
                College reft = null;
                foreach (var s in sql)
                {
                    reft = new College { clgId = s.clgId, StudentName = s.StudentName, StudentCity =s.StudentCity, EmpName =s.EmpName,EmpSalary = s.EmpSalary };
                    ds.Add(reft);
                }
                return ds.AsEnumerable<College>();
            }

        }
        public void create(College clg)
        {
            Student st = new Student() { StudentId = clg.clgId, StudentName = clg.StudentName, StudentCity = clg.StudentCity };
            Employee emp = new Employee() { EmpId = clg.clgId, EmpName = clg.EmpName, EmpSalary = clg.EmpSalary };
            dbs.Students.Add(st);
            dbs.Employees.Add(emp);
            dbs.SaveChanges();
        }

        public void delete(int id)
        {
            College data = disp.Single(k => k.clgId == id);
            Student std = new Student() { StudentId = data.clgId, StudentName = data.StudentName, StudentCity = data.StudentCity };
            Employee emp = new Employee() { EmpId = data.clgId, EmpName = data.EmpName, EmpSalary = data.EmpSalary };
            dbs.Students.Remove(std);
            dbs.Employees.Remove(emp);
            dbs.SaveChanges();
        }

        public College search(int id)
        {
            College data = disp.Single(k => k.clgId == id);
            return data;
        }

    }
}
