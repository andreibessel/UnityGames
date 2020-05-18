using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BTNStart : MonoBehaviour
{

   
    public void StartMyGame()
	{
        SceneManager.LoadScene("Game");
	}
}
