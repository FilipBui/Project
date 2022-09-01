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
    public class LeaderboardsServiceTests
    {
        private LeaderboardsService _leaderboardsService;
        private readonly Mock<IApplicationDbContext> _mockAppDbContext = new Mock<IApplicationDbContext>();

        public LeaderboardsServiceTests()
        {
            _leaderboardsService = new LeaderboardsService(_mockAppDbContext.Object);
        }

    }
}