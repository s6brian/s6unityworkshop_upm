using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovementManager : MonoBehaviour
{
	[SerializeField] private Transform m_headTransform;
	[SerializeField] private Transform[] m_tailTransforms;

	public float Speed{ get; set; }
	public float TurnAngle{ get; set; }

	private void Awake()
	{
		Assert.IsNotNull( m_headTransform  );
		Assert.IsNotNull( m_tailTransforms );
	}

	private void Update()
	{
		m_headTransform.Translate( 0f, Speed, 0f );
		// rotate on z-axis
		m_headTransform.Rotate( Vector3.forward, TurnAngle );
	}
}
