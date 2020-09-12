using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public float gravity = 9.8f;
	
	public Vector2 roomX;
	public Vector2 roomY;
	
	public float speedX, speedY;
	
	public SpriteRenderer spriteRenderer;
	public Color colorOriginal;
	public Color colorHalf;
	
    // Start is called before the first frame update
    void Start()
    {
		spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
		
		colorOriginal = spriteRenderer.color;
		colorHalf = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
		transform.GetChild(0).transform.Rotate(0, 0, -speedX * 40 * Time.deltaTime);
		
        if(transform.position.y < roomY.x+1) {
			speedY = 0;
			transform.position = new Vector2(transform.position.x, roomY.x+1);
			
			if(speedX > 0) {
				speedX -= gravity * Time.deltaTime;
				
				if(speedX < 0)
					speedX = 0;
			}
			else if(speedX < 0) {
				speedX += gravity * Time.deltaTime;
				
				if(speedX > 0)
					speedX = 0;
			}
		}
		else if(transform.position.y > roomY.y-1) {
			speedY = -1;
			transform.position = new Vector2(transform.position.x, roomY.y-1);
		}
		else {
			speedY -= gravity * Time.deltaTime;
		}
		
		if(transform.position.x < roomX.x+1) {
			speedX = -speedX;
			transform.position = new Vector2(roomX.x+1, transform.position.y);
		}
		else if(transform.position.x > roomX.y-1) {
			speedX = -speedX;
			transform.position = new Vector2(roomX.y-1, transform.position.y);
		}
    }
}
