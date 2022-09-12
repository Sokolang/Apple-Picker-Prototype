using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {
    [Header("Set Dynamically")]
    public Text scoreGT;

    void Start() {
        // Find a reference to the ScoreCounter  GameObject   
        GameObject scoreGO = GameObject.Find("ScoreCounter"); 
        // Get the Text Component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();
        // Set the starting number of points to 0 
        scoreGT.text = "0";
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter( Collision coll ) 
    {
        // Find out what hit this Basket 
        GameObject collidedWith = coll.gameObject; 
        if ( collidedWith.tag == "Apple" ) {
            Destroy( collidedWith ); 
            // Parse the text of the scoreGT into an int 
            int score = int.Parse( scoreGT.text );
            // Add points for catching the apple
            score += 100;
            // Convert the score back to a string and display it
            scoreGT.text = score.ToString();

            if (score > HighScore.score) {
                HighScore.score = score;
            }
        }
    }
    
}
