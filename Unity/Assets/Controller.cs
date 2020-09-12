using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
 
public class Controller : MonoBehaviour
{
	public GameObject game;
	public int subjectSize = 200;
	
	private long iteration = 0;
	
    // Start is called before the first frame update
    void Start()
    {
		//QualitySettings.vSyncCount = 0;  // VSync must be disabled
		//Application.targetFrameRate = 60;
		for(int i=0; i<subjectSize; i++)
		{
			Instantiate(game, new Vector3(0, 0, 0), Quaternion.identity);
		}
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Return))
		{
			 SceneManager.LoadScene("Scene");
		}
		
		iteration++;
		
		if(iteration % 50L == 0L)
		{
			Debug.Log(iteration);
			Debug.Log(1.0f/Time.deltaTime);
		}
    }
}
