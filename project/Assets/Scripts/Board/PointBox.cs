using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Board
{
    class PointBox : Box
    {
        public bool m_isRangedPoints = false;
        public Vector2 m_pointRange = new Vector2();
        public int m_points = 0;


        protected new void Awake()
        {
            // Fix for floating random result
            m_pointRange += new Vector2(0, 1);

            if (m_isRangedPoints)
                m_points = Random.Range((int) m_pointRange.x, (int) m_pointRange.y);
        }
    }
}