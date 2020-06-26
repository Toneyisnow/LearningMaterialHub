using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterialHub
{
    public class MaterialRequest
    {
        public string EmailAddress
        {
            get; set;
        }

        public List<string> MaterialList
        {
            get; set;
        }

        public MaterialRequest()
        {

        }

    }
}
