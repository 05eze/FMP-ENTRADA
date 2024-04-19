using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;


    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    
    public BattleState state;


    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }







    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
        
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName + " approaches!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        //Wait a few seconds before the PLAYER can do anything
        yield return new WaitForSeconds(2F);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
   







    IEnumerator PlayerAttack()
    {
        //Damage the enemy + wait for a few seconds
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";
        Cursor.lockState = CursorLockMode.Locked;

        yield return new WaitForSeconds(2f);
        Cursor.lockState = CursorLockMode.None;
        //Check if the enemy is dead

        if (isDead)
        {
            //End Battle, change state to WON
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            //Enemy's turn, change state to ENEMYTURN
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        //Change state based on what happened 
    }

    IEnumerator PlayerHeal()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerUnit.Heal(5);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You feel renewed strength!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine (EnemyTurn());
    }




    IEnumerator EnemyTurn()
    {

        Cursor.lockState = CursorLockMode.Locked;

        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);
        Cursor.lockState = CursorLockMode.None;

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }










    //Change to IEnumerator + yield return new WaitForSeconds after you add a transition 
    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
            //Scene Management? Reload Scene? 
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You lost...";
            //Scene Management? Reload Scene? 
        }
    }





    //The PLAYER's Turn
    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }






    public void OnAttackButton()
    {
        //Check if it is the PLAYER's turn
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

    }
    
    
    public void OnHealButton()
    {
        //Check if it is the PLAYER's turn
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());

    }
}
