using UnityEngine;

public class playerDetection : MonoBehaviour {

    public Rigidbody rb;
    public BoxCollider bc;
    public MeshRenderer mr;
    public float decaySpeed = 0.2f;
    public float spawnProtection = 0.0f;
    public AudioSource dyingSound;
    public AudioSource deathSound;

    public float decay = 0.0f; // [0.0, 1.0]

    private bool platformTouched = false;
    private bool triedKill = false;

    void Awake()
    {
        spawnProtection = Time.time + 5.0f;
    }

    bool IsSpawnProtected()
    {
        return spawnProtection == 0.0f || spawnProtection >= Time.time;
    }

    void OnCollisionStay(Collision col)
    {
        if (IsSpawnProtected()) {
            return;
        }

        if (!col.collider.CompareTag("Player")) return;
        if (platformTouched) return;
        platformTouched = true;
        dyingSound.Play(0);
    }

    private void Update()
    {
        if (IsSpawnProtected())
        {
            return;
        }

        if (!triedKill)
        {
            triedKill = true;
            Destroy(gameObject, 3);
        }

        if (rb.IsSleeping())
        {
            rb.WakeUp();
        }

        
        if (!platformTouched)
        {
            return;
        }
        this.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);

        var myDelta = Time.deltaTime * decaySpeed;
        decay += myDelta;
        //Debug.Log(decay);

        var fallingDistance = myDelta * 2.0f * (float)Mathf.Pow(decay, 3.0f);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - fallingDistance, this.transform.position.z);
    }
}
