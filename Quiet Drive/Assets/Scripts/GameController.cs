using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//various game management is here

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float roadBufferDist = 100;//distance to keep ends of road from player
    [SerializeField]
    private float roadLength = 10;
    [SerializeField]
    private GameObject roadPrefab;

    private GameObject player;
    private List<GameObject> roadList = new List<GameObject>();

    int count = 0;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //place first road
        GameObject firstRoad = Instantiate<GameObject>(roadPrefab);
        firstRoad.transform.position.Set(0, 0, 0);
        roadList.Add(firstRoad);

        //place player on first road
        player.transform.position.Set(0, 5, 0);//TODO: change y pos to account for road height
        GameObject nextRoad = Instantiate<GameObject>(roadPrefab);
        nextRoad.transform.position = new Vector3(0, 0, firstRoad.transform.position.z + roadLength);
        roadList.Add(nextRoad);

        
    }

    private void RoadBuilding()
    {

        GameObject roadFirst = roadList[roadList.Count-1];
        //GameObject roadLast = roadList.peakBack();

        //Debug.Log("player z pos: "+ player.transform.position.z);
        //Debug.Log("first road z pos: " + roadFirst.transform.position.z);


        if (count == 0)
        {
            if (roadFirst != null)
                Debug.Log("roadFirst z:" + roadFirst.transform.position.z);
            //if (roadLast != null)
            //    Debug.Log("roadLast z:" + roadLast.transform.position.z);
            count++;
        }
        Debug.Log("Road List Count: " + roadList.Count);

        //build forwards
        if(roadFirst != null && (player.transform.position.z > roadFirst.transform.position.z + roadLength - roadBufferDist))
        {
            Debug.Log("first if used");
            GameObject nextRoad = Instantiate<GameObject>(roadPrefab);
            nextRoad.transform.position = new Vector3(0, 0, roadFirst.transform.position.z + roadLength);
            roadList.Add(nextRoad);
        }
        

        //build backwards
        /*if(roadLast != null && (player.transform.position.z < roadLast.transform.position.z +roadLength - roadBufferDist))
        {
            Debug.Log("second if used");
            GameObject nextRoad = Instantiate<GameObject>(roadPrefab);
            nextRoad.transform.position = new Vector3(0, 0, roadLast.transform.position.z - roadLength);
            roadList.AddToBack(nextRoad);
        }
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        RoadBuilding();
    }
}
