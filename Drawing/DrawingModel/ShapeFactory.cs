using DrawingModel.Shape.Impl;

namespace DrawingModel
{
    public static class ShapeFactory
    {
        public static Diamond GetDiamond(double x1, double y1, double x2, double y2)
        {
            return new Diamond(x1, y1, x2, y2);
        }
        public static Line GetLine(double x1, double y1, double x2, double y2)
        {
            return new Line(x1, y1, x2, y2);
        }
        public static Ellipse GetEllipse(double x1, double y1, double x2, double y2)
        {
            return new Ellipse(x1, y1, x2, y2);
        }
    }
}
