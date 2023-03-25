using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            //No kitchenObject here
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKithcenObjectParent(this);
            } else
            {
                // Player not carrying anything
            }
        } else
        {
            if (player.HasKitchenObject())
            {
                // player is carrying something
                if(player.GetKitchenObject() is PlateKitchenObject)
                {
                    //player is holding a plate
                    PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
            } else
            {
                // player is not carrying anything
                GetKitchenObject().SetKithcenObjectParent(player);
            }

        }
    }

    
}
