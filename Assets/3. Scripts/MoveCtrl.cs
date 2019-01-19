using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    public float speed = 3.0f;                     // 이동 속도
    public float damping = 3.0f;                   // 회전 속도를 조절할 계수


    bool isUping = false;

    public float jumpPower = 5f;
    Vector3 dir;

    private Transform camTr;
    private CharacterController cc;

    public static bool isStopped = true;

    void Start()
    {
        camTr = Camera.main.GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
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
        speed = 3f;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        switch (hit.gameObject.tag)
        {
            case "JumpTable":
                isUping = true;
                Invoke("UpingEnd", 0.5f);
                break;

            case "Booster":
                speed = 5f;
                CancelInvoke("BoostingEnd");
                Invoke("BoostingEnd", 0.7f);
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

        }
    }
}
