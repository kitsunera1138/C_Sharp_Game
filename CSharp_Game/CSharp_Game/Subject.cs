using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//옵저버
namespace CSharp_Game
{
    //체력 0 게임 오버
    //몬스터에게 승리 .. 경험치 획득 및 레벨업인가
    //레벨 업 시
    //맵을 최대치까지 도달

    public interface IObserver
    {
        void Update(string message); // 
    }


    public interface ISubject
    {
        void Update(string message); // 
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void NotifyObservers();

    }
    //관찰자 패턴 사용
    public class Subject
    {
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
            Console.WriteLine("구독종료");
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
