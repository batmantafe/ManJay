using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// You will need to change Scenes
using UnityEngine.SceneManagement;

public class CustomisationSet : MonoBehaviour
{
    // Array is Static (can't change), List is Dynamic (can change)

    #region Variables
    //[Header("Texture List")]
    //Texture2D List for skin,hair, mouth, eyes
    // DON'T FORGET: To Select the "0" Texture for each Material in the Inspector!
    [Header("Texture List")]
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();

    //[Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
    [Header("Index")]
    public int skinIndex;
    public int hairIndex, mouthIndex, eyesIndex, clothesIndex, armourIndex;

    //[Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    [Header("Renderer")]
    public Renderer characterMesh;

    //[Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    // DON'T FORGET: To set these variables in the Inspector!
    [Header("Max Index")]
    public int skinMaxIndex;
    public int hairMaxIndex, mouthMaxIndex, eyesMaxIndex, clothesMaxIndex, armourMaxIndex;

    //[Header("Character Name")]
    //name of our character that the user is making
    [Header("Character Name")]
    public string charName = "Adventurer";
    #endregion

    #region Start
    //in start we need to set up the following
    private void Start()
    {
        Cursor.visible = true;
        
        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of Skin textures we need
        for (int i = 0; i < skinMaxIndex; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            //add our temp texture that we just found to the skin List

            Texture2D temp = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            skin.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of Hair textures we need
        for (int i = 0; i < hairMaxIndex; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Hair_#
            //add our temp texture that we just found to the hair List

            Texture2D temp = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;
            hair.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of Mouth textures we need
        for (int i = 0; i < mouthMaxIndex; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Mouth_#
            //add our temp texture that we just found to the mouth List

            Texture2D temp = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;
            mouth.Add(temp);
        }

        //for loop looping from 0 to less than the max amount of Eyes textures we need
        for (int i = 0; i < eyesMaxIndex; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Eyes_#
            //add our temp texture that we just found to the eyes List

            Texture2D temp = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;
            eyes.Add(temp);
        }
                
        for (int i = 0; i < clothesMaxIndex; i++)
        {
            Texture2D temp = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D;
            clothes.Add(temp);
        }

        for (int i = 0; i < armourMaxIndex; i++)
        {
            Texture2D temp = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D;
            armour.Add(temp);
        }
        #endregion

        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        characterMesh = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();

        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        SetTexture("Skin", 0);
        SetTexture("Hair", 0);
        SetTexture("Mouth", 0);
        SetTexture("Eyes", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);
        #endregion
    }
    #endregion

    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing

    void SetTexture(string typeOfMat, int dir)
    {
        //we need variables that exist only within this function
        //these are ints index numbers, max numbers, material index and Texture2D array of textures

        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];

        switch(typeOfMat)
        {
            //inside a switch statement that is swapped by the string name of our material
            //case skin
            //index is the same as our skin index
            //max is the same as our skin max
            //textures is our skin list .ToArray()
            //material index element number is 1
            //break

            case "Skin":
                index = skinIndex;
                max = skinMaxIndex;
                textures = skin.ToArray();
                matIndex = 1;
                break;

            //now repeat for each material 
            //hair is 2
            //mouth is 3
            //eyes are 4

            case "Hair":
                index = hairIndex;
                max = hairMaxIndex;
                textures = hair.ToArray();
                matIndex = 2;
                break;

            case "Mouth":
                index = mouthIndex;
                max = mouthMaxIndex;
                textures = mouth.ToArray();
                matIndex = 3;
                break;

            case "Eyes":
                index = eyesIndex;
                max = eyesMaxIndex;
                textures = eyes.ToArray();
                matIndex = 4;
                break;

            case "Clothes":
                index = clothesIndex;
                max = clothesMaxIndex;
                textures = clothes.ToArray();
                matIndex = 5;
                break;

            case "Armour":
                index = armourIndex;
                max = armourMaxIndex;
                textures = armour.ToArray();
                matIndex = 6;
                break;
        }

        //outside our switch statement
        //index plus equals our direction
        //cap our index to loop back around if is is below 0 or above max take one

        index += dir;
        if(index < 0)
        {
            index = max - 1;
        }

        if(index > max-1)
        {
            index = 0;
        }

        //Material array is equal to our characters material list
        //our material arrays current material index's main texture is equal to our texture arrays current index
        //our characters materials are equal to the material array

        Material[] mat = characterMesh.materials;
        mat[matIndex].mainTexture = textures[index];
        characterMesh.materials = mat;

        //create another switch that is goverened by the same string name of our material
        
        switch(typeOfMat)
        {
            //case skin
            //skin index equals our index
            //break
            //same thing for Hair, Mouth and Eyes

            case "Skin":
                skinIndex = index;
                break;

            case "Hair":
                hairIndex = index;
                break;

            case "Mouth":
                mouthIndex = index;
                break;

            case "Eyes":
                eyesIndex = index;
                break;

            case "Clothes":
                clothesIndex = index;
                break;

            case "Armour":
                armourIndex = index;
                break;
        }
    }
    #endregion

    #region Save
    //Function called Save this will allow us to save our indexes to PlayerPrefs
    void Save()
    {
        //SetInt for SkinIndex, HairIndex, MouthIndex, Eyesindex
        //SetString CharacterName

        PlayerPrefs.SetInt("SkinIndex", skinIndex);
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetInt("MouthIndex", mouthIndex);
        PlayerPrefs.SetInt("EyesIndex", eyesIndex);
        PlayerPrefs.SetInt("ClothesIndex", clothesIndex);
        PlayerPrefs.SetInt("ArmourIndex", armourIndex);
        PlayerPrefs.SetString("CharacterName", charName);
    }
    #endregion

    #region OnGUI
    //Function for our GUI elements
    private void OnGUI()
    {
        //create the floats scrW and scrH that govern our 16:9 ratio
        //create an int that will help with shuffulling your GUI elements under eachother
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        int i = 0;

        //GUI button on the left of the screen with the contence <
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
        //GUI Box or Lable on the left of the screen with the contence Skin
        //GUI button on the left of the screen with the contence >
        //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this

        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH),
                                0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Skin", -1);
        }

        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH),
                                scrW, 0.5f * scrH), "Skin");

        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH),
                                0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Skin", 1);
        }

        i++;

        //set up same things for Hair, Mouth and Eyes
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this

        // HAIR!
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH),
                                0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Hair", -1);
        }

        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH),
                                scrW, 0.5f * scrH), "Hair");

        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH),
                                0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Hair", 1);
        }

        i++;

        // MOUTH!
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH),
                                0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Mouth", -1);
        }

        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH),
                                scrW, 0.5f * scrH), "Mouth");

        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH),
                                0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Mouth", 1);
        }

        i++;

        // EYES!
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH),
                                0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Eyes", -1);
        }

        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH),
                                scrW, 0.5f * scrH), "Eyes");

        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH),
                                0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Eyes", 1);
        }

        i++;

        // CLOTHES!
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH),
                                0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Clothes", -1);
        }

        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH),
                                scrW, 0.5f * scrH), "Clothes");

        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH),
                                0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Clothes", 1);
        }

        i++;

        // ARMOUR!
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH),
                                0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Armour", -1);
        }

        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH),
                                scrW, 0.5f * scrH), "Armour");

        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH),
                                0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Armour", 1);
        }

        i++;

        //create 2 buttons one Random and one Reset
        //Random will feed a random amount to the direction and reset will set all to 0 both use SetTexture
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this

        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH),
                                scrW, 0.5f * scrH), "Random"))
        {
            SetTexture("Skin", Random.Range(0, skinMaxIndex - 1));
            SetTexture("Hair", Random.Range(0, hairMaxIndex - 1));
            SetTexture("Mouth", Random.Range(0, mouthMaxIndex - 1));
            SetTexture("Eyes", Random.Range(0, eyesMaxIndex - 1));
            SetTexture("Clothes", Random.Range(0, clothesMaxIndex - 1));
            SetTexture("Armour", Random.Range(0, armourMaxIndex - 1));
        }

        if (GUI.Button(new Rect(1.25f * scrW, scrH + i * (0.5f * scrH),
                                scrW, 0.5f * scrH), "Reset"))
        {
            SetTexture("Skin", skinIndex = 0);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Mouth", mouthIndex = 0);
            SetTexture("Eyes", eyesIndex = 0);
            SetTexture("Clothes", mouthIndex = 0);
            SetTexture("Armour", eyesIndex = 0);
        }

        i++;

        //name of our character equals a GUI TextField that holds our character name and limit of characters
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        charName = GUI.TextField(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH),
            2f * scrW, 0.5f * scrW), charName, 12);

        i++;

        //GUI Button called Save and Play
        //this button will run the save function and also load into the game level
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 2f * scrW, 0.5f * scrW), "Save & Play"))
        {
            Save();
            SceneManager.LoadScene("Game");
        }

    }
    #endregion
}
