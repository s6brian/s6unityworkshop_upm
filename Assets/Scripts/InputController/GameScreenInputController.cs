using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S6
{
	public class GameScreenInputController
	{
		public delegate void KeyDownTrigger();
		public static event KeyDownTrigger OnTriggerRetry;

		private GameManager m_gameManager;

		public GameScreenInputController( GameManager p_gameManager )
		{
			m_gameManager = p_gameManager;
		}

		public void ProcessInput()
		{
			// quit (left alt + q)
			if(Input.GetKey( KeyCode.LeftAlt ) && Input.GetKeyDown(KeyCode.Q))
			{
				LoadStateManager loadStateManager = new LoadStateManager( m_gameManager );
				m_gameManager.Play( loadStateManager );
			}

			// retry
			if( Input.GetKeyDown( KeyCode.R ) && OnTriggerRetry != null)
			{
				OnTriggerRetry();
			}
		}
	}
}
