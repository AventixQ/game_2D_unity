using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f; //pr�dko�� poruszania

    Vector2 movement = new Vector2(); //przechowuje po�o�enie obiekt�w gracza i przeciwnika oraz kierunki ruch�w

    Animator animator; //zmienna do kt�rej zostanie zapisana referencja komponentu Animator

    Rigidbody2D rb2D; //dekleracja w�a�ciwo�ci przechowuj�cej referencj� do klasy Rigidbody2D


    private void Start()
    {
        animator = GetComponent<Animator>(); //uzyskujemy referencje do Animator
        rb2D = GetComponent<Rigidbody2D>(); //wywo�ana w celu uzyskania referencji do komponentu Rigidbody2D
    }
    private void Update()
    {
        UpdateState();
    }
    void FixedUpdate() //metoda wywo�ywana w sta�ych odst�pach czasu
    {
        MoveCharacter();
    }
    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //ci�g znak�w okre�laj�cy dan� o�, zwraca 0/1/-1 np dla WSAD D = 1, A = -1, nic = 0 itd...
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize(); //normalizuje wektor i przesuwa gracza z dostosowan� pr�dko�ci� w ka�dym kierunku

        rb2D.velocity = movement * movementSpeed; //przemieszcza z odpowiedni� pr�dko�ci�
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
