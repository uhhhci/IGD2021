using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


public class CustomCharacter
{
    /*
     * Everything in the Minifig is a SkinnedMeshRenderer,
     * unless it is commented otherwise
     */

    public int playerId = 0;

    //Head
    public Mesh hair; //MeshFilter
    public Mesh hat; //MeshFilter
    public Material hairColor; //MeshRenderer
	public Material face;
    public Material faceTone;

    //Upper body
	public Material upperBody_front;
	public Material upperBody_back;
    public Material upperBody_main;

    //Arms
    public Material rightArm_front;
    public Material rightArm_main;
    public Material leftArm_front;
    public Material leftArm_main; 

    //Hands
    public Material right_hand;
    public Material left_hand;

    //Hip
    public Material hip_crotch;
    public Material hip_front;
    public Material hip_main;

    //Legs
    public Material leftleg_front;
    public Material leftleg_side;
    public Material leftleg_main;
    public Material rightleg_front;
    public Material rightleg_side;
    public Material rightleg_main;

    //Feet
    public Material right_foot;
    public Material left_foot;
    
}