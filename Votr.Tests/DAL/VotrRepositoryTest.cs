using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Votr.DAL;
using System.Collections.Generic;
using Votr.Models;
using Moq;
using System.Linq;
using System.Data.Entity;

namespace Votr.Tests.DAL
{
    [TestClass]
    public class VotrRepositoryTest
    {
        //these two methods will run before and after every single test in order to set up a mock database in which to test methods, and then remove info so that there is no residual data that gets in the database.
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void RepoEnsureICanCreateInstance()
        {
            VotrRepository repo = new VotrRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureIsUsingContext()
        {
            // Arrange 
            VotrRepository repo = new VotrRepository();

            // Act

            // Assert
            Assert.IsNotNull(repo.context);
        }

        [TestMethod]
        public void RepoEnsureThereAreNoPolls()
        {

            //Mocking
            List<Poll> datasource = new List<Poll>();
            Mock<VotrContext> mock_context = new Mock<VotrContext>();
            Mock<DbSet<Poll>> mock_polls_table = new Mock<DbSet<Poll>>(); // Fake Polls Table

            // Arrange 
            VotrRepository repo = new VotrRepository(mock_context.Object); //Injects mocked (fake) VotrContext
            //IQueryable<Poll> data = datasource.AsQueryable(); //turn List<Poll> into something we can query with System.Linq | must be using System.Linq for this to work.
            var data = datasource.AsQueryable(); //<--This is another option. and Casting

            // telling our fake DBset to user our datasource like something Queryable, all four lines are necessary
            mock_polls_table.As<IQueryable<Poll>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_polls_table.As<IQueryable<Poll>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_polls_table.As<IQueryable<Poll>>().Setup(m => m.Expression).Returns(data.Expression);
            mock_polls_table.As<IQueryable<Poll>>().Setup(m => m.Provider).Returns(data.Provider);

            // Tell our mocked VotrContext to use our fully mocked datasource. (List<Poll>)
            mock_context.Setup(m => m.Polls).Returns(mock_polls_table.Object);

            // Act
            List<Poll> list_of_polls = repo.GetPolls();
            List<Poll> expected = new List<Poll>();

            // Assert
            Assert.AreEqual(expected.Count, list_of_polls.Count);
        }

        [TestMethod]
        public void RepoEnsurePollCountIsZero()
        {
            // Arrange 
            VotrRepository repo = new VotrRepository();

            // Act
            int expected = 0;
            int actual = repo.GetPollCount();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepoEnsureICanAddPoll()
        {
            // Arrange
            VotrRepository repo = new VotrRepository();

            // Act
            repo.AddPoll("Some Title", DateTime.Now, DateTime.Now); // Not there yet.
            int actual = repo.GetPollCount(); 
            int expected = 1;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
