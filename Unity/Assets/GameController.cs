using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
 
public class GameController : MonoBehaviour
{
	public GameObject ball;
	public bool gameOver = false;
	public float points;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
		{
			points += Time.deltaTime;
			//textPoints.text = ((int)(points*10.0f)) + "";
			
			if(ball.transform.position.y <= ball.GetComponent<Ball>().roomY.x+1)
			{
				gameOver = true;
				ball.GetComponent<Ball>().spriteRenderer.color = ball.GetComponent<Ball>().colorHalf;
				//titleGameOver.SetActive(true);
			}
		}
    }
}
