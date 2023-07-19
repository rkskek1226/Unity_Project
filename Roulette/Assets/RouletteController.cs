using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 프레임레이트를 60으로 고정
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // 클릭하면 회전 속도 설정
        // 전달되는 값이 0이면 마우스 왼쪽 버튼, 1이면 마우스 오른쪽 버튼, 2면 마우스 휠이 클릭되었는지를 의미
        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = 10;
        }

        // 회전 속도만큼 룰렛을 회전시킴
        // 첫번째 매개변수는 x축 방향, 두번째 매개변수는 y축 방향, 세번째 매개변수는 z축 방향으로 각 축을 중심으로 회전을 수행
        // 전달되는 값이 양수면 반시계 방향, 음수면 시계 방향으로 회전
        transform.Rotate(0, 0, -1 * this.rotSpeed);

        // 감속
        this.rotSpeed *= 0.96f;
    }
}
