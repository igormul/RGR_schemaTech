using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;

namespace RGR_sch
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Schema sch = new Schema();
            sch.calculate();
            this.MyModel = new PlotModel { Title = "V(Na)" };
            this.MyModel.Series.Add(new FunctionSeries(sch.v_na, 0, Math.Pow(10, 24), Math.Pow(10, 22), "V(Na)"));
            this.MyModel1 = new PlotModel { Title = "I(W/l)" };
            this.MyModel1.Series.Add(new FunctionSeries(sch.i_wl, 0, Math.Pow(10, 3), Math.Pow(10, 1), "I(W/l)"));
            this.MyModel2 = new PlotModel { Title = "V(t0)" };
            this.MyModel2.Series.Add(new FunctionSeries(sch.v_t0, 0, Math.Pow(10, -7), Math.Pow(10, -9), "V(t0)"));
        }

        public PlotModel MyModel { get; private set; }
        public PlotModel MyModel1 { get; private set; }
        public PlotModel MyModel2 { get; private set; }
    }
}
