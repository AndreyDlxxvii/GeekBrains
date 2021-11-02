using System.Collections.Generic;

namespace AsteroidGB
{
    public class MyControllers : IOnUpdate, IOnStart, IOnFixedUpdate
    {
        private List<IOnStart> _onStarts = new List<IOnStart>();
        private List<IOnUpdate> _onUpdates = new List<IOnUpdate>();
        private List<IOnFixedUpdate> _onFixedUpdates = new List<IOnFixedUpdate>();


        public MyControllers Add(IController controller)
        {
            if (controller is IOnStart onStart)
            {
                _onStarts.Add(onStart);
            }
            
            if (controller is IOnUpdate onUpdate)
            {
                _onUpdates.Add(onUpdate);
            }
            
            if (controller is IOnFixedUpdate onFixedUpdate)
            {
                _onFixedUpdates.Add(onFixedUpdate);
            }
            
            return this;
        }

        public void OnStart()
        {
            foreach (var ell in _onStarts)
            {
                if (ell.HasMethod(AxisManager.OnStart))
                {
                    ell.OnStart();
                }
            }
        }

        public void OnUpdate()
        {
            foreach (var ell in _onUpdates)
            {
                if (ell.HasMethod(AxisManager.OnUpdate))
                {
                    ell.OnUpdate();
                }
            }
        }

        public void OnFixedUpdate()
        {
            foreach (var ell in _onFixedUpdates)
            {
                if (ell.HasMethod(AxisManager.OnFixedUpdate))
                {
                    ell.OnFixedUpdate();
                }
            }
        }
        
    }
}