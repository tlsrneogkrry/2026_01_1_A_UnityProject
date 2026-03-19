using UnityEngine;
using UnityEngine.UI;

public class MyJump : MonoBehaviour
{
    public Rigidbody rigidbody;                                    //강체 (형태와 크기가 고정된 고체) 물리 현상이 동작 하게 해주는 컴포넌트
    public float power = 200f;                                     //점프 힘을 선언 함
    public Text TimeUI;                                            //시간 UI를 생성
    public float Timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

               
        Timer = Timer + Time.deltaTime;                            //타이머를 상승 시키고
        TimeUI.text = Timer.ToString();                            //타이머 숫자를 문자열 변수로 변경한 후 표시 한다.
         
        if (Input.GetKeyDown(KeyCode.Space))                       //스페이스 바를 누르면 체력이 +2 가 된다.
        {
            power = power + Random.Range(-100, 200);               //power의 랜덤 값을 더해서 변형 시킨다. (-100 ~ 200) 사이의 값을 더 한다.
            rigidbody.AddForce(transform.up * power);              //power의 힘 값으로 위쪽(transform.up)으로 힘을 준다
        }

        if(this.gameObject.transform.position.y > 5 || this.gameObject.transform.position.y < -3)
        {
            //이 오브젝트의 y 좌표값 위치가 5보다 크거다 -3보다 작을경우
            Destroy(this.gameObject);                                    //오브젝트를 파괴한다
        }


    }
}
