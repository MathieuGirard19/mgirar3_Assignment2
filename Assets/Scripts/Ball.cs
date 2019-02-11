using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class Ball : MonoBehaviour
{   
    //make public so we can access in insepctor
    public float moveSpeed;
    private Rigidbody ball;
    private int _score;
    public int score{
        get{
            return _score;
        }
        set{
            _score = value;
        }
    }
    public Text scoreDisplay;


    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        _score = 0;
        DisplayScore();
    }

    //Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate(){
        //determine movement on each axis then apply force based on this input
        float moveHorizontal = Input.GetAxis("Horizontal")*moveSpeed;
        float moveVertical = Input.GetAxis("Vertical")*moveSpeed;
        //AddForce is a rigid body component
        ball.AddForce(moveHorizontal, 0f, moveVertical);
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Pickup"){
            other.gameObject.SetActive(false);
            score += checkColorVal(other);
            DisplayScore();
        }
    }

    void DisplayScore(){
         scoreDisplay.text = "Score: " + score.ToString();
    }

    int checkColorVal(Collider other){
        if(other.gameObject.GetComponent<Renderer>().material.color == Color.blue)
        {
            print("blue");
            return 1;
        }
        else if(other.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            print("red");
            return 3;
        }
        else if(other.gameObject.GetComponent<Renderer>().material.color == Color.yellow)
        {
            print("yellow");
            return 5;
        }
        return 0;
    }

}
