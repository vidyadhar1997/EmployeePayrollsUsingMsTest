using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace RestSharpTestCase
{
    /// <summary>
    /// Employy model class.
    /// </summary>
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Salary { get; set; }
    }

    [TestClass]
    public class RestSharpTestCase
    {
        RestClient client;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }

        /// <summary>
        /// Get the employee list.
        /// </summary>
        /// <returns></returns>
        public IRestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/employee", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }

        /// <summary>
        /// given on calling get api then return employee list 
        /// </summary>
        [TestMethod]
        public void GivenOnCalling_WhenGetApi_ThenReturnEmployeeList()
        {
            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Employee> dataResorce = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(8, dataResorce.Count);
            foreach (Employee e in dataResorce)
            {
                System.Console.WriteLine("id,: " + e.id + ",name:" + e.name + ",Salary:" + e.Salary);
            }
        }

        /// <summary>
        /// given employee when post then should return employee.
        /// </summary>
        [TestMethod]
        public void GivenEmployee_WhenOnPost_ThenShouldReturnEmployee()
        {
            RestRequest request = new RestRequest("/employee", Method.POST);
            JObject jObjectBody = new JObject();
            jObjectBody.Add("name", "max");
            jObjectBody.Add("Salary", "14748");
            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode,HttpStatusCode.Created);
            Employee dataResorce = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("max", dataResorce.name);
            Assert.AreEqual("14748", dataResorce.Salary);
            System.Console.WriteLine(response.Content);
        }

        [TestMethod]
        public void GivenMultipleEmployee_WhenOnPost_ThenShouldReturnEmployeeList()
        {
            List<Employee> employeeListRestApi = new List<Employee>();
            employeeListRestApi.Add(new Employee { name = "prem", Salary = "350000" });
            employeeListRestApi.Add(new Employee { name = "dhiru", Salary = "450000" });
            employeeListRestApi.Add(new Employee { name = "suresh", Salary = "55000000" });
            employeeListRestApi.ForEach(employeeData =>
            {
                RestRequest request = new RestRequest("/employee", Method.POST);
                JObject jObjectBody = new JObject();
                jObjectBody.Add("name", employeeData.name);
                jObjectBody.Add("Salary", employeeData.Salary);
                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
                Employee dataResorce = JsonConvert.DeserializeObject<Employee>(response.Content);
                Assert.AreEqual(employeeData.name, dataResorce.name);
                Assert.AreEqual(employeeData.Salary, dataResorce.Salary);
                System.Console.WriteLine(response.Content);
            });
            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> dataResorce = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(8, dataResorce.Count);
        }
    }
}