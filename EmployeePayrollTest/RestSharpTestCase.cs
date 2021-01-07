using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

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
        /// Gets the employee list.
        /// </summary>
        /// <returns></returns>
        public IRestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/employee", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }

        /// <summary>
        /// On the calling get API return employee list.
        /// </summary>
        [TestMethod]
        public void GivenonCalling_WhenGetApi_ThenReturnEmployeeList()
        {
            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Employee> dataResorce = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(5, dataResorce.Count);
            foreach(Employee e in dataResorce)
            {
                System.Console.WriteLine("id,: " + e.id + ",name:" + e.name + ",Salary:" + e.Salary);
            }
        }
        
        /// <summary>
        /// Ons the calling get API return employee list.
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
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
            Employee dataResorce = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("max", dataResorce.name);
            Assert.AreEqual("14748", dataResorce.Salary);
            System.Console.WriteLine(response.Content);
        }
    }
}