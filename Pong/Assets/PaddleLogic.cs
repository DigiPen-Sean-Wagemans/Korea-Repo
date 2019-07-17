using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleLogic : MonoBehaviour
{
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;

    public float MaxOffset = 4.25f;

    public float MoveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float objSizeOffset = (gameObject.transform.lossyScale.y * gameObject.GetComponent<BoxCollider2D>().size.y) / 2;
        float paddleVertPos = gameObject.transform.position.y;

        float direction = 0;

        if (Input.GetKey(Up)) direction += 1;
        else if (Input.GetKey(Down)) direction -= 1;

        float step = (direction * MoveSpeed * Time.deltaTime);

        float max = MaxOffset - objSizeOffset;
        float min = -MaxOffset + objSizeOffset;

        float projectedPos = step + paddleVertPos;

        if (projectedPos <= min) projectedPos = min;
        else if (projectedPos >= max) projectedPos = max;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, projectedPos, gameObject.transform.position.z);
    }
}
