using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bl_Joystick Joystick;
    public float speed;
    public GameObject bullet;
    public GameObject muzzlePoint;
    public GameObject Exploision;
    public int Health;
    public int NumOfHearts;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    void Start()
    {
        
    }

    void Update()
    {
        if (Health > NumOfHearts)
        {
            Health = NumOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Health)
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < NumOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        float x = Joystick.Horizontal;//Input.GetAxisRaw("Horizontal");
        float y = Joystick.Vertical;//Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);

        
    }

    void Move(Vector2 direction) 
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.4f;
        min.x = min.x + 0.4f;

        max.y = max.y - 0.4f;
        min.y = min.y + 0.4f;

        Vector2 pos = transform.position;
        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    public void Shoot()
    {
        GameObject newBullet = (GameObject)Instantiate(bullet);
        newBullet.transform.position = muzzlePoint.transform.position;
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroid")
        {
            TakeDamage();
            Debug.Log("Damage");
        }
    }

    void TakeDamage()
    {
        GameObject newExploision = (GameObject)Instantiate(Exploision);
        newExploision.transform.position = gameObject.transform.position;
        Health--;
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die() 
    {
        //Destroy(gameObject);
        Debug.Log("You Died");
    }
}
