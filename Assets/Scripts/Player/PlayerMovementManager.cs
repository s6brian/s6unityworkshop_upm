using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace S6
{
	public class PlayerMovementManager : MonoBehaviour
	{
		[SerializeField] private Transform m_headTransform;
		[SerializeField] private Transform m_mouthTransform;

		private PlayerInputController m_playerInputController;
		private PlayerSegmentManager  m_playerSegmentManager;

		private void Awake()
		{
			Assert.IsNotNull( m_headTransform  );
			Assert.IsNotNull( m_mouthTransform );

			m_playerInputController = new PlayerInputController();
			m_playerSegmentManager = this.GetComponent<PlayerSegmentManager>();
			
			Assert.IsNotNull( m_playerSegmentManager );
		}

		private void Update()
		{
			// rotate on z-axis
			m_headTransform.Rotate( Vector3.forward, m_playerInputController.GetTurnAngle());

			// move on xy-plane
			float speed = m_playerInputController.GetForwardSpeed();	
			m_headTransform.Translate( 0f, speed, 0f );

			for( int idx = m_playerSegmentManager.SegmentCount-1; idx >= 0; --idx )
			{
				m_playerSegmentManager.Segments[ idx ].Move( speed );
			}
		}
	}
}
