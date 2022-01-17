using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    bool canFire=true;
    float timer=0;
    Rigidbody rb;
    Vector3 playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement = Vector3.zero;

        playerMovement += Input.GetAxis("Horizontal") * Vector3.right;
        playerMovement += Input.GetAxis("Vertical") * Vector3.up;

        rb.MovePosition(transform.position + playerMovement * speed * Time.deltaTime);

        if (playerMovement.magnitude > 0)
        {
            transform.up = playerMovement.normalized;
        }

        //transform.Translate(horizontalTranslation, verticalTranslation, 0);

        if (Input.GetKeyDown("x"))
        {
            if (canFire == true)
            {
                Fire();
            }
        }

        timer += Time.deltaTime;
        if(timer>5)
        {
            canFire = true;
            timer = 0;
        }
    }

    void Fire()
    {
        canFire = false;
        Instantiate(bulletPrefab, transform.position+0.8f*transform.up, transform.rotation, transform);
    }
}
