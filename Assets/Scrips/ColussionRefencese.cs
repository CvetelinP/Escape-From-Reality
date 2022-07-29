using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColussionRefencese : MonoBehaviour
{
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip failure;
    AudioSource audioSource;
    [SerializeField] ParticleSystem fail;
    [SerializeField] ParticleSystem successParticles;


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Finish":
                Debug.Log("You finish the level");
                successParticles.Play();
                fail.Play();
                audioSource.PlayOneShot(success);
                DesabledPlayer();


                Invoke("NextLevel", 3f);
                break;


            case "Friendly":
                Debug.Log("Start");
                break;

            default:
                fail.Play();
                Debug.Log("Sorry , the game is OVER");
                
                audioSource.PlayOneShot(failure);
              
              

                DesabledPlayer();
                Invoke("ReloadLevel", 1f);
                break;

        }

    }


    void DesabledPlayer()
    {
        GetComponent<Movement>().enabled = false;

    }

    void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);

    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
