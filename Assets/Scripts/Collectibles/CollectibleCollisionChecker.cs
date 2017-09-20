using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace S6
{
	public class CollectibleCollisionChecker : MonoBehaviour
	{
		[SerializeField] private Transform    m_playerTransform;
		[SerializeField] private ScoreManager m_scoreManager;

		private Transform m_transform;
		private CollectibleSpawnManager m_collectibleSpawner;

		private void Awake ()
		{
			Assert.IsNotNull( m_playerTransform );
			Assert.IsNotNull( m_scoreManager );

			m_transform = this.transform;
			m_collectibleSpawner = this.GetComponent<CollectibleSpawnManager>();
			Assert.IsNotNull( m_collectibleSpawner );
		}
		
		private void Update ()
		{
			float distance = ( m_transform.position - m_playerTransform.position ).sqrMagnitude;
			if( distance < 0.2f )
			{
				m_collectibleSpawner.Respawn();
				m_scoreManager.AddScore( 1 );
			}
		}
	}
}
