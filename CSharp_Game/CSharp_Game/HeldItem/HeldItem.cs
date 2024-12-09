using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game.HeldItem
{
    public interface IItem
    {
        void Use();
    }

    abstract class HeldItem
    {
        public int Id;

        //갯수
        public abstract int OwnedItemCount { get; set; }
        //회복량
        public abstract int recoveryAmount { get; set; }
        int healingRate; //회복 비율
    }

    class Potion : HeldItem, IItem
    {
        public override int recoveryAmount { get; set; }
        public override int OwnedItemCount { get; set; }

        Potion()
        {
            recoveryAmount = 20;
            OwnedItemCount = 10;
        }
        public void Use()
        {
            OwnedItemCount--;
            if(OwnedItemCount > 0)
            {
                //대충 게임매니저나 다른 곳에서 플레이어 회복 매서드 불러온다
                //void HealRecoveryAmount(recoveryAmount);
            }
        }
    }
}
