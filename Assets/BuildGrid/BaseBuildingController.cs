using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RMGD {
    


	public class BaseBuildingController : MonoBehaviour { 


        [ContextMenu("spawn room - generic")]
        private void tempCreateRoom()
        {
            this.createRoom(RoomTypes.Generic);
        }
        [ContextMenu("spawn room - generator")]
        private void tempCreateGeneratorRoom()
        {
            this.createRoom(RoomTypes.Generator);
        }

        public void createRoom(RMGD.RoomTypes RoomType = RoomTypes.Generic)
        {
            //make sure a valid room type was passed
            if (RoomType == RoomTypes.notYetDefined)
                throw new System.Exception("'notYetDefined' is not a valid room type to create");
            //find the prefab given the room type
            GameObject RoomPrefab = (GameObject)Resources.Load("Rooms/" + RoomType.ToString() + "Room", typeof(GameObject));
            if (RoomPrefab == null)
                throw new System.Exception("Unable to load room type, are you sure it exists in the resources/Rooms directory?");
            //instantiate the prefab and then set the parent
            GameObject NewRoom = Instantiate(RoomPrefab) as GameObject;
            NewRoom.transform.parent = this.transform;
        }
    }

    public enum RoomTypes
    {
        notYetDefined,
        Generic,
        Generator,
        LivingQuarters,
        Storage,
    }
}