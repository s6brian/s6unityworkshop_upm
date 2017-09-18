using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : GameStateBehaviour
{
    public override void SetStateMachine(GameManager p_gameManager)
    {
        m_gameManager = p_gameManager;
    }
}
