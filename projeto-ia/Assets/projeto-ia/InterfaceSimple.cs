using UnityEngine;

public class ITransformSimple
{
    private readonly Transform transform;
    private readonly SpriteRenderer spriteRender;
    private float zValue;
    public ITransformSimple(Transform transform,float zValue, SpriteRenderer spriteRender)
    {
        this.transform = transform;
        this.zValue = zValue;
        this.spriteRender = spriteRender;
    }
    public bool GSRBool
    {
        get { return spriteRender.enabled; }
        set { spriteRender.enabled = value; }
    }
    public float Gx
    {
        get { return transform.position.x; }
        set { transform.position = new Vector3(value, Gy, zValue); }
    }

    public float Gy
    {
        get { return transform.position.y; }
        set { transform.position = new Vector3(Gx, value, zValue); }
    }

    public Vector3 Gg
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public float Rot
    {
        get { return transform.eulerAngles.z; }
        set { transform.eulerAngles = new Vector3(0, 0, value); }
    }
    public float RotForward
    {
        set { transform.Rotate(Vector3.forward, value); }
    }

    public float EulerZ
    {
        get { return transform.eulerAngles.z; }
        set { transform.eulerAngles = new Vector3(0, EulerY, value); }
    }

    public float EulerY
    {
        get { return transform.eulerAngles.y; }
        set { transform.eulerAngles = new Vector3(0, value, EulerZ); }
    }

    public Vector3 RotEuler
    {
        get { return transform.eulerAngles; }
        set { transform.eulerAngles = value; }
    }

    public void RotReset() {
        transform.eulerAngles = new Vector3(0,0,0);
    }

    public void SetZEulerValue(float zValue)
    {
        this.zValue = zValue;
    }
}