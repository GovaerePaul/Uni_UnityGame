using UnityEngine;
using System.Collections;

//camera follow

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed = new Vector3(8,8,8);//how fast to move
    [SerializeField]
    private Vector3 margin = new Vector3(10, 10, 10);//how close to the player to be

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        TrackPlayer();
    }

    private bool CheckXMargin()
    {
        return Mathf.Abs(this.transform.position.x - player.transform.position.x) > margin.x;
    }

    private bool CheckYMargin()
    {
        return Mathf.Abs(this.transform.position.y - player.transform.position.y) > margin.y;
    }

    private bool CheckZMargin()
    {
        return Mathf.Abs(this.transform.position.z - player.transform.position.z) > margin.z;
    }

    private void TrackPlayer()
    {
        float targetX = this.transform.position.x;
        float targetY = this.transform.position.y;
        float targetZ = this.transform.position.z;
        if(CheckXMargin())
        {
            targetX = Mathf.Lerp(this.transform.position.x, player.transform.position.x, speed.x * Time.deltaTime);
        }
        if(CheckYMargin())
        {
            targetY = Mathf.Lerp(this.transform.position.y, player.transform.position.y, speed.y * Time.deltaTime);
        }
        if(CheckZMargin())
        {
            targetZ = Mathf.Lerp(this.transform.position.z, player.transform.position.z, speed.z * Time.deltaTime);
        }
        this.transform.position = new Vector3(targetX, targetY, targetZ);
        this.transform.LookAt(player.transform);

    }
}
