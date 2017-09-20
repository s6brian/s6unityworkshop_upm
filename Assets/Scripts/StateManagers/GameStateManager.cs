using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S6
{
	public class GameStateManager : StateManager
	{
		private GameScreenInputController m_inputController;

		public GameStateManager( GameManager p_gameManager )
		{
			m_hashID = Animator.StringToHash( "GameState" );
			m_gameManager = p_gameManager;
			m_inputController = new GameScreenInputController( p_gameManager );
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
			m_inputController.ProcessInput();
		}
	}
}