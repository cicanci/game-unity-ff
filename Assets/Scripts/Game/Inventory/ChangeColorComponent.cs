using System;
using UnityEngine;

namespace Game.Inventory
{
    public class ChangeColorComponent : MonoBehaviour 
    {
        private enum ColorVariation
        {
            Black,
            Blue,
            Green,
            Red,
            Yellow
        }

        public Material ColorBlack;
        public Material ColorBlue;
        public Material ColorGreen;
        public Material ColorRed;
        public Material ColorYellow;

        public MeshRenderer[] MeshRenderers;

        public void ChangeColor(int colorIndex)
        {
            switch((ColorVariation)colorIndex)
            {
                case ColorVariation.Black:
                    SetColorVariation(ColorBlack);
                    break;
                case ColorVariation.Blue:
                    SetColorVariation(ColorBlue);
                    break;
                case ColorVariation.Green:
                    SetColorVariation(ColorGreen);
                    break;
                case ColorVariation.Red:
                    SetColorVariation(ColorRed);
                    break;
                case ColorVariation.Yellow:
                    SetColorVariation(ColorYellow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("colorIndex", colorIndex, null);
            }
        }

        private void SetColorVariation(Material material)
        {
            foreach(var meshRenderer in MeshRenderers)
            {
                meshRenderer.material = material;
            }
        }
    }
}
