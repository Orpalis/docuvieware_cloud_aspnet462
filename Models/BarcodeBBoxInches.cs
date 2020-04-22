using System;

namespace aspnet_mvc_razor_app.Models
{
    [Serializable]
    public class BarcodeBBoxInches
    {
        public float Left { get; }
        public float Top { get; }
        public float Width { get; }
        public float Height { get; }

        public BarcodeBBoxInches(float left, float top, float width, float height)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }
    }
}