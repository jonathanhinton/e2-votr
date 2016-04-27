﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Votr.Models;
using Votr.DAL;
using System.Data.Entity;
using System.Linq;

namespace Votr.Tests.Models
{
    [TestClass]
    public class PollTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Validation.DbEntityValidationException))]
        public void PollEnsureICanCreateInstance()
        {
            Poll p = new Poll();
            Assert.IsNotNull(p);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Validation.DbEntityValidationException))]
        public void PollEnsureICanSaveAPoll()
        {
            // Arrange
            VotrContext context = new VotrContext();
            Poll p = new Poll();

            // Act
            context.Polls.Add(p);
            context.SaveChanges();

            // Assert
            Assert.AreEqual(1, context.Polls.Find().PollId);
        }

        [TestMethod]
        public void PollEnsureInstanceIsValid1()
        {
            // Arrange
            VotrContext context = new VotrContext();
            Poll p = new Poll();

            p.StartDate = DateTime.Now;
            p.EndDate = DateTime.Now;
            p.Title = "My First Poll";

            // Act
            context.Polls.Add(p);
            //context.SaveChanges();

            // Assert
            Assert.IsTrue(context.Polls.Count() > 1);
        }

        [TestMethod]
        public void PollEnsureInstanceIsValid2()
        {
            // Arrange
            VotrContext context = new VotrContext();
            // Alternative way of initializing a Poll
            Poll p = new Poll { Title = "Another Poll", EndDate = DateTime.Now, StartDate = DateTime.Now};

            // Act
            context.Polls.Add(p);
            //context.SaveChanges();

            // Assert
            Assert.IsTrue(context.Polls.Count() > 1);
        }

        [TestMethod]
        public void PollEnsureInstanceIsValid1()
        {
            //Arrange
            VotrContext context = new VotrContext();
            Poll p = new Poll();

            p.StartDate = DateTime.Now;
            p.EndDate = DateTime.Now;
            p.Title = "My First Poll";


            // Act
            context.Polls.Add(p);
            context.SaveChanges();

            //Assert
            Assert.IsTrue(context.Polls.Count() > 1);
        }

        [TestMethod]
        public void PollEnsureInstanceIsValid2()
        {
            //Arrange
            VotrContext context = new VotrContext();

            //Alternate way of initializing a poll
            Poll p = new Poll { Title = "another Poll", EndDate = DateTime.Now, StartDate = DateTime.Now};
            
            // Act
            context.Polls.Add(p);
            context.SaveChanges();

            //Assert
            Assert.IsTrue(context.Polls.Count() > 1);

        }
    }
}
