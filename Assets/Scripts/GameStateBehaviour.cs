using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStateBehaviour : StateMachineBehaviour
{
	protected GameManager m_gameManager;
	public abstract void SetStateMachine(GameManager p_gameManager);
}
