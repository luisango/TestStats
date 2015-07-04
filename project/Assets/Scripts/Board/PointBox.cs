using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Board
{
    class PointBox : Box
    {
        public bool m_isRangedPoints = false;
        public Vector2 m_pointRange;
        public int m_points = 0;

        public Text m_message;


        protected new void Awake()
        {
            // Fix for floating random result
            m_pointRange = new Vector2(-3, 7);

            if (m_isRangedPoints)
                m_points = Random.Range((int) m_pointRange.x, (int) m_pointRange.y);

            if (m_points == 0)
                m_points = 1;

            m_message.text = "the game starts now!\nhave sweet fun!";
            m_message.color = new Vector4(0, 1, 0, 3);
        }

        protected override void BoxAction()
        {
            m_puppetJustEntered.GetPlayer().GetStats().AddPoints(m_points);

            if (m_points > 0)
            {
                m_message.text = "+" + m_points + " points!";
                m_message.color = new Vector4(0, 0, 1, 3);
            }
            else
            {
                m_message.text = m_points + " points!";
                m_message.color = new Vector4(1, 0, 0, 3);
            }

            Manager.Board.Instance.NextTurn();
        }

        void FixedUpdate()
        {
            m_message.color = new Vector4(m_message.color.r, m_message.color.g, m_message.color.b, m_message.color.a - 0.001f);
        }
    }
}