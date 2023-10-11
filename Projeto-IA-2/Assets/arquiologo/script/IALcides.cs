using System;
using UnityEngine;

public class IALcides : MonoBehaviour
{
    public Action moveUpdate;
    private IALcidezMove move;
    private GameObject animal;
    public float speed;
    [SerializeField]
    private Animator animacao;

    void Start()
    {
        move = new(this);
        PesquisarBool = false;
        moveUpdate = GetMove.MoveAround;
    }

    private void FixedUpdate()
    {
        moveUpdate?.Invoke();
    }

    public bool PesquisarBool { get; set; }

    public float GX
    {
        get { return transform.position.x; }
        set { transform.position = new Vector3(value, GY, 0); }
    }

    public float GY
    {
        get { return transform.position.y; }
        set { transform.position = new Vector3(GX, value, 0); }
    }
    public SpriteRenderer GetSpriteRender => transform.GetComponent<SpriteRenderer>();
    public GameObject GetAnimal => animal;
    public void SetAnimal(GameObject animal)
    {
        this.animal = animal;
        moveUpdate = GetMove.PrepearMoveToAnimal;
    }
    public IALcidezMove GetMove => move;
    public Animator GetAnimacao => animacao;
    public bool AnimacaoIsName(string name) => animacao.GetCurrentAnimatorStateInfo(0).IsName(name);
    
    public string Trigger
    {
        set { animacao.SetTrigger(value); }
    }
    public void Print(string text) => print(text);
    public bool CanMove { get; set; } = true;
}
