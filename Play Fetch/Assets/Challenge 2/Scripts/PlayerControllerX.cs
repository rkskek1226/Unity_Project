using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool isDelay = true;
    private float delayTime = 1;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isDelay == true)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                StartCoroutine(PlayerInputDelay());
                isDelay = false;
            }
        }
    }

    IEnumerator PlayerInputDelay()
    {
        yield return new WaitForSeconds(delayTime);
        isDelay = true;
    }
}
