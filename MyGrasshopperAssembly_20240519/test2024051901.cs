using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper.Kernel;

namespace MyGrasshopperAssembly_20240519
{
    public class test2024051901 : GH_Component
    {
        public override Guid ComponentGuid
        {
            get { return new Guid("e7487be6-b75f-4273-9b85-bdd9418865cc"); }
        }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            try
            {
                pManager.AddTextParameter("String", "S", "String to reverse", GH_ParamAccess.item);
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
                pManager.AddTextParameter("Reverse", "R", "Reversed string", GH_ParamAccess.item);
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
                // Declare a variable for the input String
                string data = null;

                // Use the DA object to retrieve the data inside the first input parameter.
                // If the retieval fails (for example if there is no data) we need to abort.
                if (!DA.GetData(0, ref data)) { return; }

                // If the retrieved data is Nothing, we need to abort.
                // We're also going to abort on a zero-length String.
                if (data == null) { return; }
                if (data.Length == 0) { return; }

                // Convert the String to a character array.
                char[] chars = data.ToCharArray();

                // Reverse the array of character.
                System.Array.Reverse(chars);

                // Use the DA object to assign a new String to the first output parameter.
                DA.SetData(0, new string(chars));
            }
            catch
            {

                throw new NotImplementedException();
            }
        }

        public test2024051901() : base("MyFirst", "MFC", "My first component", "Extra", "Simple")
        {

        }

    }
}
