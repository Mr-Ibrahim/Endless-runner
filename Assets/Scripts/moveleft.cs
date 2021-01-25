using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveleft : MonoBehaviour
{
    private float speed=20;
    private PlayerController playerMovementScript;
    private float leftBound=-15;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript =GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovementScript.gameOver==false){
            transform.Translate(Vector3.left *Time.deltaTime*speed);
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("obstacle")){
            Destroy(gameObject);
        }
        
    }
}
