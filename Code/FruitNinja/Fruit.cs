using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPreFab;



    public void CreateSlicedFruit()
    {
        GameObject inst=  (GameObject)Instantiate(slicedFruitPreFab, transform.position, transform.rotation);

        Rigidbody[] slicedPieces = inst.transform.GetComponentsInChildren<Rigidbody>();
        FindObjectOfType<GameManager>().IncreaseScore(1);

        foreach (Rigidbody piece in slicedPieces)
        {
            piece.transform.rotation = Random.rotation;
            piece.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);



        }

        Destroy(gameObject);
        Destroy(inst, 5);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b)
        {
            return; 
        }
        CreateSlicedFruit();
    }
}
