using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStateManager : StateManager
{
	public LoadStateManager( GameManager p_gameManager )
	{
		m_hashID = Animator.StringToHash( "LoadState" );
		m_gameManager = p_gameManager;
	}

	public override void OnStateEnter()
	{
		Debug.Log( "Load State Enter" );
	}

	public override void OnStateUpdate()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log( "Keydown Spacebar." );
			GameStateManager gameStateManager = new GameStateManager( m_gameManager );
			m_gameManager.Play( gameStateManager );
		}
	}

	public override void OnStateExit()
	{
		Debug.Log( "Load State Exit" );
	}
}
