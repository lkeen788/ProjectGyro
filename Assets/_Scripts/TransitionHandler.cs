using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionHandler : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;


    void Update()
    {
        //when button is pressed, do this
        //TransitionToNextLevel();
    }

    public void TransitionToNextLevel(int levelIndex)
    {
        StartCoroutine(Transition(levelIndex));
    }

    IEnumerator Transition(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
