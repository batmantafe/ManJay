using UnityEngine;

public static class ItemGen
{
    public static Item CreateItem(int itemID)
    {
        Item temp = new Item();

        string name = "";
        int value = 0;
        string description = "";
        string icon = "";
        string mesh = "";
        ItemType type = ItemType.Food;

        int amount = 0;
        float damage = 0f;
        float heal = 0f;
        float armour = 0f;

        switch (itemID)
        {
            #region Food 0-99
            case 0:
                name = "Meat";
                value = 5;
                description = "Meaty Goodness";
                icon = "Meat";
                mesh = "Meat";
                type = ItemType.Food;

                heal = 10f;
                break;
            case 1:
                name = "Apple";
                value = 5;
                description = "Munchies and Crunchies";
                icon = "Apple";
                mesh = "Apple";
                type = ItemType.Food;

                heal = 10f;
                break;
            #endregion

            #region Weapon 100-199
            case 100:
                name = "Axe";
                value = 15;
                description = "To cleave man";
                icon = "Axe";
                mesh = "Axe";
                type = ItemType.Weapon;
                break;
            case 101:
                name = "Bow";
                value = 15;
                description = "To shoot man";
                icon = "Bow";
                mesh = "Bow";
                type = ItemType.Weapon;
                break;
            case 102:
                name = "Sword";
                value = 15;
                description = "To stab man";
                icon = "Sword";
                mesh = "Sword";
                type = ItemType.Weapon;
                break;
            case 103:
                name = "Shield";
                value = 15;
                description = "To protect self";
                icon = "Shield";
                mesh = "Shield";
                type = ItemType.Weapon;
                break;
            #endregion

            #region Apparel 200-299
            case 200:
                name = "Armor";
                value = 15;
                description = "Strong iron stuff";
                icon = "Armor";
                mesh = "Armor";
                type = ItemType.Apparel;
                break;
            case 201:
                name = "Belts";
                value = 15;
                description = "To keep your pants up, buddy";
                icon = "Belts";
                mesh = "Belts";
                type = ItemType.Apparel;
                break;
            case 202:
                name = "Boots";
                value = 15;
                description = "To manage your foot fetish";
                icon = "Boots";
                mesh = "Boots";
                type = ItemType.Apparel;
                break;
            case 203:
                name = "Bracers";
                value = 15;
                description = "Your wrists, beast";
                icon = "Bracers";
                mesh = "Bracers";
                type = ItemType.Apparel;
                break;
            case 204:
                name = "Cloaks";
                value = 15;
                description = "Up, up and awaaay!";
                icon = "Cloaks";
                mesh = "Cloaks";
                type = ItemType.Apparel;
                break;
            case 205:
                name = "Gloves";
                value = 15;
                description = "Keep your hands warm in the long winter";
                icon = "Gloves";
                mesh = "Gloves";
                type = ItemType.Apparel;
                break;
            case 206:
                name = "Helmets";
                value = 15;
                description = "Protect your hair";
                icon = "Helmets";
                mesh = "Helmets";
                type = ItemType.Apparel;
                break;
            case 207:
                name = "Pants";
                value = 15;
                description = "Protect others' eyes";
                icon = "Pants";
                mesh = "Pants";
                type = ItemType.Apparel;
                break;
            case 208:
                name = "Shoulders";
                value = 15;
                description = "The weight of the world";
                icon = "Shoulders";
                mesh = "Shoulders";
                type = ItemType.Apparel;
                break;
            #endregion

            #region Crafting 300-399
            case 300:
                name = "Ingots";
                value = 15;
                description = "Make stuff with this";
                icon = "Ingots";
                mesh = "Ingots";
                type = ItemType.Crafting;
                break;
            case 301:
                name = "Gem";
                value = 15;
                description = "Shiny!";
                icon = "Gem";
                mesh = "Gem";
                type = ItemType.Crafting;
                break;

            #endregion

            #region Quest 400-499

            #endregion

            #region Ingredients 600-699

            #endregion

            #region Potions 700-799

            #endregion

            #region Scrolls 800-899

            #endregion


            default:
                itemID = 1;
                name = "Apple";
                value = 5;
                description = "Munchies and Crunchies";
                icon = "Apple";
                mesh = "Apple";
                type = ItemType.Food;

                heal = 10f;
                break;
            
        }

        temp.ID = itemID;
        temp.Name = name;
        temp.Value = value;
        temp.Description = description;
        temp.Icon = Resources.Load("Icons/"+icon) as Texture2D;
        temp.Mesh = mesh;
        temp.Type = type;

        // For Challenge 1:
        temp.Amount = amount;
        temp.Damage = damage;
        temp.Heal = heal;
        temp.Armour = armour;

        return temp;
    }
}
