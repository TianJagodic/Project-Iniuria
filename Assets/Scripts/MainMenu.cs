using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void OnMouseEnter()
    {
        //Debug.Log("Mouse just enter the: " + this.gameObject.name);
        transform.eulerAngles = new Vector3(-0, 180, 0);
        Wait(1);
    }

    private void OnMouseExit()
    {
        //Debug.Log("Mouse just exited the: " + this.gameObject.name);
        transform.eulerAngles = new Vector3(-15, 180, 0);
        Wait(1);
    }

    IEnumerator Wait(float secs) {

        yield return new WaitForSeconds(secs);
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("The player just presed the " + gameObject.name);

        switch (gameObject.name)
        {
            case "PlayButton":
                //TODO: load the current level that is selected
                SceneManager.LoadScene("TownLoader");
                break;

            case "LevelButton":
                //TODO: make level switching
                break;

            case "DificultyButton":
                //TODO: Change the dificulty MAKE THE MENU FOR THAT
                break;

            default:
                break;
        }
    }
}
