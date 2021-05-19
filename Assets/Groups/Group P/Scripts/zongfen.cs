using GroupP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zongfen : MonoBehaviour         //zongfen: total score
{
   
    public Text text1, text2, text3, text4;
    public int in1, in2, in3, in4;

    public int jishu1, jishu2, jishu3, jishu4;          //jishu: counter
    public KeyType  s1= KeyType.kong, s2= KeyType.kong;       //kong: null

 //fore the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = "score1:" + in1;
        text2.text = "score2：" + in2;
        text3.text = "score3" + in3;
        text4.text = "score4" + in4;

    
    }

  
}
