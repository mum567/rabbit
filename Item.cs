using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 아이템들 무기나 간이나 
public class Item : MonoBehaviour

{ 
   public enum Type { Ammo, Coin, Grenade, Heart, Weapon }; //변수가 아니라 하나의 타입일 뿐. 
    public Type type;    //위에서 말한거 선언하기 위해

    public int value;   //아이템이 가지고 있는 값

    void Update()
    {
        

    }
    
}

