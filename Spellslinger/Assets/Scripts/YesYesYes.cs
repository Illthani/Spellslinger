using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesYesYes : MonoBehaviour
{
    [SerializeField] private GameObject EnemySpawn;

    public bool YESYESYES = false;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < 100; i++)
        {
            float x = Random.Range(-45f, 45f);
            float y = Random.Range(-45f, 45f);
            Instantiate(EnemySpawn, new Vector3(x, 2, y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (YESYESYES)
        {
            Start();
            YESYESYES = false;
        }
    }
}
