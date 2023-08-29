using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f; //prêdkoœæ poruszania

    Vector2 movement = new Vector2(); //przechowuje po³o¿enie obiektów gracza i przeciwnika oraz kierunki ruchów

    Animator animator; //zmienna do której zostanie zapisana referencja komponentu Animator

    Rigidbody2D rb2D; //dekleracja w³aœciwoœci przechowuj¹cej referencjê do klasy Rigidbody2D


    private void Start()
    {
        animator = GetComponent<Animator>(); //uzyskujemy referencje do Animator
        rb2D = GetComponent<Rigidbody2D>(); //wywo³ana w celu uzyskania referencji do komponentu Rigidbody2D
    }
    private void Update()
    {
        UpdateState();
    }
    void FixedUpdate() //metoda wywo³ywana w sta³ych odstêpach czasu
    {
        MoveCharacter();
    }
    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //ci¹g znaków okreœlaj¹cy dan¹ oœ, zwraca 0/1/-1 np dla WSAD D = 1, A = -1, nic = 0 itd...
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize(); //normalizuje wektor i przesuwa gracza z dostosowan¹ prêdkoœci¹ w ka¿dym kierunku

        rb2D.velocity = movement * movementSpeed; //przemieszcza z odpowiedni¹ prêdkoœci¹
    }

    void UpdateState()
    {
        if (Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.y, 0))
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
        animator.SetFloat("xDir", movement.x);
        animator.SetFloat("yDir", movement.y);
    }
}
