using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace S6
{
	public class PlayerMovementManager : MonoBehaviour
	{
		[SerializeField] private Transform m_headTransform;

		public float Speed    { get; set; }
		public float TurnAngle{ get; set; }

		private void Awake()
		{
			Assert.IsNotNull( m_headTransform  );
		}

		private void Update()
		{
			m_headTransform.Translate( 0f, Speed, 0f );
			// rotate on z-axis
			m_headTransform.Rotate( Vector3.forward, TurnAngle );
		}
	}
}
