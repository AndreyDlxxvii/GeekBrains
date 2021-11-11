using System.Collections.Generic;

namespace GBPlatformer
{
    public class Controllers
    {
        public const string startMethod = "OnStart";
        public const string updateMethod = "OnUpdate";
        public const string fixedUpdateMethod = "OnFixedUpdate";
        
        private List<IOnStart> _onStarts = new List<IOnStart>();
        private List<IOnUpdate> _onUpdates = new List<IOnUpdate>();
        private List<IOnFixedUpdate> _onFixedUpdates = new List<IOnFixedUpdate>();


        public Controllers Add(IOnController controller)
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
                if (ell.HasMethod(startMethod))
                {
                    ell.OnStart();
                }
            }
        }

        public void OnUpdate()
        {
            foreach (var ell in _onUpdates)
            {
                if (ell.HasMethod(updateMethod))
                {
                    ell.OnUpdate();
                }
            }
        }

        public void OnFixedUpdate()
        {
            foreach (var ell in _onFixedUpdates)
            {
                if (ell.HasMethod(fixedUpdateMethod))
                {
                    ell.OnFixedUpdate();
                }
            }
        }
    }
}