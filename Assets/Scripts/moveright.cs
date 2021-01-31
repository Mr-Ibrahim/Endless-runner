using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveright : MonoBehaviour
{
    private float speed=20;
    public float multiplier=1;
    private PlayerController playerMovementScript;
    private float leftBound=-30;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript =GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovementScript.gameOver==false){
            transform.Translate(Vector3.right *Time.deltaTime*speed * multiplier);
            multiplier+=0.002f;
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("obstacle")){
            Destroy(gameObject);
        }
        
    }
}
