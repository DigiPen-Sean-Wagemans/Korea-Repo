using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardLogic : MonoBehaviour
{
    int score = 0;

    public Sprite Icon_0 = null;
    public Sprite Icon_1 = null;
    public Sprite Icon_2 = null;
    public Sprite Icon_3 = null;
    public Sprite Icon_4 = null;
    public Sprite Icon_5 = null;
    public Sprite Icon_6 = null;
    public Sprite Icon_7 = null;
    public Sprite Icon_8 = null;
    public Sprite Icon_9 = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    public void UpdateScore()
    {
        ++score;

        var image = gameObject.GetComponent<Image>();

        if(score == 0) image.sprite = Icon_0;
        else if(score == 1) image.sprite = Icon_1;
        else if(score == 2) image.sprite = Icon_2;
        else if(score == 3) image.sprite = Icon_3;
        else if(score == 4) image.sprite = Icon_4;
        else if(score == 5) image.sprite = Icon_5;
        else if(score == 6) image.sprite = Icon_6;
        else if(score == 7) image.sprite = Icon_7;
        else if(score == 8) image.sprite = Icon_8;
        else if(score == 9) image.sprite = Icon_9;
    }
}
