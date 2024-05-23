using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace MyGrasshopperAssembly_2024052403
{
    public class MyGrasshopperAssembly_2024052403Info : GH_AssemblyInfo
    {
        public override string Name => "MyGrasshopperAssembly_2024052403";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("badc2c7d-0a94-465c-b0b5-c3e10b395f59");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}