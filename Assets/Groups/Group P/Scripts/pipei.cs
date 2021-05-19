using GroupP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pipei : MonoBehaviour
{
    public KeyType key;

    public zongfen zf;

    bool iskaiqi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zf.text1.text = "score1：" + zf.in1;
        zf.text2.text = "score2：" + zf.in2;
        zf.text3.text = "score3：" + zf.in3;
        zf.text4.text = "score4：" + zf.in4;


        if (iskaiqi)
        {
            switch (key)
            {
                case KeyType.UP:      //up arrow
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in1++;
                            zf.jishu1++;
                            if (zf.jishu1 % 5 == 0)
                            {

                                zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                            }

                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Y))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in2++;
                            zf.jishu2++;
                            if (zf.jishu2 % 5 == 0)
                            {

                                zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                            }
                            iskaiqi = false;

                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad5))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in3++;
                            zf.jishu3++;
                            if (zf.jishu3 % 5 == 0)
                            {

                                zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in4++;
                            zf.jishu4++;
                            if (zf.jishu4 % 5 == 0)
                            {

                                zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    break;
                case KeyType.DOWN:      //down arrow
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in1++;
                            zf.jishu1++;
                            if (zf.jishu1 % 5 == 0)
                            {

                                zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    if (Input.GetKeyDown(KeyCode.H))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in2++;
                            zf.jishu2++;
                            if (zf.jishu2 % 5 == 0)
                            {

                                zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad2))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in3++;
                            zf.jishu3++;
                            if (zf.jishu3 % 5 == 0)
                            {

                                zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Semicolon))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in4++;
                            zf.jishu4++;
                            if (zf.jishu4 % 5 == 0)
                            {

                                zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    break;
                case KeyType.LEFT:     //left arrow
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in1++;
                            zf.jishu1++;
                            if (zf.jishu1 % 5 == 0)
                            {

                                zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in2++;
                            zf.jishu2++;
                            if (zf.jishu2 % 5 == 0)
                            {

                                zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad1))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in3++;
                            zf.jishu3++;
                            if (zf.jishu3 % 5 == 0)
                            {

                                zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    if (Input.GetKeyDown(KeyCode.L))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in4++;
                            zf.jishu4++;
                            if (zf.jishu4 % 5 == 0)
                            {

                                zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    break;
                case KeyType.RIGHT:        //right arrow
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in1++;
                            zf.jishu1++;
                            if (zf.jishu1 % 5 == 0)
                            {

                                zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in2++;
                            zf.jishu2++;
                            if (zf.jishu2 % 5 == 0)
                            {

                                zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Keypad3))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in3++;
                            zf.jishu3++;
                            if (zf.jishu3 % 5 == 0)
                            {

                                zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Quote))
                    {
                        if (zf.s2 == KeyType.kong)
                        {
                            zf.in4++;
                            zf.jishu4++;
                            if (zf.jishu4 % 5 == 0)
                            {

                                zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                            }
                            iskaiqi = false;
                        }
                        else
                        {
                            switch (zf.s2)
                            {
                                case KeyType.UP:      //up arrow
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {

                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }

                                        iskaiqi = false;

                                    }
                                    if (Input.GetKeyDown(KeyCode.Y))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad5))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.P))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.DOWN:      //down arrow
                                    if (Input.GetKeyDown(KeyCode.S))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.H))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad2))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Semicolon))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.LEFT:     //left arrow
                                    if (Input.GetKeyDown(KeyCode.A))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.G))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad1))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.L))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                case KeyType.RIGHT:        //right arrow
                                    if (Input.GetKeyDown(KeyCode.D))
                                    {
                                        zf.in1++;
                                        zf.jishu1++;
                                        if (zf.jishu1 % 5 == 0)
                                        {

                                            zf.in1 = zf.in1 * 2 * (zf.jishu1 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.J))
                                    {
                                        zf.in2++;
                                        zf.jishu2++;
                                        if (zf.jishu2 % 5 == 0)
                                        {

                                            zf.in2 = zf.in2 * 2 * (zf.jishu2 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Keypad3))
                                    {
                                        zf.in3++;
                                        zf.jishu3++;
                                        if (zf.jishu3 % 5 == 0)
                                        {

                                            zf.in3 = zf.in3 * 2 * (zf.jishu3 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    if (Input.GetKeyDown(KeyCode.Quote))
                                    {
                                        zf.in4++;
                                        zf.jishu4++;
                                        if (zf.jishu4 % 5 == 0)
                                        {

                                            zf.in4 = zf.in4 * 2 * (zf.jishu4 / 5);
                                        }
                                        iskaiqi = false;
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                    break;
                default:
                    break;
            }
           
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Note>().key == key)
        {
            Debug.Log("lll");
            iskaiqi = true;
            if (zf.s1==KeyType.kong)
            {
                zf.s1 = key;
            }
            else
            {
                zf.s2 = key;
            }


            Invoke("Guan", 0.2f);
        }
    }

    void Guan()
    {
        if (iskaiqi)
        {

            iskaiqi = false;
            zf.s1 = KeyType.kong;
            zf.s2 = KeyType.kong;
            switch (key)
            {
                case KeyType.UP:      //up arrow
                    zf.jishu1 = 0;
                    break;
                case KeyType.DOWN:      //down arrow
                    zf.jishu2 = 0;
                    break;
                case KeyType.LEFT:     //left arrow
                    zf.jishu3 = 0;
                    break;
                case KeyType.RIGHT:        //right arrow
                    zf.jishu4 = 0;
                    break;
                default:
                    break;
            }
        }
    }
}
