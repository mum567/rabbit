using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController1 : MonoBehaviour
{ 

    //스피드 조정 변수

    [SerializeField] //인스펙터창에서 쉽게 수정할 수 있도록
    private float walkSpeed;

    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private float crouchSpeed;   //걷기

    private float applySpeed;   //워크나 런 대입하면 하나로 조정할 수 있기 때문에

    [SerializeField]
    private float jumpForce;


    //상태변수
    private bool isRun = false;
    private bool isCrouch = false;   // 앉았는지 안앉았는지
    private bool isGround = true;   //땅에 있는지 없는지, 땅에 붙어있을때만 점프할 수 있도록


    // 앉았을 때 얼마나 앉을지 결정하는 변수. 
    [SerializeField]
    private float crouchPosY;     //숙이는건 Y값이 감소해야하니까  
    private float originPosY;      // 숙였다가 원래대로 돌아가야하니까 첫 높이 기억
    private float applyCrouchPosY;  

    // 땅 착지 여부  >> 콜라이더가 땅에 닿아있을때만 점프하는거다
    private CapsuleCollider capsuleCollider;


    //민감도
    [SerializeField]
    private float lookSensitivity;

    //카메라 한계
    [SerializeField]
    private float cameraRotationLimit;   //자연스러운 시선처리를 위해
    private float currentCameraRotationX = 0f;    //일단 정면을 바라본다


    //필요한 컴포넌트
    [SerializeField]
    private Camera theCamera;

    private Rigidbody myRigid;   //덩어리





    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>();   //rigidbody 변수
        applySpeed = walkSpeed;  //달리기 전까지 무조건 걷는 상태이기 때문에

        // 초기화.
        originPosY = theCamera.transform.localPosition.y;  //플레이어가 아니라 카메라를 움직일것. 상대적인 카메라가 기준
        applyCrouchPosY = originPosY;   //기본은 서있는 상태
    }


    
    void Update()
    {
        IsGround();
        TryJump();
        TryRun();
        TryCrouch();
        Move();
        CameraRotation();
        CharacterRotation();

    }

    // 앉기 시도
    private void TryCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))  //키코드 수정하고싶으면 말해
        {
            Crouch();
        }
    }

    // 앉기 동작
    private void Crouch()
    {
        isCrouch = !isCrouch;

        if (isCrouch)   //앉겠다는것
        {
            applySpeed = crouchSpeed;
            applyCrouchPosY = crouchPosY;
        }
        else   //서겠다는것
        {
            applySpeed = walkSpeed;
            applyCrouchPosY = originPosY;
        }

        StartCoroutine(CrouchCoroutine());

    }

    // 부드러운 동작 실행.(부드러운 카메라 이동)
    IEnumerator CrouchCoroutine()
    {

        float _posY = theCamera.transform.localPosition.y;  //카메라가 지금 토끼의 자식개체라서 로컬포지션 사용
        int count = 0;

        while (_posY != applyCrouchPosY)   //표지션 Y가 원하는 값이 되면 그만둠
        {
            count++;
            _posY = Mathf.Lerp(_posY, applyCrouchPosY, 0.3f);  //어플라이크로치포스와이가 목적지, 속도 바꾸고싶으면 0.3f 조정해
            theCamera.transform.localPosition = new Vector3(0, _posY, 0);  
            if (count > 15)
                break;
            yield return null;  //한 프레임 대기
        }
        theCamera.transform.localPosition = new Vector3(0, applyCrouchPosY, 0f);   //15번정도 반복하다가 목적지 도착하고 멈춤 빠져나온다
    }

    // 지면 체크.
    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
        //계단, 대각선 이런곳에서도 오류가 없기위해 약간의 여유를 준다
    }


    // 점프 시도
    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
    }

    // 점프
    private void Jump()
    {

        // 앉은 상태에서 점프시 앉은 상태 해제.
        if (isCrouch)
            Crouch();

        myRigid.velocity = transform.up * jumpForce;   //jumpForce에 들어가는 힘만큼 뛰어오르는거
    }



    private void TryRun()  //달리기 시도
    {
        if(Input.GetKey(KeyCode.R))  //왼쪽 R 누르면 달리고 >> 키코드 바꾸고싶으면 말해
        {
            Running();
        }

        if(Input.GetKeyUp(KeyCode.R))  //왼쪽 R 안누르면 걷는다 >> 키코드 바꾸고싶으면 말해
        {   RunningCancel();
        }
    }

    private void Running()   //달리기 시행
{
     
           if (isCrouch)    //앉았다가 일어날때도 오류없이 잘 달리기 위해서
            Crouch();

    isRun = true;
    applySpeed = runSpeed;
}

private void RunningCancel()    //달리기 취소
{
    isRun = false;
    applySpeed = walkSpeed;  //멈췄으니까 다시 걸어야지
}


    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");   // 화살표 좌우 입력하면 X축 바뀌는것
        float _MoveDirZ = Input.GetAxisRaw("Vertical");     // 화살표 정면,후면 입력하면 바뀌는것

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _MoveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;  //1초에 얼마나 이동시킬건지 계산 편하게 하기 위해  //달리지 않는 이상 걷는다

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);  //업데이트 함수가 1초동안 움직이는 만큼
    }

    private void CharacterRotation()
    {
        // 좌우 캐릭터 회전
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;  //위아래와 좌우민감도 동일하게 설정
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        Debug.Log(myRigid.rotation);
        Debug.Log(myRigid.rotation.eulerAngles);
    }

    private void CameraRotation()
    {
        // 상하 카메라 회전
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;   //어느정도 카메라 천천히 움직이게
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);  //limit만큼 가두기

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

}
