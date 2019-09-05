using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMCore
{
    class DataTypes
    {
    }

    public class TreeModel
    {
        public string id { get; set; }     // required
        public string parent { get; set; }      // required
        public string text { get; set; }  // node text
        public string icon { get; set; }   // string for custom
        public TreeStateModel state;
        public TreeStateli_attrModel a_attr;
        public string li_attr { get; set; }
        public Boolean children { get; set; }

        //  li_attr     : {}  // attributes for the generated LI node
        //  a_attr      : {}  // attributes for the generated A node
    }
    public class TreeStateModel
    {
        public Boolean opened { get; set; }  // is the node open
        public Boolean disabled { get; set; } // is the node disabled
        public Boolean selected { get; set; }// is the node selected
    }
    public class TreeStateli_attrModel
    {
        public string @class { get; set; }
    }
}
