using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject Asteroid;
    public float SpawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, SpawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn() 
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject newAsteroid = (GameObject)Instantiate(Asteroid);
        newAsteroid.transform.position = new Vector2(Random.Range(min.x + 0.5f, max.x - 0.5f), max.y);
    }
}
