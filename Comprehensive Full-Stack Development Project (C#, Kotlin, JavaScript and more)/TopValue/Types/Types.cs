using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public class Types
    {

        public struct ParmStruct
        {
            public ParmStruct(string name, object value,
                SqlDbType dataType, ParameterDirection direction = ParameterDirection.Input, int size = 0)
            {
                Name = name;
                Value = value;
                Size = size;
                DataType = dataType;
                Direction = direction;
            }

            public string Name;
            public object Value;
            public int Size;
            public SqlDbType DataType;
            public ParameterDirection Direction;

        }
    }
}
