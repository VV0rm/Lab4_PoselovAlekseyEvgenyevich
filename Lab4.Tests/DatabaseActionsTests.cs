using NUnit.Framework;
using DatabaseActionsLibrary.Model;
using DatabaseActionsLibrary;
using System.Collections.Generic;

namespace Lab4.Tests
{
    [TestFixture]
    public class DatabaseActionsTests
    {
        [Test]
        public void GetByID_ValidIndex_ReturnsMessage()
        {
            // Arrange
            int index = 56;
            ActionsDB parser = new ActionsDB();

            // Act
            Messages_users message = parser.GetByID(index);

            // Assert
            Assert.IsNotNull(message);
            Assert.AreEqual(index, message.Id_message);
        }

        [Test]
        public void GetByID_InvalidIndex_ReturnsNull()
        {
            // Arrange
            int index = int.MaxValue;
            ActionsDB parser = new ActionsDB();

            // Act
            Messages_users message = parser.GetByID(index);

            // Assert
            Assert.IsNull(message);
        }

        [Test]
        public void GetByName_ValidName_ReturnsMessage()
        {
            // Arrange
            string name = "svansvan";
            ActionsDB parser = new ActionsDB();

            // Act
            List<Messages_users> message = parser.GetByName(name);

            // Assert
            Assert.IsNotNull(message);
            Assert.AreEqual(name, message[1].Login_user);
        }

        [Test]
        public void GetByName_InvalidName_ReturnsNull()
        {
            // Arrange
            string name = "NoName";
            ActionsDB parser = new ActionsDB();

            // Act
            List<Messages_users> message = parser.GetByName(name);

            // Assert
            Assert.IsNull(message);
        }

        [Test]
        public void Add_AddsMessagesToDatabase()
        {
            // Arrange
            ActionsDB parser = new ActionsDB();

            // Act
            parser.Add();

            // Assert
            Assert.AreEqual(parser.Add(), "Данные успешно добавлены");
        }

        [Test]
        public void Update_ValidIndex_UpdatesMessage()
        {
            // Arrange
            int index = 56;
            ActionsDB parser = new ActionsDB();

            // Act
            parser.Update(index);

            // Assert
            Assert.AreEqual(parser.Update(index), "Данные успешно изменены");
        }

        [Test]
        public void Update_ValidIndex_UpdatesNotExistingMessage()
        {
            // Arrange
            int index = int.MaxValue;
            ActionsDB parser = new ActionsDB();

            // Act
            parser.Update(index);

            // Assert
            Assert.AreEqual(parser.Update(index), "Неверный Id сообщения");
        }

        [Test]
        public void Delete_ValidIndex_DeletesMessage()
        {
            // Arrange
            int index = 56;
            ActionsDB parser = new ActionsDB();

            // Act
            parser.Delete(index);

            // Assert
            Assert.AreEqual(parser.Delete(index), "Данные успешно удалены");       
        }

        [Test]
        public void Delete_ValidIndex_DeletesMotExistingMessage()
        {
            // Arrange
            int index = int.MaxValue;
            ActionsDB parser = new ActionsDB();

            // Act
            parser.Delete(index);

            // Assert
            Assert.AreEqual(parser.Delete(index), "Неверный Id сообщения");
        }
    }
}
