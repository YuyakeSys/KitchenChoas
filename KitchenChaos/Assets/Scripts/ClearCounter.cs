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
            } else
            {
                // player is not carrying anything
                GetKitchenObject().SetKithcenObjectParent(player);
            }

        }
    }

    
}
