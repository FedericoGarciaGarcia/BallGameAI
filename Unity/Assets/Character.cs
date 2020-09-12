using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public float speed = 1;
	public float kickStrength = 10;
	public Vector2 roomX;
	public bool status = true;
	public GameObject ball;
	public Character otherCharacter;
	
	public SpriteRenderer spriteRenderer;
	public Color colorOriginal;
	public Color colorHalf;
	
	private bool revive;
	
    // Start is called before the first frame update
    void Start()
    {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		
		colorOriginal = spriteRenderer.color;
		colorHalf = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, 0.5f);
		
        if(!status)
		{
			spriteRenderer.color = colorHalf;
		}
    }

    // Update is called once per frame
    void Update()
    {
		if(status && Input.GetKeyDown(KeyCode.Space) && TouchingBall())
		{
			status = false;
			otherCharacter.revive = true;
			
			spriteRenderer.sortingOrder = 1;
			spriteRenderer.color = colorHalf;
			
			otherCharacter.spriteRenderer.sortingOrder = 2;
			otherCharacter.spriteRenderer.color = otherCharacter.colorOriginal;
			
			// Get direction vector
			Vector2 dir = ball.transform.position + Vector3.up * 1.5f - transform.position;
			dir.Normalize();
			
			// Make it a bit random
			dir = Quaternion.Euler(0, 0, Random.Range(-25f, 25f)) * dir;
			dir.Normalize();
			
			ball.GetComponent<Ball>().speedX = kickStrength * dir.x;
			ball.GetComponent<Ball>().speedY = kickStrength * dir.y;
		}
		
		if(status)
		{
			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.Translate(speed * Time.deltaTime, 0, 0);
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.Translate(-speed * Time.deltaTime, 0, 0);
			}
			
			if(transform.position.x < roomX.x+1) {
				transform.position = new Vector2(roomX.x+1, transform.position.y);
			}
			
			if(transform.position.x > roomX.y-1) {
				transform.position = new Vector2(roomX.y-1, transform.position.y);
			}
		}
		
		if(revive) {
			status = true;
			revive = false;
		}
    }
	
	private bool TouchingBall() {
		if(ball.transform.position.y <= transform.position.y+2.5 &&
		   ball.transform.position.x <= transform.position.x+2 &&
		   ball.transform.position.x >= transform.position.x-2)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
}
