using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenInputController
{
	private GameManager m_gameManager;

	public GameScreenInputController( GameManager p_gameManager )
	{
		m_gameManager = p_gameManager;
	}

	public void ProcessInput()
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			Debug.Log( "Keydown Enter / Return." );
			LoadStateManager loadStateManager = new LoadStateManager( m_gameManager );
			m_gameManager.Play( loadStateManager );
		}
	}
}
