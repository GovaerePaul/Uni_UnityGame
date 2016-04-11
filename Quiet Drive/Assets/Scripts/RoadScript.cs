using UnityEngine;
using System.Collections;

//procedural generator
//each road segment is responsible for making the next one in the sequence

/*
inputs
    seed
    player pos
internal
    available pieces
    previous pieces
*/

public class RoadScript : MonoBehaviour
{
    public Transform Player;//TODO: change to private and show in inspector 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //is the player close enough for making the next one?

        //is the player far away enough to delete this one
    }
}
