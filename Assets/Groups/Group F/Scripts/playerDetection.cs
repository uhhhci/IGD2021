using UnityEngine;

public class playerDetection : MonoBehaviour {

    public float decaySpeed = 0.2f;
    public float spawnProtection = 0.0f;
    public AudioSource dyingSound;

    public float decay = 0.0f; // [0.0, 1.0]

    private Rigidbody rigidBody;
    private BoxCollider boxCollider;
    private MeshRenderer meshRenderer;

    private bool platformTouched = false;
    private bool triedKill = false;

    void Awake()
    {
        spawnProtection = Time.time + 5.0f;
        this.boxCollider = this.GetComponent<BoxCollider>();
        this.meshRenderer = this.GetComponent<MeshRenderer>();
        this.rigidBody = this.GetComponent<Rigidbody>();
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


        if (rigidBody.IsSleeping())
        {
            rigidBody.WakeUp();
        }

        var col = new Color(1.0f, 0.0f, 0.0f, 1.0f);

        this.meshRenderer.material.SetColor("_Color", col);

        var myDelta = Time.deltaTime * decaySpeed;
        decay += myDelta;
        //Debug.Log(decay);

        var fallingDistance = myDelta * 2.0f * (float)Mathf.Pow(decay, 3.0f);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - fallingDistance, this.transform.position.z);
    }
}
