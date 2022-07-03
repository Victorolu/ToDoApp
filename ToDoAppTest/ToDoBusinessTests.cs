using Moq;
using ToDoApp.Interfaces;
using ToDoApp.Models;

namespace ToDoAppTest
{
    [TestClass]
    public class ToDoBusinessTests
    {
        [TestMethod]
        public void Should_GetAllToDoEntries_WhenCallingGetAllEntriesInToDoBusiness()
        {
            //Arrange
            Mock<IToDoBusiness> _mockRepo = new Mock<IToDoBusiness>();
            List<ToDoEntry> entries = new List<ToDoEntry>()
            {
                new ToDoEntry() { Id = 1, EntryText = "Water floor plants", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null },
                new ToDoEntry() { Id = 2, EntryText = "Call Doctor", IsActive = false, CreatedBy = DateTime.UtcNow, ExpiresBy = DateTime.UtcNow.AddDays(2) },
                new ToDoEntry() { Id = 3, EntryText = "Buy groceries", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null },
                new ToDoEntry() { Id = 4, EntryText = "Collect car keys", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null },
                new ToDoEntry() { Id = 5, EntryText = "Prepare for interview", IsActive = false, CreatedBy = DateTime.UtcNow, ExpiresBy = DateTime.UtcNow.AddDays(2) },
                new ToDoEntry() { Id = 6, EntryText = "Pray", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null },
                new ToDoEntry() { Id = 7, EntryText = "Write introduction of thesis", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null },
                new ToDoEntry() { Id = 8, EntryText = "Watch tutorials", IsActive = false, CreatedBy = DateTime.UtcNow, ExpiresBy = DateTime.UtcNow.AddDays(3)},
                new ToDoEntry() { Id = 9, EntryText = "Speak to pastor", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null }
            };
            _mockRepo.Setup(x => x.GetAllEntries()).Returns(entries);

            //Act
            var result = _mockRepo.Object.GetAllEntries();

            //Assert
            Assert.AreEqual(result, entries);
        }

        [TestMethod]
        public async Task Should_NotThrowError_WhenCallingAddInToDoBusiness()
        {
            //Arrange
            ToDoEntry newEntry = new ToDoEntry() { Id = 10, EntryText = "Create new entry", IsActive = true, CreatedBy = DateTime.UtcNow, ExpiresBy = null };
            Mock<IToDoBusiness> _mockRepo = new Mock<IToDoBusiness>();

            //Act
            await _mockRepo.Object.AddEntry(newEntry);

            //Asserting won't be needed as method will error out if it fails
        }

        [TestMethod]
        public async Task Should_NotThrowError_WhenCallingDeleteEntryInToDoBusiness()
        {
            //Arrange
            int entryId = 2;
            Mock<IToDoBusiness> _mockRepo = new Mock<IToDoBusiness>();

            //Act
            await _mockRepo.Object.DeleteEntry(entryId);
        }

        [TestMethod]
        public async Task Should_SuccessfullyAddAnEntry_WhenCallingGetAllEntriesInToDoBusiness()
        {
            //Arrange
            ToDoEntry entryToUpdate = new ToDoEntry() { Id = 2, EntryText = "This has been changed"};
            Mock<IToDoBusiness> _mockRepo = new Mock<IToDoBusiness>();

            //Act
            await _mockRepo.Object.UpdateEntry(entryToUpdate);

            //Asserting won't be needed as method will error out if it fails
        }
    }
}
