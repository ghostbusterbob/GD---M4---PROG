using System.Timers;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] float speed = 5f;             // Aanpasbaar in Inspector
    [SerializeField] GameObject coinPrefab;        // Sleep prefab hierin

    void Start()
    {

        for (int i = 0; i <= 30; i++)
        {
                    float randVal = Random.Range(-10,10);

            Instantiate(coinPrefab, new Vector3(randVal, 0, 0), Quaternion.identity); 
        }

    }

    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(input * speed * Time.deltaTime, 0, 0));
    }
}