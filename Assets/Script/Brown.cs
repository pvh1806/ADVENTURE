using UnityEngine;

public class Brown : MonoBehaviour
{
    int direction = 1;
    Vector2 vitribandau;
    // Start is called before the first frame update
    void Start()
    {
        vitribandau = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x - vitribandau.x >= 5)
            direction *= -1;
        else if (transform.position.x - vitribandau.x <= -5)
            direction *= -1;
        transform.Translate(Vector2.right * direction * 2 * Time.deltaTime * Vacham.speedBrowm);
    }
}
