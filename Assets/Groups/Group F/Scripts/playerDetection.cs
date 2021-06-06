using UnityEngine;

public class playerDetection : MonoBehaviour {
    enum PlatformState { Virgin, Dying, Dead }

    public Rigidbody rb;
    public BoxCollider bc;
    public MeshRenderer mr;
    public float decaySpeed = 0.2f;

    private float decay = 0.0f; // [0.0, 1.0]

    private PlatformState state = PlatformState.Virgin;


    void OnCollisionStay(Collision col) {
        if (!col.collider.CompareTag("Player")) return;
        if (state == PlatformState.Dead) return;

        state = PlatformState.Dying;
    }

    private void Update() {
        if (rb.IsSleeping())
            rb.WakeUp();

        if (state == PlatformState.Dying) {

            var myDelta = Time.deltaTime * decaySpeed;
            decay += myDelta;
            Debug.Log(decay);

            var fallingDistance = myDelta * 2.0f * (float)Mathf.Pow(decay, 3.0f);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - fallingDistance, this.transform.position.z);

        }

        CalculateNewState();
        SetStateDependentColor();
        SetStateDependentPhysics();
    }

    void CalculateNewState() {
        if (state == PlatformState.Dying && decay >= 1.0)
            state = PlatformState.Dead;
    }

    void SetStateDependentColor() {
        switch (state) {
            case PlatformState.Virgin:
                this.GetComponent<MeshRenderer>().material.color = new Color(0.2f, 0.2f, 0.2f, 1.0f);
                break;
            case PlatformState.Dying:
                // The rottier the more red
                var newColor = new Color(0.2f + (decay * 0.8f), 0.2f - (decay * 0.2f), 0.2f - (decay * 0.2f), 1.0f);
                this.GetComponent<MeshRenderer>().material.color = newColor;
                break;
            case PlatformState.Dead:
                // make platform invisible
                Debug.Log("DEAD");
                this.GetComponent<MeshRenderer>().material.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                break;
        }
    }

    void SetStateDependentPhysics() {
        var isAlive = state != PlatformState.Dead;
        bc.enabled = isAlive;
        mr.enabled = isAlive;
    }
}
