using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 1.0f;                      //이동 속도 변수 선언
    Camera viewCamera;                                  //카메라 정보 값을 가져오기 위해 선언
    Vector3 velocity;                                   //이동 방향 벡터 값 선언
    
    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;                       //주 사용 카메라 입력
    }

    // Update is called once per frame
    void Update()
    {
        //모니터 2D -> 인게임 3D 좌표 변환 (마우스가 3D 상에 어디에 있는지)
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        //바라볼 위치를 계산하기 위해서 오브젝트 y축 좌표를 설정 (바닥은 x,z 축)
        Vector3 targetPosition = new Vector3(mousePos.x, transform.position.y, mousePos.z);
        //w,a,s,d 나 화살표 이동 or 지원하는 이동입력 도구 (Horizontal , Vertical)
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;

        
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + velocity * Time.fixedDeltaTime);
        //GetComponent -> 소스가 있는 게임오브젝트에서 <> 안에 있는 컴퍼넌트를 접근
        //접근을 한 후에 계산 된 이동 위치 값을 MovePosition 함수에 적용
    }
    
}
