using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AsteroidGB.Chain_of_responsibility
{
    public class FirstBonusHandler : BonusHandler
    {
        public override void HandleRequest(int num)
        {
            if (num == 1)
            {
                var player = Object.FindObjectOfType<PlayerView>();
                foreach (Transform ell in player.transform)
                {
                    if (ell.TryGetComponent(out MeshRenderer mesh))
                    {
                        mesh.material.color = Color.green;
                    }
                }
            }
            else if (num != null)
            {
                Succesor.HandleRequest(num);
            }
        }
    }
}