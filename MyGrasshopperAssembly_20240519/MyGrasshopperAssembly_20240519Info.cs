using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace MyGrasshopperAssembly_20240519
{
    public class MyGrasshopperAssembly_20240519Info : GH_AssemblyInfo
    {
        public override string Name => "MyGrasshopperAssembly_20240519";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("ab82a5d2-eddb-40d9-aebe-9179065cb7d7");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}