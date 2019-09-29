using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RMGD {
    


	public class BaseBuildingController : MonoBehaviour {
        [SerializeField]
        public GameObject roomPrefab;

        [ContextMenu("create room")]
        private void tempCreateRoom()
        {
            this.createRoom();
        }

        public void createRoom(RMGD.RoomTypes roomType = RoomTypes.generic)
        {
            GameObject newRoom = Instantiate(roomPrefab) as GameObject;
            
            newRoom.transform.parent = this.transform;
            newRoom.GetComponent<Room>().roomData = ScriptableObject.CreateInstance<generatorRoom>();



        }
    }

    public enum RoomTypes
    {
        generic,
        generator,
        livingQuarters,
        storage,
    }
}