using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // apparently loads the next scene in hierarchy
	}

	public void Settings()
	{
		SceneManager.LoadScene(5);
	}

	public void QuitGame()
	{
		Debug.Log("QUIT!");
		Application.Quit();
	}
}
