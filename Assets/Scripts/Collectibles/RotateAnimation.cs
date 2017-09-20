using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
	private Transform m_transform;

	void Awake ()
	{
		m_transform = this.transform;
	}
	
	void Update ()
	{
		m_transform.Rotate( Vector3.up,      3f );
		// m_transform.Rotate( Vector3.right,   3f );
		m_transform.Rotate( Vector3.forward, 3f );
	}
}
