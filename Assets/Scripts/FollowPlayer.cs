using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float offset ;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(player.position.x);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + offset, -10);

    }
}
