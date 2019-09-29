using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RMGD
{
    public class Room : MonoBehaviour
    {
        public int health = 100;
        public int fortificationLevel = 0;
        public int floodedAmount = 0;
        public RoomData roomData;

        public bool runRoom = false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(runRoom)
                roomData.Update();
        }

        
    }
}
