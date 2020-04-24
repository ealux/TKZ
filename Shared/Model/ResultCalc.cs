using System.Data;

namespace TKZ.Shared.Model
{
    /// <summary>
    /// Stores the results of calculation short circuit current
    /// </summary>
    public class ResultCalc
    {
        public DataTable Bus { get; set; }

        public DataTable Branch { get; set; }

        public ResultCalc()
        {
            Bus = new DataTable("Bus Parametrs");

            Bus.Columns.Add("BusID", typeof(int));

            Bus.Columns.Add("V1 ABS", typeof(double));
            Bus.Columns.Add("V1 ang", typeof(double));
            Bus.Columns.Add("V2 ABS", typeof(double));
            Bus.Columns.Add("V2 ang", typeof(double));
            Bus.Columns.Add("V0 ABS", typeof(double));
            Bus.Columns.Add("V0 ang", typeof(double));

            Bus.Columns.Add("Va ABS", typeof(double));
            Bus.Columns.Add("Va ang", typeof(double));
            Bus.Columns.Add("Vb ABS", typeof(double));
            Bus.Columns.Add("Vb ang", typeof(double));
            Bus.Columns.Add("Vc ABS", typeof(double));
            Bus.Columns.Add("Vc ang", typeof(double));

            Branch = new DataTable("Branch Parametrs");

            Branch.Columns.Add("BranchID", typeof(int));

            Branch.Columns.Add("start I1 ABS", typeof(double));
            Branch.Columns.Add("start I1 ang", typeof(double));
            Branch.Columns.Add("start I2 ABS", typeof(double));
            Branch.Columns.Add("start I2 ang", typeof(double));
            Branch.Columns.Add("start I0 ABS", typeof(double));
            Branch.Columns.Add("start I0 ang", typeof(double));

            Branch.Columns.Add("start Ia ABS", typeof(double));
            Branch.Columns.Add("start Ia ang", typeof(double));
            Branch.Columns.Add("start Ib ABS", typeof(double));
            Branch.Columns.Add("start Ib ang", typeof(double));
            Branch.Columns.Add("start Ic ABS", typeof(double));
            Branch.Columns.Add("start Ic ang", typeof(double));

            Branch.Columns.Add("start Z1 ABS", typeof(double));
            Branch.Columns.Add("start Z1 ang", typeof(double));
            Branch.Columns.Add("start Z2 ABS", typeof(double));
            Branch.Columns.Add("start Z2 ang", typeof(double));
            Branch.Columns.Add("start Z0 ABS", typeof(double));
            Branch.Columns.Add("start Z0 ang", typeof(double));

            Branch.Columns.Add("start Za ABS", typeof(double));
            Branch.Columns.Add("start Za ang", typeof(double));
            Branch.Columns.Add("start Zb ABS", typeof(double));
            Branch.Columns.Add("start Zb ang", typeof(double));
            Branch.Columns.Add("start Zc ABS", typeof(double));
            Branch.Columns.Add("start Zc ang", typeof(double));

            Branch.Columns.Add("final I1 ABS", typeof(double));
            Branch.Columns.Add("final I1 ang", typeof(double));
            Branch.Columns.Add("final I2 ABS", typeof(double));
            Branch.Columns.Add("final I2 ang", typeof(double));
            Branch.Columns.Add("final I0 ABS", typeof(double));
            Branch.Columns.Add("final I0 ang", typeof(double));

            Branch.Columns.Add("final Ia ABS", typeof(double));
            Branch.Columns.Add("final Ia ang", typeof(double));
            Branch.Columns.Add("final Ib ABS", typeof(double));
            Branch.Columns.Add("final Ib ang", typeof(double));
            Branch.Columns.Add("final Ic ABS", typeof(double));
            Branch.Columns.Add("final Ic ang", typeof(double));

            Branch.Columns.Add("final Z1 ABS", typeof(double));
            Branch.Columns.Add("final Z1 ang", typeof(double));
            Branch.Columns.Add("final Z2 ABS", typeof(double));
            Branch.Columns.Add("final Z2 ang", typeof(double));
            Branch.Columns.Add("final Z0 ABS", typeof(double));
            Branch.Columns.Add("final Z0 ang", typeof(double));

            Branch.Columns.Add("final Za ABS", typeof(double));
            Branch.Columns.Add("final Za ang", typeof(double));
            Branch.Columns.Add("final Zb ABS", typeof(double));
            Branch.Columns.Add("final Zb ang", typeof(double));
            Branch.Columns.Add("final Zc ABS", typeof(double));
            Branch.Columns.Add("final Zc ang", typeof(double));
        }
    }
}