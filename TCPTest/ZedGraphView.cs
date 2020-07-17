using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace TCPTest
{
    public class ZedGraphView
    {
        private ZedGraph.ZedGraphControl zedGraphControl;
        private int TickStart;
        public ZedGraphView(ref ZedGraphControl _zedGraphControl)
        {
            zedGraphControl = _zedGraphControl;
        }
        public void Init()
        {
            // Clear ZedGraph
            zedGraphControl.GraphPane.CurveList.Clear();
            zedGraphControl.GraphPane.GraphObjList.Clear(); ;
            zedGraphControl.Invalidate();
            // Init ZedGraph
            GraphPane myPane = zedGraphControl.GraphPane;
            myPane.Title.Text = "Check 03 Voltage of System (Volt)";
            myPane.XAxis.Title.Text = "Time (s)";
            myPane.YAxis.Title.Text = "Voltage (Volt)";

            RollingPointPairList list = new RollingPointPairList(60000);
            RollingPointPairList list1 = new RollingPointPairList(600000);
            RollingPointPairList list2 = new RollingPointPairList(600000);

            LineItem curve = myPane.AddCurve("Volt 1", list, Color.Red, SymbolType.None);
            LineItem curve1 = myPane.AddCurve("Volt 2", list1, Color.Blue, SymbolType.None);
            LineItem curve2 = myPane.AddCurve("Volt 3", list2, Color.Green, SymbolType.None);

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 15;

            myPane.AxisChange();

            // Save the beginning time for reference
            TickStart = Environment.TickCount;
        }
        public void Clear()
        {
            Init();
            //zedGraphControl.GraphPane.CurveList.Clear();
            //zedGraphControl.GraphPane.GraphObjList.Clear(); ;
            //zedGraphControl.Invalidate();
        }
        public void Draw(double data, double data1, double data2)
        {

            if (zedGraphControl.GraphPane.CurveList.Count <= 0)
                return;

            LineItem curve = zedGraphControl.GraphPane.CurveList[0] as LineItem;
            LineItem curve1 = zedGraphControl.GraphPane.CurveList[1] as LineItem;
            LineItem curve2 = zedGraphControl.GraphPane.CurveList[2] as LineItem;

            if (curve == null)
                return;
            if (curve1 == null)
                return;

            IPointListEdit list = curve.Points as IPointListEdit;
            IPointListEdit list1 = curve1.Points as IPointListEdit;
            IPointListEdit list2 = curve2.Points as IPointListEdit;

            if (list == null)
                return;

            // Time is measured in seconds
            double time = (Environment.TickCount - TickStart) / 1000.0;

            list.Add(time, data); // Thêm điểm trên đồ thị
            list1.Add(time, data1);
            list2.Add(time, data2);

            Scale xScale = zedGraphControl.GraphPane.XAxis.Scale;
            Scale yScale = zedGraphControl.GraphPane.YAxis.Scale;

            // Tự động Scale theo trục x
            if (time > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = time + xScale.MajorStep;
                xScale.Min = xScale.Max - 30;
            }

            // Tự động Scale theo trục y
            if (data > yScale.Max - yScale.MajorStep)
            {
                yScale.Max = data + yScale.MajorStep;
            }
            else if (data < yScale.Min + yScale.MajorStep)
            {
                yScale.Min = data - yScale.MajorStep;
            }

            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
            zedGraphControl.Refresh();
        }      
    }
}
