using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;                                     //최대 생명력
    public int currentLives;                                     //현재 생명력

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLives = maxLives;                                  //생명력 초기화 
    }

    void OnTriggerEnter(Collider other)                   //트리거 안에 들어왔나를 검사하는 함수
    {
        if (other.CompareTag("Missile"))                          //미사일과 충돌 하면
        {
            currentLives--;
            Destroy(other.gameObject);                            //미사일 오브젝트를 없앤다.

            if (currentLives <= 0)                                //채력이 0 이하일 경우
            {
                GameOver();                                       //종료 함수를 호출 한다.
            }
        }

    }


    void GameOver()
    {
        gameObject.SetActive(false);                              //플레이어 비활성화
        Invoke("RestarGame", 3.0f);                               //3초후 RestarGame 함수를 호출
    }


    void RestarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);            //현재 씬 재시작

    }

}
