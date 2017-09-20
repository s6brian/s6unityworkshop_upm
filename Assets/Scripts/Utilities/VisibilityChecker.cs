using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S6
{
	public class VisibilityChecker : MonoBehaviour
	{
		[SerializeField] private string m_stateBehaviourName;

		private GameObject m_gameObject;
		private int m_stateHashID;

		private void Awake()
		{
			m_stateHashID = Animator.StringToHash( m_stateBehaviourName );
			m_gameObject = this.gameObject;

			StateManager.OnTriggerStateEnter += OnTriggerStateEnter;
			StateManager.OnTriggerStateExit  += OnTriggerStateExit;
		}
		
		private void OnDestroy()
		{
			StateManager.OnTriggerStateEnter -= OnTriggerStateEnter;
			StateManager.OnTriggerStateExit  -= OnTriggerStateExit;
		}

		private void OnTriggerStateEnter( int p_stateHashID )
		{
			m_gameObject.SetActive( m_stateHashID == p_stateHashID );
		}

		private void OnTriggerStateExit( int p_stateHashID )
		{
			
		}
	}
}
