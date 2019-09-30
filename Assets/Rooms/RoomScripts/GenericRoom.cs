using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RMGD
{
    public class GenericRoom : RoomBase
    {
        public GenericRoom()
        {
            this.RoomType = RoomTypes.Generic;
        }
        // This is called when the object is instantiated, at the end of the awake() function.
        // Runs after the GenericBegin() function finishes.
        public override void Begin()
        {
            //do nothing yet
        }
        // This is called once per frame after the obejct has been placed onto the grid.
        // This runs directly after GenericTick()
        public override void Tick()
        {
            //@todo
            //decrease the health by 1 every second


        }

    }

}
