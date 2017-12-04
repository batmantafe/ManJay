using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHat : MonoBehaviour
{
    [Header("Customise Scene Hat")]
    public Toggle hatToggleUI;
    public bool hatToggleBool, hatInGameBool, hatInCustomiseBool;
    public int customHatCheck;
    public GameObject hat1Prefab, headForHats, customHat, hair;

    // Use this for initialization
    void Start()
    {
        //if (SceneManager.GetActiveScene().name == "Customise")
        //{
            hatInGameBool = false;
        //}



        customHatCheck = 0;

        customHatCheck = PlayerPrefs.GetInt("CustomHatToggle");

        if (customHatCheck == 1)
        {
            hatToggleBool = true;
            hatToggleUI.isOn = true;

            customHat = Instantiate(hat1Prefab, headForHats.transform.position, headForHats.transform.rotation);

            customHat.transform.position = new Vector3(headForHats.transform.position.x, headForHats.transform.position.y + .5f, headForHats.transform.position.z + .05f);

            customHat.transform.parent = headForHats.transform; // Make customHat child of headForHats;

            customHat.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;

            customHat.transform.Find("Hat 1 Bottom").gameObject.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material; // Get Bottom of Hat (Child) and change colour

            hatInGameBool = true;

            hatToggleBool = true;

            PlayerPrefs.SetInt("CustomHatToggle", 1);

            return;
        }

        else if (customHatCheck == 0)
        {
            hatToggleBool = false;
            hatToggleUI.isOn = false;
        }

        //Debug.Log("hatToggleBool at Start = " + hatToggleBool);
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
            //Debug.Log("hatToggleBool = " + hatToggleBool);

            customHat = Instantiate(hat1Prefab, headForHats.transform.position, headForHats.transform.rotation);

            customHat.transform.position = new Vector3(headForHats.transform.position.x, headForHats.transform.position.y + .5f, headForHats.transform.position.z + .05f);

            customHat.transform.parent = headForHats.transform; // Make customHat child of headForHats;

            customHat.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material;

            customHat.transform.Find("Hat 1 Bottom").gameObject.GetComponent<Renderer>().material = hair.GetComponent<Renderer>().material; // Get Bottom of Hat (Child) and change colour

            hatInGameBool = true;

            hatToggleBool = true;

            PlayerPrefs.SetInt("CustomHatToggle", 1);

            return;
        }

        if (hatToggleBool == true)
        {
            //Debug.Log("hatToggleBool = " + hatToggleBool);

            Destroy(customHat);

            hatInGameBool = false;

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
