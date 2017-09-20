using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace S6
{
	public class PlayerSegmentManager : MonoBehaviour
	{
		private const int   SEGMENT_COUNT   = 20;
		private const float SEGMENT_SPACING = 0.35f;

		[SerializeField] private GameObject  m_headGameObject;
		[SerializeField] private GameObject  m_segmentGameObject;
		[SerializeField] private Transform[] m_tailTransforms;

		private Transform m_headTransform;

		// for object pooling
		private GameObject[] m_segmentObjects;
		private Transform [] m_segmentTransforms;
		private int m_currentSegmentCount;

		private void OnEnable()
		{
			StateManager.OnTriggerStateEnter += OnTriggerStateEnter;
			StateManager.OnTriggerStateExit  += OnTriggerStateExit;
		}

		private void OnDisable()
		{
			StateManager.OnTriggerStateEnter -= OnTriggerStateEnter;
			StateManager.OnTriggerStateExit  -= OnTriggerStateExit;
		}

		private void Awake()
		{
			Assert.IsNotNull( m_headGameObject    );
			Assert.IsNotNull( m_tailTransforms    );
			Assert.IsNotNull( m_segmentGameObject );

			m_headTransform = m_headGameObject.transform;

			InitSegments();
		}

		// private void Update()
		// {
		// 	Vector3 direction;
		// 	Vector3 lookAtPosition;

		// 	lookAtPosition = m_headTransform.position;

		// 	for( int idx = 0; idx < m_currentSegmentCount; ++idx )
		// 	{
				
		// 	}
		// }

		private void OnTriggerStateEnter( int p_stateHashID )
		{
			if( p_stateHashID == Constants.GAME_STATE_HASH_ID )
			{
				ResetPlayer();
			}
			else
			{
				HideAllSegments();	
			}
		}

		private void OnTriggerStateExit( int p_stateHashID )
		{
			if( p_stateHashID == Constants.GAME_STATE_HASH_ID )
			{
				HideAllSegments();
			}
		}

		private void InitSegments()
		{
			m_segmentObjects    = new GameObject[ SEGMENT_COUNT ];
			m_segmentTransforms = new Transform [ SEGMENT_COUNT ];

			Transform  parent = this.transform;
			Transform  tfm;
			GameObject obj;

			for( int idx = 0; idx < SEGMENT_COUNT; ++idx )
			{
				obj = Instantiate( m_segmentGameObject );
				tfm = obj.transform;

				// note:
				//   this.transform is an expensive function. same with this.gameObject and GetComponent
				//   if you'll be using them repeatedly, better cache them first.
				tfm.SetParent( parent );
				tfm.position   = Vector3.zero;

				m_segmentObjects[idx]    = obj;
				m_segmentTransforms[idx] = tfm;
			}
		}

		private void InsertSegment()
		{

		}

		private void RemoveSegment()
		{

		}

		private void ResetPlayer()
		{
			m_headTransform.position = Vector3.zero;
			m_headTransform.rotation = Quaternion.identity;
			m_currentSegmentCount    = 0;

			HideAllSegments();

			for( int idx = m_tailTransforms.Length-1; idx >= 0; --idx )
			{
				m_tailTransforms[idx].position = Vector3.down * ( idx + 1 ) * SEGMENT_SPACING;
			}

			m_headGameObject.SetActive( true );
			for( int idx = m_tailTransforms.Length-1; idx >= 0; --idx )
			{
				// i decided not to cache tail gameobjects because they're only used during reset.
				// you can always insert a loading screen for cases like this.
				m_tailTransforms[idx].gameObject.SetActive( true );
			}
		}

		private void HideAllSegments()
		{
			m_headGameObject.SetActive( false );

			for( int idx = m_tailTransforms.Length-1; idx >= 0; --idx )
			{
				m_tailTransforms[idx].gameObject.SetActive( false );
			}

			for( int idx = 0; idx < SEGMENT_COUNT; ++idx )
			{
				m_segmentObjects[idx].SetActive( false );
			}
		}
	}
}