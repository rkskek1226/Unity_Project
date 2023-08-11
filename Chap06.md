#### Key Frame
* 애니메이션에서 시작과 끝을 나타내는 프레임
<br/>

#### inbetween(tweens)
* Key Frame 사이의 frame

<br/>

#### Animation
* 녹화 버튼 누르고 특정 프레임 클릭한 후 오브젝트 움직이면 자동으로 보간해줌
* 시작과 끝을 지정하면 중간 과정인 inbetween frame들을 처리해줌

<br/>

#### Squash, Stretch
1. Squash
  * 물체가 힘을 받아 표면에 부딪히면 물체의 표면에 변형이 발생하는데 이를 위한 기술
2. Stretch
  * 변형이 발생한 물체에 타격 에너지가 소멸되면 다시 원래 형태에 가깝게 물체가 되돌아가는데 이를 위한 기술

<br/>

#### State Machine
* 어떤 상태인지에 따라 재생할 애니메이션이 다를때 각각의 조건을 설정하는 기능
* A 상태에서 B 상태로 변화시키려면 A 상태 우클릭 -> Make Transition -> 화살표로 B 상태 연결해주고 화살표의 Condition에서 조건을 설정
* Parameter 설정하고 A 상태에거 B 상태로의 화살표 클릭 -> Condition에서 Parameter 설정

<br/>

#### UGUI
* 유니티 엔진에서 사용되는 GUI 시스템

<br/>

#### Canvas
* 유니티 엔진에서 UI를 배치하기 위한 영역
* UI 요소들의 부모 오브젝트
* World 좌표계를 사용하지 않고 Screen 좌표계를 사용
* UI 요소들의 렌더링 순서는 Hierachy창에서 위에 있는 요소들부터 순차적으로 렌더링됨
* Canvas Scaler
  * 멀티 해상도에 대응하는 방법
  * UI Scale Mode : Canvas에서 UI 요소가 스케일되는 방법을 결정
    * Constant Pixel Size : UI 요소가 화면 크기에 관계없이 동일한 픽셀 크기로 유지
    * Scale With Screen Size : 화면 크기에 따라 UI 요소의 크기가 결정(주로 사용)
      * Match : 스케일링 레퍼런스로 너비와 높이중 어떤 것을 사용할 것인지 결정(배합하는 것도 가능하지만 주로 Height를 1로 설정)  
    * Constant Physical Size : 화면 크기와 해상도에 관계없이 동일한 물리적인 크기를 가짐
<br/>

#### Renderer Mode
* https://ansohxxn.github.io/unitydocs/canvas/
1. Screen Space - Overlay
  * Canvas가 화면에 맞게 스케일된 후 렌더링됨
  * Main Camera같은 카메라 오브젝트를 통해 게임 세상을 먼저 렌더링한 후 그 위에 캔버스를 랜더링하는 방식
2. Screen Space - Camera
  * Canvas가 특정 카메라의 앞쪽으로부터 일정 거리에 위치한 평면 오브젝트위에 드로우되는 것처럼 렌더링됨
  * UI 크기는 카메라 절두체 내에 정확히 맞도록 스케일되기 때문에 거리에 따라 크기가 달라지지는 않음
  * Screen안의 3D 오브젝트중 UI 평면보다 카메라에 가까운 오브젝트들은 UI 앞에 렌더링되고 UI 평면보다 뒤에있는 오브젝트들은 가려짐
3. Wordl Space
  * 3D 게임 세상에서 좌표를 가죠 Canvas의 게임 세상 좌표를 수정할 수 있음
  * Canvas를 3D 오브젝트 취급할 수 있고 배치할 수 있음

<br/>

#### Anchor
* Anchor를 설정하면 부모 오브젝트의 크기가 변경되더라도 위치가 고정됨
* 특정 오브젝트를 좌상단으로 앵커를 설정하면 화면 크기가 어떻게 변하더라도 좌상단에 해당 오브젝트가 계속 존재
* Rect Transform의 Pos X, Pos Y, Pox Z는 앵커값을 기준으로 설정됨

