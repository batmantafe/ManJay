using UnityEngine;

// Not attached to ANYTHING, but is GLOBAL script that INTERACTS with EVERYTHING!

// CHALLENGE 1: Item script allows for Amounts, Damage, Heal and Armour.

public class Item
{
    #region Private Var
    private int _idNum;
    private string _name;
    private int _value;
    private string _description;
    private Texture2D _icon;
    private string _mesh;
    private ItemType _type;

    // For Challenge 1:
    private int _amount;
    private float _damage;
    private float _heal;
    private float _armour;
    private string _location;
    #endregion

    public void ItemConstructor(int itemID, string itemName, Texture2D itemIcon, ItemType itemType)
    {
        _idNum = itemID;
        _name = itemName;
        _icon = itemIcon;
        _type = itemType;
    }

    #region Public Var
    public int ID
    {
        get { return _idNum; }
        set { _idNum = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public Texture2D Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    public string Mesh
    {
        get { return _mesh; }
        set { _mesh = value; }
    }

    public ItemType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    // For Challenge 1:
    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public float Heal
    {
        get { return _heal; }
        set { _heal = value; }
    }

    public float Armour
    {
        get { return _armour; }
        set { _armour = value; }
    }

    public string Location
    {
        get { return _location; }
        set { _location = value; }
    }
    #endregion
}

public enum ItemType
{
    Food,
    Weapon,
    Apparel,
    Crafting,
    Quest,
    Money,
    Ingredients,
    Potions,
    Scrolls
}


