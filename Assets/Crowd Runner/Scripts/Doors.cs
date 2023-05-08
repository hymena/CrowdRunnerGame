using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum Bonustype
{
    Addition, Difference, Product, Division
}
public class Doors : MonoBehaviour
{
   
    

    [Header("Elements")]
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;
    [SerializeField] private Collider doorsCollider;

    [Header("Settings")]
    [SerializeField] private Bonustype rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;
    
    [SerializeField] private Bonustype leftDoorBonusType;
    [SerializeField] private int leftDoorBonusAmount;

    [SerializeField] private Color bonusColor;
    [SerializeField] private Color penaltyColor;

    void Start()
    {
        ConfigureDoors();
    }

     
    void Update()
    {
        
    }

    private void ConfigureDoors()
    {
        // Configure the right door

        switch(rightDoorBonusType)
        {
            case Bonustype.Addition:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rightDoorBonusAmount;
                break;
            case Bonustype.Difference:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "-" + rightDoorBonusAmount;
                break;
            case Bonustype.Product:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "x" + rightDoorBonusAmount;
                break;
            case Bonustype.Division:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "/" + rightDoorBonusAmount;
                break;
        }

        switch (leftDoorBonusType)
        {
            case Bonustype.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;
            case Bonustype.Difference:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmount;
                break;
            case Bonustype.Product:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "x" + leftDoorBonusAmount;
                break;
            case Bonustype.Division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorBonusAmount;
                break;
        }

    }

    public int GetBonusAmount(float xPosition)
    {
        if (xPosition > 0)
            return rightDoorBonusAmount;
        else
            return leftDoorBonusAmount;
    }

    public Bonustype GetBonusType(float xPosition)
    {
        if (xPosition > 0)
            return rightDoorBonusType;
        else
            return leftDoorBonusType;
    }

    public void Disable()
    {
        doorsCollider.enabled = false;
    }
}
