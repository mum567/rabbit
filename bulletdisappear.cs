using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdisappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //충돌시 처리
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Fire")
        {
            //충돌체 파괴
            Destroy(coll.gameObject);

            //총알도 파괴
            Destroy(gameObject);
        }
    }
}
