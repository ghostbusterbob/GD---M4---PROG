    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    [SerializeField] float speed = 5f;         // Maak de Snelheid van de speler aanpasbaar in de inspector
    public NewBehaviourScript scoreManager;// Zorg dat je een Referentie naar je score-script kunt ontvangen door de classnaam als type aan te geven.

    void Start()
    {
        // Controleer of er een referentie naar je score-script is meegegeven in de inspector. Als die er niet is krijg je een "null - referentie"
        if (scoreManager == null)
        {
          //debug het met een eigen error
            Debug.LogError("ScoreManager niet ingesteld!");
        }
    }

    void Update()
    {
        // Beweeg de speler links en rechts met pijltjestoetsen of A,D. gebruik ook de aanpasbare snelheid.
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 move = new Vector3(moveX,0f,0f);
        transform.Translate(move);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check of het een munt is
        if (other.CompareTag ("Coin"))
        {
            scoreManager.AddScore(10); // Roep de AddScore methode van de je score-script aan en geef 10 punten mee

           Debug.Log($"Munt gepakt!");

            //Vernietig de munt
            Destroy(other.transform.gameObject);
        }
    }
}
