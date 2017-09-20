using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S6
{
    public class PlayerSegment : MonoBehaviour
    {
        private Transform m_transform;
        private Transform m_followedTransform;
        private Vector3 m_nextPosition;

        private void Awake()
        {
            m_transform = this.transform;
        }

        public void Move( float p_speed )
        {
            Vector3 direction = m_followedTransform.position - m_transform.position;

            if( direction.magnitude < PlayerSegmentManager.SEGMENT_SPACING )
            {
                return;
            }

            m_transform.Translate( direction.normalized * p_speed );

            if(( m_nextPosition - m_transform.position ).sqrMagnitude < 0.1f )
            {
                m_nextPosition = m_followedTransform.position;
            }
        }

        public void SetFollowedTransform( Transform p_transform )
        {
            m_followedTransform = p_transform;
        }
    }
}
