using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int lanevalue=0;
    public static SpawnManager spawn;
    // Start is called before the first frame update
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos=new Vector3(25,0,0);
    private float startDelay=2;
    //private float repeatRate=2;
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
            int randomObstaclevalue=Random.Range(0,obstaclePrefabs.Length);
            if (obstaclePrefabs[randomObstaclevalue].gameObject.tag == "obstacle")
            {
                randomObstacleSpawner(randomObstaclevalue);
                yield return new WaitForSeconds(startDelay / 2);
            }
            else
            {
                Instantiate(obstaclePrefabs[randomObstaclevalue], obstaclePrefabs[randomObstaclevalue].transform.position, obstaclePrefabs[randomObstaclevalue].transform.rotation);
                yield return new WaitForSeconds(startDelay);
            }
            
        }
    }
    public void randomObstacleSpawner(int randomvalue)
    {
        //first spawn
        Vector3 temp = obstaclePrefabs[randomvalue].transform.position;
        float zaxis = randomize();
        temp.z = zaxis;
        Instantiate(obstaclePrefabs[randomvalue], temp, obstaclePrefabs[randomvalue].transform.rotation);
    }
    public void Ended()
    {
        StopCoroutine("SpawnObstacle");
    }
    public float randomize()
    {
        int randomvalue;
        if(lanevalue<3){
            randomvalue=lanevalue;
            lanevalue++;
        }else{
            lanevalue=0;
            randomvalue=Random.Range(0,3);
        }
        
        if (randomvalue == 0)
        {
            return -5f;
        }
        else if (randomvalue == 1)
        {
            return -14f;
        }
        else
        {
            return -23f;
        }
    }
}
