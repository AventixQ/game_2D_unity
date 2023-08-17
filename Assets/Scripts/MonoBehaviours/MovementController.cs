using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f; //pr�dko�� poruszania

    Vector2 movement = new Vector2(); //przechowuje po�o�enie obiekt�w gracza i przeciwnika oraz kierunki ruch�w

    Animator animator; //zmienna do kt�rej zostanie zapisana referencja komponentu Animator
    string animationState = "AnimationState"; //s�u�y do odwo�ywania si� do AnimationState

    Rigidbody2D rb2D; //dekleracja w�a�ciwo�ci przechowuj�cej referencj� do klasy Rigidbody2D

    enum CharStates //deklaruje zbi�r wyliczanych sta�ych
    {
        walkEast = 1,
        walkWest = 2,
        walkNorth = 3,
        walkSouth = 4,
        idleSouth = 5
    }

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

    private void UpdateState() //update'or poruszania si�
    {
        if(movement.x > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharStates.idleSouth);
        }
    }
}
