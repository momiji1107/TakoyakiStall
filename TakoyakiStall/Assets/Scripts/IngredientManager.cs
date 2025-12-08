using System;
using UnityEngine;
using System.Collections.Generic;

public class IngredientManager : MonoBehaviour
{
    private List<string> ingredients = new List<string>(); //たこ焼きに入っている具材
    [SerializeField] private Sprite[] ingreSprites; //具材のSprite
    private Dictionary<string, Sprite> ingreDic = new Dictionary<string, Sprite>(); //具材の名称とSpriteを登録する

    private void Start()
    {
        ingreDic.Add("NEGI",ingreSprites[0]);
        ingreDic.Add("BENI",ingreSprites[1]);
    }

    public void AddIngredient(string ingredient)
    {
        if (ingredients.Contains(ingredient))
        {
            Debug.Log(ingredient + "is already in the ingredient list");
        }
        else
        {
            ingredients.Add(ingredient);
            var obj = Instantiate(new GameObject(ingredient), transform);
            SpriteRenderer sr = obj.AddComponent<SpriteRenderer>();
            sr.sortingOrder = ingredients.Count + 1;
            sr.sprite = ingreDic[ingredient];
            Debug.Log(ingredient + "was added.");
        }
       
    }
}
