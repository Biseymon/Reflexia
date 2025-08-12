using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflexia
{
    public class ReflectionManager
    {
        public string path = @"..\..\..\..\bin";
        public IEnumerable<IDetector> GetAllDetector()
        {
            var dets = new DirectoryInfo(path).GetFiles("*Detector*.dll");
            List<Type> types = new();
            List<IDetector> detectors = new();
            foreach (var det in dets)
            {
                var asm = Assembly.LoadFrom(det.FullName);
                types.AddRange(asm.GetTypes().Where(t => t.FullName.Contains("Detector") && !t.FullName.Contains("IDetector")).ToArray());
                
            }
            foreach (var type in types)
            {
                object peopleDetector = Activator.CreateInstance(type);
                IDetector iDet = peopleDetector as IDetector;
                if (iDet != null) detectors.Add(iDet);  
            }
            return detectors;
        }
    }
}
