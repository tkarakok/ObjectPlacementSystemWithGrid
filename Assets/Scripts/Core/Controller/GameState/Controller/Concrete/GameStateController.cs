using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour, IGameStateController
{
    public GameStates GameState { get; set; }
    
    public GameStateController()
    {
        GameState = GameStates.MainMenuState;
    }

    public void SetNewGameState(GameStates gameState)
    {
        GameState = gameState;
    }

}
