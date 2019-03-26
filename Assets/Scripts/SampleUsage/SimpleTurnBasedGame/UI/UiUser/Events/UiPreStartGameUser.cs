using System.Collections.Generic;
using SimpleTurnBasedGame;
using UnityEngine;

[RequireComponent(typeof(IUiUserInput))]
[RequireComponent(typeof(IUiPlayerController))]
public class UiPreStartGameUser : UiListener, IPreGameStart
{
    private IUiUserInput UserInput { get; set; }
    private IUiPlayerController Player { get; set; }

    void IPreGameStart.OnPreGameStart(List<IPrimitivePlayer> players)
    {
        if (Player.IsMyTurn)
            UserInput.Disable();
    }

    private void Awake()
    {
        UserInput = GetComponent<IUiUserInput>();
        Debug.Log(UserInput);
        Player = GetComponent<IUiPlayerController>();
    }
}