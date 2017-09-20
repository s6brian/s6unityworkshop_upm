using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace S6
{
	public class PlayerSegmentManager : MonoBehaviour
	{
		private const int   SEGMENT_COUNT     = 30;
		private const int   MIN_SEGMENT_COUNT = 2; // excluding the head
		public  const float SEGMENT_SPACING   = 0.35f;

		[SerializeField] private GameObject   m_headGameObject;
		[SerializeField] private GameObject   m_segmentGameObject;
		[SerializeField] private GameObject[] m_tailGameObjects;
		
		// properties
		public int             SegmentCount{ get{ return m_currentSegmentCount; }}
		public PlayerSegment[] Segments    { get{ return m_segments; }}

		private Transform m_headTransform;
		private Transform[] m_tailTransforms;

		// for object pooling
		private GameObject   [] m_segmentObjects;
		private PlayerSegment[] m_segments;
		private Transform    [] m_segmentTransforms;
		private int m_currentSegmentCount;

		private void OnEnable()
		{
			StateManager.OnTriggerStateEnter         += OnTriggerStateEnter;
			StateManager.OnTriggerStateExit          += OnTriggerStateExit;
			GameScreenInputController.OnTriggerRetry += ResetPlayer;
		}

		private void OnDisable()
		{
			StateManager.OnTriggerStateEnter         -= OnTriggerStateEnter;
			StateManager.OnTriggerStateExit          -= OnTriggerStateExit;
			GameScreenInputController.OnTriggerRetry -= ResetPlayer;
		}

		private void Awake()
		{
			Assert.IsNotNull( m_headGameObject    );
			Assert.IsNotNull( m_tailGameObjects   );
			Assert.IsNotNull( m_segmentGameObject );

			m_headTransform = m_headGameObject.transform;
			InitSegments();

			// set tail transform
			int tailLen = m_tailGameObjects.Length;
			m_tailTransforms = new Transform[tailLen];

			for( int idx = 0; idx < tailLen; ++idx )
			{
				m_tailTransforms[idx] = m_tailGameObjects[idx].transform;
			}
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
			m_segmentObjects    = new GameObject   [ SEGMENT_COUNT ];
			m_segmentTransforms = new Transform    [ SEGMENT_COUNT ];
			m_segments          = new PlayerSegment[ SEGMENT_COUNT ];

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

				m_segmentTransforms[idx] = tfm;
				m_segmentObjects[idx]    = obj;
				m_segments[idx]          = obj.GetComponent<PlayerSegment>();
				
				obj.SetActive( false );
			}
		}

		public void AddSegment()
		{
			if( m_currentSegmentCount >= SEGMENT_COUNT ){ return; }
			m_segmentObjects[ m_currentSegmentCount ].SetActive( true );
			m_segments[ m_currentSegmentCount ].SetFollowedTransform( m_headTransform );
			++m_currentSegmentCount;
		}

		public void RemoveSegment()
		{

		}

		public void ResetPlayer()
		{
			m_headTransform.position = Vector3.zero;
			m_headTransform.rotation = Quaternion.identity;
			m_currentSegmentCount    = MIN_SEGMENT_COUNT;

			HideAllSegments();
			m_headGameObject.SetActive( true );

			for( int idx = m_currentSegmentCount-1; idx >= 0; --idx )
			{
				m_segmentObjects[idx].SetActive( true );
				m_segmentTransforms[idx].position = Vector3.down * ( idx + 1 ) * SEGMENT_SPACING;

				if( idx == 0 )
				{
					m_segments[idx].SetFollowedTransform( m_headTransform );
				}
				else
				{
					m_segments[idx].SetFollowedTransform( m_segmentTransforms[ idx-1 ]);
				}
			}
		}

		private void HideAllSegments()
		{
			m_headGameObject.SetActive( false );

			for( int idx = 0; idx < SEGMENT_COUNT; ++idx )
			{
				m_segmentObjects[idx].SetActive( false );
			}
		}
	}
}
