using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot.Series;
using OxyPlot;

namespace RGR_sch
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Schema sch = new Schema();
            sch.calculate();
            TB_data.Text = "V threshold = " + sch._v_threshod + "B\n" 
                            + "I channel = " + sch._i_channel + "A\n"
                            + "V gate = " + sch._v_gate + "B\n"
                            + "V drain = " + sch._v_drain + "B\n"
                            + "V source = " + sch._v_source + "B\n"
                            + "V sub = " + sch._v_sub + "B";
            TB_const.Text = "Fermi level = " + sch.f_fermi + "B\n"
                            + "Permittivity SiO2: " + sch._e_sio2 + "\n"
                            + "Permittivity Si: " + sch._e_si + "\n"
                            + "Movability: " + sch._nu;
            Conc.Content = "Na = " + sch.Na;
            wl.Content = "W/l = " + sch.w_l;


            //const double margin = 10;
            //double xmin = margin;
            //double xmax = can_graph1.Width - margin;
            //double ymin = margin;
            //double ymax = can_graph1.Height - margin;
            //const double step = 30;

            //// Make the X axis.
            //GeometryGroup xaxis_geom = new GeometryGroup();
            //xaxis_geom.Children.Add(new LineGeometry(
            //    new Point(0, ymax), new Point(can_graph1.Width, ymax)));
            //for (double x = xmin + step;
            //    x <= can_graph1.Width - step; x += step)
            //{
            //    xaxis_geom.Children.Add(new LineGeometry(
            //        new Point(x, ymax - margin / 2),
            //        new Point(x, ymax + margin / 2)));
            //}

            //Path xaxis_path = new Path();
            //xaxis_path.StrokeThickness = 1;
            //xaxis_path.Stroke = Brushes.Black;
            //xaxis_path.Data = xaxis_geom;

            //can_graph1.Children.Add(xaxis_path);

            //// Make the Y ayis.
            //GeometryGroup yaxis_geom = new GeometryGroup();
            //yaxis_geom.Children.Add(new LineGeometry(
            //    new Point(xmin, 0), new Point(xmin, can_graph1.Height)));
            //for (double y = step; y <= can_graph1.Height - step; y += step)
            //{
            //    yaxis_geom.Children.Add(new LineGeometry(
            //        new Point(xmin - margin / 2, y),
            //        new Point(xmin + margin / 2, y)));
            //}

            //Path yaxis_path = new Path();
            //yaxis_path.StrokeThickness = 1;
            //yaxis_path.Stroke = Brushes.Black;
            //yaxis_path.Data = yaxis_geom;

            //can_graph1.Children.Add(yaxis_path);

            //// Make some data sets.

            //    PointCollection points = new PointCollection();
            //    for (double x = xmin; x <= xmax; x += 0.01)
            //    {
            //        points.Add(new Point(x, ymax - sch.v_na(x * Math.Pow(10, 23))));
            //    }

            //    Polyline polyline = new Polyline();
            //    polyline.StrokeThickness = 1;
            //    polyline.Stroke = Brushes.Black;
            //    polyline.Points = points;

            //    can_graph1.Children.Add(polyline);
        }
        //<Canvas Name = "can_graph1" Background="White" HorizontalAlignment="Left" Height="312" VerticalAlignment="Top" Width="404" Margin="10,10,0,0"/>
        
    }
}
