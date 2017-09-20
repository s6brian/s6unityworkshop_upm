using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S6
{
	public class LoadStateManager : StateManager
	{
		private LoadScreenInputController m_inputController;

		public LoadStateManager( GameManager p_gameManager )
		{
			m_hashID = Animator.StringToHash( "LoadState" );
			m_gameManager = p_gameManager;
			m_inputController = new LoadScreenInputController( p_gameManager );
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();
			// Debug.Log( "Load State Enter" );
		}

		public override void OnStateExit()
		{
			base.OnStateExit();
			// Debug.Log( "Load State Exit" );
		}

		public override void OnStateUpdate()
		{
			m_inputController.ProcessInput();
		}
	}
}