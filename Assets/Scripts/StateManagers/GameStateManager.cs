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
		base.OnStateEnter();
		Debug.Log( "Game State Enter" );
	}

	public override void OnStateExit()
	{
		base.OnStateExit();
		Debug.Log( "Game State Exit" );
	}

	public override void OnStateUpdate()
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			Debug.Log( "Keydown Enter / Return." );
			LoadStateManager loadStateManager = new LoadStateManager( m_gameManager );
			m_gameManager.Play( loadStateManager );
		}
	}
}
