using UnityEngine;

public class IALcidezMove
{
    private readonly IALcides main;
    private IAnimal anim;

    public IALcidezMove(IALcides main)
    {
        this.main = main;
    }

    public void MoveToAnimal()
    {
        if (LeftRight && anim.GetAnimal().PosX < main.GX)
        {
            main.GX -= main.speed * Time.deltaTime;
            if(anim.GetAnimal().PosX >= main.GX)
                main.GX = anim.GetAnimal().PosX;
        }
        if(!LeftRight && anim.GetAnimal().PosX > main.GX)
        {
            main.GX += main.speed * Time.deltaTime;
            if(anim.GetAnimal().PosX <= main.GX)
                main.GX = anim.GetAnimal().PosX;
        }
        
        if (TopDown && anim.GetAnimal().PosY > main.GY)
        {
            main.GY += main.speed * Time.deltaTime;
            if(anim.GetAnimal().PosY <= main.GY)
                main.GY = anim.GetAnimal().PosY;
        }
        if(!TopDown && anim.GetAnimal().PosY < main.GY)
        {
            main.GY -= main.speed * Time.deltaTime;
            if(anim.GetAnimal().PosY >= main.GY)
                main.GY = anim.GetAnimal().PosY;
        }


        if(anim.GetAnimal().PosX == main.GX && anim.GetAnimal().PosY == main.GY)
        {
            main.moveUpdate = null;
            anim.ShowUi();
            anim = null;
            if (!main.AnimacaoIsName("idle"))
                main.Trigger = "idle";
        }
    }

    public void PrepearMoveToAnimal()
    {
        if (main.GetAnimal != null)
        {
            anim = main.GetAnimal.GetComponent<AnimalGame>();
            if(anim.GetAnimal().PosX < main.GX)
            {
                LeftRight = true;
                if(!main.GetSpriteRender.flipX)
                    main.GetSpriteRender.flipX = true;
            }
            else
            {
                LeftRight = false;
                if (main.GetSpriteRender.flipX)
                    main.GetSpriteRender.flipX = false;
            }

            if(anim.GetAnimal().PosY > main.GY)
                TopDown = true;
            else
                TopDown = false;
            main.moveUpdate = main.GetMove.MoveToAnimal;
            if(main.AnimacaoIsName("idle"))
                main.Trigger = "run";
        }
        else
        {
            main.moveUpdate = null;
            anim = null;
            if(!main.AnimacaoIsName("idle"))
                 main.Trigger = "idle"; 
        }
    }

    public void MoveAround()
    {
        if (countMove < MaxCountMove)
            countMove++;
        if(countMove >= MaxCountMove && main.AnimacaoIsName("run"))
            main.Trigger = "idle";
        if((Input.GetKey(KeyCode.A) && main.GX > -15.7f) && !Input.GetKey(KeyCode.D))
        {
            main.GX -= main.speed * Time.deltaTime;
            if(!main.GetSpriteRender.flipX)
                main.GetSpriteRender.flipX = true;
            countMove = 0;
            if (main.AnimacaoIsName("idle"))
                main.Trigger = "run";
            if (main.GX < -15.7f)
                main.GX = -15.7f;
        }
        if ((Input.GetKey(KeyCode.D) && main.GX < 15.8f) && !Input.GetKey(KeyCode.A))
        {
            main.GX += main.speed * Time.deltaTime;
            if(main.GetSpriteRender.flipX)
                main.GetSpriteRender.flipX = false;
            countMove = 0;
            if (main.AnimacaoIsName("idle"))
                main.Trigger = "run";
            if (main.GX > 15.8f)
                main.GX = 15.8f;
        }
        if((Input.GetKey(KeyCode.W) && main.GY < 5.8f) && !Input.GetKey(KeyCode.S))
        {
            main.GY += main.speed * Time.deltaTime;
            countMove = 0;
            if (main.AnimacaoIsName("idle"))
                main.Trigger = "run";
            if (main.GY > 5.8f)
                main.GY = 5.8f;
        }
        if((Input.GetKey(KeyCode.S) && main.GY > -5.9f) && !Input.GetKey(KeyCode.W))
        {
            main.GY -= main.speed * Time.deltaTime;
            countMove = 0;
            if (main.AnimacaoIsName("idle"))
                main.Trigger = "run";
            if (main.GY < -5.9f)
                main.GY = -5.9f;
        }
    }

    private int countMove;
    private bool LeftRight { get; set; } = false;
    private bool TopDown { get; set; } = false;
    private int MaxCountMove { get; set; } = 3;
}
