using System;
using Grasshopper.Kernel;
using Rhino;
using Rhino.Commands;

namespace MyGrasshopperAssembly_20240519
{
    public class MathPractice20240523 : GH_Component
    {
        public MathPractice20240523() : base("MySecondComponent", "MSC", "My second component", "Extra", "Simple2")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("1ae4e025-0f79-40b0-a0d3-8843e65a03ba"); }
        }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            try
            {
                pManager.AddNumberParameter("Angle","A","The angle to measure", GH_ParamAccess.item);
                pManager.AddBooleanParameter("Radians", "R", "Work in Radians", GH_ParamAccess.item, true);
                //The default value is 'true'
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            try
            {
                pManager.AddNumberParameter("Sin", "sin", "The sine of the Angle.", GH_ParamAccess.item);
                pManager.AddNumberParameter("Cos", "cos", "The cosine of the Angle.", GH_ParamAccess.item);
                pManager.AddNumberParameter("Tan", "tan", "The tangent of the Angle.", GH_ParamAccess.item);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            try
            {
                double angle = double.NaN;
                bool radians = false;

                if (!DA.GetData(0, ref angle)) { return; }
                if (!DA.GetData(1, ref radians)) { return; }

                if (!Rhino.RhinoMath.IsValidDouble(angle)) { return; }

                if (!radians)
                {
                    angle = Rhino.RhinoMath.ToRadians(angle);
                }

                DA.SetData(0, Math.Sin(angle));
                DA.SetData(1, Math.Cos(angle));
                DA.SetData(2, Math.Tan(angle));
            }
            catch
            {

                throw new NotImplementedException();
            }
        }


    }
}