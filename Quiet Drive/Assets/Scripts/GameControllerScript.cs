using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//various game management is here

public class GameControllerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject roadPrefab;

    private GameObject player;
    private List<GameObject> roadList = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //place first road
        GameObject firstRoad = Instantiate<GameObject>(roadPrefab);
        firstRoad.transform.position.Set(0, 0, 0);

        //place player on first road
        player.transform.position.Set(0, 5, 0);//TODO: change y pos to account for road height
    }

    void RoadBuilding()
    {
        /*
        inputs
            seed
            player pos
        internal
            available pieces
            previous pieces
        */

        //GameObject nextRoad = Instantiate<GameObject>(roadPrefab);
        //nextRoad.transform.position = new Vector3(0, 0, this.transform.position.z + 10);
    }

    // Update is called once per frame
    void Update()
    {
        RoadBuilding();
    }
}
