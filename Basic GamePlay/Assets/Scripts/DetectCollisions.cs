using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gm = new GameManager();

    public enum Type
    {
        Player,
        Animal,
        Bullet,
    }
    public Type type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject == GameObject.Find("Player"))
        {
            gm.minusLives();
            string str = "Score : " + gm.getScore().ToString() + "   " + "Lives : " + gm.getLives().ToString();
            Debug.Log(str);
            Destroy(other.gameObject);
        }
        else
        {
            if (gameObject.CompareTag("Animal"))
            {
                gm.plusScore();
                string str = "Score : " + gm.getScore().ToString() + "   " + "   Lives : " + gm.getLives().ToString();
                gameObject.GetComponent<AnimalHunger>().FeedAnimal(1);
                Debug.Log(str);
            }
            if (gameObject.CompareTag("Bullet"))
                Destroy(gameObject);
        }
        if (gm.getLives() == 0)
            Debug.Log("Game Over");
    }
}
