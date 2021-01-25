using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawn;
    // Start is called before the first frame update
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos=new Vector3(25,0,0);
    private float startDelay=2;
    private float repeatRate=2;
    void Start()
    {
        spawn = this;
        //InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
        StartCoroutine("SpawnObstacle");

    }


    IEnumerator SpawnObstacle()
    {

        while (true)
        {
            yield return new WaitForSeconds(startDelay);
            int randomvalue=Random.Range(0,obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomvalue],obstaclePrefabs[randomvalue].transform.position,obstaclePrefabs[randomvalue].transform.rotation);
        }
    }
    public void Ended()
    {
        StopCoroutine("SpawnObstacle");

    }
}
