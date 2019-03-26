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

I am not going to go further with details about the implementation but basically you have a MVC with a separation between logic and the data. The game logic is driven and bunch of [Processes](https://github.com/ycarowr/SimpleTurnBasedGame/blob/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Model/Game/Processes) and reflected in the following [Finite State Machine](https://github.com/ycarowr/SimpleTurnBasedGame/blob/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Controller/TurnBasedCs/TurnBasedFSM.cs) in addition to many [UI](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/UI) components:

1. [Game Controllers](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Controller)
2. [Game Model](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Model)
3. [More Logic](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Model/Game)
4. [Game Events](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/GameEvent)
5. [Game Data](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/GameData)
6. [Game UI](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/UI)
7. [Game AI](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Model/Ai)
8. [Some Patterns Used in the Implementation](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/Patterns)
9. [Configurations](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Configurations)

Gif for a better visualization of the Game Flow:

![alt text](https://github.com/ycarowr/SimpleTurnBasedGame/blob/master/Assets/Textures/SimpleTurnBasedGame/gifs/Game%20Flow.gif)


The game is also a bit configurable:

![Configurations](https://github.com/ycarowr/SimpleTurnBasedGame/blob/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Configurations/Editor/configs.JPG)
