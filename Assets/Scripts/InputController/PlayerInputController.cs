using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace S6
{
	public class PlayerInputController : MonoBehaviour
	{
		[SerializeField] private PlayerMovementManager m_playerMovementManager;

		private void Awake()
		{
			Assert.IsNotNull( m_playerMovementManager );
		}

		private void Update ()
		{
			// move forward
			if( Input.GetKey( KeyCode.W ))
			{
				m_playerMovementManager.Speed = 2.5f * Time.deltaTime;
			}

			// stop forward movement
			if( Input.GetKeyUp( KeyCode.W ))
			{
				m_playerMovementManager.Speed = 0f;
			}

			// turn right
			if( Input.GetKey( KeyCode.D ))
			{
				m_playerMovementManager.TurnAngle = -100f * Time.deltaTime;
			}

			// turn left
			if( Input.GetKey( KeyCode.A ))
			{
				m_playerMovementManager.TurnAngle = 100f * Time.deltaTime;
			}

			// stop turning
			if( Input.GetKeyUp( KeyCode.A ) || Input.GetKeyUp( KeyCode.D ))
			{
				m_playerMovementManager.TurnAngle = 0f;
			}
		}
	}
}
