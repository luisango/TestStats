using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Board
{
    class MinigameBox : Box
    {
        public Manager.Minigame.Type m_minigame = Manager.Minigame.Type.NONE;
        public Minigame.Definition m_definition = null;


        protected new void Awake()
        {
            Assembly a = typeof(Minigame.Definition).Assembly;
            m_definition = (Minigame.Definition) a.CreateInstance(m_minigame.ToString() + ".MinigameDefinition");

            // If minigame is not selected, then select one randomly
            if (m_definition == null) {
                Manager.Minigame m = Manager.Minigame.Instance;
                int selected = Random.Range(0, m.Get().Count);

                m_definition = m.Get()[selected];
            }
        }

        protected new bool OnTriggerAction(Collider other)
        {
            if (base.OnTriggerAction(other))
                return false;

            return true;
        }

        protected override void BoxAction()
        {
            Manager.Minigame.Instance.Load(m_definition);
        }
    }
}