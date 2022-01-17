using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    float maxX = 9f;
    float minX = -9f;
    float maxY = 5f;
    float minY = -5f;
    bool shootTime = true;
    float timer = 0;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = enemyDirection(-5f, 5f);
        rb.velocity = enemyDirection(-2f, 2f).normalized *1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5f)
        {
            shootTime = true;
        }

        /*if(shootTime==true && GameController.instance.player)
        {
            Vector3 bulletDir = GameController.instance.player.position-transform.position;
            GameObject bullet = Instantiate(bulletPrefab,transform.position, Quaternion.identity, transform);
            bullet.transform.up = bulletDir.normalized;
            shootTime = false;
            timer = 0;
        }*/
      
        if (transform.position.x <= minX || transform.position.x>=maxX || transform.position.y <= minY || transform.position.y >= maxY)
        {
            
            rb.velocity = -rb.velocity;
        }
    }

    private Vector3 enemyDirection(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        return new Vector3(x, y,0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ship>())
        {
            Destroy(gameObject);
        }
    }
}
