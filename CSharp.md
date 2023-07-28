#### 데이터 타입
| 데이터형 이름 | 설명        | 값의 범위                                    |
| ------- | --------- | ---------------------------------------- |
| int     | 정수형       | -2147483648 ~ 2147483647                 |
| float   | 부동소수점형    | -3.402823E+38 ~ 3.402823E+38             |
| double  | 배정도부동소수점형 | -1.79769313486232E+3.8 ~ 1.79769313486232E+3.8 |
| bool    | 불형        | true 또는 false                            |
| char    | 문자형       | 텍스트로 사용되는 유니코드 기호                        |
| string  | 문자열형      | 텍스트                                      |
```c#
int hp = 200;
float f1 = 10.5f;   // float형에는 f를 써야 float형으로 인식
double d1 = 10.5;   // f 안쓰면 double형으로 인식
bool isTrue = true;
bool isFalse = false;
char ch1 = 'A';
char ch2 = '\n';
string s = "Hello world";
```

<br/>

#### 조건문
```c#
int hp = 200;

if (hp <= 50)
{
  Debug.Log("도망");
}
else if (hp >= 200)
{
  Debug.Log("공격");
}
else
{
  Debug.Log("방어");
}
```

<br/>

#### switch
```c#
char ch = 'F';

switch(ch)
{
    case 'M':
        Console.WriteLine("남성");
        break;
    case 'F':
        Console.WriteLine("여성");
        break;
    default:
        Console.WriteLine("알 수 없음");
        break;
}
```

<br/>

#### 반복문
```c#
for (int i = 0; i <= 10; i++)
{
  Debug.Log(i);
}
```
```c#
int[] arr = new int[]{1, 2, 3, 4, 5};

foreach (int elem in arr)
{
    Console.WriteLine(elem);
}
```
```c#
int sum = 0;
int n = 1;

while (n <= 100)
{
    if (n % 2 == 0)
    {
        sum += n;
    }
    n ++;
}
```

<br/>

#### 배열
```c#
int[] arr1;
int[] arr2 = new int[5];
int[] arr3 = {0, 1, 2, 3, 4};
int sum = 0;

for (int i = 0; i <= arr3.Length; i++)
{
  Debug.Log(arr3[i]);
  sum += arr3[i];
}

float avg = sum / arr3.Length;
// C#에서 정수끼리 나눗셈을 하면 소수점 이하가 버려져 정수가 됨
// 소수점까지 저장하고 싶으면 처음에 1.0f를 넣어줘야함
// float avg = 1.0f * sum / arr3.Length;
```
```c#
// 다차원 배열
// ,를 사용
int[,] arr1 = new int[10, 5];   // 10행 5열의 2차원 배열
int[,,] arr2 = new int[4, 5, 6];   // 5행 6열 배열이 4개있는 3차원 배열
int[,] arr3 = new int[2, 3]{{1, 2, 3}, {4, 5, 6}};
```
```c#
// 가변 배열
// 배열의 배열로 배열의 요소가 임의 크기의 배열
int[][] arr = new int[5][];
arr[0] = new int[10];
arr[1] = new int[9];
arr[2] = new int[8];
arr[3] = new int[7];
arr[4] = new int[6];
```

<br/>

#### 메소드
```c#
void Hello()
{
  Debug.Log("Hello");
}

string Test(string s)
{
  return s + "Test";
}

Hello();
Test("Good");
```

<br/>

#### 클래스
```c#
public class Player
{
  private int hp = 100;
  private int power = 50;
  
  public void Attack()
  {
    Debug.Log(this.power + "데미지를 입혔다");   // this는 자신의 인스턴스를 가리키는 키워드
  }
  
  public void Damage(int damage)
  {
    this.hp -= damage;
    Debug.Log(damage + "데미지를 입었다");
  }
}

public class Test : MonoBehaviour
{
  void Start()
  {
  	Player p1 = new Player();   // new 키워드 사용해 인스턴스 생성
  	p1.Attack();
  	p1.Damage(30);
  }
}
```

* MonoBehaviour 클래스는 게임 오브젝트를 구성하는 기본 기능을 가지는 클래스

<br/>

#### Vector 클래스
* Vector3 클래스
  * 3D 게임에서 사용하는 float형 x, y, z값을 사용하는 클래스
  ```c#
  class Vector3
  {
    public float x;
    public float y;
    public float z;
  }
  ```

* Vector2 클래스
  * 2D 게임에서 사용하는 float형 x, y값을 사용하는 클래스

  ```c#
  class Vector2
  {
    public float x;
    public float y;
  }
  ```
* 좌표와 벡터 모두 사용할 수 있으며 x = 3, y = 5를 좌표로 사용하면 오브젝트가 (3, 5)에 배치되었다는 의미이고 벡터로 사용하면 x축으로 3, y축으로 5 움직였다는 의미
```c#
Vector2 playerPos = new Vector2(3.0f, 4.0f);
playerPos.x += 8.0f;
playerPos.y += 5.0f;
Debug.Log(playerPos);

Vector2 startPos = new Vector2(2.0f, 1.0f);
Vector2 endPos = new Vector2(8.0f, 5.0f);
Vector2 dir = endPos - startPos;   // startPos에서 endPos로 향하는 벡터
float len = dir.magnitude;   // startPos에서 endPos까지의 거리로 dir벡터 길이와 같으므로 magnitude 멤버 변수를 사용했음
```

