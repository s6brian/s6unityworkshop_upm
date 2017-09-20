using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace S6
{
	public class ScoreManager : MonoBehaviour
	{
		private Text m_scoreTextUI;
		private int m_score;

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
			m_scoreTextUI = this.GetComponent<Text>();
			Assert.IsNotNull( m_scoreTextUI );

			Reset();
		}

		private void Reset()
		{
			m_score = 0;
			m_scoreTextUI.text = "Score: 0";
		}

		public void AddScore( int p_score )
		{
			m_score += p_score;
			m_scoreTextUI.text = "Score: " + m_score;
		}
	}
}
