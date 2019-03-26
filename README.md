# Simple Turn-Based Game Core Mechanics

The idea here is to have the core implementation and the basic funcionalities of a Turn-Based Game working in a clean repository. So, every time you begin a new turn-based project/prototype you may use this implementation not rebuild the wheel starting from the point zero.

Structures and funcionalities:
- A Game with two players, both sitting in the respective positions: Top and Bottom; (can be extended to more players)
- Events such as Start and End match integrated with a primitive UI;
- Events such as Player Started and Finished Turn also integrated with a primitive UI;
- Events that heal and deal damage to players;
- Timeouts for players turns;
- Restart point.


The game example consists in a fight between two players where both start the match with 6 Health Points, every turn the current player has to choose one of the options below and then pass the turn:

- give 1 to 3 damage to the opponent;
- heal itself for 1 to 3 damage;
- a random option above with +2 in the result;
- wait the timeout of 5 seconds and pass the turn doing nothing.

The player who starts the match is decided randomly before the game starts. 
The loser is the player who reaches Zero life points first.

Links for the implementation:

1. [Game Controllers](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Controller)
2. [Game Model](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Model)
3. [Game Events](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/GameEvent)
4. [Game UI](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/UI)
5. [Game AI](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Model/Ai)
6. [Some Patterns Used in the Implementation](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/Patterns)





Gif for a better visualization of the Game Flow:

![alt text](https://github.com/ycarowr/SimpleTurnBasedGame/blob/master/Assets/Textures/SimpleTurnBasedGame/gifs/Game%20Flow.gif)
