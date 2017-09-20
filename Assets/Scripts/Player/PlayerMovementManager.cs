using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace S6
{
	public class PlayerMovementManager : MonoBehaviour
	{
		[SerializeField] private Transform m_headTransform;
		[SerializeField] private PlayerInputController m_playerInputController;

		public float Speed    { get; set; }
		public float TurnAngle{ get; set; }

		private void Awake()
		{
			Assert.IsNotNull( m_headTransform  );
			Assert.IsNotNull( m_playerInputController );
		}

		private void Update()
		{
			m_headTransform.Translate( 0f, m_playerInputController.GetForwardSpeed(), 0f );
			// rotate on z-axis
			m_headTransform.Rotate( Vector3.forward, m_playerInputController.GetTurnAngle());
		}
	}
}
