using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    [Header("Customise Scene Hat")]
    public bool hatToggleBool, hatInGameBool;
    public int customHatCheck;
    public GameObject hat1Prefab, headForHats, customHat, bottomHat, hair;

    // Use this for initialization
    void Start()
    {
        hatToggleBool = false;
        hatInGameBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            PutCustomHatOn();
        }
    }

    // For Customise Scene Canvas
    public void CustomiseHatToggle()
    {
        if (hatToggleBool == false)
        {
            customHat = Instantiate(hat1Prefab, headForHats.transform.position, headForHats.transform.rotation);

            customHat.transform.position = new Vector3(headForHats.transform.position.x, headForHats.transform.position.y + .5f, headForHats.transform.position.z + .05f);

            customHat.transform.parent = headForHats.transform; // Make customHat child of headForHats;

            customHat.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;

            hatToggleBool = true;

            PlayerPrefs.SetInt("CustomHatToggle", 1);

            return;
        }

        if (hatToggleBool == true)
        {
            Destroy(customHat);

            hatToggleBool = false;

            PlayerPrefs.SetInt("CustomHatToggle", 0);

            return;
        }
    }

    // For above Function, but for Game Scene
    void PutCustomHatOn()
    {
        customHatCheck = PlayerPrefs.GetInt("CustomHatToggle");

        if (customHatCheck == 1 && hatInGameBool == false)
        {
            customHat = Instantiate(hat1Prefab, headForHats.transform.position, headForHats.transform.rotation);

            customHat.transform.position = new Vector3(headForHats.transform.position.x, headForHats.transform.position.y + .5f, headForHats.transform.position.z + .05f);

            customHat.transform.parent = headForHats.transform; // Make customHat child of headForHats;

            customHat.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;
            //bottomHat.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;

            hatInGameBool = true;
            return;
        }
    }
}
