﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace S6
{
	public class PlayerMovementManager : MonoBehaviour
	{
		[SerializeField] private Transform m_headTransform;
		private PlayerInputController m_playerInputController;
		private PlayerSegmentManager  m_playerSegmentManager;

		public float Speed    { get; set; }
		public float TurnAngle{ get; set; }

		private void Awake()
		{
			Assert.IsNotNull( m_headTransform  );
			// Assert.IsNotNull( m_playerInputController );

			m_playerInputController = new PlayerInputController();
			m_playerSegmentManager = this.GetComponent<PlayerSegmentManager>();
			
			Assert.IsNotNull( m_playerSegmentManager );
		}

		private void Update()
		{
			if( m_playerInputController.OnRetry())
			{
				m_playerSegmentManager.ResetPlayer();
			}

			m_headTransform.Translate( 0f, m_playerInputController.GetForwardSpeed(), 0f );
			// rotate on z-axis
			m_headTransform.Rotate( Vector3.forward, m_playerInputController.GetTurnAngle());
		}


	}
}
