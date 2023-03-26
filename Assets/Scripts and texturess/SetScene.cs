using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetScene : MonoBehaviour
{
	public string SceneName;
	public void OnTriggerEnter2D ()
	{
		SceneManager.LoadScene(SceneName);
	}
	public void Pressed ()
	{
		SceneManager.LoadScene(SceneName);
	}
}
