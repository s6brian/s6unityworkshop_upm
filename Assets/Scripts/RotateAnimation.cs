using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S6
{
	public class RotateAnimation : MonoBehaviour
	{
		private Transform m_transform;

		private void Awake ()
		{
			m_transform = this.transform;
		}
		
		private void Update ()
		{
			m_transform.Rotate( Vector3.up,      3f );
			// m_transform.Rotate( Vector3.right,   3f );
			m_transform.Rotate( Vector3.forward, 3f );
		}
	}
}
