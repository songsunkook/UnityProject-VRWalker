using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCtrl : MonoBehaviour
{
    public float speed = 3.0f;                     // 이동 속도
    public float damping = 3.0f;                   // 회전 속도를 조절할 계수
    public float jumpPower = 5f;

    public GameObject starEffect;

    bool isUping = false;

    double originalSpeed;
    float boostSpeed = 2f;
    float cactusSpeed = 0.6f;



    Vector3 dir;

    private Transform camTr;
    private CharacterController cc;

    public static bool isStopped = true;

    void Start()
    {
        camTr = Camera.main.GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            originalSpeed = 3f;
        }
        else
        {
            int sceneName = System.Convert.ToInt32(SceneManager.GetActiveScene().name[2]) - '0' - 1;
            originalSpeed = 3 + 0.5 * (float)sceneName;
        }

        speed = (float)originalSpeed;
    }

    void Update()
    {
        Debug.Log("Speed : " + speed);
        if (!isStopped)
        {

            // 메인카메라가 바라보는 방향
            dir = camTr.TransformDirection(Vector3.forward);

            // dir 벡터의 방향으로 초당 speed만큼씩 이동
            cc.SimpleMove(dir * speed);

            if (isUping)
            {
                transform.Translate(Vector3.up * jumpPower * Time.deltaTime);
            }
        }
    }

    void UpingEnd()
    {
        isUping = false;
    }

    void BoostingEnd()
    {
        speed = (float)originalSpeed;
    }

    void CactusEnd()
    {
        speed = (float)originalSpeed;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        switch (hit.gameObject.tag)
        {
            case "JumpTable":
                isUping = true;
                Invoke("UpingEnd", hit.gameObject.GetComponent<JumpTime>().jumpTime);
                break;

            case "Booster":
                speed = (float)originalSpeed + boostSpeed;
                CancelInvoke("BoostingEnd");
                CancelInvoke("CactusEnd");
                Invoke("BoostingEnd", 0.7f);
                break;

            case "Cactus":
                speed = (float)originalSpeed - cactusSpeed;
                CancelInvoke("BoostingEnd");
                CancelInvoke("CactusEnd");
                Invoke("CactusEnd", 0.3f);
                break;

            case "Water":
                HeartManager.timeNow = HeartManager.timeFull;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Goal":
                NextStage.gotoNext();
                isStopped = true;
                break;

            case "Car":
                DIe.die = true;
                break;

            case "Star":
                StarManager.GetStar(other.gameObject,starEffect);
                break;
        }
    }
}
