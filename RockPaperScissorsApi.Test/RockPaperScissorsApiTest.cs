using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace RockPaperScissorsApi.Test
{
    public class RockPaperScissorsApiTest: TestBase
    {
        [Fact]
        public async Task ShouldDisplayAWelcomeMessage()
        {
            var response = await GetAsync(Get.WelcomeScreen);
            response.EnsureSuccessStatusCode();
            (await response.Content.ReadAsStringAsync()).Should().Be("Hello, players!");
        }

        [Fact]
        public void ShouldBeAbleToStartANewGameAndAssignPlayers()
        {
            true.Should().BeFalse();
        }
    }
}