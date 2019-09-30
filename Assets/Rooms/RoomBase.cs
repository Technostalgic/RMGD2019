using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RMGD
{
    /*
     * This is the base class for the room.
     * This handles any default/generic behavior that is shared between all rooms.
     *
     * Each room type should have a class that inherits from this (see Assets/Rooms/RoomScripts/GenericRoom).
     * When creating a new room type, you should create a prefab and place that into Assets/resources/Rooms - make sure to attach your class you created in the step above!
     */
    public abstract class RoomBase : MonoBehaviour
    {
        public int Health
        {
            get { return this.Health; }
            private set { this.Health = Mathf.Clamp(value, 0, 100); }
        }
        public int Fortification
        {
            get { return this.Fortification; }
            set { this.Fortification = Mathf.Clamp(value, 0, 100);  }
        }
        public int FloodedAmount
        {
            get { return this.FloodedAmount; }
            set { this.FloodedAmount = Mathf.Clamp(value, 0, 100); }
        }
        public RoomTypes RoomType { get; protected set; }
        [SerializeField]
        private Sprite RoomSprite;




        private bool isPlaced = false; //used below to run the tick once the room is placed

        //do preliminary checks and instantiate all values on the base class
        void Awake()
        {
            if (this.RoomType == RoomTypes.notYetDefined)
                Debug.LogError("Room object created but type is undefined");
            this.Health = 100;
            this.Fortification = 0;
            this.FloodedAmount = 0;
            this.GenericBegin();
            this.Begin();
        }

        // Update is called once per frame
        void Update()
        {
            if (isPlaced)
            {
                this.GenericTick();
                this.Tick();
            }
            else
            {
                //@todo
                //show the sprite at the mouse tile location
            }
        }

        //------------------------------------------------------------------------
        // The following two functions / methods are implemented here and will run regardless
        // of what type of child inherits this class.  This is where you can place generic
        // logic that applies to all rooms regardless of type, eg: when flooded decrease health.
        //------------------------------------------------------------------------

        // This is called after the awake() function has completed.
        private void GenericBegin()
        {

        }
        // This is called once per frame after the object has been placed.
        private void GenericTick()
        {

        }



        //------------------------------------------------------------------------
        // The following two methods/functions are to be implemented by the children.
        // They will contain logic specific to those children, such as generating power, etc.
        //------------------------------------------------------------------------

        // This is called after the awake() and GenericBegin() functions have completed.
        abstract public void Begin();
        // This is called once per frame after the object has been placed, is called directly after GenericTick()
        abstract public void Tick();
    }

}

