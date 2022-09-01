using SpearSharp.Models.DTOs;
using Moq;
using SpearSharp.Database;
using SpearSharp.Models;
using SpearSharp.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoFixture;
using Xunit;

namespace SpearSharpTests
{
    public class KingdomServiceTests
    {
        private KingdomService _kingdomService;
        private readonly Mock<IApplicationDbContext> _mockAppDbContext = new Mock<IApplicationDbContext>(); // if several dependencies - mock them all

        public KingdomServiceTests()
        {
            _kingdomService = new KingdomService(_mockAppDbContext.Object); //creates instance + provides the db context to work with
        }

        [Fact] 
        public void OneKingdom_ReturnKingdoms_ShouldReturnListWithOne()
        {
            var dataSet = new List<Kingdom> //creating data manually 
            {
                new Kingdom("Test"),
            }.AsQueryable();

            var data = MoqData.SetupMockSet<Kingdom>(dataSet); //getting mockeddb set from appdbcontext

            _mockAppDbContext.Setup(c => c.Kingdoms).Returns(data.Object); //in this dbcontext - var data = kingdom dbset/table !only kingdom!    
            
            var actual = _kingdomService.ReturnKingdoms();

            Assert.Equal(dataSet.Count(), actual.Count());
        }

        [Fact]
        public void ZeroKingdoms_ReturnKingdoms_ShouldReturnEmptyList()
        {
            var dataSet = new List<Kingdom>  
            {
            }.AsQueryable();

            var data = MoqData.SetupMockSet<Kingdom>(dataSet);  

            _mockAppDbContext.Setup(c => c.Kingdoms).Returns(data.Object);     

            var actual = _kingdomService.ReturnKingdoms();

            Assert.Equal(dataSet.Count(), actual.Count());
        }

        [Fact]
        public void TenKingdoms_ReturnKingdoms_ShouldReturnListWithTen()
        {
            var dataSet = new List<Kingdom>
            {
                new Kingdom("Test"),
                new Kingdom("Test"),
                new Kingdom("Test"),
                new Kingdom("Test"),
                new Kingdom("Test"),
                new Kingdom("Test"),
                new Kingdom("Test"),
                new Kingdom("Test"),
                new Kingdom("Test"),
                new Kingdom("Test"),
            }.AsQueryable();

            var data = MoqData.SetupMockSet<Kingdom>(dataSet);

            _mockAppDbContext.Setup(c => c.Kingdoms).Returns(data.Object);

            var actual = _kingdomService.ReturnKingdoms();

            Assert.Equal(dataSet.Count(), actual.Count());
        }

        [Fact]
        public void OneKingdom_GetKingdomIdByName_ShouldReturnCorrectId()
        {
            var dataSet = new List<Kingdom>
            {
                new Kingdom(1,"Test"),
            }.AsQueryable();
            var data = MoqData.SetupMockSet<Kingdom>(dataSet); 

            _mockAppDbContext.Setup(c => c.Kingdoms).Returns(data.Object);

            var actual = _kingdomService.GetKingdomIdByName("Test");

            Assert.Equal(1, actual);
        }

        [Fact]
        public void TenKingdoms_GetKingdomIdByName_ShouldReturnCorrectId()
        {
            var dataSet = new List<Kingdom>
            {
                new Kingdom(1,"Test"),
                new Kingdom(1,"Test"),
                new Kingdom(1,"Test"),
                new Kingdom(1,"Test"),
                new Kingdom(1,"Test"),
                new Kingdom(1,"Test"),
                new Kingdom(1,"Test"),
                new Kingdom(1,"Test"),
                new Kingdom(1,"Test"),
                new Kingdom(2,"Test2")
            }.AsQueryable();

            var data = MoqData.SetupMockSet<Kingdom>(dataSet);

            _mockAppDbContext.Setup(c => c.Kingdoms).Returns(data.Object); 

            var actual = _kingdomService.GetKingdomIdByName("Test2");

            Assert.Equal(2, actual);
        }

        [Fact]
        public void XCoordinatesTaken_AreCoordinatesTaken_ShouldReturnTrue()
        {
            var dataSet = new List<Kingdom>
            {
                new Kingdom(1,"Test", 1, 1),
            }.AsQueryable();

            var data = MoqData.SetupMockSet<Kingdom>(dataSet);

            _mockAppDbContext.Setup(c => c.Kingdoms).Returns(data.Object);

            var actual = _kingdomService.AreCoordinatesTaken(1, 1, 1);

            Assert.Equal(true, actual);
        }

        [Fact]
        public void XCoordinateTaken_AreCoordinatesTaken_ShouldReturnFalse()
        {
            var dataSet = new List<Kingdom>
            {
                new Kingdom(1,"Test", 1, 1),
            }.AsQueryable();

            var data = MoqData.SetupMockSet<Kingdom>(dataSet);

            _mockAppDbContext.Setup(c => c.Kingdoms).Returns(data.Object);

            var actual = _kingdomService.AreCoordinatesTaken(1, 1, 5);

            Assert.Equal(false, actual);
        }

        [Fact]
        public void YCoordinateTaken_AreCoordinatesTaken_ShouldReturnFalse()
        {
            var dataSet = new List<Kingdom>
            {
                new Kingdom(1,"Test", 1, 1),
            }.AsQueryable();

            var data = MoqData.SetupMockSet<Kingdom>(dataSet);

            _mockAppDbContext.Setup(c => c.Kingdoms).Returns(data.Object);

            var actual = _kingdomService.AreCoordinatesTaken(1, 5, 1);

            Assert.Equal(false, actual);
        }

        [Fact]
        public void CoordinatesNotTaken_AreCoordinatesTaken_ShouldReturnFalse()
        {
            var dataSet = new List<Kingdom>
            {
                new Kingdom(1,"Test", 1, 1),
            }.AsQueryable();

            var data = MoqData.SetupMockSet<Kingdom>(dataSet);

            _mockAppDbContext.Setup(c => c.Kingdoms).Returns(data.Object);

            var actual = _kingdomService.AreCoordinatesTaken(1, 5, 5);

            Assert.Equal(false, actual);
        }

    }
}

