using UnityEngine;

public class CameraMain : MonoBehaviour
{
    [SerializeField]
    private GameObject alcidesObjeto;
    private IALcides alcidesScript;

    private void Start()
    {
        alcidesScript = alcidesObjeto.GetComponent<IALcides>();
    }

    private void FixedUpdate()
    {
        if(alcidesScript.GX > -7.3f && alcidesScript.GX < 7.3f)
            GX = alcidesScript.GX;
        if(alcidesScript.GY > -1.9f && alcidesScript.GY < 1.9f)
            GY = alcidesScript.GY;
    }
    public float GX
    {
        get { return transform.position.x; }
        set { transform.position = new Vector3(value, GY, -10); }
    }

    public float GY
    {
        get { return transform.position.y; }
        set { transform.position = new Vector3(GX, value, -10); }
    }
}
