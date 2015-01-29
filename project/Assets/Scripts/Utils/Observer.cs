using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
    public abstract class IObservable
    {
        private List<IObserver> m_observers;

        IObservable()
        {
            m_observers = new List<IObserver>();
        }

        public void Notify()
        {
            foreach (IObserver o in m_observers)
                o.OnNotification();
        }

        public void Subscribe(IObserver observer)
        {
            m_observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            m_observers.Remove(observer);
        }
    }

    public abstract class IObserver
    {
        public abstract void OnNotification();
    }
}
