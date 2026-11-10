using UnityEngine;

public class Rat : MonoBehaviour
{
    [SerializeField] private float _shrinkAmount;
    [SerializeField] private float _spawnAmount;
    [SerializeField] private GameObject _ratPrefab;
    [SerializeField] private SpriteRenderer _explosionPrefab;

    private Color[] _colors = new Color[3]
    {
        Color.yellow,
        Color.red,
        Color.blue
    };
    private int _colorIndex;

    // ------------------------------------------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // STEP 2 -------------------------------------------------------------
        // If the Rat collides with a GameObject with the "Attack" tag,
        //      call SpawnSmallRat() _spawnAmount number of times to spawn
        //      more rats. (The spawning logic is written for you.)
        //
        // Also, shrink the original Rat by _shrinkAmount amount.
        if (collision.gameObject.CompareTag("Attack"))
        {
    // Spawn additional small rats
        for (int i = 0; i < _spawnAmount; i++)
        {
        SpawnSmallRat();
        }   

    // Shrink the original rat
        transform.localScale -= Vector3.one * _shrinkAmount;
        SpawnExplosion(_colors[_colorIndex]);

        // Move to the next color
        _colorIndex = (_colorIndex + 1) % _colors.Length;
        }
        // STEP 3
        // Additionally, call SpawnExplosion(), and pass in a different color
        //      every time.
        // SPECIFICALLY, go through the colors in the array named _colors
        //      IN ORDER.
        // Each time the Rat is kicked, the explosion should be a different
        //      color: first yellow, then red, then blue, then looping back
        //      around to yellow, etc.



        // STEP 2 -------------------------------------------------------------
    }

    // ------------------------------------------------------------------------
    private void SpawnExplosion(Color color)
    {
        SpriteRenderer explosion = Instantiate(_explosionPrefab);
        explosion.transform.position = transform.position;
        explosion.color = color;
        explosion.gameObject.SetActive(true);
    }

    // ------------------------------------------------------------------------
    private void SpawnSmallRat()
    {
        GameObject rat = Instantiate(_ratPrefab);

        Vector3 pos = Random.onUnitSphere;
        rat.transform.position += pos;

        // STEP 3 -------------------------------------------------------------
        // Uncomment and fix the below lines to give the small rat a random
        //      rotation correctly.
        // Your game should look exaclty like the finished example.

        float randomAngle = Random.Range(0, 360);
        Vector3 rotationAngles = new Vector3(0, 0, randomAngle);
        rat.transform.Rotate(rotationAngles);

        // STEP 3 -------------------------------------------------------------
    }
}