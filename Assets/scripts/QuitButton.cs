using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;

    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("active", true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("press", true);
				QuitGame();
			}else if (animator.GetBool ("press")){
				animator.SetBool ("press", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("active", false);
		}
    }

	 public void QuitGame()
	{
        Debug.Log("Quit");
		Application. Quit();
		//SceneManager.LoadScene("Map 1"); //to test
	}
}
