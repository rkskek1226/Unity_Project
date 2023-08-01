using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 10.0f;
    private float xRange = 10;
    private float zRange = 15f;
    public GameObject projectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if (transform.position.x > 10)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        if (transform.position.z < 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (transform.position.z > zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);

        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // player�κ��� �߻�Ǿ��ϹǷ� projectPrefab�� ��ġ�� transform.position�� ��
            // ȸ���� �ʿ䰡 ���⶧���� �׳� projectPrefab�� ȸ���� projectPrefab.transform.rotation�� ��
            Instantiate(projectPrefab, transform.position + new Vector3(0, 0, 1.5f), projectPrefab.transform.rotation);   
        }
    }
}
