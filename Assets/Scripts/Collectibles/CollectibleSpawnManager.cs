using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S6
{
	public class CollectibleSpawnManager : MonoBehaviour
	{
		private Transform m_transform;
		private Vector2   m_v2MinRange;
		private Vector3   m_v2MaxRange;

		private void OnEnable()
		{
			GameScreenInputController.OnTriggerRetry += Reset;
		}

		private void OnDisable()
		{
			GameScreenInputController.OnTriggerRetry -= Reset;
		}

		private void Awake()
		{
			m_transform  = this.transform;
			m_v2MinRange = Camera.main.ViewportToWorldPoint( new Vector2( 0.05f, 0.05f ));
			m_v2MaxRange = Camera.main.ViewportToWorldPoint( new Vector2( 0.95f, 0.90f ));

			Reset();
		}

		private void Reset()
		{
			// initially spawn out of screen
			m_transform.position = new Vector3( Screen.width * 1.5f, 0f, 0f );
			// after n seconds, spawn in random position within screen
			Invoke( "Respawn", 1.5f );
		}

		public void Respawn()
		{
			m_transform.position = new Vector3( Random.Range( m_v2MinRange.x, m_v2MaxRange.x ), Random.Range( m_v2MinRange.y, m_v2MaxRange.y ), 0f );
		}
	}
}
