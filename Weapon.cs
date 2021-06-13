using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public enum Type { Melee,  Range };  //타입 근접공격, 원거리 공격
    public Type type;
    public int damage;  //공격력
    public float rate;  //공격 속도
    public BoxCollider meleeArea;  //공격 범위

    public void Use() //플레이어가 무기를 사용
    {
        if(type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
    }
    
    IEnumerator Swing() //열거형 함수 클래스
    {

        
        yield return new WaitForSeconds(0.1f);  
        meleeArea.enabled = true;

        
       yield return new WaitForSeconds(0.3f);
        meleeArea.enabled = false;

       
    }

}
