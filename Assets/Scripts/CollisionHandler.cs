using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip failureAudio;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Friendly")
        {         
        }
        else if (collision.gameObject.tag == "Finish")
        {          
           StartSuccessSequence();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            StartCrashSequence();        
        }
    }



    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
           
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void StartCrashSequence()
    {
        audioSource.PlayOneShot(failureAudio);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 1f);
        
    }
    void StartSuccessSequence()
    {
        audioSource.PlayOneShot(successAudio);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 1);
    }
}
