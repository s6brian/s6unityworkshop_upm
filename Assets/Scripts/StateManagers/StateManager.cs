using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager
{
	public delegate void StateTrigger( int p_stateHashID );
	public static event StateTrigger OnTriggerStateEnter;
	public static event StateTrigger OnTriggerStateExit;

	protected GameManager m_gameManager;

	protected int m_hashID;
	public int HashID{ get{ return m_hashID; }}
	
	public virtual void OnStateEnter()
	{
		if( OnTriggerStateEnter != null )
		{
			OnTriggerStateEnter( m_hashID );
		}
	}

	public virtual void OnStateExit()
	{
		if( OnTriggerStateExit != null )
		{
			OnTriggerStateExit( m_hashID );
		}
	}

	public virtual void OnStateUpdate(){}
}
