using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStateController : IControllerBase
{
    public void SetNewGameState(GameStates gameState);
}
