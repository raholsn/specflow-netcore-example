Feature: Player
	
@Attack
Scenario: Attack should kill enemy when strength minus resistance is greater then enemy health
	Given I´am have stats
	| race | strength | dexterity | health |
	| Orc  | 30       | 10        | 10     |
	And my enemy have stats
	| race | strength | dexterity | health |
	| Elf  | 10       | 10        | 10     |
	When I attack enemy
	Then the enemy should be dead

@Attack
Scenario: Attack should not kill enemy when strength minus resistance is less then enemy health
	Given I´am have stats
	| race | strength | dexterity | health |
	| Orc  | 29      | 10        | 10     |
	And my enemy have stats
	| race | strength | dexterity | health |
	| Elf  | 10       | 10        | 10     |
	When I attack enemy
	Then the enemy should be alive

@Resistance
Scenario Outline: Race should have resistance
	Given I´am a <race>
	When I am creating player
	Then I should have <resistance>
	Examples: 
	| race | resistance |
	| Elf  | 20         |
	| Orc  | 10         |