using CodeTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Application.Service
{
    public interface ICnabParser
    {
        Cnab Parse(string line);
    }

}
