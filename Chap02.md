#### Prefab

* 특정 게임 오브젝트를 재사용해야하는 경우(NPC나 발사체, 나무같은 환경 에셋) 프리팹을 사용하면 효율적
* 프로젝트 뷰에 존재하는 프리팹 원본은 에셋 상태로 이를 그대로 Scene에서 보거나 사용할 수 없기 때문에 Instantiate()를 통해 인스턴스화 해야함
* 프리팹으로부터 원하는 만큼의 프리팹 인스턴스를 생성할 수 있고 생성된 프리팹 인스턴스는 각각 독립적으로 동작
* 프리팹 인스턴스의 프로퍼티를 수정해도 다른 프리팹 인스턴스에는 영향을 주지 않음
* 프리팹 만드는 방법 : Assets에 Prefabs 폴더 생성하고 Hierachy 뷰에서 프리팹으로 만들고자 하는 게임 오브젝트를 선택해서 프로젝트 뷰로 끌어오면 됨(무채색 육면체에서 파란색 육면체로 바뀜)
* 프리팹 등록하는 방법
  1. Resources 폴더에서 가져오는 방법
    * 가져오고자 하는 프리팹이 프로젝트 뷰에서 Assets/Resources 폴더안에 있어야함
    * Resources 폴어에 있는 파일들은 게임이 실행되면 무조건 메모리에 적재되기 때문에 필요한 에셋들만 Resources에 넣어두는 것이 좋음
    ```
    var boxPrefab = Resources.Load<BlackBoX>("Black Box");
    Instantiate(boxPrefab;)
    ```
  2. 컴포넌트의 프로퍼티로 참조하는 방법
    * Scene에 배치된 게임 오브젝트에 부착된 컴포넌트의 프로퍼티로 프리팹 원본을 참조
    ```
    private GameObject boxPrefab;

    private void Start()
    {
        Instantiate(boxPrefab);
    }
    ```

<br/>

#### 유니티 카메라
* Main Camera의 Projection 모드에는 Perspective와 Orthographic이 있음
* Perspective
  * 원근법이 적용되는 3D 화면에서 주로 사용
* Orthographic
  * 직각 투영으로 원근법이 없는 2D 화면에서 주로 사용
  * 3D 게임에서 Orthographic 모드를 사용하면 원근법을 사용하지 않는 2.5D처럼 보임(위에서 아래를 내려보는 Top-Down 형식의 게임에서 주로 사용)

<br/>

#### 유니티 KeyCode
* https://docs.unity3d.com/kr/2018.4/ScriptReference/KeyCode.html

<br/>

#### GameObject, gameObject
* GameObject
  * GameObject는 클래스
  * 게임을 구성하는 요소들을 의미
  * private GameObject animalPrefab = GameObject.Find("Animal");
* gameObject
  * gameObject는 객체로 자신을 사용중인 게임 오브젝트를 의미
  * GameObject에 C# 스크립트를 Add Component하면 GameObject gameObject = new GameObject();가 선언된 것
  * Destroy(gameObject);는 해당 스크립트가 적용된 자신을 제거하라는 의미

<br/>

#### 스크립트에서 게임 오브젝트 찾는 방법
1. 이름으로 찾는 방법
   * 오브젝트들이 많아지면 전체 오브젝트들을 탐색하므로 성능상 불리함
   * target = GameObject.Find("GameObject Name");
2. 태그(Tag)로 찾는 방법
   * 오브젝트에 태그를 먼저 달아야 함(Add Tag)
   * == 연산자는 사용하지 않는 것이 좋음(메모리 효율상 별로)
   * target = GameObject.FindGameObjectWithTag("Tag Name");
   * if (gameObject.CompareTag("Tag Name")) {}

<br/>

#### Destroy()
* 게임 오브젝트나 컴포넌트, 에셋을 제거하는 함수
* 플레이어의 시야에서 보이지 않는 게임 오브젝트들은 제거하는 것이 좋음
* https://velog.io/@kjhdx/Unity-Destroy

<br/>

#### Invoke()
* 특정 함수를 일정 시간만큼 지연시킨 후 실행하는 함수
<br/>

#### InvokeRepeating()
* 특정 함수를 일정 시간만큼 지연시칸 후 반복해서 실행하는 함수

#### CancelInvoke()
* 실행중인 Invoke()를 중지하는 함수

<br/>

#### OnTrigger(), OnCollision()
* OnTrigger()와 OnCollision()의 기능은 같음
* OnTrigger()는 물리 연산을 안하고 관통이 가능
* OnCollision()은 물리 연산을 하고 관통이 불가능
<br/>

#### OnTrigger()
* Trigger를 사용하려면 두 오브젝트 모두 Collider 컴포넌트가 있어야 하고 둘 중 하나는 Is Trigger 옵션이 체크되야 하며 RigidBody 컴포넌트를 가지고 있어야 함
* void OnTrigger(Collider other) : 충돌한 순간 호출됨
* void OnTriggerStay(Collider other) : 충돌이 발생하고 지속되는 동안 호출됨
* void OnTriggerExit(Collider other) : 충돌이 끝난 순간 호출됨
<br/>

#### OnCollision()
* Collision을 사용하려면 두 오브젝트 모두 RigidBody 컴포넌트와 Collider 컴포넌트를 가지고 있어야 하고 Is Trigger 옵션과 Kinematic 속성이 비활성화 상태여야 함
* void OnCollisionEnter(Collision Other) : 충돌한 순간 호출됨
* void OnCollisionStay(Collision other) : 충돌이 발생하고 지속되는 동안 호출됨
* void OnCollisionExit(Collision other) : 충돌이 끝난 순간 호출됨

