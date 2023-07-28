using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Standard Settings")]
    public int maxHealth = 100;
    public float health = 100;
    public float healthRegen = 0.03f; // 3% of health per second
    public float moveSpeed = 5f;
    public int strength = 10;

    [Header("Leveling System")]
    public int level = 1;
    public int exp = 0;
    public float expReq = 10;   // a float because when this value scales it needs to be multuplied by a float

    public int skillPoints = 0; // The amount of skill points the user has to spend
    

    [Header("Damage")]
    [Range(0, 0.75f)] public float damageReduction = 0.0f;
    public float baseDamageMultiplier = 1f;

    [Header("Magic Settings")]
    public float baseMagicReduction = 0f;
    public int magicCapacity = 100;
    public int baseMagicCost = 10;

    private void Update() {
        if (exp >= expReq) {    // if the player has enought exp to level up
            LevelUp(GameObject.Find("Level Text").GetComponent<Text>());    // runs teh funciton with the text obect being found asthe level text
        }

        // Updates the health
        UpdateHealth();
        
        // Regen health
        StartCoroutine(Regeneration());
    }

    private void UpdateHealth() {
        var sliderParent = GameObject.Find("HealthSlider");
        Slider slider = sliderParent.GetComponent<Slider>();
        slider.maxValue = maxHealth;
        slider.value = health;

        if (health > maxHealth) {health = maxHealth;}   // if the health becomes greater than max health, then sets the health to the max health
    }

    bool isCoroutineExecuting = false;
    private IEnumerator Regeneration() {
        if (isCoroutineExecuting) {
            yield break;
        }

        isCoroutineExecuting = true;

        if (health < maxHealth) {
            yield return new WaitForSeconds(1f);
            health += (healthRegen * maxHealth);
        }

        isCoroutineExecuting = false;
    }

    public void LevelUp(Text text) {
        level += 1; // Increases the players level
        text.text = level.ToString(); // updates the text in the ui to show the correct player level

        // increasing stats
        healthRegen = 0.03f + ((level - 1f) /200f);

        // give skill points
        skillPoints += 1; // Getting the skill points variable from the component on the parent gameobject and increasing it by 1

        // Updating needed exp
        expReq = expReq + (5 * (level - 1));    
        exp = 0;    // ressetting the exp
        // y=2.5x^2 - 7.5x + 15 - The equation for the amount of exp, where x is the level, and y is the amount of exp needed from 0      
    }
}
