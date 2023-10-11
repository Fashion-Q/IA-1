using BaseDeAnimais;
using UnityEngine;

public abstract class IAnimal : MonoBehaviour
{
    public abstract void SetAnimal(Animal animal);

    public abstract Animal GetAnimal();

    public abstract void ShowUi();

}
