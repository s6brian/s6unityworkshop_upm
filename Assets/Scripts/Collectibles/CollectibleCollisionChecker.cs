using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace S6
{
	public class CollectibleCollisionChecker : MonoBehaviour
	{
		[SerializeField] private Transform m_playerTransform;
		[SerializeField] private ScoreManager m_scoreManager;

		private void Awake ()
		{
			Assert.IsNotNull( m_playerTransform );
		}
		
		private void Update ()
		{
			
		}
}
}
