using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public enum BattleState2 { START, PLAYERTURN, PLAYERTURN2, ENEMYTURN, WON, LOST }//ENEMYTURN2

public class BattleSystem2Player : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject playerPrefab2;
    public GameObject enemyPrefab;
   // public GameObject enemyPrefab2;

    public GameObject BackToGameButton;


    public Transform playerBattleStation;
    public Transform playerBattleStation2;
    public Transform enemyBattleStation;
   // public Transform enemyBattleStation2;

    Unit playerUnit;
    Unit playerUnit2;
    Unit enemyUnit;
   // Unit enemyUnit2;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD playerHUD2;
    public BattleHUD enemyHUD;
   // public BattleHUD enemyHUD2;

    public BattleState2 state;

    public Animator playerAnimator1;
    public Animator playerAnimator2;
    public Animator enemyAnimator1;
   // public Animator enemyAnimator2;

    void Start()
    {
        state = BattleState2.START;
        StartCoroutine(SetupBattle());

        BackToGameButton.SetActive(false);

    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject player2GO = Instantiate(playerPrefab2, playerBattleStation2);
        playerUnit = player2GO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

       // GameObject enemy2GO = Instantiate(enemyPrefab2, enemyBattleStation2);
       // enemyUnit = enemy2GO.GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName + " approaches!";

        playerHUD.SetHUD(playerUnit);
        playerHUD2.SetHUD(playerUnit2);
        enemyHUD.SetHUD(enemyUnit);
      //  enemyHUD2.SetHUD(enemyUnit2);

        //Wait a few seconds before the PLAYER can do anything
        yield return new WaitForSeconds(2F);

        state = BattleState2.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        playerAnimator1.SetBool("BasicAttack", true);
        yield return new WaitForSeconds(2f);
        playerAnimator1.SetBool("BasicAttack", false);
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
            state = BattleState2.WON;
            EndBattle();
        }
        else
        {
            //pLAYER2 turn, change state to PLAYERTURN2
            state = BattleState2.PLAYERTURN2;
            StartCoroutine(PlayerTurn2());
        }
        //Change state based on what happened 
    }

    IEnumerator PlayerTurn2()
    {
        playerAnimator2.SetBool("GuitarAttack", true);
        yield return new WaitForSeconds(2f);
        playerAnimator2.SetBool("GuitarAttack", false);
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
            state = BattleState2.WON;
            EndBattle();
        }
        else
        {
            //Enemy's turn, change state to ENEMYTURN
            state = BattleState2.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        //Change state based on what happened 
    }


    IEnumerator EnemyTurn()
    {

        Cursor.lockState = CursorLockMode.Locked;
        enemyAnimator1.SetBool("EnemyAttack1", true);
        dialogueText.text = enemyUnit.unitName + " attacks!";
        yield return new WaitForSeconds(2f);

        enemyAnimator1.SetBool("EnemyAttack1", false);
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);            //

        playerHUD.SetHP(playerUnit.currentHP);                            //

        yield return new WaitForSeconds(1f);
        Cursor.lockState = CursorLockMode.None;

        if (isDead)
        {
            state = BattleState2.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState2.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState2.WON)
        {
            dialogueText.text = "You won the battle!";
            //Scene Management? Reload Scene? 
        }
        else if (state == BattleState2.LOST)
        {
            dialogueText.text = "You lost...";
            //Scene Management? Reload Scene? 
        }

        BackToGameButton.gameObject.SetActive(true);
    }






    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    public void OnAttackButton()
    {
        //Check if it is the PLAYER's turn
        if (state != BattleState2.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

    }

    IEnumerator PlayerHeal()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
        playerUnit.Heal(5);
        playerAnimator2.SetBool("GuitarAttack", true);

        playerHUD.SetHP(playerUnit.currentHP);
        playerHUD2.SetHP(playerUnit.currentHP);
        dialogueText.text = "You both feel renewed strength!";

        yield return new WaitForSeconds(3f);


        playerAnimator2.SetBool("GuitarAttack", false);

        state = BattleState2.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }


    public void OnHealButton()
    {
        //Check if it is the PLAYER's turn
        if (state != BattleState2.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());

    }
    void Update()
    {
        
    }
}
