using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoApp.Controllers;
using ToDoApp.Interfaces;
using ToDoApp.Models;

namespace ToDoAppTest
{
    [TestClass]
    public class ToDoControllerTests
    {
        [TestMethod]
        public void Should_ReturnView_WhenCallingIndexInToDoController()
        {
            //Arrange
            Mock<IToDoBusiness> _mockRepo = new Mock<IToDoBusiness>();
            var controller = new ToDoController(_mockRepo.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult), "Not returning view");
        }

        [TestMethod]
        public async Task Should_ReturnJsonObject_WhenCallingAddInToDoController()
        {
            //Arrange
            ToDoEntry newEntry = new ToDoEntry() { Id = 10, EntryText = "Create new entry", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null };
            Mock<IToDoBusiness> _mockRepo = new Mock<IToDoBusiness>();
            var controller = new ToDoController(_mockRepo.Object);

            //Act
            var result = await controller.Add(newEntry);

            //Assert
            Assert.IsInstanceOfType(result, typeof(JsonResult), "Not returning view");
        }

        [TestMethod]
        public async Task Should_ReturnJsonObject_WhenCallingDeleteInToDoController()
        {
            //Arrange
            int entryId = 2;
            Mock<IToDoBusiness> _mockRepo = new Mock<IToDoBusiness>();
            var controller = new ToDoController(_mockRepo.Object);

            //Act
            var result = await controller.DeleteEntry(entryId);

            //Assert
            Assert.IsInstanceOfType(result, typeof(JsonResult), "Not returning json object");
        }

        [TestMethod]
        public async Task Should_ReturnJsonObject_WhenCallingUpdateInToDoController()
        {
            //Arrange
            ToDoEntry existingEntry = new ToDoEntry() { Id = 10, EntryText = "Create new entry" };
            Mock<IToDoBusiness> _mockRepo = new Mock<IToDoBusiness>();
            var controller = new ToDoController(_mockRepo.Object);

            //Act
            var result = await controller.Update(existingEntry);

            //Assert
            Assert.IsInstanceOfType(result, typeof(JsonResult), "Not returning json object");
        }
    }
}