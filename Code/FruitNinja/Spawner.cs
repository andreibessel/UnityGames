using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bomb;
    public GameObject[] objectsToSpawn;
    public Transform[] spawnPlaces;

    public float minWait = .3f;
    public float maxWait = 1f;

    public float minFore = 12;
    public float maxFroce = 17;


    public void Start()
    {
        StartCoroutine(SpawnFruits());
    }
    private IEnumerator SpawnFruits()
    {
        do
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject go = null;
            float p = Random.Range(0, 100);
            if (p < 15)
            {
                go = bomb;

            }
            else
            {
                go = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            }

            GameObject fruit = Instantiate(go, t.position,t.rotation);


            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minFore,maxFroce), ForceMode2D.Impulse);
            Destroy(fruit, 5);


        } while (true);
    }

}
