using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TestCompanyApi
{
    [TestFixture]
    internal class RepositoryTests
    {
        //[Test]
        //public void TestRep()
        //{
        //    var context = new CompanyContext();
        //    var rep = new Repository<Employee>(context);
        //    rep.Add(new Employee() { Description = "asdfasdf", id = 4, Name = "Vasya", LastName = "Pushkin" });
        //    context.SaveChanges();


        //    if (rep.GetById(4) != null)
        //    {
        //        string name = rep.GetById(4).Name;
        //        Assert.AreEqual("Vasya", name);
        //    }
        //}

        //[Test]
        //public void findTest()
        //{
        //    var context = new CompanyContext();
        //    var rep = new Repository<Employee>(context);

        //    const string testName = "asdfg";

        //    rep.Add(new Employee() { Description = "asdfasdf", Name = testName, LastName = "Pushkin" });
        //    context.SaveChanges();
            
        //    IEnumerable<Employee> empls = rep.Find(e => e.Name == testName);
        //    var sameLastName = new List<Employee>();

        //    if (empls != null)
        //    {
        //        sameLastName.AddRange(empls.Where(employee => employee.Name == testName));
        //    }
        //}
    }
}
