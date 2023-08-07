using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    private float jumpForce = 700;
    private float gravityModifier = 2f;
    public bool isOnGround = true;
    public bool gameOver = false;
    private int jumpCnt = 0;
    public bool dash = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        //{
        //    playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //    isOnGround = false;
        //    playerAnim.SetTrigger("Jump_trig");
        //    dirtParticle.Stop();
        //    playerAudio.PlayOneShot(jumpSound, 0.5f);
        //}

        if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < 2 && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.5f);
            jumpCnt++;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            dash = true;
            playerAnim.SetFloat("Speed_mul", 2.0f);
        }
        else
        {
            dash = false;
            playerAnim.SetFloat("Speed_mul", 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
            jumpCnt = 0;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
            dirtParticle.Stop();

            playerAudio.PlayOneShot(crashSound, 0.5f);
        }
    }
}
