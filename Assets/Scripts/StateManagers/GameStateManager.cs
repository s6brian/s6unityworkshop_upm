using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : StateManager
{
	public GameStateManager( GameManager p_gameManager )
	{
		m_hashID = Animator.StringToHash( "GameState" );
		m_gameManager = p_gameManager;
	}

	public override void OnStateEnter()
	{
		Debug.Log( "Game State Enter" );
	}

	public override void OnStateUpdate()
	{

	}

	public override void OnStateExit()
	{
		Debug.Log( "Game State Exit" );
	}
}
