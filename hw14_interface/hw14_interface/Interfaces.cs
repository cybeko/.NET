using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw14_interface
{
    public interface ICalc
    {
        int Less(int valueToCompare);
        int Greater(int valueToCompare);
        void Print();
    }
    public interface ICalc2
    {
        int CountDistinct();
        int EqualToValue(int valueToCompare);
    }
    public interface IOutput
    {
        void ShowEven();
        void ShowOdd();
    }
}
