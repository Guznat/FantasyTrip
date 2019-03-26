using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slash : MonoBehaviour
{

    public int damage = 50;
    public Animator playerAnim;
    public Button slashBtn;
    public GameObject sword;

  

    public void Attack()
    {
        sword.SetActive(true);
        playerAnim.SetBool("IsAttack", true);
        
    }

     public void EndAttack()
    {
        sword.SetActive(false);
        playerAnim.SetBool("IsAttack", false);
    }

    private void Update()
    {
        slashBtn.onClick.AddListener(Attack);
    }

}
