using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CustomiseSet : MonoBehaviour
{
    public Material[] mats;

    public GameObject head, body, ear1, ear2, eye, beard, hair;

    public int headMatsIndex, bodyMatsIndex, earMatsIndex, eyeMatsIndex, beardMatsIndex, hairMatsIndex, matsMaxIndex;

    // Use this for initialization
    void Start()
    {
        headMatsIndex = 0; // Sets Defaults before Load
        bodyMatsIndex = 0;
        earMatsIndex = 0;
        eyeMatsIndex = 0;
        beardMatsIndex = 0;
        hairMatsIndex = 0;

        Load();

        matsMaxIndex = mats.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HeadColourButton()
    {
        if (headMatsIndex < matsMaxIndex)
        {
            head.GetComponent<Renderer>().material = mats[headMatsIndex + 1]; // whatever Mats is, plus One
            headMatsIndex = headMatsIndex + 1;
            return;
        }

        if (headMatsIndex == matsMaxIndex)
        {
            head.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            headMatsIndex = 0;
            return;
        }
    }

    public void BodyColourButton()
    {
        if (bodyMatsIndex < matsMaxIndex)
        {
            body.GetComponent<Renderer>().material = mats[bodyMatsIndex + 1]; // whatever Mats is, plus One
            bodyMatsIndex = bodyMatsIndex + 1;
            return;
        }

        if (bodyMatsIndex == matsMaxIndex)
        {
            body.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            bodyMatsIndex = 0;
            return;
        }
    }

    public void EarColourButton()
    {
        if (earMatsIndex < matsMaxIndex)
        {
            ear1.GetComponent<Renderer>().material = mats[earMatsIndex + 1]; // whatever Mats is, plus One
            ear2.GetComponent<Renderer>().material = mats[earMatsIndex + 1];
            earMatsIndex = earMatsIndex + 1;
            return;
        }

        if (earMatsIndex == matsMaxIndex)
        {
            ear1.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            ear2.GetComponent<Renderer>().material = mats[0];
            earMatsIndex = 0;
            return;
        }
    }

    public void EyeColourButton()
    {
        if (eyeMatsIndex < matsMaxIndex)
        {
            eye.GetComponent<Renderer>().material = mats[eyeMatsIndex + 1]; // whatever Mats is, plus One
            eyeMatsIndex = eyeMatsIndex + 1;
            return;
        }

        if (eyeMatsIndex == matsMaxIndex)
        {
            eye.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            eyeMatsIndex = 0;
            return;
        }
    }

    public void BeardColourButton()
    {
        if (beardMatsIndex < matsMaxIndex)
        {
            beard.GetComponent<Renderer>().material = mats[beardMatsIndex + 1]; // whatever Mats is, plus One
            beardMatsIndex = beardMatsIndex + 1;
            return;
        }

        if (beardMatsIndex == matsMaxIndex)
        {
            beard.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            beardMatsIndex = 0;
            return;
        }
    }

    public void HairColourButton()
    {
        if (hairMatsIndex < matsMaxIndex)
        {
            hair.GetComponent<Renderer>().material = mats[hairMatsIndex + 1]; // whatever Mats is, plus One
            hairMatsIndex = hairMatsIndex + 1;
            return;
        }

        if (hairMatsIndex == matsMaxIndex)
        {
            hair.GetComponent<Renderer>().material = mats[0]; // reset Mats to Zero
            hairMatsIndex = 0;
            return;
        }
    }

    public void RandomColoursButton()
    {
        headMatsIndex = Random.Range(0, matsMaxIndex);
        bodyMatsIndex = Random.Range(0, matsMaxIndex);
        earMatsIndex = Random.Range(0, matsMaxIndex);
        eyeMatsIndex = Random.Range(0, matsMaxIndex);
        beardMatsIndex = Random.Range(0, matsMaxIndex);
        hairMatsIndex = Random.Range(0, matsMaxIndex);

        head.GetComponent<Renderer>().material = mats[headMatsIndex];
        body.GetComponent<Renderer>().material = mats[bodyMatsIndex];
        ear1.GetComponent<Renderer>().material = mats[earMatsIndex];
        ear2.GetComponent<Renderer>().material = mats[earMatsIndex];
        eye.GetComponent<Renderer>().material = mats[eyeMatsIndex];
        beard.GetComponent<Renderer>().material = mats[beardMatsIndex];
        hair.GetComponent<Renderer>().material = mats[hairMatsIndex];
    }

    public void SaveAndPlayButton()
    {
        PlayerPrefs.SetInt("Head Colour", headMatsIndex);
        PlayerPrefs.SetInt("Body Colour", bodyMatsIndex);
        PlayerPrefs.SetInt("Ear Colour", earMatsIndex);
        PlayerPrefs.SetInt("Eye Colour", eyeMatsIndex);
        PlayerPrefs.SetInt("Beard Colour", beardMatsIndex);
        PlayerPrefs.SetInt("Hair Colour", hairMatsIndex);

        SceneManager.LoadScene("Game");
    }

    void Load()
    {
        headMatsIndex = PlayerPrefs.GetInt("Head Colour");
        bodyMatsIndex = PlayerPrefs.GetInt("Body Colour");
        earMatsIndex = PlayerPrefs.GetInt("Ear Colour");
        eyeMatsIndex = PlayerPrefs.GetInt("Eye Colour");
        beardMatsIndex = PlayerPrefs.GetInt("Beard Colour");
        hairMatsIndex = PlayerPrefs.GetInt("Hair Colour");

        head.GetComponent<Renderer>().material = mats[headMatsIndex];
        body.GetComponent<Renderer>().material = mats[bodyMatsIndex];
        ear1.GetComponent<Renderer>().material = mats[earMatsIndex];
        ear2.GetComponent<Renderer>().material = mats[earMatsIndex];
        eye.GetComponent<Renderer>().material = mats[eyeMatsIndex];
        beard.GetComponent<Renderer>().material = mats[beardMatsIndex];
        hair.GetComponent<Renderer>().material = mats[hairMatsIndex];
    }
}
