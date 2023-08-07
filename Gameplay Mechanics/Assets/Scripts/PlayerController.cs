using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 2;
    private Rigidbody playerRb;
    private float forwardInput;

    private GameObject focalPoint;

    public bool hasPowerup = false;
    private float powerupStrength = 10;

    public GameObject powerupIndicator;
    private bool hasPowerupRocket = false;

    private int enemyCount = 0;
    public GameObject bullet;
    public GameObject[] bullets;
    private GameObject[] enemy;

    private bool hasPowerJump = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        // 카메라가 보고있는 방향에서 앞뒤로 이동
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.3f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            hasPowerup = true;
            StartCoroutine(PowerupCountdownRoutine());
        }
        else if (other.CompareTag("PowerIcon"))
        {
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            hasPowerupRocket = true;
            StartCoroutine(PowerupRocketCountdownRoutine());
        }
        else if (other.CompareTag("PowerJump"))
        {
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            hasPowerJump = true;
            StartCoroutine(PowerupJumpCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;   // 적이 튕겨나갈 방향
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            
            // Debug.Log("Collided with : " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
        else if (collision.gameObject.CompareTag("Enemy") && hasPowerupRocket)
        {
            //Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            //Vector3 awayFromPlayer = collision.gameObject.transform.position;
            //enemyRigidbody.AddForce(awayFromPlayer * powerupStrength * 200, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    IEnumerator PowerupJumpCountdownRoutine()
    {
        // playerRb.AddForce(transform.up * 10, ForceMode.Impulse);
        float tmp = gameObject.transform.position.y;

        for (int i = 0; i < 50; i++)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, tmp, gameObject.transform.position.z);
            tmp += 0.1f;
        }

        // gameObject.transform.position = new Vector3(gameObject.transform.position.x, 10, gameObject.transform.position.z);
        yield break;
    }


    IEnumerator PowerupRocketCountdownRoutine()
    {
        // 여기서 발사하면 될 듯
        // enemyCount = FindObjectsOfType<Enemy>().Length;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        // Debug.Log(enemy.Length);

        for (int i = 0; i < enemy.Length; i++)
        {
            // Instantiate(bullet, transform.position + new Vector3(1.5f, 0, 1.5f), enemy[i].transform.rotation);
            // Instantiate(bullet, enemy[i].transform.position, enemy[i].transform.rotation);
            // Instantiate(bullet, (enemy[i].transform.position - transform.position).normalized, enemy[i].transform.rotation);


            //Vector3 heading = enemy[i].transform.position - transform.position;
            //float distance = heading.magnitude;
            //Vector3 direction = heading / distance;
            // Instantiate(bullet, direction, enemy[i].transform.rotation);

            Instantiate(bullet, transform.position, transform.rotation);
            GameObject tmp = GameObject.FindGameObjectWithTag("Bullet");
            tmp.transform.LookAt(enemy[i].transform);

        }

        //for (int i = 0; i < bullets.Length; i++)
        //{
        //    bullets[i].transform.Translate(Vector3.forward * 20);
        //}


        yield return new WaitForSeconds(7);
        hasPowerupRocket = false;
    }
}
