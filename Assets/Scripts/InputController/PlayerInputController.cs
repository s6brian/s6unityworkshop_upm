using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace S6
{
	public class PlayerInputController : MonoBehaviour
	{
		private float m_walkSensitivity = 2.5f;
		private float m_turnSensitivity = 100f;

		public float GetForwardSpeed()
		{
			float speed = 0f;

			if( Input.GetKey( KeyCode.W ))
			{
				speed = m_walkSensitivity * Time.deltaTime;
			}

			return speed;
		}

		public float GetTurnAngle()
		{
			float angle = 0f;

			// turn right
			if( Input.GetKey( KeyCode.D ))
			{
				angle = -m_turnSensitivity * Time.deltaTime;
			}

			// turn left
			if( Input.GetKey( KeyCode.A ))
			{
				angle = m_turnSensitivity * Time.deltaTime;
			}

			return angle;
		}
	}
}
