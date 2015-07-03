using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Board
{
    class PointBox : Box
    {
        public bool m_isRangedPoints = false;
        public Vector2 m_pointRange;
        public int m_points = 0;


        protected new void Awake()
        {
            // Fix for floating random result
            m_pointRange = new Vector2(-5, 7);

            if (m_isRangedPoints)
                m_points = Random.Range((int) m_pointRange.x, (int) m_pointRange.y);

            if (m_points == 0)
                m_points = 1;
        }

        protected override void BoxAction()
        {
            m_puppetJustEntered.GetPlayer().GetStats().AddPoints(m_points);
        }
    }
}