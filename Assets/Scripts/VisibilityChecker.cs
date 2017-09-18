using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityChecker : MonoBehaviour
{
	// [SerializeField] private Renderer m_displayComponent;
	[SerializeField] private string    m_stateBehaviourName;

	private GameObject m_gameObject;
	private int m_stateHashID;

	// private void OnEnable()
	// {
	// 	StateManager.OnTriggerStateEnter += OnTriggerStateEnter;
	// 	StateManager.OnTriggerStateExit  += OnTriggerStateExit;
	// }

	// private void OnDisable()
	private void OnDestroy()
	{
		StateManager.OnTriggerStateEnter -= OnTriggerStateEnter;
		StateManager.OnTriggerStateExit  -= OnTriggerStateExit;
	}

	private void Awake()
	{
		m_stateHashID = Animator.StringToHash( m_stateBehaviourName );
		m_gameObject = this.gameObject;

		StateManager.OnTriggerStateEnter += OnTriggerStateEnter;
		StateManager.OnTriggerStateExit  += OnTriggerStateExit;
	}

	private void OnTriggerStateEnter( int p_stateHashID )
	{
		// if( m_stateHashID != p_stateHashID ){ return; }
		// m_gameObject.SetActive( true );
		m_gameObject.SetActive( m_stateHashID == p_stateHashID );
	}

	private void OnTriggerStateExit( int p_stateHashID )
	{
		// if( m_stateHashID != p_stateHashID ){ return; }
		// m_gameObject.SetActive( false );
		// m_gameObject.SetActive( m_stateHashID != p_stateHashID );
	}
}
