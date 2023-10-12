namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
        private Mock<IStudentLogic> studentLogicMock;
        private StudentController controller;

        [TestInitialize]
        public void Initialize()
        {
                studentLogicMock = new Mock<IStudentLogic>();
                controller = new StudentController(studentLogicMock.Object);
        }

        [TestMethod]
        public void PostStudentOk()
        {
                var student = new Student();
                studentLogicMock.Setup(x => x.InsertStudents(student));

                var result = controller.PostStudent(student);

                var objectResult = result as ObjectResult;
                Assert.IsNotNull(objectResult);
                Assert.AreEqual(200, objectResult.StatusCode);
        }

        [TestMethod]
        public void PostStudentFail()
        {
                var student = new Student();
                studentLogicMock.Setup(x => x.InsertStudents(student)).Throws(new Exception());

                var result = controller.PostStudent(student);

                var objectResult = result as ObjectResult;
                Assert.IsNotNull(objectResult);
                Assert.AreEqual(400, objectResult.StatusCode);
        }
}
