using AutoFixture;
using Domain;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class PlayerSteps
    {
        private Player player;
        private Player enemy;
        private RaceEnum raceEnum;
        private readonly Fixture _fixture;

        public PlayerSteps()
        {
            _fixture = new Fixture();
        }

        [Given(@"I´am have stats")]
        public void GivenIAmHaveStats(Table table)
        {
            player = Init(table);
        }
        
        [Given(@"my enemy have stats")]
        public void GivenMyEnemyHaveStats(Table table)
        {
            enemy = Init(table);
        }
        
        [When(@"I attack enemy")]
        public void WhenIAttackEnemy()
        {
            player.Attack(enemy);
        }
        
        [Then(@"the enemy should be dead")]
        public void ThenTheEnemyShouldBeDead()
        {
            enemy.IsDead.Should().BeTrue("Because health is <= 0");
        }

        private Player Init(Table table)
        {
            var strength = table.GetStat<int>("strength");
            var dexterity = table.GetStat<int>("dexterity");
            var health = table.GetStat<int>("health");
            var race = table.GetStat<string>("race");

            var raceEnum = (RaceEnum)Enum.Parse(typeof(RaceEnum), race, true);

            var stats = new Stats(strength, dexterity, raceEnum, health);

            return new Player(stats);
        }

        [Then(@"the enemy should be alive")]
        public void ThenTheEnemyShouldBeAlive()
        {
            enemy.IsDead.Should().BeFalse();
        }


        [Given(@"I´am a (.*)")]
        public void GivenIAma(string race)
        {
            raceEnum = (RaceEnum)Enum.Parse(typeof(RaceEnum), race, true);
        }

        [When(@"I am creating player")]
        public void WhenIAmCreatingPlayer()
        {
            player = new Player(new Stats(_fixture.Create<int>(), _fixture.Create<int>(), raceEnum));
        }

        [Then(@"I should have (.*)")]
        public void ThenIShouldHave(int resistance)
        {
            player.Stats.Resistance.Should().Be(resistance);
        }

    }
}
