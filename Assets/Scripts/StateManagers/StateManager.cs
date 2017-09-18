using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager
{
	protected GameManager m_gameManager;

	protected int m_hashID;
	public int HashID{ get{ return m_hashID; }}
	
	public abstract void OnStateEnter();
	public abstract void OnStateUpdate();
	public abstract void OnStateExit();
}
