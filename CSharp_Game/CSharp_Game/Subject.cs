using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game
{
    public interface IObserver
    {
        void Update(string message); // 
    }

    //관찰자 패턴 사용
    internal class Subject
    {
        //체력 0 게임 오버

        //몬스터에게 승리 .. 경험치 획득 및 레벨업인가

        //레벨 업 시

        //맵을 최대치까지 도달
        private readonly List<IObserver> observers = new(); // 옵저버 리스트

        public void Subscribe(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void Unsubscribe(IObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        protected void NotifyObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }

    }
}
