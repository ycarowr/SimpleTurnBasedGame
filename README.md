# Simple Turn-Based Game Core Mechanics

The idea here is to have the core implementation and the basic funcionalities of a turn-based game working in a clean repository. Every time I start a new project/prototype I may use this implementation and skip rebuilding the basics.

The player who starts the match is decided randomly before the game starts. The game play consists in a fight between two players where both start the match with some health points. Each turn the current player has to choose one of the options below and then pass the turn:

- give some damage to the opponent;
- heal some damage itself;
- a random option above with a bonus in the result;
- wait the timeout and pass the turn doing nothing.

The loser is the player who reaches zero life points first.

Structures and funcionalities:
- Two players, both sitting in the respective positions: Top and Bottom; (can be extended to more players)
- Events such as Start and End match integrated with a simple UI;
- Events like Player Started and Finished Turn also integrated with a simple UI;
- Events that when players Heal and Deal damage;
- Timeouts for players turns;
- Restart point.

Links for the implementation:

1. [Game Controllers](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Controller)
2. [Game Model](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Model)
3. [Game Events](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/GameEvent)
4. [Game UI](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/UI)
5. [Game AI](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Model/Ai)
6. [Some Patterns Used in the Implementation](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/Patterns)
7. [Configurations](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Configurations)

Gif for a better visualization of the Game Flow:

![alt text](https://github.com/ycarowr/SimpleTurnBasedGame/blob/master/Assets/Textures/SimpleTurnBasedGame/gifs/Game%20Flow.gif)


The game is also a bit configurable:

![Configurations](https://github.com/ycarowr/SimpleTurnBasedGame/blob/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Configurations/Editor/configs.JPG)

