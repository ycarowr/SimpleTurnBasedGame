# Simple Turn-Based Game Core Mechanics

The idea here is to have the core implementation and the basic funcionalities of a turn-based game working in a clean repository, so every time a new project/prototype comes along I may use this implementation and skip rebuilding the basics mechanics.


Description of the game:

The player who starts the match is decided randomly before the game starts, and the game play consists in a fight between two players who start the match with some health points. On each of the players turns, they have to choose one of the actions below:

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

I am not going to go further with details about the implementation but basically you have a MVC with a separation between logic and the data. The game logic is driven and bunch of pure C# classes named [Processes](https://github.com/ycarowr/SimpleTurnBasedGame/blob/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Model/Game/Processes) which change the game data and dispatch events to the interested listeners. 

The listeners are the [UI](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/UI) components and the following [State Machine](https://github.com/ycarowr/SimpleTurnBasedGame/blob/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Controller/TurnBasedCs/TurnBasedFSM.cs) that has two purposes: to control the flow in the client side and hold the controllers (States) that provide access to the Processes mentioned earlier:

All the comunication among the Views and Controller is done using the [Singleton Pattern](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/Patterns/Singleton) and the [Observer Pattern](https://github.com/ycarowr/SimpleTurnBasedGame/blob/master/Assets/Scripts/Patterns/Observer/Observer.cs).

1. [Game Controller](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Controller) and [Turn-Based States](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Controller/TurnBasedCs/States)
2. [Processes](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Model/Game/Processes)
3. [Game Model](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Model/Game)
4. [Game Events](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/GameEvent)
5. [Game Data](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/GameData)
6. [Game UI](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/UI)
7. [Game AI](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Model/Ai)
8. [Some Patterns Used in the Implementation](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/Patterns)
9. [Configurations](https://github.com/ycarowr/SimpleTurnBasedGame/tree/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Configurations)

Gif for a better visualization of the Game Flow:

![alt text](https://github.com/ycarowr/SimpleTurnBasedGame/blob/master/Assets/Textures/SimpleTurnBasedGame/gifs/Game%20Flow.gif)

The game is also a bit configurable, you can define:
- Players Health;
- Turn time out and time until start game;
- Damage, Heal and Bonus for Random
- AI Archetypes for both players;

![Configurations](https://github.com/ycarowr/SimpleTurnBasedGame/blob/master/Assets/Scripts/SampleUsage/SimpleTurnBasedGame/Configurations/Editor/configs.JPG)
