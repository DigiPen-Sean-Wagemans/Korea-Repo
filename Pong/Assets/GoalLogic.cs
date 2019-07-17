using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLogic : MonoBehaviour
{
    public GameObject ScoreTracker;

    public void Goal()
    {
        print("Debug 0");

        if (ScoreTracker != null)
        {
            ScoreTracker.GetComponent<ScoreBoardLogic>().UpdateScore();
        }
    }
}
