using UnityEngine;
using UnityEngine.UI;

namespace FinalFrontier.Game.UI.Util
{
    // FPS Conter implemented based on this tutorial: http://catlikecoding.com/unity/tutorials/frames-per-second/
    public class FPSCounter : MonoBehaviour
    {
        public Text HighestFPS;
        public Text AverageFPS;
        public Text LowestFPS;

        private const int _frameRange = 60;
        private int[] _fpsBuffer;
        private int _fpsBufferIndex;
        private int _fpsHigh;
        private int _fpsAverage;
        private int _fpsLow;
        
        private readonly string[] _stringsFrom00To99 = 
        {
            "00", "01", "02", "03", "04", "05", "06", "07", "08", "09",
            "10", "11", "12", "13", "14", "15", "16", "17", "18", "19",
            "20", "21", "22", "23", "24", "25", "26", "27", "28", "29",
            "30", "31", "32", "33", "34", "35", "36", "37", "38", "39",
            "40", "41", "42", "43", "44", "45", "46", "47", "48", "49",
            "50", "51", "52", "53", "54", "55", "56", "57", "58", "59",
            "60", "61", "62", "63", "64", "65", "66", "67", "68", "69",
            "70", "71", "72", "73", "74", "75", "76", "77", "78", "79",
            "80", "81", "82", "83", "84", "85", "86", "87", "88", "89",
            "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"
        };
        
        [System.Serializable]
        private struct FPSColor 
        {
            public Color ColorValue;
            public int MinimumFPS;
        }
        
        [SerializeField]
        private FPSColor[] _coloring;

        private void Awake()
        {
            _fpsBuffer = new int[_frameRange];
            _fpsBufferIndex = 0;
        }

        private void Update()
        {
            UpdateBuffer();
            CalculateFPS();
            UpdateCounter();
        }

        private void UpdateBuffer() 
        {
            _fpsBuffer[_fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
            if (_fpsBufferIndex >= _frameRange) 
            {
                _fpsBufferIndex = 0;
            }
        }

        private void CalculateFPS()
        {
            int sum = 0;
            int highest = 0;
            int lowest = int.MaxValue;

            for (int i = 0; i < _frameRange; i++) 
            {
                int fps = _fpsBuffer[i];
                sum += fps;

                if (fps > highest) 
                {
                    highest = fps;
                }
                if (fps < lowest) 
                {
                    lowest = fps;
                }
            }

            _fpsAverage = sum / _frameRange;
            _fpsHigh = highest;
            _fpsLow = lowest;
        }
        
        private void UpdateCounter()
        {
            Display(HighestFPS, _fpsHigh);
            Display(AverageFPS, _fpsAverage);
            Display(LowestFPS, _fpsLow);
        }
        
        private void Display(Text label, int fps) 
        {
            label.text = _stringsFrom00To99[Mathf.Clamp(fps, 0, 99)];
            for (int i = 0; i < _coloring.Length; i++) 
            {
                if (fps >= _coloring[i].MinimumFPS) 
                {
                    label.color = _coloring[i].ColorValue;
                    break;
                }
            }
        }
    }
}