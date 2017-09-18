using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Bootloader : MonoBehaviour
{
	private GameManager m_gameManager;
	private Animator    m_stateMachineAnimator;

	private void Awake ()
	{
		m_gameManager          = GameManager.Instance;
		m_stateMachineAnimator = this.GetComponent<Animator>();

		Assert.IsNotNull(m_gameManager);
		Assert.IsNotNull(m_stateMachineAnimator);
	}

	private void Start ()
	{
		GameStateBehaviour[] gameStateBehaviours = m_stateMachineAnimator.GetBehaviours<GameStateBehaviour>();
		for(int idx = gameStateBehaviours.Length-1; idx >= 0; --idx)
		{
			gameStateBehaviours[idx].SetStateMachine(m_gameManager);
		}
	}
}
