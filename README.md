# SimpleTurnBasedGame Core Mechanics

The idea here is to have the core implementation and the basic funcionalities of a Turn-Based Game working in a clean repository. So, every time you start a new turn-based game project/prototype just reuse this implementation and don't start from Zero.

Here you have the the core structures like:
- A Game with two players, both sitting in the respective positions: Top and Bottom; (can be extended to more players)
- Events such as Start and End match integrated with a primitive UI;
- Events such as Player Started and Finished Turn also integrated with a primitive UI;
- Events that heal and deal damage to players;
- Timeouts for players turns.


The game example consists in a fight between two players where both start the match with 6 Health Points and every turn the current player has to choose in less than 5 seconds one of the following options:

- give 1 to 3 damage to the opponent;
- heal itself 1 to 3 damage;
- a random option above with +2 in the result;
- wait the timeout of 5 seconds and pass the turn doing nothing.

The player who starts the match is decided randomly before the game starts. 
The loser is the player who reaches Zero life points first.

About the implementation:

Game Model:
Game Events: 
Game UI: 

