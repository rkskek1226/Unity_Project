using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController pcScript;
    private GameObject player;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
        player = GameObject.Find("Player");
        Invoke("SpeedInvoke", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!pcScript.gameOver)
        {
            if (pcScript.dash)
                score += 2;
            else
                score++;
        }
        Debug.Log(score);
    }

    private void SpeedInvoke()
    {
        player.GetComponent<Animator>().SetFloat("Speed_f", 1f);
    }
}
