using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitEndMenu : MonoBehaviour
{
	public void QuitGame()
	{
		SceneManager.LoadScene(0);
		// Application.Quit(); // apparently closes the game only in deployed mode. wont do here on unity play mode
	}
}
