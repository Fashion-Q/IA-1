using UnityEngine;

public class Play
{
    readonly Main main;
    public int instance;
    public int indexAutomato;
    public bool canPlay = false,inWay = false,goUpDown,goLeftRight,endLeftRight,endUpDown;
    public int countGral;
    public float fixY = -2.5f,speed = 7.5f;

    public Play(Main main)
    {
        this.main = main;
    }
    public void Playy()
    {
        if (canPlay)
        {
            if (instance == 0)
                State1();
            else if (instance == 1)
                AlcidesNoGrau();
            else if (inWay)
                Move();
        }
    }
    
    private void AlcidesNoGrau()
    {
        PneuRot();
        if (endLeftRight && endUpDown)
        {
            countGral++;
            Gz = -main.rotCharacter * -main.controlSpeedRot;
            if(countGral > 40)
            {
                instance++;
                inWay = false;
                canPlay = false;
                main.transform.eulerAngles = new Vector3();
                main.animacao.SetBool("run", false);
                main.main.RotReset();
                main.iFront.RotReset();
                main.iBack.RotReset();
                if(indexAutomato+1 == main.profundidade.automatosGerados.Count)
                {
                    main.textVitoria.enabled = true;
                }
                countGral = 0;
            }
        }
        else
        {
            countGral++;
            Gz = -main.rotCharacter * main.controlSpeedRot;
            if (countGral > 40)
            {
                instance++;
                countGral = 0;
            }
        }
    }
    private void Move()
    {
        if(goLeftRight && !endLeftRight)
        {
            Gx -= speed * Time.deltaTime;
            endLeftRight = Gx > getIndexX() ? false : true;
        }else if(!goLeftRight && !endLeftRight){
            Gx += speed * Time.deltaTime;
            endLeftRight = Gx < getIndexX() ? false : true;
        }

        if(goUpDown && !endUpDown) 
        {
            Gy += speed * Time.deltaTime;
            endUpDown = Gy < getIndexY() ? false : true;
        }
        else if(!goUpDown && !endUpDown)
        {
            Gy -= speed * Time.deltaTime;
            endUpDown = Gy > getIndexY() ? false : true;
        }
        if(endLeftRight && endUpDown)
        {
            instance = 1;
            main.audioSource.clip = main.edu2;
            main.audioSource.loop = false;
            main.audioSource.Play();
        }
        Cg = Gg;
        main.alcidesName.transform.position = Gg + new Vector3(main.nameFixX, main.nameFixY, 0);
        main.iBrasileirinho.Gx = Gx + main.brasileirinhoX;
        main.iBrasileirinho.Gy = Gy + 0.6f;
        PneuRot();
    }

    private void PneuRot()
    {
        main.iFront.RotForward = main.speedRot * main.controlSpeedRot;
        main.iBack.RotForward = main.speedRot * main.controlSpeedRot;
    }
    private void State1()
    {
        countGral = 0;
        instance = -1;
        Gg = new Vector3(getIndexX(),getIndexY(),0);
        main.transform.eulerAngles = new Vector3();
        Cg = Gg;
        main.alcidesName.transform.position = Gg + new Vector3(main.nameFixX, main.nameFixY, 0);
        main.iBrasileirinho.Gx = Gx + main.brasileirinhoX;
        main.iBrasileirinho.Gy = Gy + 0.6f;
    }

    public float getIndexX()
    {
        return main.profundidade.automatosGerados[indexAutomato].x * main.calcDistance;
    }

    public float getIndexY()
    {
        return main.profundidade.automatosGerados[indexAutomato].y * main.calcDistance + fixY;
    }

    public float Gx
    {
        get { return main.transform.position.x; }
        set { main.transform.position = new Vector3(value,Gy,0); }
    }

    public float Gy
    {
        get { return main.transform.position.y; }
        set { main.transform.position = new Vector3(Gx, value, 0); }
    }

    public float Gz
    {
        get { return main.transform.eulerAngles.z;  }
        set { main.transform.Rotate(0,0,value); }
    }

    public Vector3 Gg
    {
        get { return main.transform.position; }
        set { main.transform.position = value; }
    }

    public float Cx
    {
        get { return main.cam.transform.position.x; }
        set { main.cam.transform.position = new Vector3(value, Cy, -10f); }
    }

    public float Cy
    {
        get { return main.cam.transform.position.y; }
        set { main.cam.transform.position = new Vector3(Cx, value + fixY, -10f); }
    }

    public Vector3 Cg
    {
        get { return main.cam.transform.position; }
        set { main.cam.transform.position = value + new Vector3(0f,0f,-10f); }
    }

    
}
