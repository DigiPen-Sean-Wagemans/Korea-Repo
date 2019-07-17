using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTailLogic : MonoBehaviour
{
    public GameObject ParentBall = null;

    Vector3 BallPos_Prev;
    Vector3 BallPos_Cur;

    public float Offset = 0.07f;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 BallPos_Prev = ParentBall.transform.position;
        Vector3 BallPos_Cur  = ParentBall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Direction = (BallPos_Prev - BallPos_Cur).normalized;

        gameObject.transform.position = (ParentBall.transform.position + (Direction * Offset) - Vector3.back);

        BallPos_Prev = BallPos_Cur;
        BallPos_Cur = ParentBall.transform.position;
    }
}
