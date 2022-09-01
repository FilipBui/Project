using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using SpearSharp.Database;
using SpearSharp.Models;

namespace SpearSharpTests
{
    public class MoqData
    {
        public static  Moq.Mock<ApplicationDbContext> CreateMoqData()
        {

            Fixture fixture = new Fixture();
            var data = new List<Kingdom>
            {
                new Kingdom("Test"),
                fixture.Build<Kingdom>().Create(),
                fixture.Build<Kingdom>().With(k => k.Id == 1).Create(),
                fixture.Build<Kingdom>().With(k => k.Id == 2).With(k => k.KingdomName == "Test").Create(),
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Kingdom>>();

            mockSet.As<IQueryable<Kingdom>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Kingdom>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Kingdom>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Kingdom>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();

            mockContext.Setup(c => c.Kingdoms).Returns(mockSet.Object);

            return mockContext;
        }

        public static Mock<DbSet<T>> SetupMockSet<T>(IQueryable<T> data) where T : class                         //T = generic object
        {
            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }
    }
}

