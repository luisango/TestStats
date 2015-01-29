using UnityEngine;
using System.Collections;

namespace Utils
{
	public class Singleton
	{
		private static Singleton m_instance = null;

		protected Singleton()
		{
		}
	
		public static Singleton Instance()
		{
			if (m_instance == null)
				m_instance = new Singleton();
			
			return m_instance;
		}
	}
}
