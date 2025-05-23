using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public float speed = 5f;//Zet de snelheid op 5 (float)
    public float timeLeft = 20f; //Zet de starttijd op 20 seconden (float).
    private int score = 0;  //Zet de score op 0 (int)

   void Update()
   {
         // Beweging
         float moveX = Input.GetAxis("Horizontal");//laat de input reageren op de pijltjes links/rechts en A/D toetsen
         float moveZ = Input.GetAxis("Vertical");////laat de input reageren op de pijltjes boven/onder en W/S toetsen

         Vector3 move = new Vector3(moveX, 0, moveZ).normalized * speed * Time.deltaTime;
         //zorg dat de input Vector word berekend met de snelheid en dat deze altijd vloeiend is ongeacht de framerate (Time.deltaTime)

         //Beweeg de speler met de Translate methode. Gebruik de move variabele als arguement.
         transform.Translate(move);

         // Timer
         //Voer deze code uit als de tijd op of onder 0 staat.
         if (timeLeft <= 0)
         {
            //Stuur een bericht naar de console met daarin "Game Over! Eindscore: " en je behaalde score.
            Debug.Log("Game Over! Eindscore: ");

            enabled = false; // Schakelt Update uit
            return;           // stopt uitvoer van de rest van de code.
         }

         //Haal Time.deltaTime van de resterende tijd af
         timeLeft -= Time.deltaTime;

         //Laat in de console het aantal resterende seconden zien (afgerond) en je score

         Debug.Log("Tijd: " + Mathf.Round(timeLeft) + " | Score: " + score);
   }

   void OnTriggerEnter(Collider other)
   {

      //Check de naam van het gameobject dat de trigger heeft geraakt. Dit moet "Coin" zijn.
         if (other.gameObject.CompareTag("Coin"))
         {
            //Voeg 10 punten toe aan je score
            score += 10;

            //Stuur een bericht naar de console dat je een munt hebt gepakt en hoeveel punten dit oplevert
            Debug.Log("Picked up coin: " + "Score: " + score);

            //Vernietig de geraakte coin
            Destroy(other.gameObject);
         }
   }
}