﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common;
using EntityFrameworkHelper;

namespace DataContracts
{
    
    [DataContract(IsReference = true)]
    [SoftDelete("Status")]
    public class BaseTable
    {
        private DbStatus _status = DbStatus.Active;

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public DateTime ModifiedDate { get; set; }

        [DataMember]
        public string ModifiedBy { get; set; }

        [DataMember]
        public DbStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

    }
}
