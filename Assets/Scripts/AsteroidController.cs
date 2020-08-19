using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed;
    public GameObject Exploision;
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Bullet")
        {
            GameObject newExploision = (GameObject)Instantiate(Exploision);
            newExploision.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }
}
