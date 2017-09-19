using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenInputController
{
	private GameManager m_gameManager;

	public LoadScreenInputController( GameManager p_gameManager )
	{
		m_gameManager = p_gameManager;
	}

	public void ProcessInput()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log( "Keydown Spacebar." );
			GameStateManager gameStateManager = new GameStateManager( m_gameManager );
			m_gameManager.Play( gameStateManager );
		}
	}
}
