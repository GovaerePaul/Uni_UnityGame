using UnityEngine;
using System.Collections;
using Nito; //see Deque.cs

//various game management is here

public class GameControllerScript : MonoBehaviour
{
    public float roadBufferDist = 10;//distance to keep ends of road from player
    [SerializeField]
    private GameObject roadPrefab;

    private GameObject player;
    private Deque<GameObject> roadList = new Deque<GameObject>();

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //place first road
        GameObject firstRoad = Instantiate<GameObject>(roadPrefab);
        firstRoad.transform.position.Set(0, 0, 0);
        roadList.AddToBack(firstRoad);

        //place player on first road
        player.transform.position.Set(0, 5, 0);//TODO: change y pos to account for road height
        GameObject nextRoad = Instantiate<GameObject>(roadPrefab);
        nextRoad.transform.position = new Vector3(0, 0, firstRoad.transform.position.z + 10);
        roadList.AddToFront(nextRoad);
    }

    void RoadBuilding()
    {

        GameObject roadFirst = roadList.peakFront();
        GameObject roadLast = roadList.peakBack();

        
        if(player.transform.position.z > roadFirst.transform.position.z - roadBufferDist)
        {
            Debug.Log("first if used");
            GameObject nextRoad = Instantiate<GameObject>(roadPrefab);
            nextRoad.transform.position = new Vector3(0, 0, roadFirst.transform.position.z + 10);
            roadList.AddToFront(nextRoad);
        }
        

        
        if(player.transform.position.z < roadLast.transform.position.z - roadBufferDist)
        {
            Debug.Log("second if used");
            GameObject nextRoad = Instantiate<GameObject>(roadPrefab);
            nextRoad.transform.position = new Vector3(0, 0, roadLast.transform.position.z - 10);
            roadList.AddToBack(nextRoad);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        RoadBuilding();
    }
}
