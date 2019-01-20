using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPlayer : MonoBehaviour
{

    Vector3 firstPos;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = firstPos + Player.transform.position;
        transform.rotation = Player.transform.GetChild(0).transform.rotation;
    }
}
