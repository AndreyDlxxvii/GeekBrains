using UnityEngine;

namespace GBPlatformer
{
    public class DoorController
    {
        private DoorView _doorView;

        public DoorController(DoorView doorView)
        {
            _doorView = doorView;
        }

        public void MoveDoors()
        {
            Vector3 dir = Vector3.down;
            for (int i = 0; i < _doorView.DoorPlatform.Length; i++)
            {
                _doorView.DoorPlatform[i].position = _doorView.DoorPlatform[i].position + dir;
                dir.y -= 1f;
            }
        }
    }
}