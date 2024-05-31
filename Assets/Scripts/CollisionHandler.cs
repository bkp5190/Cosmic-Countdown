using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Bumped into a friendly item");
                break;
            case "Finish":
                Debug.Log("Congrats, you finished the level");
                break;
            case "Fuel":
                Debug.Log("You picked up some fuel");
                Destroy(other.gameObject);
                break;
            default:
                SceneManager.LoadScene(0);
                break;
        }
    }
}