using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    public GameObject PlayerGO;
    public GameObject firePoint;
    [SerializeField] private float rotateSpeed = 0f;
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float sightingRange = 15f;
    private Rigidbody rb;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject effectToSpawn;

    [SerializeField] private float timer;

    [SerializeField] private float timerMax = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        timer = timerMax;
        RotateTowardsPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
//        gameObject.transform.rotation = Quaternion.LookRotation(-PlayerGO.transform.position);
    }

    void FixedUpdate()
    {
        RotateTowardsPlayer();
        MoveTowardsPlayer();
        TargetRay();
    }
    void OnTriggerStay(Collider other)
    {
    }



    void TargetRay()
    {
        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position, Vector3.forward, out hit, sightingRange);
//        Ray ray = new Ray(firePoint.transform.position, gameObject.transform.position);
//        bool hit = Physics.Raycast(gameObject.transform.position, PlayerGO.transform.position, 15f);
        if (hit.collider != null)
        {
//            Debug.Log(hit.collider);

            if (hit.collider.gameObject.CompareTag("Player"))
            {
                if (timer <= 0)
                {
                    MouseButtonSpell();
                    timer = timerMax;
                }
            }
        }
    }

    void MoveTowardsPlayer()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, PlayerGO.transform.position, movementSpeed * Time.deltaTime);
    }

    void RotateTowardsPlayer()
    {
        rb.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(PlayerGO.transform.position - gameObject.transform.position), rotateSpeed * Time.deltaTime);
    }


    private void MouseButtonSpell()
    {
        GameObject vfx;
        if (firePoint != null)
        {

            Vector3 direction = firePoint.transform.position - gameObject.transform.position;
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.LookRotation(direction));

            
        }
    }
}
