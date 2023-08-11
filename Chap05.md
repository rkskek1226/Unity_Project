#### AddTorque()
* 정의된 축을 기준으로 Game Object를 회전시키는 힘을 적용시킴

<br/>

#### TextMeshPro
* 화면에서 Text를 표시할 때 사용
* 그냥 TEXT를 사용하는 것보다 더 많은 기능을 제공
* using TMPro; 선언하고 사용

<br/>

#### 특정 Button 눌렸을 때 특정 동작을 수행하고자 하는 경우
* 해당 Button에 이벤트를 할당하면 됨
1. Inspector창에서 OnClick()에서 스크립트를 직접 연결하는 방법
  * 해당 방법은 함수 이름이 변겨오디거나 연결이 풀리면 다시 연결해줘야하는 단점이 있음
2. AddListener()로 이벤트 할당하는 방법
    ```
    Button button1;

    void Start()
    {
       button1 = GetComponene<Button>();
       button1.onClick.AddListener(PressButton1);
    }

    void PressButton1()
    {

    }
    ```
    * 매개변수가 있는 함수를 등록하고자 한다면 람다나 델리게이트를 사용 

<br/>

#### RequireComponent
* 스크립트에 특정 Component를 RequireComponent에 등록하고 GameObject에 해당 스크립트 파일 적용하면 자동으로 Component를 추가해줌
* RequireComponent는 스크립트 파일에서 클래스 위에 작성해야함
  ```
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  [RequireComponent(typeof(Rigidbody))]

  public class Player : MonoBehaviour
  {
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(Vector3.up);
    }
  }
  ```

<br/>

#### Awake()
* 게임이 시작되기전 모든 변수와 게임의 상태를 초기화하기 위해 호출됨
* Start()보다 먼저 호출됨
* 모든 오브젝트가 초기화되고 호출되기 때문에 GameObject.FindWithTag()를 이용해 매핑하는 것은 가능
* 오브젝트들의 Awake()는 랜덤 순서로 실행됨

<br/>

#### Trail Renderer
* 움직이는 Game Object 뒤에 트레일을 렌더링함
* 이동하는 물체의 움직임이나 경로, 위치를 강조할 때 주로 사용
* Time : Trail을 몇초동안 유지할 것인지
* Width : Trail의 시간에 따른 넓이를 어떻게 할 것인지
* Min Vertex Distance : point간의 넓이로 Trail을 어느 구간마다 찍을 것인지(값이 커지면 직선으로 보임)
* AutoDedestrct : 일정 시간 움직이지 않으면 Trail Renderer를 가진 오브젝트 파괴

<br/>

#### 유니티의 Space
* 유니티의 Space(공간)에는 Screen Space와 World Space가 있음
1. Screen Point
  * Screen Space에서 사용
  * 스크린 좌표계는 화면의 width와 height에 따라 x, y값이 결정됨
  * 해상도가 800x400이라면 왼쪽 아래가 (0, 0)이고 오른쪽 위가 (800, 400)이 됨
  * 마우스 포인터의 위치나 Canvas가 스크린 좌표계를 사용
2. World Point
  * World Space에서 사용
  * 게임 세계에서 오브젝트의 위치를 나타낼 때 사용
  * Local 좌표가 포함됨
3. Viewport point
  * 카메라에 상대적이며 전체 크기를 normalized(정규화)해서 범위를 0~1로 설정
  * 왼쪽 아래가 (0, 0)이고 오른쪽 위가 (1, 1)이 됨
<br/>

#### Screen Space -> World Space
* 마우스 클릭한 위치로 캐릭터를 이동시키는 처리를 할 때 사용
<br/>

#### World Space -> Screen Space
* 캐릭터의 머리위에 HP UI를 띄우는 처리를 할 때 사용
* 유니티의 UI는 스크린 공간에 그려지기 때문에 월드 공간에서 움직이는 캐릭터를 따라가려면 월드 공간의 캐릭터 좌표를 스크린 공간으로 변환해서 HP UI에게 알려줘야함
<br/>

#### WorldToScreenPoint()
* World Point를 Screen Point로 변환해줌
* Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);   // pos에는 오브젝트의 Screen 좌표값이 들어감
<br/>

#### ScreenToWorldPoint()
* Screen Point를 World Point로 변환해줌
* Vector3 pos = Camera.main.ScreenToWorldPoint(transform.position);   // pos에는 오브젝트의 World 좌표값이 들어감(z값은 카메라와 오브젝트의 거리)

