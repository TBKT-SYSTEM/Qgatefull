using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QGate_system
{
    class model
    {
        private static model instance;
        private model() { }
        public static model Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new model();
                }
                return instance;
            }
        }

        private object _dataPartNo;
        public object DataPartNo
        {
            get { return _dataPartNo; }
            set
            {
                _dataPartNo = value;
            }
        }




    }
}
