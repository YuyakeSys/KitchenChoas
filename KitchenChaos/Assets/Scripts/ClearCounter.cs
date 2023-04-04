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
                // player is carrying something try to get plate
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //player is holding a plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                } else
                {
                    // player is not carrying palte but something else
                    if(GetKitchenObject().TryGetPlate(out plateKitchenObject)){
                        // counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
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
