using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
	private StateManager m_currStateManager;
	private StateManager m_prevStateManager;
	private Animator     m_stateMachineAnimator;
	private int 		 m_nextStateHashID;

	public GameManager( Animator p_stateMachineAnimator )
	{
		m_stateMachineAnimator = p_stateMachineAnimator;
	}

	public void Play( StateManager p_stateManager )
	{
		m_currStateManager = p_stateManager;
		m_stateMachineAnimator.Play( p_stateManager.HashID );
	}

	public void OnStateEnter()
	{
		m_currStateManager.OnStateEnter();
	}

	public void OnStateUpdate()
	{
		m_currStateManager.OnStateUpdate();
	}

	public void OnStateExit()
	{
		if(m_prevStateManager != null)
		{
			m_prevStateManager.OnStateExit();
		}

		m_prevStateManager = m_currStateManager;
	}
}
