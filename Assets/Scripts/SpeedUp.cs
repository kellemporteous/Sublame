using UnityEngine;
using System.Collections;

public class SpeedUp : BaseBlock {
    public override void OnHit(GameObject player, PlayerController controller)
    {
        // run the base code as well
        base.OnHit(player, controller);

        controller.Speed *= 5;
    }
}
