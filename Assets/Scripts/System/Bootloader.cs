using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace S6
{
	public class Bootloader : MonoBehaviour
	{
		private GameManager m_gameManager;
		private Animator    m_stateMachineAnimator;

		private void Awake ()
		{
			m_stateMachineAnimator = this.GetComponent<Animator>();
			Assert.IsNotNull( m_stateMachineAnimator );

			m_gameManager = new GameManager( m_stateMachineAnimator );
			Assert.IsNotNull( m_gameManager );
		}

		private void Start ()
		{
			StateBehaviour[] stateBehaviours = m_stateMachineAnimator.GetBehaviours<StateBehaviour>();
			for( int idx = stateBehaviours.Length-1; idx >= 0; --idx )
			{
				stateBehaviours[idx].SetStateMachine( m_gameManager );
			}

			// LoadStateManager loadStateManager = new LoadStateManager( m_gameManager );
			// m_gameManager.Play( loadStateManager );
			GameStateManager gameStateManager = new GameStateManager( m_gameManager );
			m_gameManager.Play( gameStateManager );
		}
	}
}