using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CarMove : MonoBehaviour
{
    public float firstDelay = 0f;

    public float speed = 7f;
    

    public Transform[] wayPoints;

    bool canMove = false;
    int turn = 0;
    Transform trans;

    void MoveStart()
    {
        canMove = true;
        trans.position = wayPoints[0].position;
    }

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        trans.position = new Vector3(-100, -100, -100);
        Invoke("MoveStart", firstDelay);

        for (int i = 0; i < wayPoints.Length; i++)
            wayPoints[i].gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {

            if (trans.position == wayPoints[turn + 1].position)
            {
                if (wayPoints.Length == turn + 2)
                {
                    turn = 0;
                    trans.position = wayPoints[0].position;
                }
                else
                    turn++;
            }
            else
            {
                trans.LookAt(wayPoints[turn + 1]);
                trans.position = Vector3.MoveTowards(trans.position, wayPoints[turn + 1].position, speed * Time.deltaTime);
            }

        }
    }
}
