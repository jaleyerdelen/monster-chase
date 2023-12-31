using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
       // Debug.Log("The selected index: " + GameManager.instance.CharIndex);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // monster player'a �arp�nca hata veriyordu ��nk� referans'� null idi. 
        if(!player)
            return;
   
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if(tempPos.x < minX) 
            tempPos.x = minX;

        if(tempPos.x > maxX) 
            tempPos.x = maxX;

        transform.position = tempPos;

    }
}
