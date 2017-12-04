using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHat : MonoBehaviour
{
    [Header("Customise Scene Hat")]
    public bool hatToggleBool, hatInGameBool;
    public int customHatCheck;
    public GameObject hat1Prefab, headForHats, customHat, hair;

    // Use this for initialization
    void Start()
    {
        hatInGameBool = false;

        customHatCheck = PlayerPrefs.GetInt("CustomHatToggle");

        Debug.Log("customHatCheck = " + customHatCheck);

        if (customHatCheck == 1)
        {
            hatToggleBool = true;
        }
        else
        {
            hatToggleBool = false;
        }

        Debug.Log("hatToggleBool at Start = " + hatToggleBool);
    }

    // Update is called once per frame
    void Update()
    {
        //if (SceneManager.GetActiveScene().name == "Game")
        //{
            PutCustomHatOn();
        //}
    }

    // For Customise Scene Canvas
    public void CustomiseHatToggle()
    {
        if (hatToggleBool == false)
        {
            Debug.Log("hatToggleBool = " + hatToggleBool);

            customHat = Instantiate(hat1Prefab, headForHats.transform.position, headForHats.transform.rotation);

            customHat.transform.position = new Vector3(headForHats.transform.position.x, headForHats.transform.position.y + .5f, headForHats.transform.position.z + .05f);

            customHat.transform.parent = headForHats.transform; // Make customHat child of headForHats;

            customHat.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;

            customHat.transform.Find("Hat 1 Bottom").gameObject.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material; // Get Bottom of Hat (Child) and change colour

            hatToggleBool = true;

            PlayerPrefs.SetInt("CustomHatToggle", 1);

            return;
        }

        if (hatToggleBool == true)
        {
            Debug.Log("hatToggleBool = " + hatToggleBool);

            Destroy(customHat);

            hatToggleBool = false;

            PlayerPrefs.SetInt("CustomHatToggle", 0);

            return;
        }
    }

    // For above Function, but for Game Scene
    void PutCustomHatOn()
    {
        Debug.Log("customHatCheck = " + customHatCheck);

        if (customHatCheck == 1 && hatInGameBool == false)
        {
            customHat = Instantiate(hat1Prefab, headForHats.transform.position, headForHats.transform.rotation);

            customHat.transform.position = new Vector3(headForHats.transform.position.x, headForHats.transform.position.y + .5f, headForHats.transform.position.z + .05f);

            customHat.transform.parent = headForHats.transform; // Make customHat child of headForHats;

            customHat.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;

            customHat.transform.Find("Hat 1 Bottom").gameObject.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material; // Get Bottom of Hat (Child) and change colour

            hatInGameBool = true;
            return;
        }
    }
}
