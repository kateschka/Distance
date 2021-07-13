using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
			double segment = Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));
			double lineAX = Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
			double lineBX = Math.Sqrt((x - bx) * (x - bx) + (y - by) * (y - by));
			
			if (IsAngleSharp(segment, lineAX, lineBX))
            {
                double perimeter = (segment + lineAX + lineBX)/2;
                double triangleArea = Math.Sqrt(perimeter*(perimeter-lineAX)*(perimeter-lineBX)*(perimeter-segment));
				double length = triangleArea / segment * 2;
				return length;              
            }
            else if (lineAX>=lineBX)
                    return lineBX;
            return lineAX;
		}
		
		public static bool IsAngleSharp(double segment, double lineAX, double lineBX)
        {
			return Math.Max(lineBX, lineAX) * Math.Max(lineBX, lineAX) < segment * segment + Math.Min(lineBX, lineAX) * Math.Min(lineBX, lineAX);
		}
	}
}