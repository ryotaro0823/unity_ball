using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject player;
    //public GoalChecker goalchecker;
    Vector3 offset;
    Vector3 result_offset;
    Vector3 result_cam;
    public bool goal_flg = false;
    // Start is called before the first frame update
    void Start()
    {
        goal_flg = false;
        result_offset = new Vector3(0, -5, 5);
        offset = this.transform.position - player.transform.position;
        result_cam = this.transform.position + result_offset - player.transform.position;
    }
    private void Update()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (goal_flg == false)
        {
            this.transform.position = player.transform.position + offset;
        }
        else
        {
            this.transform.position = player.transform.position + result_cam;
        }
        
    }
}
