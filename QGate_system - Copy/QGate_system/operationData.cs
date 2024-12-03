using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QGate_system
{
    class operationData
    {
        private static operationData instance;
        private operationData() { }
        public static operationData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new operationData();
                }
                return instance;
            }
        }

        private string _tagfaid;
        private string _tagfa;
        private string _partcodemaster;
        private string _partline;
        private string _partnotagfa;
        private string _partplantdate;
        private string _partseqplan;
        private string _partactualdate1;
        private string _partsnp;
        private string _partlotno;
        private string _partactualdate2;
        private string _partseqactual;
        private string _partplant;
        private string _partbox;
        private string _lotcur;
        private int _boxNo;
        private string _typeStation;
        private string _model;
        private string _partNoName;
        private string _partworkshift;
        private string _countDefectNGId;
        private string _countDefectNCId;
        private string _countDMCDefectNGId;
        private string _countDMCDefectNCId;

        private string _isdt_id;

        public string tagfaid
        {
            get { return _tagfaid; }
            set
            {
                _tagfaid = value;
            }
        }

        public string tagfa
        {
            get { return _tagfa; }
            set
            {
                _tagfa = value;
            }
        }

        public string partcodemaster
        {
            get { return _partcodemaster; }
            set
            {
                _partcodemaster = value;
            }
        }

        public string partline
        {
            get { return _partline; }
            set
            {
                _partline = value;
            }
        }

        public string partnotagfa
        {
            get { return _partnotagfa; }
            set
            {
                _partnotagfa = value;
            }
        }

        public string partplantdate
        {
            get { return _partplantdate; }
            set
            {
                _partplantdate = value;
            }
        }

        public string partseqplan
        {
            get { return _partseqplan; }
            set
            {
                _partseqplan = value;
            }
        }

        public string partactualdate1
        {
            get { return _partactualdate1; }
            set
            {
                _partactualdate1 = value;
            }
        }

        public string partsnp
        {
            get { return _partsnp; }
            set
            {
                _partsnp = value;
            }
        }

        public string partlotno
        {
            get { return _partlotno; }
            set
            {
                _partlotno = value;
            }
        }

        public string partactualdate2
        {
            get { return _partactualdate2; }
            set
            {
                _partactualdate2 = value;
            }
        }

        public string partseqactual
        {
            get { return _partseqactual; }
            set
            {
                _partseqactual = value;
            }
        }

        public string partplant
        {
            get { return _partplant; }
            set
            {
                _partplant = value;
            }
        }

        public string partbox
        {
            get { return _partbox; }
            set
            {
                _partbox = value;
            }
        }

        public int boxNo
        {
            get { return _boxNo; }
            set
            {
                _boxNo = value;
            }
        }

        public string lotcur
        {
            get { return _lotcur; }
            set
            {
                _lotcur = value;
            }
        }

        public string typeStation
        {
            get { return _typeStation; }
            set
            {
                _typeStation = value;
            }
        }

        public string model
        {
            get { return _model; }
            set
            {
                _model = value;
            }
        }
        public string partNoName
        {
            get { return _partNoName; }
            set
            {
                _partNoName = value;
            }
        }

        public string partworkshift
        {
            get { return _partworkshift; }
            set
            {
                _partworkshift = value;
            }
        }

        public string countDefectNGId
        {
            get { return _countDefectNGId; }
            set
            {
                _countDefectNGId = value;
            }
        }

        public string countDefectNCId
        {
            get { return _countDefectNCId; }
            set
            {
                _countDefectNCId = value;
            }
        }

        public string countDMCDefectNGId
        {
            get { return _countDMCDefectNGId; }
            set
            {
                _countDMCDefectNGId = value;
            }
        }

        public string countDMCDefectNCId
        {
            get { return _countDMCDefectNCId; }
            set
            {
                _countDMCDefectNCId = value;
            }
        }

        public string isdt_id
        {
            get { return _isdt_id; }
            set
            {
                _isdt_id = value;
            }
        }



        private Stack<string> _operationCount = new Stack<string>();

        public Stack<string> OperationCount
        {
            get { return _operationCount; }
            set { _operationCount = value; }
        }

        private Stack<string> _operationCountDMC = new Stack<string>();

        public Stack<string> OperationCountDMC
        {
            get { return _operationCountDMC; }
            set { _operationCountDMC = value; }
        }



        // id count defect (table info_defect_count_app)
        private int _countNgId;
        private int _countNcId;

        public int countNgId
        {
            get { return _countNgId; }
            set
            {
                _countNgId = value;
            }
        }
        public int countNcId
        {
            get { return _countNcId; }
            set
            {
                _countNcId = value;
            }
        }


    }


}
