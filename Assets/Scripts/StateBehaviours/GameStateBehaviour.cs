using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S6
{
    public class GameStateBehaviour : StateBehaviour
    {
        public override void SetStateMachine(GameManager p_gameManager)
        {
            m_gameManager = p_gameManager;
        }

        override public void OnStateEnter( Animator p_animator, AnimatorStateInfo p_stateInfo, int p_layerIndex )
        {
            m_gameManager.OnStateEnter();
        }

        override public void OnStateExit( Animator p_animator, AnimatorStateInfo p_stateInfo, int p_layerIndex )
        {
            m_gameManager.OnStateExit();
        }

        override public void OnStateUpdate( Animator p_animator, AnimatorStateInfo p_stateInfo, int p_layerIndex )
        {
            m_gameManager.OnStateUpdate();
        }
    }
}