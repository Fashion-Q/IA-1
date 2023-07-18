using UnityEngine;

public class Play
{
    readonly Main main;
    public int instance;
    public int indexAutomato;
    public bool canPlay = false,inWay = false,goUpDown,goLeftRight,endLeftRight,endUpDown;
    public float fixY = -1.76f,speed = 15;

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
            Gz = -main.rotCharacter;
            if(Gz > 300f)
            {
                instance++;
                inWay = false;
                canPlay = false;
                main.transform.eulerAngles = new Vector3();
            }
        }
        else
        {
            Gz = main.rotCharacter;
            if(Gz > 50f)
            {
                instance++;
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
        }
        Cg = Gg;
        main.alcidesName.transform.position = Gg + new Vector3(0.88f,1.5f,0);
        PneuRot();
    }

    private void PneuRot()
    {
        main.pFront.Rotate(0, 0, main.speedRot * main.controlSpeedRot);
        main.pBack.Rotate(0, 0, main.speedRot * main.controlSpeedRot);
    }
    private void State1()
    {
        instance = -1;
        Gg = new Vector3(getIndexX(),getIndexY(),0);
        main.transform.eulerAngles = new Vector3();
        Cg = Gg;
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
