using Draw.Base;
using Draw.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Draw.Services
{
    public class FileService
    {

        public void SaveFile(List<BaseShape> shapes, string stringPath)
        {
            string shapesFigure = JsonSerializer.Serialize(shapes);
            File.WriteAllText(stringPath, shapesFigure);
        }
        public List<BaseShape> LoadFile( string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var shapes = JsonSerializer.Deserialize<List<BaseShape>>(jsonString);
            return shapes;
        }
    }
}
