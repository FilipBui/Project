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
    public class LeaderBoardsServiceTests
    {
        private BuildingService _buildingService;
        private readonly Mock<IApplicationDbContext> _mockAppDbContext = new Mock<IApplicationDbContext>();
        private readonly Mock<IRulesService> _mockRulesService = new Mock<IRulesService>(); 

        public LeaderBoardsServiceTests()
        {
            _buildingService = new BuildingService(_mockAppDbContext.Object, _mockRulesService.Object);
        }      
    }
}