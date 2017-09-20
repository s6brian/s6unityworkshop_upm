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

			InitSegments();
		}

		private void Update()
		{
			Vector3 direction;
		}

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

			GameObject obj;
			Transform  tfm;

			for( int idx = 0; idx < SEGMENT_COUNT; ++idx )
			{
				obj = Instantiate( m_segmentGameObject );
				tfm = obj.transform;

				// note:
				//   this.transform is an expensive function. same with this.gameObject and GetComponent
				//   if you'll be using them repeatedly, better cache them first.
				//   for this example, it's acceptable because we're only using it for initialization
				tfm.SetParent( this.transform );
				tfm.position   = Vector3.zero;

				m_segmentObjects[idx]    = obj;
				m_segmentTransforms[idx] = tfm;
			}
		}

		private void ResetPlayer()
		{
			Transform headTransform = m_headGameObject.transform;
			headTransform.position = Vector3.zero;
			headTransform.rotation = Quaternion.identity;

			m_currentSegmentCount = 0;
			HideAllSegments();

			for( int idx = m_tailTransforms.Length-1; idx >= 0; --idx )
			{
				m_tailTransforms[idx].position = Vector3.down * ( idx + 1 ) * SEGMENT_SPACING;
			}

			m_headGameObject.SetActive( true );
			for( int idx = m_tailTransforms.Length-1; idx >= 0; --idx )
			{
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