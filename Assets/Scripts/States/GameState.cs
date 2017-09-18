using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : GameStateBehaviour
{
    public override void SetStateMachine(GameManager p_gameManager)
    {
        m_gameManager = p_gameManager;
    }
}
