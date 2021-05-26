using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float In_Pos, Anchura;
    public GameObject Cam;
    public float Paral_Ef;

    void Start()
    {
        In_Pos = transform.position.x;
        Anchura = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void FixedUpdate()
    {
        float Temp = (Cam.transform.position.x * (1 - Paral_Ef));
        float Dist = (Cam.transform.position.x * Paral_Ef);

        transform.position = new Vector3(In_Pos + Dist, transform.position.y, transform.position.z);

        if (Temp > In_Pos + Anchura) In_Pos += Anchura;
        else if (Temp < In_Pos - Anchura) In_Pos -= Anchura;
    }
}