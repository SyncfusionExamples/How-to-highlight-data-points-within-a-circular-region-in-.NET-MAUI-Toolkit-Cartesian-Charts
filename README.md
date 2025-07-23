# How to highlight data points within a circular region in .NET MAUI Toolkit Cartesian Charts

Explore advanced data visualization techniques by extending the capabilities of [.NET MAUI Toolkit Cartesian Charts](https://www.syncfusion.com/maui-controls/maui-cartesian-charts) to implement circular data point selection.

## Overview

[.NET MAUI Toolkit Cartesian Charts](https://www.syncfusion.com/maui-controls/maui-cartesian-charts) offer sophisticated customization capabilities for enhancing data visualization. While the standard [GetDataPoints(Rect rectangle)](https://help.syncfusion.com/cr/maui-toolkit/Syncfusion.Maui.Toolkit.Charts.CartesianSeries.html#Syncfusion_Maui_Toolkit_Charts_CartesianSeries_GetDataPoints_Microsoft_Maui_Graphics_Rect_) method of the Cartesian series retrieves data points within a rectangular region, this project shows how to extend functionality to highlight data points within a circular region. This approach provides a more precise selection mechanism for specific data visualization needs.

## Key Features

### Advanced Interaction Behavior

- Implement custom circular data point selection using touch interactions.
- Visual feedback with a user-defined circular area on touch.
- Real-time updates of selected data points within the circle.

### Precision Data Visualization

- More accurate data point selection for advanced analysis needs.
- Dynamic radius adjustment during user interaction.

### Seamless Component Integration

- Utilize the ChartInteractiveBehavior class for custom behavior.
- Integrate GraphicsView for drawing the interactive selection circle.

## Technologies Used

- **.NET MAUI** – Cross-platform app framework.
- **Syncfusion® .NET MAUI Components** – For advanced charting capabilities.
- **MVVM Pattern** – Promote clean architecture and separate concerns.

## Syncfusion® Controls Used

This project demonstrates integration between key Syncfusion® controls:

- **[SfCartesianChart](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html)** – For versatile charting capabilities.
- **GraphicsView** – For custom drawing interactions.

![CircularDataPointSelectionDemo](https://github.com/user-attachments/assets/4a860869-ff93-47fd-a13f-e574f2617f3a)

## Troubleshooting

### Path Too Long Exception

If encountering a "Path too long" exception, shorten the repository name and retry. Refer to the referenced KB article for more insights and relevant code snippets - [How to highlight data points within a circular region in .NET MAUI Toolkit Cartesian Charts](https://support.syncfusion.com/kb/article/20500/how-to-highlight-data-points-within-a-circular-region-in-net-maui-toolkit-cartesian-charts
)
