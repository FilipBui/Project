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
    public class RulesServiceTests
    {
        private RulesService _rulesService;
        private readonly Mock<IApplicationDbContext> _mockAppDbContext = new Mock<IApplicationDbContext>(); // if several dependencies - mock them all

        public RulesServiceTests()
        {
            _rulesService = new RulesService(_mockAppDbContext.Object); //creates instance + provides the db context to work with
        }

        [Fact]
        public void CorrectInput_GetBuildingCostFarm_ShouldReturnCorrectAmount()
        {
            var dataSet = new List<BuildingTemplate>
            {
                new BuildingTemplate() {Type = "Farm", Cost = 100},
            }.AsQueryable();

            var data = MoqData.SetupMockSet<BuildingTemplate>(dataSet);

            _mockAppDbContext.Setup(c => c.BuildingsTemplate).Returns(data.Object);

            var actual = _rulesService.GetBuildingCost("Farm", 1);

            Assert.Equal(100, actual);
        }

        [Fact]
        public void EmptyType_GetBuildingCostFarm_ShouldReturn0()
        {
            var dataSet = new List<BuildingTemplate>
            {
                new BuildingTemplate() {Type = "Farm", Cost = 100},
            }.AsQueryable();

            var data = MoqData.SetupMockSet<BuildingTemplate>(dataSet);

            _mockAppDbContext.Setup(c => c.BuildingsTemplate).Returns(data.Object);

            var actual = _rulesService.GetBuildingCost("", 1);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void LevelIs0_GetBuildingCostFarm_ShouldReturn0()
        {
            var dataSet = new List<BuildingTemplate>
            {
                new BuildingTemplate() {Type = "Farm", Cost = 100},
            }.AsQueryable();

            var data = MoqData.SetupMockSet<BuildingTemplate>(dataSet);

            _mockAppDbContext.Setup(c => c.BuildingsTemplate).Returns(data.Object);

            var actual = _rulesService.GetBuildingCost("Farm", 0);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void CorrectInput_GetBuildingHP_ShouldReturnCorrectAmount()
        {
            var dataSet = new List<BuildingTemplate>
            {
                new BuildingTemplate() {Type = "Farm", Cost = 100},
            }.AsQueryable();

            var data = MoqData.SetupMockSet<BuildingTemplate>(dataSet);

            _mockAppDbContext.Setup(c => c.BuildingsTemplate).Returns(data.Object);

            var actual = _rulesService.GetBuildingHP("Farm", 1);

            Assert.Equal(100, actual);
        }

        [Fact]
        public void EmptyType_GetBuildingHP_ShouldReturn0()
        {
            var dataSet = new List<BuildingTemplate>
            {
                new BuildingTemplate() {Type = "Farm", Cost = 100},
            }.AsQueryable();

            var data = MoqData.SetupMockSet<BuildingTemplate>(dataSet);

            _mockAppDbContext.Setup(c => c.BuildingsTemplate).Returns(data.Object);

            var actual = _rulesService.GetBuildingHP("", 1);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void LevelIs0_GetBuildingHP_ShouldReturn0()
        {
            var dataSet = new List<BuildingTemplate>
            {
                new BuildingTemplate() {Type = "Farm", Cost = 100},
            }.AsQueryable();

            var data = MoqData.SetupMockSet<BuildingTemplate>(dataSet);

            _mockAppDbContext.Setup(c => c.BuildingsTemplate).Returns(data.Object);

            var actual = _rulesService.GetBuildingHP("Farm", 0);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void CorrectInput_GetBuildingTime_ShouldReturnCorrectAmount()
        {
            var dataSet = new List<BuildingTemplate>
            {
                new BuildingTemplate() {Type = "Farm", Cost = 100},
            }.AsQueryable();

            var data = MoqData.SetupMockSet<BuildingTemplate>(dataSet);

            _mockAppDbContext.Setup(c => c.BuildingsTemplate).Returns(data.Object);

            var actual = _rulesService.GetBuildingTime("Farm", 1);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void EmptyType_GetBuildingTime_ShouldReturn0()
        {
            var dataSet = new List<BuildingTemplate>
            {
                new BuildingTemplate() {Type = "Farm", Cost = 100},
            }.AsQueryable();

            var data = MoqData.SetupMockSet<BuildingTemplate>(dataSet);

            _mockAppDbContext.Setup(c => c.BuildingsTemplate).Returns(data.Object);

            var actual = _rulesService.GetBuildingTime("", 0);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void LevelIs0_GetBuildingTime_ShouldReturn0()
        {
            var dataSet = new List<BuildingTemplate>
            {
                new BuildingTemplate() {Type = "Farm", Cost = 100},
            }.AsQueryable();

            var data = MoqData.SetupMockSet<BuildingTemplate>(dataSet);

            _mockAppDbContext.Setup(c => c.BuildingsTemplate).Returns(data.Object);

            var actual = _rulesService.GetBuildingTime("Farm", 0);

            Assert.Equal(0, actual);
        }

    }
}