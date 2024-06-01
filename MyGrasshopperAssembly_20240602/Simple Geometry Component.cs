using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace MyGrasshopperAssembly_20240602
{
    public class Simple_Geometry_Component : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Simple_Geometry_Component class.
        /// </summary>
        public Simple_Geometry_Component()
          : base("Circle & Line", "CL",
              "Simple Geometry Component",
              "Extra", "Simple")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddCircleParameter("Circle","C","The circle to slice", GH_ParamAccess.item);
            pManager.AddLineParameter("Line","L","Slicing", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddArcParameter("Arc A","A","First Split result",GH_ParamAccess.item);
            pManager.AddArcParameter("Arc B","B","Second Split result",GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Rhino.Geometry.Circle circle = Rhino.Geometry.Circle.Unset;
            Rhino.Geometry.Line line = Rhino.Geometry.Line.Unset;

            if (!DA.GetData(0, ref circle)) { return; }
            if (!DA.GetData(1, ref line)) { return; }

            if (!circle.IsValid) {  return; }
            if (!line.IsValid) {return; }

            line.Transform(Rhino.Geometry.Transform.PlanarProjection(circle.Plane));

            if (line.Length < Rhino.RhinoMath.ZeroTolerance)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Line could not be projected onto the Circle plane");
                return;
            }

            double t1;
            double t2;
            Rhino.Geometry.Point3d p1;
            Rhino.Geometry.Point3d p2;

            switch(Rhino.Geometry.Intersect.Intersection.LineCircle(line,circle,out t1,out p1,out t2, out p2))
            {
                case Rhino.Geometry.Intersect.LineCircleIntersection.None:
                    AddRuntimeMessage(GH_RuntimeMessageLevel.Warning,"No intersections were found");
                    return;

                case Rhino.Geometry.Intersect.LineCircleIntersection.Single:
                    AddRuntimeMessage(GH_RuntimeMessageLevel.Warning,"Only a single intersection was found");
                    return;
            }

            double ct;
            circle.ClosestParameter(p1, out ct);

            Rhino.Geometry.Vector3d tan = circle.TangentAt(ct);

            DA.SetData(0, new Rhino.Geometry.Arc(p1, tan, p2));
            DA.SetData(1, new Rhino.Geometry.Arc(p1, -tan, p2));

        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("50c69822-0cf7-4c4f-9e51-f98dbb61cb31"); }
        }
    }
}