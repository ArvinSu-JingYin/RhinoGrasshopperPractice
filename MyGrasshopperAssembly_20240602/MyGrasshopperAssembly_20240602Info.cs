using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace MyGrasshopperAssembly_20240602
{
    public class MyGrasshopperAssembly_20240602Info : GH_AssemblyInfo
    {
        public override string Name => "MyGrasshopperAssembly_20240602";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("4895e7af-e187-4453-98b1-9b0f2a940d33");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}