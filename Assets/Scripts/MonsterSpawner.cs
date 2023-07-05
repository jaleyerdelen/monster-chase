using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterRefence;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters() 
    {
      while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterRefence.Length); //3 karakter oldu�u i�in 0 ile 3 aras�nda monster ��k�yor 0,1,2
         
            randomSide = Random.Range(0, 2); // 0 ve 1 sonucu ��k�yor console'da


            spawnedMonster = Instantiate(monsterRefence[randomIndex]); //objeyi kopyalar yani s�rekli yeni canavarlar geliyor
 


            // left side
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                // right side
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1, 1f, 1f); //local scale transform'daki scale ve oraya -1 yazarsak karakter ters tarafa d�n�yor
            }
        }
    }

}
