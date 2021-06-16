using UnityEngine;

public class MissileManager : MonoBehaviour
{

    public Missile missileTemplate;

    public Missile CreateMissile(Transform transform)
    {
        Missile missile = Instantiate(missileTemplate, transform.position + 7.0f * transform.forward + 1.0f * transform.up, transform.rotation);
        missile.gameObject.SetActive(true);
        missile.Init();
        return missile;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
