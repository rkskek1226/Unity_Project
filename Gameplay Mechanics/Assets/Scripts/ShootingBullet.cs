using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{

    private float speed = 5f;
    private float forceSpeed = 5f;
    private GameObject[] enemy;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name);
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * forceSpeed, ForceMode.Impulse);
        }
    }
}
