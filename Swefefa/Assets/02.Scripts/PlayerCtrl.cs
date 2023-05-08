using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 1.0f;                      //�̵� �ӵ� ���� ����
    Camera viewCamera;                                  //ī�޶� ���� ���� �������� ���� ����
    Vector3 velocity;                                   //�̵� ���� ���� �� ����
    
    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;                       //�� ��� ī�޶� �Է�
    }

    // Update is called once per frame
    void Update()
    {
        //����� 2D -> �ΰ��� 3D ��ǥ ��ȯ (���콺�� 3D �� ��� �ִ���)
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        //�ٶ� ��ġ�� ����ϱ� ���ؼ� ������Ʈ y�� ��ǥ�� ���� (�ٴ��� x,z ��)
        Vector3 targetPosition = new Vector3(mousePos.x, transform.position.y, mousePos.z);
        //w,a,s,d �� ȭ��ǥ �̵� or �����ϴ� �̵��Է� ���� (Horizontal , Vertical)
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;

        
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + velocity * Time.fixedDeltaTime);
        //GetComponent -> �ҽ��� �ִ� ���ӿ�����Ʈ���� <> �ȿ� �ִ� ���۳�Ʈ�� ����
        //������ �� �Ŀ� ��� �� �̵� ��ġ ���� MovePosition �Լ��� ����
    }
    
}
