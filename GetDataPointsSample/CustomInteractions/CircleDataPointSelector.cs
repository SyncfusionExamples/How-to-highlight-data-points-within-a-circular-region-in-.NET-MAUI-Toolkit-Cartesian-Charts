using Syncfusion.Maui.Toolkit.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleDataPoints
{
    public class CircleDataPointSelector : ChartInteractiveBehavior, IDrawable
    {

        private float CenterX;
        private float CenterY;
        private float radius = 0;
        private bool showCircle = false;

        public GraphicsView Graphics { get; set; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;
            canvas.FillColor = Colors.Red.WithAlpha(0.2f);
            canvas.DrawEllipse(CenterX - radius, CenterY - radius, radius * 2, radius * 2);
        }

        protected override void OnTouchDown(ChartBase chart, float pointX, float pointY)
        {
            var seriesBounds = chart.SeriesBounds;

            CenterX = (float)(pointX - seriesBounds.Left);
            CenterY = (float)(pointY - seriesBounds.Top);
            radius = 0;
            showCircle = true;
            Graphics.Invalidate();
        }

        protected override void OnTouchMove(ChartBase chart, float pointX, float pointY)
        {
            if (showCircle)
            {
                var seriesBounds = chart.SeriesBounds;

                // Calculate radius using exact code from clipboard
                float dx = (float)(pointX - seriesBounds.Left - CenterX);
                float dy = (float)(pointY - seriesBounds.Top - CenterY);
                radius = (float)Math.Sqrt(dx * dx + dy * dy);


                Graphics.Invalidate();
            }
        }

        protected override void OnTouchUp(ChartBase chart, float pointX, float pointY)
        {
            if (chart is SfCartesianChart cartesianChart)
            {
                var viewModel = chart.BindingContext as ScatterSeriesViewModel;

                // Create bounding rect for the circle in chart coordinates.
                var boundingRect = new Rect(
                    CenterX - radius,
                    CenterY - radius,
                    radius * 2,
                    radius * 2
                );

                var selectedIndexes = new List<int>();

                foreach (var series in cartesianChart.Series)
                {
                    if (series is ScatterSeries scatterSeries)
                    {
                        var rectanglePoints = scatterSeries.GetDataPoints(boundingRect);

                        if (rectanglePoints != null && viewModel != null)
                        {
                            for (int i = 0; i < viewModel.Data.Count; i++)
                            {
                                var point = viewModel.Data[i];

                                if (rectanglePoints.Contains(point))
                                {
                                    var xAxis = cartesianChart.XAxes[0];
                                    var yAxis = cartesianChart.YAxes[0];

                                    // Convert data coordinates to pixel coordinates
                                    double pixelX = xAxis.ValueToPoint(point.XValue);
                                    double pixelY = yAxis.ValueToPoint(point.YValue);

                                    // Calculate distance from center to this point
                                    double distance = Math.Sqrt(
                                        Math.Pow(pixelX - CenterX, 2) +
                                        Math.Pow(pixelY - CenterY, 2));

                                    // If distance is less than radius, point is in circle
                                    if (distance <= radius)
                                    {
                                        selectedIndexes.Add(i);
                                    }
                                }
                            }

                            scatterSeries.SelectionBehavior.SelectedIndexes = selectedIndexes;
                        }
                    }
                }
            }

            showCircle = false;
            Graphics.Invalidate();
        }
    }
}
