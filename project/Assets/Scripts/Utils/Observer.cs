using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
    public class Observable
    {
        private List<IListener> m_listeners;

        public Observable()
        {
            m_listeners = new List<IListener>();
        }

        public void Notify(int evt)
        {
            foreach (IListener o in m_listeners)
                if (!o.OnEvent(evt)) break;
        }

        public void Subscribe(IListener listener)
        {
            m_listeners.Add(listener);
        }

        public void Unsubscribe(IListener listener)
        {
            m_listeners.Remove(listener);
        }
    }

    public interface IListener
    {
        bool OnEvent(int evt);
    }
}
