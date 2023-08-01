using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    private GameManager gm = new GameManager();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If an object goes past the players view in the game, remove that object
        if (transform.position.z > topBound)
            Destroy(gameObject);
        else if (transform.position.z < lowerBound)
        {
            gm.minusLives();
            string str = "Score : " + gm.getScore().ToString() + "   " + "Lives : " + gm.getLives().ToString();
            Debug.Log(str);

            if (gm.getLives() == 0)
                Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
