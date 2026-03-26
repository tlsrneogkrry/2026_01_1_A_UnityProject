using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;                                 //이동 속도 변수 설정
    public float jumpForce = 5.0f;                                 //점프 힘 값을 선언 한다.

    public Rigidbody rb;                                           //플레이어 강체 선언 

    public bool isGrounded = true;                                 //땅 위에 있는지 체크 하는 변수 (true/false)

    public int coinCount = 0;                                         //코인 획득 변수 설정

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //움직임 입력
        float moveHorizontal = Input.GetAxis("Horizontal");            //수평 이동(키값을 받아온다 , -1 ~ 1)
        float moveVertical = Input.GetAxis("Vertical");                //수직 이동(키값을 받아온다 , -1 ~ 1)

        //강체에 속도의 값을 변경해서 캐릭터를 이동 시킨다.
        rb.linearVelocity = new Vector3(moveHorizontal * moveSpeed, rb.linearVelocity.y, moveVertical * moveSpeed);

        //점프 입력
        if (Input.GetButtonDown("Jump") && isGrounded)   // && 두 값을 만족할때 -> (스페이스 버튼을 눌렀을때와 땅 위에 있을때)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);    // 위쪽 방향으로 설정한 힘수치만큼 순간적으로 힘을 가한다.
            isGrounded = false;                                        // 점프를 하는 순간 땅에서 떨어졌기 때문에 false로 한다.
        }
    }


    void OnCollisionEnter(Collision collision)                     //유니티에서 지원해주는 충돌 체크 함수
    {
        if (collision.gameObject.tag == "Ground")                               //충돌이 일어난 물체의 Tag 가 Ground 인 경우
        {
            isGrounded = true;                                         //땅과 충돌하면 true로 만들어 준다.

        }
    }



    private void OnTriggerEnter(Collider other)                    //캐릭터가 특정 지역을 들어갈때(충돌 범위) 체크 하는 함수
    {
        if (other.CompareTag("Coin"))                              // Tag 가 코인일 경우
        {
            coinCount++;                                           //코인 변수를 1 올린다.
            Destroy(other.gameObject);                             //코인 오브젝트를 파괴 한다.
        }
    }
}
