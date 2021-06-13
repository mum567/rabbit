using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get : MonoBehaviour
{
    public GameObject[] weapons;
    public bool[] hasweapons;

    Rigidbody rigid;

    bool iDown;
    bool sDown1;
    bool sDown2;
    bool sDown3;

    bool fDown;
    bool isFireReady;

    float fireDelay;

    GameObject nearObject;
    Weapon equipWeapon;  //장착중인 무기는 어떤것입니까?


void Update()
    {
        GetInput();
        Swap();
        Interaction();
        Attack();

    }

void GetInput()
    {
        iDown = Input.GetButtonDown("Interaction");
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        sDown3 = Input.GetButtonDown("Swap3");
        fDown = Input.GetButtonDown("Fire1");
    }

    void Attack()
    {
        if (equipWeapon == null)
            return;

        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.rate < fireDelay;   //공격딜레이에 시간을 더해주고 공격가능 여부를 확인

        if (fDown && isFireReady)
        {
            equipWeapon.Use();
            fireDelay = 0;
        }
    }

    void Swap()
    {
        int weaponIndex = -1;
        if (sDown1) weaponIndex = 0;
        if (sDown2) weaponIndex = 1;
        if (sDown3) weaponIndex = 2;

        if(sDown1 || sDown2 || sDown3)
        {
           if(equipWeapon != null) //빈손이 아닐때만 실행해주세요
            
            equipWeapon.gameObject.SetActive(false);   //손에 이미 있으면
            equipWeapon = weapons[weaponIndex].GetComponent<Weapon>();  //바꿔준다
            equipWeapon.gameObject.SetActive(true);
        }
    }

void Interaction()
    {
        if(iDown && nearObject != null )
        {
            if(nearObject.tag == "Weapon")
            {
                Item item = nearObject.GetComponent<Item>();
                int weaponIndex = item.value;
                hasweapons[weaponIndex] = true;

                Destroy(nearObject);
            }
        }

    }

void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon")
            nearObject = other.gameObject;  //닿아있는 물체가 무기면 저장

        Debug.Log(nearObject.name);
    }

void OnTriggerExit(Collider other)
    {
        if (other.tag == "Weapon")
            nearObject = null;
    }


}
