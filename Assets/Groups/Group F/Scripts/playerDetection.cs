using UnityEngine;

public class playerDetection : MonoBehaviour {

    public float decaySpeed = 0.2f;
    public float spawnProtection = 0.0f;
    public AudioSource dyingSound;

    public float decay = 0.0f; // [0.0, 1.0]

    private Rigidbody rb;
    private BoxCollider bc;
    private MeshRenderer mr;

    private bool platformTouched = false;
    private bool triedKill = false;

    void Awake()
    {
        spawnProtection = Time.time + 5.0f;
        this.bc = this.GetComponent<BoxCollider>();
        this.mr = this.GetComponent<MeshRenderer>();
        this.rb = this.GetComponent<Rigidbody>();
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
        
        if (dyingSound != null)
        {
            dyingSound.Play(0);
        }
    }

    private void Update()
    {
        if (IsSpawnProtected())
        {
            return;
        }
        
        if (!platformTouched)
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


        this.GetComponent<MeshRenderer>().material.color = new Color(255.0f, 0.0f, 0.0f, 0.0f);

        var myDelta = Time.deltaTime * decaySpeed;
        decay += myDelta;
        //Debug.Log(decay);

        var fallingDistance = myDelta * 2.0f * (float)Mathf.Pow(decay, 3.0f);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - fallingDistance, this.transform.position.z);
    }
}
