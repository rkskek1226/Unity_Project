using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �����ӷ���Ʈ�� 60���� ����
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // Ŭ���ϸ� ȸ�� �ӵ� ����
        // ���޵Ǵ� ���� 0�̸� ���콺 ���� ��ư, 1�̸� ���콺 ������ ��ư, 2�� ���콺 ���� Ŭ���Ǿ������� �ǹ�
        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = 10;
        }

        // ȸ�� �ӵ���ŭ �귿�� ȸ����Ŵ
        // ù��° �Ű������� x�� ����, �ι�° �Ű������� y�� ����, ����° �Ű������� z�� �������� �� ���� �߽����� ȸ���� ����
        // ���޵Ǵ� ���� ����� �ݽð� ����, ������ �ð� �������� ȸ��
        transform.Rotate(0, 0, -1 * this.rotSpeed);

        // ����
        this.rotSpeed *= 0.96f;
    }
}
