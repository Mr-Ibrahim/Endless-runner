using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject playerposition;
    Vector3 offset = new Vector3(-8, 9, 0);
    // Start is called before the first frame update
    void awake()
    {
        playerposition = GetComponent<GameObject>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != (playerposition.transform.position + offset))
        {
            transform.position = Vector3.Lerp(transform.position, playerposition.transform.position + offset, Time.deltaTime * 8);
        }
    }
}
