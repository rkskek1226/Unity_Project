#### 렌더링
* 2차원이나 3차원 장면을바탕으로 사진이나 영상을 만들어내는 과정이나 기법

<br/>

#### Sprite
* 2D 그래픽 오브젝트
* Sprite Renderer 컴포넌트를 이용해 Sprite가 2D 및 3D Scene에서 시각적으로 표시되는 방식을 제어

<br/>

#### 스크립트에서 Rigidbody 컴포넌트 가져오는 방법
```
private Rigidbody playerRb = GetComponent<Rigidbody>();
```

<br/>

#### AddForce()
* Translate()처럼 이동하지만 물리적인 힘으로 이동하는함수
* public void AddForce(Vector3 forc3, ForceMode mode=ForceMode.Force)
* public void AddForce(float x, float y, float z, ForceMode mode=ForceMode.Force)
* ForceMode는 어떤 방식으로 힘을 전달할지 결정하는 파라미터
  * Acceleration : 연속적인 힘 + 질량을 무시 -> 오브젝트의 질량에 관계없이 가속됨
  * Force : 연속적인 힘 + 질량을 무시하지 않음 -> 현실적인 물리 현상을 나타낼 때 주로 사용
  * Impulse : 불연속적인 힘 + 질량을 무시하지 않음 -> 짧은 순간의 힘이나 충돌에 주로 사용
  * VelocityChange : 불연속적인 힘 + 질량을 무시 -> 오브젝트의 질량에 관계없이 속도를 변경

<br/>

#### Physics
* 물리와 관련된 함수들이 미리 들어있는 함수 집합
* physics.gravity = 10;   // 중력 가속도 상수 벡터를 변경한다는 의미

#### 플레이어가 오른쪽으로 계속해서 이동하는 느낌 주는 방법(쿠키런)
* 왼쪽으로 이동하는 스크립트 만들고 배경과 특정 오브젝트들에 적용
* 배경이 특정 범위를 넘어갈 때 배경의 transform.position에 배경의 시작 위치를 대입하면 끊임없이 이어지는 연출이 가능

<br/>

#### Rigidbpdy 컴포넌트 Constraints
* 특정 축(x, y, z축)을 기준으로 회전이나 위치를 고정하는 기능
* Constraints를 설정함으로써 캐릭터가 특정 지형에 따라 물리 효과를 받아도 넘어지지 않음(만약 Constraints를 설정하지 않았다면 무엇인가를 밟는 순간 넘어짐)
* Inspector창에서 설정 가능하지만 스크립트에서도 설정 가능
```
private Rigidbody rb;
rb.Constraints.FreezeRotationX;   // x축으로 회전하지 않기
rb.Constraints.FreezeRotationY;   // y축으로 회전하지 않기
rb.Constraints.FreezeRotationZ;   // z축으로 회전하지 않기
rb.Constraints.FreezePositionX;   // x축으로 이동하지 않기
rb.Constraints.FreezePositionY;   // y축으로 이동하지 않기
rb.Constraints.FreezePositionZ;   // z축으로 이동하지 않기
rb.Constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;   // x축으로 이동 및 회전하지 않기
```

<br/>

#### A 스크립트에서 특정 오브젝트에 적용된 B 스크립트 가져오는 방법
```
private BScript sc = GameObject.Find("Player").GetComponent<BScript>();
```

<br/>

#### Animator
* Walk_Static : 제자리에서 걷는 느낌
* Run_Static : 제자리에서 뛰는 느낌
* Walk : 특정 방향으로 걷는 느낌
* Run : 특정 방향으로 뛰는 느낌

<br/>

#### Audio
* Main Camera에서 Audio Source 컴포넌트 추가하고 AudioClip에서 재생할 음악 추가하면 배경 음악처럼 사용 가능
* 특정 동작에서 특정 사운드를 연출하고 싶다면 AudioSource, AudioClip 추가해서 사용
  ```
  private AudioSource playerAudio;
  private AudioClip crashSound;

  playerAudio.PlayOneShot(crashSound);
  ```