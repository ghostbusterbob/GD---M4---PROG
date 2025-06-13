using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private GameObject enemyposition;

    private GameObject currentBullet; // holds the reference to the instantiated bullet

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 move = new Vector3(moveX, 0f, moveZ);
        transform.Translate(move);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireBullet();
        }

        if (currentBullet != null)
        {
            currentBullet.transform.position = Vector3.Lerp(
                currentBullet.transform.position,
                enemyposition.transform.position,
                10f * Time.deltaTime
            );
        }
    }

    void FireBullet()
    {
        currentBullet = Instantiate(bulletprefab, transform.position, transform.rotation);
    }
}
