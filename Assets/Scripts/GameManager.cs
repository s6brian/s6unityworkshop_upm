// singleton in native c#: https://msdn.microsoft.com/en-us/library/ff650316.aspx

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
	private static volatile GameManager m_instance;
	private static object m_syncRoot = new System.Object();

	private GameManager(){}

	public static GameManager Instance
	{
		get
		{
			if(m_instance == null)
			{
				lock(m_syncRoot)
				{
					if(m_instance == null)
					{
						m_instance = new GameManager();
					}
				}
			}

			return m_instance;
		}
	}
}
