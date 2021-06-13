using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //활마다 다르게 할 수 있다

    public string arrowName;     // 활 이름
    public float range;    //사정 거리
    public float accuracy;   //정확도
    public float fireRate;   //연사 속도. 높으면 높을수록 연사 속도는 느려진다
    public float reloadTime;  //재장전 속도

    public int damage; //화살의 데미지.

    public int reloadBulletCount; // 화살알 재정전 개수.
    public int currentBulletCount; // 현재 화살통 안에 남아있는 화살의 개수.
    public int maxBulletCount; // 최대 소유 가능 화살 개수.
    public int carryBulletCount; // 현재 소유하고 있는 화살 개수.

    public float retroActionForce; // 반동 세기
    public float retroActionFineSightForce; // 정조준시의 반동 세기.

    public Vector3 fineSightOriginPos;    //정조준시 활이 가운데로 오는 그런
    public Animator anim;   //근데 우리는 활에 애니메이션 없으니까 pass
    public ParticleSystem muzzleFlash;   //이펙트시스템 효과

    public AudioClip fire_Sound;     //발사 소리
}
