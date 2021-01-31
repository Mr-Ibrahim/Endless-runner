using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovements : MonoBehaviour
{
    Vector3 currentposition;

    public float leftlane=-5f;
    public float centerlane=-14;
    public float rightlane=-23;
    // Start is called before the first frame update
    void Start()
    {
        currentposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentposition.z == centerlane)
            {
                currentposition.y = transform.position.y;
                currentposition.z =  rightlane;
                transform.position = currentposition;
            }
            else if (currentposition.z == leftlane)
            {
                currentposition.y = transform.position.y;
                currentposition.z =  centerlane;
                transform.position = currentposition;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentposition.z == centerlane)
            {
                currentposition.y = transform.position.y;
                currentposition.z =  leftlane;
                transform.position = currentposition;
            }
            else if (currentposition.z == rightlane)
            {
                currentposition.y = transform.position.y;
                currentposition.z =  centerlane;
                transform.position = currentposition;
            }
        }
    }
}
