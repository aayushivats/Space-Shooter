using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 3;
    public Transform player;

    public static GameController instance;

    private void Awake()
    {
        if (instance == null )
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
