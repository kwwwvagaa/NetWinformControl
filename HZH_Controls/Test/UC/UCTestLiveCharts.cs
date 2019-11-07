using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.UC
{
    public partial class UCTestLiveCharts : UserControl
    {
        public UCTestLiveCharts()
        {
            InitializeComponent();
        }
        private void btnIObservable_Click(object sender, EventArgs e)
        {
            new FullyResponsive().Show();
        }

        private void btnLabels_Click(object sender, EventArgs e)
        {
            new Labels().Show();
        }

        private void btnSeries_Click(object sender, EventArgs e)
        {
            new CustomizedSeries().Show();
        }

        private void btnBasicLine_Click(object sender, EventArgs e)
        {
            new BasicLineExample().Show();
        }

        private void btnInvertedSeries_Click(object sender, EventArgs e)
        {
            new InvertedSeries().Show();
        }

        private void btnStackedArea_Click(object sender, EventArgs e)
        {
            new StackedAreaExample().Show();
        }

        private void btnSection_Click(object sender, EventArgs e)
        {
            new SectionsExample().Show();
        }

        private void btnIrregularIntervals_Click(object sender, EventArgs e)
        {
            new IrregularIntervalsExample().Show();
        }

        private void btnZoomingAndPanning_Click(object sender, EventArgs e)
        {
            new ZomingAndPanningExample().Show();
        }

        private void btnMissingPoints_Click(object sender, EventArgs e)
        {
            new MissingPoint().Show();
        }

        private void btnMultiAx_Click(object sender, EventArgs e)
        {
            new MultipleAxesExample().Show();
        }

        private void btnDateTime_Click(object sender, EventArgs e)
        {
            new DateTimeExample().Show();
        }

        private void btnLogScale_Click(object sender, EventArgs e)
        {
            new LogarithmSacale().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ConstantChanges().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new PieChartExample().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new DynamicVisibiltyExample().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new DataPaginationExample().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new HeatSeriesExample().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Gauge360Example().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new DoughnutExample().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new LinqExample().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new UielementsExample().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new AngularGugeForm().Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new ScatterForm().Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new GeoMapExample().Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            new StepLineExample().Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new GanttExample().Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new FunnelExample().Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            new EventsExample().Show();
        }

      

        private void button18_Click(object sender, EventArgs e)
        {
            new BasicsStackedRowExample() { TopMost = true }.Show();
            new BasicStackedColumnExample() { TopMost = true }.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            new BasicColumnExample() { TopMost = true }.Show();
            new BasicRowExample() { TopMost = true }.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            new BasicBubblesExample() { TopMost = true }.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            new BasicLineExample { TopMost = true }.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            new ConstantChanges { TopMost = true }.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            new CustomizedSeries { TopMost = true }.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            new DataPaginationExample { TopMost = true }.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            new DateTimeExample { TopMost = true }.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            new DynamicVisibiltyExample { TopMost = true }.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            new EventsExample { TopMost = true }.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            new FinancialExample { TopMost = true }.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            new FullyResponsive { TopMost = true }.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            new FunnelExample { TopMost = true }.Show();

        }

        private void button28_Click(object sender, EventArgs e)
        {
            new GanttExample { TopMost = true }.Show();

        }

        private void button27_Click(object sender, EventArgs e)
        {
            new HeatSeriesExample { TopMost = true }.Show();

        }

        private void button32_Click(object sender, EventArgs e)
        {
            new InvertedSeries { TopMost = true }.Show();

        }

        private void button33_Click(object sender, EventArgs e)
        {
            new IrregularIntervalsExample { TopMost = true }.Show();

        }

        private void button34_Click(object sender, EventArgs e)
        {
            new Labels { TopMost = true }.Show();

        }

        private void button35_Click(object sender, EventArgs e)
        {
            new LinqExample { TopMost = true }.Show();

        }

        private void button36_Click(object sender, EventArgs e)
        {
            new LogarithmSacale { TopMost = true }.Show();

        }

        private void button37_Click(object sender, EventArgs e)
        {
            new MissingPoint { TopMost = true }.Show();

        }

        private void button38_Click(object sender, EventArgs e)
        {
            new MultipleAxesExample { TopMost = true }.Show();

        }

        private void button39_Click(object sender, EventArgs e)
        {
            new NegativeStackedRow { TopMost = true }.Show();

        }

        private void button40_Click(object sender, EventArgs e)
        {
            new PointState { TopMost = true }.Show();

        }

        private void button41_Click(object sender, EventArgs e)
        {
            new ScatterForm { TopMost = true }.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new SectionsExample { TopMost = true }.Show();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new StackedAreaExample { TopMost = true }.Show();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new StepLineExample { TopMost = true }.Show();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new UielementsExample { TopMost = true }.Show();

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            new ZomingAndPanningExample { TopMost = true }.Show();

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            new Gauge360Example { TopMost = true }.Show();

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            new AngularGugeForm { TopMost = true }.Show();

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            new GeoMapExample { TopMost = true }.Show();

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            new DoughnutExample { TopMost = true }.Show();

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            new PieChartExample { TopMost = true }.Show();

        }
    }
}
